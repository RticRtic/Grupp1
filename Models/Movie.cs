using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Grupp1.Models;


public class Movie {
   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [Required]
    public string? Id { get; set; }

    [BsonElement("plot")]
    [JsonPropertyName("plot")]
    public string Plot { get; set; } = null!;

    [BsonElement("genres")]
    [JsonPropertyName("genres")]
    public List<string> Genres { get; set; } = null!;

    [BsonElement("runtime")]
    [JsonPropertyName("runtime")]
    public int Runtime { get; set; } = 0!;

    [BsonElement("cast")]
    [JsonPropertyName("cast")]
    public List<String> Cast { get; set; } = null!;

    [BsonElement("num_mflix_comments")]
    [JsonPropertyName("num_mflix_comments")]
    public int Num_mflix_comments { get; set; } = 0!;

    [BsonElement("title")]
    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    [BsonElement("fullplot")]
    [JsonPropertyName("fullplot")]
    public string Fullplot { get; set; } = null!;

    [BsonElement("countries")]
    [JsonPropertyName("countries")]
    public List<string> Countries { get; set; } = null!;

    [BsonElement("released")]
    [JsonPropertyName("released")]
    public DateTime Released { get; set; } 

    [BsonElement("directors")]
    [JsonPropertyName("directors")]
    public List<string> Directors { get; set; } = null!;

    [BsonElement("rated")]
    [JsonPropertyName("rated")]
    public string Rated { get; set; } = null!;

    [BsonElement("awards")]
    [JsonPropertyName("awards")]
    public Award? Award {get; set;}

    [BsonElement("lastupdated")]
    [JsonPropertyName("lastupdated")]
    public DateTime Lastupdated { get; set; }

    [BsonElement("year")]
    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [BsonElement("imdb")]
    [JsonPropertyName("imdb")]
    public Imdb Imdb {get; set;} = null!;

    [BsonElement("type")]
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [BsonElement("tomatoes")]
    [JsonPropertyName("tomatoes")]
    public Tomatoes Tomatoes {get; set;} = null!;

    [BsonElement("poster")]
    [JsonPropertyName("poster")]
    public string Poster { get; set; } = null!;

    [BsonElement("languages")]
    [JsonPropertyName("languages")]
    public List<string> Languages { get; set; } = null!;

    [BsonElement("writers")]
    [JsonPropertyName("writers")]
    public List<string> Writers { get; set; } = null!;

    [BsonElement("metacritic")]
    [JsonPropertyName("metacritic")]
    public int Metacritic { get; set; } = 0!;

    [BsonElement("critic")]
    [JsonPropertyName("critic")]
    public Critic? Critic { get; set; } = null!;


}
