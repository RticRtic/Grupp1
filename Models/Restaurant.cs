using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;


public class Restaurant {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}
    public string username {get; set;} = null!;

    [BsonElement("items")]
    [JsonPropertyName("items")]

    public List<string> restaurantIds {get; set;} = null!;


}