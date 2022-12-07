using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Grupp1.Models;


public class Movie {
   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string plot { get; set; } = null!;
    public List<string> genres { get; set; } = null!;
    public int runtime { get; set; } = 0!;
    public CustomClassesMovie.Cast Cast { get; set; } = null!;
    public int num_mflix_comments { get; set; } = 0!;
    public string title { get; set; } = null!;
    public string fullplot { get; set; } = null!;
    public List<string> countries { get; set; } = null!;
    public CustomClassesMovie.Released? Released { get; set; }
    public List<string> directors { get; set; } = null!;
    public string rated { get; set; } = null!;
    public CustomClassesMovie.Award Award {get; set;}
    public CustomClassesMovie.LastUpdated Lastupdated { get; set; } = null!;
    public dynamic year { get; set; } = 0!;
    public CustomClassesMovie.Imdb Imdb {get; set;} = null!;
    public string type { get; set; } = null!;
    public object tomatoes {get; set;} = null!;
    public string poster { get; set; } = null!;
    public List<string> languages { get; set; } = null!;
    public List<string> writers { get; set; } = null!;
    public int metacritic { get; set; } = 0!;

    public Movie(string plot, List<string> genres, int runtime, List<String> cast, int num_mflix_comments,
    string title, string fullplot, List<string> countries, DateTime released, List<String> directors,
    string rated, object award, DateTime lastupdated, dynamic year, object imdb, string type, object tomatoes,
    string poster, List<String> languages, List<String> writers, int metacritic) {
        this.plot = plot;
        this.genres = genres;
        this.runtime = runtime;
        this.Cast = cast;
        this.num_mflix_comments = num_mflix_comments;
        this.title = title;
        this.fullplot = fullplot;
        this.countries = countries;
        this.Released = (CustomClassesMovie.Released)released;
        this.directors = directors;
        this.rated = rated;
        this.Award = (CustomClassesMovie.Award)award;
        this.Lastupdated = (CustomClassesMovie.LastUpdated)lastupdated;
        this.year = year;
        this.Imdb = (CustomClassesMovie.Imdb)imdb;
        this.type = type;
        this.tomatoes = tomatoes;
        this.poster = poster;
        this.languages = languages;
        this.writers = writers;
        this.metacritic = metacritic;
        
    }

}
