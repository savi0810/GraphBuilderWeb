using GraphBuilderFrontend;
using GraphBuilderFrontend.Models;
using GraphBuilderFrontend.Services;
using GraphBuilderFrontend.Services.EventHandlers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<FunctionManager>();
builder.Services.AddScoped<ViewportManager>();
builder.Services.AddScoped<GraphApiService>();
builder.Services.AddScoped<GraphEventHandlers>();
builder.Services.AddScoped<FunctionEventHandlers>();
builder.Services.AddScoped<ViewportEventHandlers>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
