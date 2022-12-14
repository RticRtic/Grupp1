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

    public async Task<List<Movie>> GetAsync() => await _movielistCollection.Find(_ => true).ToListAsync();
    public async Task<Movie?> GetAsyncId(string id) => await _movielistCollection.Find(movieId => movieId.Id == id).FirstOrDefaultAsync();
    public async Task AddToMovieListAsync(Movie newMovie) => await _movielistCollection.InsertOneAsync(newMovie);
    public async Task UpdateAsync(string id, Movie updatedMovie) => 
    await _movielistCollection.ReplaceOneAsync(movie => movie.Id == id, updatedMovie);
    public async Task DeleteMovie(string id) => await _movielistCollection.DeleteManyAsync(movieId => movieId.Id == id);
    public async Task isForRent(int nrOfCopies, Movie updatedStatus) => 
    await _movielistCollection.ReplaceOneAsync(copies => copies.IsForRent!.NrOfCopiesAvailable == 0, updatedStatus);

}

