using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace Grupp1.Models;


public class Address {

    [BsonElement("building")]
    [JsonPropertyName("building")]
    public string? Building {get; set;} = null!;

    [BsonElement("coord")]
    [JsonPropertyName("coord")]
    public List<double> Coord {get; set;} = null!;

    [BsonElement("street")]
    [JsonPropertyName("street")]
    public string? Street {get; set;} = null!;
    

    [BsonElement("zipcode")]
    [JsonPropertyName("zipcode")]
    public string? Zipcode {get; set;} = null!;
    
    }
 