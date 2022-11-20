using System.Collections.ObjectModel;
using System.Diagnostics;
using UFOSighting.Models;
using UFOSighting.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UFOSighting.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    // UFODataService
    UFODataService _ufoDataService;
   
    // An observable collection of transactions for the view
    public ObservableCollection<Encounter> UFOEncounters{ get; set; } = new();


    public MainPageViewModel(UFODataService ufoDataService)
    {
        _ufoDataService = ufoDataService;       
    }
    

    // Create a method to get the encounters from the data service and add them to the view model.
    // [RelayCommand] Comes from the MVVM namespace and turns the GetEncountersAsync task into a command
    [RelayCommand] //https://learn.microsoft.com/en-gb/windows/communitytoolkit/mvvm/relaycommand
    async Task GetEncountersAsync()
    {
        // If we are already busy just return to prevent the user spamming the button
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var encounters = await _ufoDataService.GetEncounters();
            if (encounters.Count != 0)
                UFOEncounters.Clear();

            foreach (var encounter in encounters)
            {
                // This will create notification every time we add an encounter to the observable collection
                // .NET 7 might have an add range to add items in a batch
                UFOEncounters.Add(encounter);
            }
           

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // The display alert is really a UI call which doesn't fit into the viewmodel pattern
            // We could abstract this and create an interface that injects the message/alert
            await Shell.Current.DisplayAlert("Error", $"Unable to get UFO encounters", "OK");
        }
        finally
        {
            // Finally always gets called
            IsBusy = false;

        }

    }
}

