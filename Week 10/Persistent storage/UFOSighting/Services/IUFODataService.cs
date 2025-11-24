using UFOSighting.Models;

namespace UFOSighting.Services;

public interface IUFODataService
{
    public Task<List<Encounter>> GetEncounters();
    public Task AddNewEncounter();
}
