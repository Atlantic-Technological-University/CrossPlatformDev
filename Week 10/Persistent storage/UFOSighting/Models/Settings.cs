namespace UFOSighting.Models;

public sealed class Settings
{
    public bool FileDataEnabled { get; set; }
    public bool LocalDBEnabled { get; set; }
    public bool WebDataEnabled { get; set; }
    public string DBName { get; set; }
}

