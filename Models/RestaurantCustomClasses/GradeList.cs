using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace Grupp1.Models;


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
