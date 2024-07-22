using Auth0.AspNetCore.Authentication;
using FlightDispatcher.FrontEnd.WebApp.Components;
using Fluxor;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Store;
using Fluxor.Blazor.Web.ReduxDevTools;
using FlightDispatcher.FrontEnd.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Auth0
builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
        options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
    })
    .WithAccessToken(options =>
    {
        options.Audience = builder.Configuration["Auth0:Audience"];
    });

// Add services to the container.
#if RELEASE
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
#endif

#if DEBUG
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options => {
        options.DetailedErrors = true;
    });
#endif

// Add Fluxor for state management
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly, [
        typeof(FluxorStoreScanner).Assembly
    ]);

#if DEBUG
    options.UseReduxDevTools(settings =>
    {
        settings.Name = "Flight Dispatcher - FrontEnd";
    });
#endif
});

// Shared services
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

#region EndPoints for Login & LogOut for Auth0
app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/") =>
{
    var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(returnUrl)
            .Build();

    await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("/Account/Logout", async (HttpContext httpContext) =>
{
    var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
            .WithRedirectUri("/")
            .Build();

    await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});
#endregion

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
