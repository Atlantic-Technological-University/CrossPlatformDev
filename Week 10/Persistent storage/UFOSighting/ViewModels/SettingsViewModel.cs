using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using UFOSighting.Models;

namespace UFOSighting.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{  
    public SettingsViewModel()  
    {
    }

    [RelayCommand]
    async Task UpdatePreferences()
    {
        await Shell.Current.GoToAsync("..");
    }
}