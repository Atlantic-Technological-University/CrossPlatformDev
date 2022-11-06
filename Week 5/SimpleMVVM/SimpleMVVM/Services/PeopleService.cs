using SimpleMVVM.Model;
using System.Text.Json;

namespace SimpleMVVM.Services;

public class PeopleService
{
    // List of person objects
    List<Person> _peopleList = new List<Person>();
    public PeopleService()
    {

    }
    /// <summary>
    /// The GetPeopleFileAsync task reads a list of people from a local JSON file
    /// </summary>
    /// <returns>A list of people objects</returns>
    public async Task<List<Person>> GetPeopleFileAsync()
    {
        if(_peopleList.Count > 0)
        {
            return _peopleList;
        }
        // Load the Json data from file
        using var stream = await FileSystem.OpenAppPackageFileAsync("People.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        _peopleList = JsonSerializer.Deserialize<List<Person>>(contents);

        // Return the list of people
        return _peopleList;
    }
    
}
