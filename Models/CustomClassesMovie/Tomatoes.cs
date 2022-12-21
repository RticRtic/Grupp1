using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;


public class Tomatoes {

    // A big Custom type class with nested objects.

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

    // The Tomatoes class takes the Crictic object and many more, see the custom type class for further info.
    public Critic Critic { get; set; }

    [BsonElement("rotten")]
    [JsonPropertyName("rotten")]
    public int? Rotten { get; set; }

    [BsonElement("dvd")]
    [JsonPropertyName("dvd")]
    public DateTime? Dvd { get; set; }

    [BsonElement("website")]
    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [BsonElement("production")]
    [JsonPropertyName("production")]
    public string? Production { get; set; }

    [BsonElement("consensus")]
    [JsonPropertyName("consensus")]
    public string? Consensus { get; set; }

    [BsonElement("boxOffice")]
    [JsonPropertyName("boxOffice")]
    public string? BoxOffice { get; set; }
    
}