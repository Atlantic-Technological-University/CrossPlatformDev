using UFOSighting.Views;
using UFOSighting.ViewModels;
using UFOSighting.Services;

namespace UFOSighting;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //Register connectivity, geolocation and Maps
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current); //passing default implementation current
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);

        // Register the services
        builder.Services.AddSingleton<UFODataService>();

        // Register the viewmodels
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddTransient<EncounterViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();

        // Register the views
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<EncounterPage>();
        builder.Services.AddTransient<SettingsPage>();

        return builder.Build();
	}
}
