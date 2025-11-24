using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using UFOSighting.Models;

namespace UFOSighting.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    IConfiguration _appConfiguration;

    [ObservableProperty]
    Boolean _localData;
    [ObservableProperty]
    Boolean _localDataEnabled;

    public bool Tempo => !LocalData;

    [ObservableProperty]
    Boolean _localDB;
    [ObservableProperty]
    Boolean _localDBEnabled;

    [ObservableProperty]
    Boolean _webService;
    [ObservableProperty]
    Boolean _webServiceEnabled;

    //public SettingsViewModel()
    public SettingsViewModel(IConfiguration configuration)
    {
        // Load user preferences
        _localData = Preferences.Get("FileData", true);
        _localDB = Preferences.Get("LocalDBData", false);
        _webService = Preferences.Get("WebData", false);

        _appConfiguration = configuration;

        // Get the configuration from the app Configuration service
        var appSettings = _appConfiguration.GetRequiredSection("Settings").Get<Settings>();
        
        // Read the configuration data to enable data selection switches

        _localDataEnabled = appSettings.FileDataEnabled;
        _localDBEnabled = appSettings.LocalDBEnabled;
        _webServiceEnabled = appSettings.WebDataEnabled;
    }

    [RelayCommand]
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    async Task UpdatePreferences()
    {
        Preferences.Set("FileData", _localData);
        Preferences.Set("LocalDBData", _localDB);
        Preferences.Set("WebData", _webService);

        bool answer = await Shell.Current.DisplayAlert("Preferences", "Preferences sucessfully updated, return to main page?", "Yes", "No");
        if (answer)
            await Shell.Current.GoToAsync("..");

    }
}