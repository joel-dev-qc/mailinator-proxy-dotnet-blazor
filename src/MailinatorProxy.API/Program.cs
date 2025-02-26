using MailinatorProxy.API;
using MailinatorProxy.API.Common.Extensions;
using MartinCostello.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddMailinatorApiClientProxy(builder.Configuration);
builder.Services.AddMediatR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(options =>
{
    options.SetOpenApiDocumentation();
});
builder.Services.AddOpenApiExtensions(options =>
{
});
builder.Services.AddFluentValidation();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandlers();

var app = builder.Build();

app.MapOpenApi();
app.MapOpenApiYaml();
app.MapScalarApiReference(options =>
{
    options
        .WithTitle("Mailinator API Proxy")
        .WithTheme(ScalarTheme.Mars)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});


app.UseHttpsRedirection();

app.UseExceptionHandler();

app.MapEndpoints();


app.Run();
