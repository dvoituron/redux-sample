using ReduxSample.Redux;
using System;
using System.Reactive.Linq;

namespace ReduxSample.Pages.CounterManagement
{
    public class CounterDecrementEffect : Effect<CounterState>
    {
        public override void Initialize(Container<CounterState> container)
        {
            container.ActionDispatched
                     .Where(a => a is CounterDecrementAction)
                     .Subscribe(a =>
                     {
                         Console.WriteLine($"Counter decremented: {container.State.Counter} ");
                     });
        }
    }
}
