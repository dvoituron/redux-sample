namespace BlazorDataService.Data
{
    using System;

    public class CounterService
    {
        private readonly DataService _dataService;
        public Dispatcher<CounterService> Dispatcher { get; } = new Dispatcher<CounterService>();
        
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
            Dispatcher.DispatchChanges(this);
        }

        public void Decrement()
        {
            Value--;
            Dispatcher.DispatchChanges(this);
        }
    }

}
