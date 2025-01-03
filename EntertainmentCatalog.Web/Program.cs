using EntertainmentCatalog.Shared.Services;
using EntertainmentCatalog.Web.Components;
using EntertainmentCatalog.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// Add device-specific services used by the EntertainmentCatalog.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

// Register HttpClient and ApiService
builder.Services.AddSingleton(new HttpClient());
builder.Services.AddSingleton<FilmServiceApi>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var apiKey = "247db97b";
    return new FilmServiceApi(httpClient, apiKey);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(EntertainmentCatalog.Shared._Imports).Assembly,
        typeof(EntertainmentCatalog.Web.Client._Imports).Assembly);

app.Run();
