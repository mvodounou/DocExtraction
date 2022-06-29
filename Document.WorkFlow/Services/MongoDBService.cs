using System;
using Document.WorkFlow.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Document.WorkFlow.Services
{
    public class MongoDBService
    {

        private readonly IMongoCollection<dynamic>? _supplierCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _supplierCollection = database.GetCollection<dynamic>(mongoDBSettings.Value.CollectionName);
        }

        public MongoDBService(MongoDBSettings dBSettings)
        {
            MongoClient client = new MongoClient(dBSettings.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(dBSettings.DatabaseName);
            _supplierCollection = database.GetCollection<object>(dBSettings.CollectionName);
        }

        public async Task<List<dynamic>> GetAsync() { return await _supplierCollection.Find(new BsonDocument()).ToListAsync(); }

        public async Task CreateAsync(object item)
        {
            await _supplierCollection.InsertOneAsync(item);
            return;
        }

        public async Task CreateAsync(List<object> items)
        {
            await _supplierCollection.InsertManyAsync(items);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<object> filter = Builders<object>.Filter.Eq("Id", id);
            await _supplierCollection.DeleteOneAsync(filter);
            return;
        }

    }
}

