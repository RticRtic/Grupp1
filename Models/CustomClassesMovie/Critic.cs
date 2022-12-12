using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;

public class Critic {

    [BsonElement("rating")]
    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    [BsonElement("numReviews")]
    [JsonPropertyName("numReviews")]
    public int? NumReviews { get; set; }

    [BsonElement("meter")]
    [JsonPropertyName("meter")]
    public int? Meter { get; set; }
}