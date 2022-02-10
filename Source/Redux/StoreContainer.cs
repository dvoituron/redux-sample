using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace ReduxSample.Redux
{
	public sealed class Container<TState>
	{
		private readonly Subject<TState> _stateChangedSubject = new Subject<TState>();
		private readonly Subject<IAction> _actionsToDispatchSubject = new Subject<IAction>();
		private readonly Subject<IAction> _actionDispatchedSubject = new Subject<IAction>();
		private readonly Subject<TState> _containerResetSubject = new Subject<TState>();
		private readonly Subject<Exception> _dispatchFailedSubject = new Subject<Exception>();
		private readonly IEnumerable<Reducer<TState>> _reducers;
		private readonly IEnumerable<Effect<TState>> _effects;

		private TState _initialState;

		public Container(TState initialState, 
						 IEnumerable<Reducer<TState>> reducers,
						 IEnumerable<Effect<TState>> effects = null)
		{
			State = _initialState = initialState;
			_reducers = reducers;
			_effects = effects;

			SetupEffects();
			_actionsToDispatchSubject.Synchronize().Subscribe(OnToDispatch, OnToDispatchFailed);
		}

		public TState State { get; private set; }

		public IObservable<TState> StateChanged => _stateChangedSubject.AsObservable();

		public IObservable<IAction> ActionDispatched => _actionDispatchedSubject.AsObservable();
		
		public IObservable<TState> ContainerReset => _containerResetSubject.AsObservable();
		
		public IObservable<Exception> DispatchFaield => _dispatchFailedSubject.AsObservable();

		public void Dispatch<TAction>(TAction action)
			where TAction : IAction
		{
			_actionsToDispatchSubject.OnNext(action);
		}

		public void Reset()
		{
			SetState(_initialState);
			_containerResetSubject.OnNext(State);
		}

		private void SetState(TState state)
		{
			State = state;
			_stateChangedSubject.OnNext(State);
		}

		private void OnToDispatch(IAction action)
		{
			if (_reducers.Where(i => i.Type.Equals(action.GetType())).FirstOrDefault() is Reducer<TState> reducer)
			{
				SetState(reducer.Reduce(State, action));
				Console.WriteLine($"Action dispatched: {action.GetType().FullName}");

				_actionDispatchedSubject.OnNext(action);
			}
			else
			{
				throw new NotImplementedException($"{nameof(Reducer<TState>)} for {nameof(action)} {action} in {GetSimplifiedTypeName(GetType())} is not found.");
			}
		}

		private void OnToDispatchFailed(Exception exception) => _dispatchFailedSubject.OnNext(exception);

		private void SetupEffects()
		{
			if (_effects != null)
			{
				foreach (var effect in _effects)
				{
					effect.Initialize(this);
				}
			}
		}

		private string GetSimplifiedTypeName(Type type)
		{
			var name = type.Name;
			if (type.IsGenericType)
			{
				name += $"<{string.Join(",", type.GenericTypeArguments.Select(i => GetSimplifiedTypeName(i)))}>";
			}

			return name;
		}
	}
}
