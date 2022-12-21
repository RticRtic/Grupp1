using Grupp1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp1.Services;

public class MovieDBService {

    private readonly IMongoCollection<Movie> _movielistCollection;

    //Establishing connection to AtlasDB and work with documents.
    public MovieDBService(IOptions<MongoDBSettingsMovie> movieDBSettings) {
        MongoClient client = new MongoClient(movieDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(movieDBSettings.Value.DatabaseName);
        _movielistCollection = database.GetCollection<Movie>(movieDBSettings.Value.CollectionName);
    }

    //Get movies collection
    public async Task<List<Movie>> GetAsync() => await _movielistCollection.Find(_ => true).ToListAsync();

    //Get a movie-item whith an id
    public async Task<Movie?> GetAsyncId(string id) => await _movielistCollection.Find(movieId => movieId.Id == id).FirstOrDefaultAsync();

    //Add an movie-item to the movies collection
    public async Task AddToMovieListAsync(Movie newMovie) => await _movielistCollection.InsertOneAsync(newMovie);

    //Update a movie-item, requires an movie-id to update the right item
    public async Task UpdateAsync(string id, Movie updatedMovie) => 
    await _movielistCollection.ReplaceOneAsync(movie => movie.Id == id, updatedMovie);

    //Delete a movie-item, requires an movie-id to delete the right item
    public async Task DeleteMovie(string id) => await _movielistCollection.DeleteManyAsync(movieId => movieId.Id == id);

    //Update a bool if the nrOfCopies is 0 or > 0, NrOfCopiesAvailable is set to 0
    public async Task isForRent(int nrOfCopies, Movie updatedStatus) => 
    await _movielistCollection.ReplaceOneAsync(copies => copies.IsForRent!.NrOfCopiesAvailable == 0, updatedStatus);

}

