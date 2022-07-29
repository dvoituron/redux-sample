using System;

namespace ReduxSample.Models
{
    public class CounterService : DispatcherBase<CounterService>
    {
        private readonly DataService _dataService;
        
        public CounterService(DataService dataService)
        {
            _dataService = dataService;
            
            // Default value
            Value = 10;
        }

        public int Value { get; private set; }   // Read only property

        public void Increment()
        {
            Value++;
            DispatchChanges(this);
        }

        public void Decrement()
        {
            Value--;
            DispatchChanges(this);
        }
    }
}
