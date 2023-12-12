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

        // Register the services
        builder.Services.AddSingleton<UFODataService>();

        // Register the viewmodels
        builder.Services.AddSingleton<MainPageViewModel>();

        // Register the views
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
	}
}
