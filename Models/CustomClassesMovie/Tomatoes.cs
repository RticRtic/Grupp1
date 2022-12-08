using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;


public class Tomatoes {

    public Viewer Viewer { get; set; }

    public DateTime? LastUpdated { get; set; }
}