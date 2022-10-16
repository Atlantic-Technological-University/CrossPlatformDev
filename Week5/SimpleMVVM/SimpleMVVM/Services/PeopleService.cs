using SimpleMVVM.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace SimpleMVVM.Services;

public class PeopleService
{
    // List of person objects
    List<Person> _peopleList = new List<Person>();

    // .NET HTTP client for REST calls
    HttpClient _httpClient;

    public PeopleService()
    {
        _httpClient = new HttpClient();
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

    public async Task<List<Person>> GetPeopleRemoteAsync()
    {
        if (_peopleList.Count > 0)
        {
            return _peopleList;
        }
        // Fetch the data from the remort repository
        var url = "https://raw.githubusercontent.com/Atlantic-Technological-University/CrossPlatformDev/main/Week5/SimpleMVVM/SimpleMVVM/Resources/Raw/People.json";    
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            _peopleList = await response.Content.ReadFromJsonAsync<List<Person>>();
        }


        // Return the list of people
        return _peopleList;
    }

    
}
