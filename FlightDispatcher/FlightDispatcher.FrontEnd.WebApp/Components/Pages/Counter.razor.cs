using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace FlightDispatcher.FrontEnd.WebApp.Components.Pages
{
    public partial class Counter
    {
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }

        private string Username = "";

        private int currentCount = 0;

        protected override async Task OnInitializedAsync()
        {
            if (authenticationState is not null)
            {
                var state = await authenticationState;

                Username = state?.User?.Identity?.Name ?? string.Empty;
            }

            await base.OnInitializedAsync();
        }

        private void IncrementCount()
        {
            currentCount++;
        }
    }
}
