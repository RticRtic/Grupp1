using Grupp1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp1.Services;


public class RestaurantDBService {

 

    private readonly IMongoCollection<Restaurant> _restaurantListCollection;

    public RestaurantDBService(IOptions<MongoDBSettingsRestaurant> restaurantDBSettings) {
        MongoClient client = new MongoClient(restaurantDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(restaurantDBSettings.Value.DatabaseName);
        _restaurantListCollection = database.GetCollection<Restaurant>(restaurantDBSettings.Value.CollectionName);

    }

    public async Task<List<Restaurant>> GetAsync() => await _restaurantListCollection.Find(_ => true).ToListAsync();
    

    public async Task<Restaurant?> GetAsyncId(string id) => await _restaurantListCollection.Find(restaurantId => restaurantId.Id == id).FirstOrDefaultAsync();


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