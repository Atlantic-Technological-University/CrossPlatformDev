using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UFOSighting.Models;

namespace UFOSighting.ViewModels;

[QueryProperty("Encounter", "Encounter")]
public partial class EncounterViewModel : BaseViewModel
{
    
    IMap _mapService;
    
    [ObservableProperty]
    Encounter encounter;

    public EncounterViewModel(IMap mapService)
    {
        _mapService = mapService;
    }

    [RelayCommand]
    async Task OpenMapAsync()
    {
        try
        {
            // could use TryOpenAsync which returns a boolean if opening it was successful.
            await _mapService.OpenAsync(Encounter.Latitude, Encounter.Longitude, new MapLaunchOptions
            {
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unable to open map: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

}
