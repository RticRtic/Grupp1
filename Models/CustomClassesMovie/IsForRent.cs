using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using MongoDB.Driver;
using System.ComponentModel;

namespace Grupp1.Models;


public class IsForRent {

[BsonElement("nrOfCopiesAvaiable")]
[JsonPropertyName("nrOfCopiesAvaiable")]

public int? NrOfCopiesAvailable { get; set; }

[BsonElement("available")]
[JsonPropertyName("available")]
[DefaultValue(false)]
public bool Available { get; set; }

}

