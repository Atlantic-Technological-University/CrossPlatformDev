using System.Collections.ObjectModel;
using System.Diagnostics;
using UFOSighting.Models;
using UFOSighting.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UFOSighting.Views;

namespace UFOSighting.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    // UFODataService
    UFOFileDataService _ufoDataService;

    // Connectivity and geolocation services
    IConnectivity _connectivityService;
    IGeolocation _geolocationService;
    
    // An observable collection of transactions for the view
    public ObservableCollection<Encounter> UFOEncounters{ get; set; } = new();

    [ObservableProperty]
    bool isRefreshing;

    public MainPageViewModel(UFOFileDataService ufoDataService, IConnectivity connectivity, 
        IGeolocation geolocation)
    {
        _ufoDataService = ufoDataService;
        _connectivityService = connectivity; 
        _geolocationService = geolocation; 
    }
    
    [RelayCommand]
    async Task NavigateToSettingsAsync(){
        await Shell.Current.GoToAsync($"{nameof(SettingsPage)}", true);
    }

    //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");

    [RelayCommand]
    async Task TestDB()
    {
        await Shell.Current.GoToAsync($"{nameof(DBTest)}", true);
    }

    [RelayCommand]
    private void TestWrite() {
        // Get the path on the device to the app sandbox
        string fileName = Path.Combine(FileSystem.AppDataDirectory, "temp.txt");
        File.WriteAllText(fileName, "Hello World");       
    }

    [RelayCommand]
    async Task TestReadAsync()
    {
        string fileName = Path.Combine(FileSystem.AppDataDirectory, "temp.txt");
        if (File.Exists(fileName))
        {
            string text = await File.ReadAllTextAsync(fileName);
            await Shell.Current.DisplayAlert("File Read", text, "OK");
        }
        else
        {
            await Shell.Current.DisplayAlert("File Read", "File does not exist", "OK");
        }
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
            // **New
            // Check to see if there is an internet connection
            if (_connectivityService.NetworkAccess != NetworkAccess.Internet)
            {
                // If there is no internet connection, display an error message
                await Shell.Current.DisplayAlert("No Internet Connection", "Please connect to the internet and try again.", "OK");
                return;
            }


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
            IsRefreshing = false; //**new
        }

    }

    // Navigate to the encounter details page
    [RelayCommand]
    async Task GoToDetailsAsync(Encounter encounter)
    {
        if (encounter is null)
            return;

        // navigate to the details page passing true for animation and a new dictionary with the encounter details
        await Shell.Current.GoToAsync($"{nameof(EncounterPage)}", true,
            new Dictionary<string, object>
            { {"Encounter", encounter}});

        //"Encounter" = query identifier 
    }

    [RelayCommand]
    async Task GetClosestEncounterAsync()
    {
        // If we are busy or we don't have any encounters loaded just return. 
        if (IsBusy || UFOEncounters.Count == 0)
            return;
        try
        {
            //Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>;

            //Get the cached locaiton if it is available
            var location = await _geolocationService.GetLastKnownLocationAsync();
            if (location is null)
            {
                location = await _geolocationService.GetLocationAsync(
                    new GeolocationRequest
                    {
                        // Set the accuracy and timeout of the request
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30),

                    });
            }

            if (location is null)
                return;
            // Get the closest UFO encounter from us. First order the encounters by distance from us
            var firstEncounter = UFOEncounters.OrderBy(m =>
                location.CalculateDistance(m.Latitude, m.Longitude, DistanceUnits.Kilometers)).FirstOrDefault();
            if (firstEncounter is null)
                return;

            // Try a reverse geocode the specified geocoordinate.
            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(firstEncounter.Latitude,
                firstEncounter.Longitude);
            Placemark placemark = placemarks?.FirstOrDefault();
            if (placemark is not null)
            {
                await Shell.Current.DisplayAlert("Closest UFO encounter", $"{placemark.Locality}", "OK");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unable to get closest ufo encounter", "OK");
        }   
    }

}

