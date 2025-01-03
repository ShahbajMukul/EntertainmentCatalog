using EntertainmentCatalog.Shared.Services;
using EntertainmentCatalog.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the EntertainmentCatalog.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddMudServices();
// Register HttpClient and ApiService
builder.Services.AddSingleton(new HttpClient());
builder.Services.AddSingleton<ApiService>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var apiKey = "247db97b";
    return new ApiService(httpClient, apiKey);
});


await builder.Build().RunAsync();
