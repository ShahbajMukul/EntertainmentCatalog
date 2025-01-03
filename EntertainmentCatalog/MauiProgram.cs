using EntertainmentCatalog.Services;
using EntertainmentCatalog.Shared.Services;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;

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

            // Add device-specific services used by the EntertainmentCatalog.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
            });

            // Register HttpClient and ApiService
            builder.Services.AddSingleton(new HttpClient());
            builder.Services.AddSingleton<ApiService>(provider =>
            {
                var httpClient = provider.GetRequiredService<HttpClient>();
                var apiKey = "247db97b"; 
                return new ApiService(httpClient, apiKey);
            });


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
