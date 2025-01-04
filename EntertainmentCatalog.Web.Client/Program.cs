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
builder.Configuration.AddJsonFile("appsettings.json", optional: false);


builder.Services.AddSingleton<ApiService>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var apiKey = builder.Configuration["OmdbApiKey"];

    if (apiKey == null)
        throw new InvalidOperationException("Failed to load Api key from the json file. Please debug and check what's wrong");

    return new ApiService(httpClient, apiKey);
});

builder.Services.AddSingleton<StorageService>();



await builder.Build().RunAsync();
