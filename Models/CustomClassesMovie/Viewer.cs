using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp1.Models;


public class Viewer {

    public int? Rating { get; set; }

    public int? NumReviews { get; set; }

    public int? Meter { get; set; }
}