using Microsoft.Maui.Devices.Sensors;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using UFOSighting.Models;

namespace UFOSighting.Services;

public class UFOFileDataService : IUFODataService
{
    List<Encounter> _encounters= new List<Encounter>();

    public class tempEncounter
    {
        public int ID { get; set; }
        public bool Abduction { get; set; }
        public bool EntitySeen { get; set; }
        public bool Sighting { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string DateTime { get; set; }
        public string Shape { get; set; }
        public string Notes { get; set; }
        public Image icon { get; set; }
    }

    public async Task<List<Encounter>> GetEncounters()
    {
        try
        {
            // Load the people People.json file
            using var stream = await FileSystem.OpenAppPackageFileAsync("SmallSightings.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();

            var rawEncounters = JsonSerializer.Deserialize<List<tempEncounter>>(contents);
            // Convert to transaction objects
            _encounters = ConvertToEncounterObjects(rawEncounters);
            _encounters.Sort((x, y) => DateTime.Compare(x.DateTime, y.DateTime));

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return _encounters;
    }

    private List<Encounter> ConvertToEncounterObjects(List<tempEncounter> rawEncounters)
    {
        Random random = new Random();

        List<Encounter> encounters = new List<Encounter>();
        foreach (tempEncounter rawEncounter in rawEncounters)
        {
            var encounter = new Encounter(rawEncounter.ID, rawEncounter.Abduction, rawEncounter.EntitySeen,
                rawEncounter.Sighting, rawEncounter.Latitude, rawEncounter.Longitude,
                DateTime.ParseExact(rawEncounter.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), 
                rawEncounter.Shape, rawEncounter.Notes);

            if (encounter.Abduction)
            {
                encounter.Icon = "abduction.png";
            }
            else if (encounter.EntitySeen)
            {
                string iconString = "alien" + random.Next(1, 5).ToString() + ".png";
                encounter.Icon = iconString;
            }
            else
            {
                encounter.Icon = "ufo.png";
            }
            if (encounter.Notes.Length is 0)
            {
                encounter.Notes = "No further information on this strange event.";
            }
            
            encounters.Add(encounter);           
        }
        return encounters;
    }

    public async Task AddNewEncounter()
    {
        throw new NotImplementedException();
    }
}
