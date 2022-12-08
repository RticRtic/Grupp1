using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;
public class Award {
    [BsonElement("wins")]
    [JsonPropertyName("wins")]

    public int? Wins { get; set; }

    [BsonElement("nominations")]
    [JsonPropertyName("nominations")]

    public int? Nominations { get; set; }

    [BsonElement("text")]
    [JsonPropertyName("text")]

    public string? Text { get; set; }
   
}