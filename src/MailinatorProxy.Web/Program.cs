using Blazored.LocalStorage;
using HighlightBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MailinatorProxy.Web;
using MailinatorProxy.Web.ApiClients;
using MailinatorProxy.Web.Services;
using MailinatorProxy.Web.States;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
});
builder.Services.AddScoped<IClipboardService, ClipboardService>();
builder.Services.AddScoped<IDomainService, DomainService>();
builder.Services.AddScoped<DomainState>();
builder.Services.AddHighlight();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IMalinatorApiClient>(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5273/") };
    return new MailinatorApiClient(httpClient);
});

await builder.Build().RunAsync();
