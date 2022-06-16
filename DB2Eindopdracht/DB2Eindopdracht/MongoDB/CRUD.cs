using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace DB2Eindopdracht.MongoDB
{
    public class CRUD
    {
        MongoClient dbClient;
        IMongoDatabase database;

        public CRUD()
        {
            dbClient = new MongoClient("mongodb+srv://testAcc:testAcc@cluster0.ywwyyyo.mongodb.net/?retryWrites=true&w=majority");
            database = dbClient.GetDatabase("NetflixDB");
            
        }

/*        public async void createSeries(int seriesId, int contentId, string title)
        {
            var collection = database.GetCollection<BsonDocument>("test");
            var document = new BsonDocument { { "seriesId", seriesId }, { "contentId", contentId }, { "title", title } };
            collection.InsertOneAsync(document);
            Console.WriteLine("Created");
        }*/
        
        public async void readSeries()
        {
            var collection = database.GetCollection<BsonDocument>("Series");
            var firstdocument = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(firstdocument);
        } 

        public void updateSeries()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("seriesId", 121);
            var update = Builders<BsonDocument>.Update.Set("title", "Nieuws");
            var collection = database.GetCollection<BsonDocument>("Series");
            collection.UpdateOne(filter, update);
        }

        public void deleteSeries()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("seriesId", 121);
            var collection = database.GetCollection<BsonDocument>("Series");
            collection.DeleteOne(filter);
        }
    }
}
