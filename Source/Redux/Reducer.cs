using System;

namespace ReduxSample.Redux
{
	public abstract class Reducer<TState>
	{
		public abstract Type Type { get; }
		public abstract TState Reduce(TState state, IAction action);

		public static Reducer<TState> For<TAction>(Func<TState, TAction, TState> reduce)
			where TAction : IAction => new Reducer<TState, TAction>(reduce);
	}

	public sealed class Reducer<TState, TAction> : Reducer<TState>
		where TAction : IAction
	{
		private readonly Func<TState, TAction, TState> _reduce;

		internal Reducer(Func<TState, TAction, TState> reduce) => _reduce = reduce;

		public override Type Type => typeof(TAction);

		public override TState Reduce(TState state, IAction action) => _reduce(state, (TAction)action);
	}
}
