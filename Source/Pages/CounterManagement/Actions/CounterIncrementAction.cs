using ReduxSample.Redux;
using System;

namespace ReduxSample.Pages.CounterManagement
{
    public class CounterIncrementAction : IAction
    {
        public string Type => "CounterIncrementAction";
    }
}
