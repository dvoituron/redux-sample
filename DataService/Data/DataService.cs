﻿namespace BlazorDataService.Data
{
    using System;

    public class DataService
    {
        private CounterService? _counter;

        public CounterService Counter => _counter
                                      ?? (_counter = new CounterService(this));
    }

}
