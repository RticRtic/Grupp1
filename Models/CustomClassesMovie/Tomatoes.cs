using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;


public class Tomatoes {

    [BsonElement("viewer")]
    [JsonPropertyName("viewer")]
    public Viewer Viewer { get; set; }

    [BsonElement("lastUpdated")]
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [BsonElement("fresh")]
    [JsonPropertyName("fresh")]

    public int? Fresh { get; set; }

    [BsonElement("critic")]
    [JsonPropertyName("critic")]
    public Critic Critic { get; set; }

    [BsonElement("rotten")]
    [JsonPropertyName("rotten")]
    public int? Rotten { get; set; }

    [BsonElement("dvd")]
    [JsonPropertyName("dvd")]
    public DateTime? Dvd { get; set; }
    
}