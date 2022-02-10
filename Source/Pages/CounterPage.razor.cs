using Microsoft.AspNetCore.Components;
using ReduxSample.Models;
using ReduxSample.Pages.CounterManagement;
using ReduxSample.Redux;
using System;

namespace ReduxSample.Pages
{
    public partial class CounterPage
    {
        [Inject]
        public Container<CounterState> Container { get; set; } = default!;

        [Inject]
        public DataService DataService { get; set; } = default!;

        private void btnIncrement_Click()
        {
            Container.Dispatch(new CounterIncrementAction());
            DataService.Counter.Increment();
        }

        private void btnDecrement_Click()
        {
            Container.Dispatch(new CounterDecrementAction());
            DataService.Counter.Decrement();
        }
    }
}
