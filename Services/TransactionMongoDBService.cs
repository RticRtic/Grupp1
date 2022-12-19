using Grupp1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp1.Services;

public class TransactionMongoDBService {

    private readonly IMongoCollection<Transaction> _transactionCollection;

    public TransactionMongoDBService(IOptions<SuppliesDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _transactionCollection = database.GetCollection<Transaction>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Transaction>> GetAsync() {
    return await _transactionCollection.Find(new BsonDocument()).ToListAsync();
}

        public async Task<Transaction?> GetAsyncId(string id) => await _transactionCollection.Find(transactionId => transactionId.Id == id).FirstOrDefaultAsync();


    public async Task CreateAsync(Transaction transaction) {
    await _transactionCollection.InsertOneAsync(transaction);
    return;
}

    public async Task AddToTransactionAsync(string id, string itemsBought) {
    FilterDefinition<Transaction> filter = Builders<Transaction>.Filter.Eq("Id", id);
    UpdateDefinition<Transaction> update = Builders<Transaction>.Update.AddToSet<string>("itemsBought", itemsBought);
    await _transactionCollection.UpdateOneAsync(filter, update);
    return;
}

    public async Task DeleteAsync(string id) {
    FilterDefinition<Transaction> filter = Builders<Transaction>.Filter.Eq("Id", id);
    await _transactionCollection.DeleteOneAsync(filter);
    return;
}

}