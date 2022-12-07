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
    public Address? Address { get; set;}

    [BsonElement("borough")]
    [JsonPropertyName("borough")]
    public string? Borough {get; set;} = null!;

    [BsonElement("cuisine")]
    [JsonPropertyName("cuisine")]
    public string? Cuisine {get; set;} = null!;

    [BsonElement("grades")]
    [JsonPropertyName("grades")]
    public List<GradeList> Grades {get; set;} = null!;


    [BsonElement("name")]
    [JsonPropertyName("name")]

    public string? Name {get; set;} = null!;

    
}


public class GradeList {

    [BsonElement("date")]
    [JsonPropertyName("date")]
    public DateTime? Date {get; set;} = null!;

    [BsonElement("grade")]
    [JsonPropertyName("grade")]
    public string? Grade {get; set;} = null!;

    [BsonElement("score")]
    [JsonPropertyName("score")]

    public int? Score {get; set;} = 0;


}


public class Address {

    [BsonElement("building")]
    [JsonPropertyName("building")]
    public string? Building {get; set;} = null!;

    [BsonElement("coord")]
    [JsonPropertyName("coord")]
    public List<double> Coord {get; set;} = null!;

    [BsonElement("street")]
    [JsonPropertyName("street")]
    public string? Zipcode {get; set;} = null!;
}