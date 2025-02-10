using System.Reflection;
using System.Text.Json;
using MailinatorProxy.API;
using MartinCostello.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddMailinatorApiClientProxy(builder.Configuration);
builder.Services.AddMediatR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddOpenApiExtensions(options =>
{
    //options.SerializationContexts.Add(JsonSerializerOptionsExtensions.DefaultSerializationContext);
    options.AddXmlComments<Program>();
    //options.AddExamples = true;
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
