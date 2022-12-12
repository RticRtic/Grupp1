using Grupp1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp1.Services;

public class MovieDBService {

    public  readonly IMongoCollection<Movie> _movielistCollection;

    public MovieDBService(IOptions<MongoDBSettingsMovie> movieDBSettings) {
        MongoClient client = new MongoClient(movieDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(movieDBSettings.Value.DatabaseName);
        _movielistCollection = database.GetCollection<Movie>(movieDBSettings.Value.CollectionName);
    }

    //public async Task<List<Movie>> GetAsync() { return await _movielistCollection.Find(new BsonDocument()).ToListAsync(); }

    public async Task<List<Movie>> GetMoviesAsync () => await _movielistCollection.Find(_ => true).ToListAsync();
    public async Task CreateAsync(Movie movie) { await _movielistCollection.InsertOneAsync(movie); return; }
    public async Task AddToMovielistAsync(string id, string movieId) {
        FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq("Id", id);
        UpdateDefinition<Movie> update = Builders<Movie>.Update.AddToSet<string>("movieIds", movieId);
        await _movielistCollection.UpdateOneAsync(filter, update);

    }
    public async Task DeleteAsync(string id) {
        FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq("Id", id);
        await _movielistCollection.DeleteOneAsync(filter);
        return;
     }

}

