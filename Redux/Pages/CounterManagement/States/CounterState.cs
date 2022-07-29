using System;

namespace ReduxSample.Pages.CounterManagement
{
    public class CounterState
    {
        public CounterState(int counter)
        {
            Counter = counter;
        }

        public int Counter { get; }     // Read only property
    }
}
