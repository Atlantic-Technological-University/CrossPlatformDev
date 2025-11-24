using UFOSighting.Views;
using UFOSighting.ViewModels;
using UFOSighting.Services;
using UFOSighting.Models;
using Microsoft.Extensions.Configuration;
using System.Reflection;

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

        //From the assembly where this code lives!
        // var res = a.GetManifestResourceNames(); //Returns a list of resources in the assembly

        // Get the configuration file from the Apps assembly
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("UFOSighting.Resources.Raw.appsettings.json");
        // Create the configuration builder
        var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();
        // Get the connection string from the configuration for the database
        var dbName = config.GetSection("Settings").Get<Settings>().DBName;

        // Add the configuration to the app
        builder.Configuration.AddConfiguration(config);

        //Register connectivity, geolocation and Maps
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current); //passing default implementation current
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);
        
        // Register the services
        builder.Services.AddSingleton<UFOFileDataService>();

        //string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "UFOEncounters.db3");

        //Register the database service 
        string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, dbName);
        builder.Services.AddSingleton<IUFODataService, UFODBDataService>(
            s => ActivatorUtilities.CreateInstance<UFODBDataService>(s, dbPath));
        

        // Register the viewmodels
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddTransient<EncounterViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();

        // Register the views
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<EncounterPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<DBTest>();

        return builder.Build();
	}
}
