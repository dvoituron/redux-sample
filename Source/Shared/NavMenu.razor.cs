using Microsoft.AspNetCore.Components;
using ReduxSample.Models;
using ReduxSample.Pages.CounterManagement;
using ReduxSample.Redux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduxSample.Shared
{
    public partial class NavMenu
    {
        [Inject]
        public Container<CounterState> Container { get; set; } = default!;

        [Inject]
        public DataService DataService { get; set; } = default!;

        // Update the counter display on this page
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                // ... using Redux
                Container.ActionDispatched.Subscribe(a =>
                {
                    InvokeAsync(() => StateHasChanged());
                });

                // ... using DataService
                DataService.Counter.ActionsDispatched.Subscribe(a =>
                {
                    InvokeAsync(() => StateHasChanged());
                });
            }
        }

        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

    }
}
