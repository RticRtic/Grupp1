
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;


public class Imdb {

    [BsonElement("rating")]
    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    [BsonElement("votes")]
    [JsonPropertyName("votes")]

    public int? Votes { get; set; }

    [BsonElement("id")]
    [JsonPropertyName("id")]

    public int? IdOfMovie { get; set; }
}