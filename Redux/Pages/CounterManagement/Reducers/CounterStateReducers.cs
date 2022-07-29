using ReduxSample.Redux;
using System;
using System.Reactive.Linq;

namespace ReduxSample.Pages.CounterManagement
{
    public static class CounterStateReducers
    {
        public static CounterState InitialState => new CounterState(10);

        public static IEnumerable<Reducer<CounterState>> Create()
        {
            return new[]
            {
                // Action to increment
                Reducer<CounterState>.For<CounterIncrementAction>((currentState, action) =>
                {
                    return new CounterState(currentState.Counter + 1);
                }),

                // Action to decrement
                Reducer<CounterState>.For<CounterDecrementAction>((currentState, action) =>
                {
                    return new CounterState(currentState.Counter - 1);
                })
            };
        }
    }
}
