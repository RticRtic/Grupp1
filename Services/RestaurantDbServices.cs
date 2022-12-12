using Grupp1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp1.Services;


public class RestaurantDBService {

    private readonly IMongoCollection<Restaurant> _restaurantListCollection;

    public RestaurantDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _restaurantListCollection = database.GetCollection<Restaurant>(mongoDBSettings.Value.CollectionName);

    }

    public async Task<List<Restaurant>> GetAsync() {

        return await _restaurantListCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task CreateAsync(Restaurant restaurant) {
        await _restaurantListCollection.InsertOneAsync(restaurant);
        return;
    }

    public async Task AddToRestaurantListAsync(string id, string restaurantId) {
        FilterDefinition<Restaurant> filter =
        Builders<Restaurant>.Filter.Eq("id", id);

        UpdateDefinition<Restaurant> update = 
        Builders<Restaurant>.Update.AddToSet<string>("restaurantIds", restaurantId);

        await
        _restaurantListCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id) {

        FilterDefinition<Restaurant> filter = 
        Builders<Restaurant>.Filter.Eq("Id", id);
        await
        _restaurantListCollection.DeleteOneAsync(filter);
        return;
    }
}