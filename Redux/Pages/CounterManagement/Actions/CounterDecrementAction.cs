using ReduxSample.Redux;
using System;

namespace ReduxSample.Pages.CounterManagement
{
    public class CounterDecrementAction : IAction
    {
        public string Type => "CounterDecrementAction";
    }
}
