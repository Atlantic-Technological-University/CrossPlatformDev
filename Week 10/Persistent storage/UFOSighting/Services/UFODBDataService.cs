using SQLite;
using System.Diagnostics;
using UFOSighting.Models;
using static SQLite.SQLite3;

namespace UFOSighting.Services;

public class UFODBDataService : IUFODataService
{
    //SQLiteConnection _connection;
    SQLiteAsyncConnection _connection;
    private const SQLite.SQLiteOpenFlags _dbFlags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;
    
    string _dbPath;

    List<Encounter> _encounters = new List<Encounter>();

    public string StatusMessage;

    public UFODBDataService(string path)
    {
        _dbPath = path;
        //throw new NotImplementedException();

    }

    //private void Init()
    /// <summary>
    /// Initialise the database connection.
    /// </summary>
    /// <returns></returns>
    private async Task Init()
    {

        if (_connection is not null)
            return;
        _connection = new SQLiteAsyncConnection(_dbPath, _dbFlags);
        var result = await _connection.CreateTableAsync<Encounter>();

        // Old synchronous code
        //if (_connection is not null)
        //    return;
        //_connection = new SQLiteConnection(_dbPath);
        //_connection.CreateTable<Encounter>();

        //await CreateDatabaseTest();
    }

    public async Task<List<Encounter>> GetEncounters()
    {
        // TODO: Init then retrieve a list of Person objects from the database into a list
        try
        {
            await Init();
            var query = _connection.Table<Encounter>().Where(s => s.Sighting == true);
            var result = await query.ToListAsync();
            return await _connection.Table<Encounter>().ToListAsync();


            //await Task.Run(() =>
            //{
            //    Init();
            //    //_encounters = _connection.Table<Encounter>().ToList();

            //    //_connection.CreateTable<Encounter>();
            //    //_encounters = _connection.Table<Encounter>().ToList();
            //});
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data from local DB. {0}", ex.Message);
        }

        return _encounters;
    }

   
    //public void AddNewEncounter()
    public async Task AddNewEncounter()
    {
        int result = 0;
        try
        {
            await Init();
            result = await _connection.InsertAsync(
                new Encounter(1, true, true, true, 55.023787, -7.427538, 
                DateTime.Now, "Triangle", "Keep watching the skies!"));
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", ex.Message);
            Debug.WriteLine(StatusMessage);
        }
        
    }

   public async Task<List<Encounter>> GetAllEncounters()
    {
        int result = 0;
        try
        {
            await Init();
            result = await _connection.InsertAsync(
               new Encounter(1, true, true, true, 55.023787, -7.427538,
               DateTime.Now, "Triangle", "Keep watching the skies!"));
            result = await _connection.InsertAsync(
               new Encounter(1, true, true, true, 55.023787, -7.427538,
               DateTime.Now, "Triangle", "Keep watching the skies!"));
            return await _connection.Table<Encounter>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            Debug.WriteLine(StatusMessage);
        }

        return new List<Encounter>();
    }

    //A nested class just for the createDatabaseTest
    class UFO
    {
        public string shape { get; set; }

    }
    public async Task CreateDatabaseTest()
    {

        var result = await _connection.ExecuteAsync($"create table UFO(shape varchar(100) not null)");
        //result = await _connection.ExecuteAsync($"create table ufo (contact INTEGER PRIMARY KEY)");
        result = await _connection.ExecuteAsync($"insert into UFO(shape) values (?)", "Triangle");
        result = await _connection.ExecuteAsync($"insert into UFO(shape) values (?)", "Sphere");
        var shapes = await _connection.QueryAsync<UFO>($"select * from UFO");

    }
}