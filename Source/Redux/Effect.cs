using System;

namespace ReduxSample.Redux
{
	public abstract class Effect<TState>
	{
		public abstract void Initialize(Container<TState> container);
	}
}
