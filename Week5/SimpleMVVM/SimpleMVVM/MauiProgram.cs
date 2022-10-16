using SimpleMVVM.Services;
using SimpleMVVM.ViewModel;

namespace SimpleMVVM;

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

		// Register the PeopleService as a singleton with the DI service
		builder.Services.AddSingleton<PeopleService>();
		// Register our ViewModel
		builder.Services.AddSingleton<PeopleViewModel>();
		// Register our MainPage
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
