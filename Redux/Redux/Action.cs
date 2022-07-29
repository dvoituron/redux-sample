using System;

namespace ReduxSample.Redux
{
	public interface IAction
	{
		string Type { get; }
	}
}
