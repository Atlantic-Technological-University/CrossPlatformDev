using UFOSighting.Models;
using UFOSighting.Services;

namespace UFOSighting.Views;

public partial class DBTest : ContentPage
{
    IUFODataService _dataService;
    public DBTest(IUFODataService dataService)
    //public DBTest()
    {
        InitializeComponent();
        _dataService = dataService;
    }

    public void OnAddEncounter(object sender, EventArgs args)
    {
        _dataService.AddNewEncounter();

    }

    public async void OnGetAllEncounters(object sender, EventArgs args)
    {
        var encounters = await _dataService.GetEncounters();
        //List<Encounter> encounters = await _dataService.GetEncounters();
        encounterList.ItemsSource = encounters;
    }
}