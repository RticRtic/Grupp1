using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace Grupp1.Models;

public class CustomClassesRestaurant { 

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
    public string? Street {get; set;} = null!;
    

    [BsonElement("zipcode")]
    [JsonPropertyName("zipcode")]
    public string? Zipcode {get; set;} = null!;
    
    }
 
 
 }

