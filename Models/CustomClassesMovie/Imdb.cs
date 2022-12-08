using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;


public class Imdb {

    [BsonElement("rating")]
    [JsonPropertyName("rating")]
    public int? Rating { get; set; }

    [BsonElement("votes")]
    [JsonPropertyName("votes")]

    public double? Votes { get; set; }

    [BsonElement("id")]
    [JsonPropertyName("id")]

    public int? Id { get; set; }
}