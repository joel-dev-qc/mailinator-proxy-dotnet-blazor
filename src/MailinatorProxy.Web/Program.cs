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
builder.Services.AddScoped<ILayoutService, LayoutService>();
builder.Services.AddStores();
builder.Services.AddStates();
builder.Services.AddHighlight();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddLocalization();
builder.Services.AddMudServices();

string? httpClientBaseUrl = builder.Configuration.GetValue<string>("MailinatorProxyApiOptions:BaseUrl");
builder.Services.AddScoped<IMalinatorApiClient>(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri(httpClientBaseUrl) };
    return new MailinatorApiClient(httpClient);
});


var host = builder.Build();

await host.SetDefaultCulture();

await host.RunAsync();
