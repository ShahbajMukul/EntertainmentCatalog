using EntertainmentCatalog.Services;
using EntertainmentCatalog.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using System.Net.Http;
using System.Text.Json;

namespace EntertainmentCatalog
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
            });

            // Load configuration file
            using var stream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;
            using var reader = new StreamReader(stream);
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(reader.ReadToEnd());

            // Register HttpClient and ApiService
            builder.Services.AddSingleton(new HttpClient());
            builder.Services.AddSingleton<ApiService>(provider =>
            {
                var httpClient = provider.GetRequiredService<HttpClient>();
                var apiKey = config?["OmdbApiKey"];

                if (apiKey == null)
                    throw new InvalidOperationException("Failed to load Api key from the json file.");

                return new ApiService(httpClient, apiKey);
            });

            builder.Services.AddSingleton<StorageService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
