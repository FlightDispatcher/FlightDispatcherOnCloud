using FlightDispatcher.FrontEnd.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FlightDispatcher.FrontEnd.WebApp.Components
{
    public partial class App
    {
        [Parameter]
        public InitialApplicationState InitialState { get; set; }

        [Inject]
        public IAuthorizationService AuthorizationService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }

        private string Username = "";

        protected override async Task OnInitializedAsync()
        {
            if (authenticationState is not null)
            {
                var state = await authenticationState;

                Username = state?.User?.Identity?.Name ?? string.Empty;
            }
                
            if (InitialState != null)
            {
                AuthorizationService.LoginSuccessful(InitialState.AccessToken, InitialState.IdToken);
            }
            else
            {
                AuthorizationService.LoginFailed();
            }

            await base.OnInitializedAsync();
        }
    }
}
