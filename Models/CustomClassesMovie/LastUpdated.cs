using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;


public class LastUpdated {
    [BsonElement("lastupdated")]
    [JsonPropertyName("lastupdated")]

    public DateTime? lastupdated { get; set; }

    public static implicit operator LastUpdated(DateTime v)
    {
        throw new NotImplementedException();
    }
}