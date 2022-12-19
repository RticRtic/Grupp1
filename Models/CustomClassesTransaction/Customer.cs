using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;

public class Customer {
    
    public string gender { get; set; } = null!;
    public int age { get; set;}
    public string email { get; set;} = null!;
    public int satisfactionRateOneToFive { get; set; }
    

}

