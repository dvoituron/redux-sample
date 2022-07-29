namespace BlazorDataService.Pages
{
    using BlazorDataService.Data;
    using Microsoft.AspNetCore.Components;
    using System;

    public partial class Counter
    {
        [Inject]
        public DataService DataService { get; set; } = default!;

        private void btnIncrement_Click()
        {
            DataService.Counter.Increment();
        }

        private void btnDecrement_Click()
        {
            DataService.Counter.Decrement();
        }
    }

}
