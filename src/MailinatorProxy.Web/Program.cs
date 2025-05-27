using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MailinatorProxy.Web;
using MailinatorProxy.Web.ApiClients;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddMudServices();
builder.Services.AddScoped<IMalinatorApiClient>(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5273/") };
    return new MailinatorApiClient(httpClient);
});

await builder.Build().RunAsync();
