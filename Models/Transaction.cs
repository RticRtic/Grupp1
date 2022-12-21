using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;



public class Transaction {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string storeLocation { get; set; } = null!;

    [BsonElement("itemsBought")]
    [JsonPropertyName("itemsBought")]
    public List<string> itemsBought { get; set; } = null!;

    public bool usedCoupon { get; set; }
    public Customer customer { get; set; } = null!;

    public string purchaseMethod { get; set; } = null!;
    public DateTime? Date {get; set;} = null!;

}

