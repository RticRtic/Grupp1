using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;

public class CustomClassesMovie {
 
public class Imdb {

    [BsonElement("rating")]
    [JsonPropertyName("rating")]
    public int Rating { get; set; }

    [BsonElement("votes")]
    [JsonPropertyName("votes")]

    public double Votes { get; set; }

    [BsonElement("id")]
    [JsonPropertyName("id")]

    public int Id { get; set; }
}

public class Award {
    [BsonElement("wins")]
    [JsonPropertyName("wins")]

    public int Wins { get; set; }

    [BsonElement("nominations")]
    [JsonPropertyName("nominations")]

    public int Nominations { get; set; }

    [BsonElement("text")]
    [JsonPropertyName("text")]

    public string Text { get; set; }
   
}

public class LastUpdated {
    [BsonElement("lastupdated")]
    [JsonPropertyName("lastupdated")]

    public DateTime? DateTime { get; set; }

    public static implicit operator LastUpdated(DateTime v)
    {
        throw new NotImplementedException();
    }
}

public class Released {
    [BsonElement("released")]
    [JsonPropertyName("released")]

    public DateTime? DateTime { get; set; }

    public static implicit operator Released(DateTime v)
    {
        throw new NotImplementedException();
    }
}

public class Cast {
    public List<string>? Janne { get; set; }

        public static implicit operator Cast(List<string> v)
        {
            throw new NotImplementedException();
        }
    }

}