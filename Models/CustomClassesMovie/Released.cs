using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;


public class Released {
    [BsonElement("released")]
    [JsonPropertyName("released")]

    public DateTime? released { get; set; }

    public static implicit operator Released(DateTime v)
    {
        throw new NotImplementedException();
    }
}


