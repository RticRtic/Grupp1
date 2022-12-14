using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;



namespace Grupp1.Models;


public class Restaurant {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
     public string? Id {get; set;}
    
    [BsonElement("address")]
    [JsonPropertyName("address")]
    public Address Address { get; set;}

    [BsonElement("borough")]
    [JsonPropertyName("borough")]
    public string? Borough {get; set;} = null!;

    [BsonElement("cuisine")]
    [JsonPropertyName("cuisine")]
    public string? Cuisine {get; set;} = null!;

    [BsonElement("grades")]
    [JsonPropertyName("grades")]
    public List<GradeList> Grades {get; set;}


    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string? Name {get; set;} = null!;

    [BsonElement("restaurant_id")]
    [JsonPropertyName("restaurant_id")]
    public string? RestaurantId {get; set;} = null!;

    
}


