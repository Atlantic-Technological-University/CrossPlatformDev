using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace UFOSighting.Models;

[Table("Encounter")]
public class Encounter
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public bool Abduction { get; set; }
    public bool EntitySeen { get; set; }
    public bool Sighting { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime DateTime { get; set; }
    [MaxLength(60)]
    public string Shape { get; set; }
    [MaxLength(500)]
    public string Notes { get; set; }
    public string Icon { get; set; }

    public Encounter() { }
    public Encounter(int iD, bool abduction, bool entitySeen, bool sighting,
    double latitude, double longitude, DateTime dateTime, string shape, string notes)
    {
        ID = iD;
        Abduction = abduction;
        EntitySeen = entitySeen;
        Sighting = sighting;
        Latitude = latitude;
        Longitude = longitude;
        DateTime = dateTime;
        Shape = shape;
        Notes = notes;
    }

}
