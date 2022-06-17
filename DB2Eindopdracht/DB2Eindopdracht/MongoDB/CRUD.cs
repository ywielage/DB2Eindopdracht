using MongoDB.Driver;
using MongoDB.Bson;
using System.Diagnostics;
using System;

namespace DB2Eindopdracht.MongoDB
{
    public class CRUD
    {
        MongoClient dbClient;
        IMongoDatabase database;
        Stopwatch stopwatch;

        public CRUD()
        {
            dbClient = new MongoClient("mongodb+srv://testAcc:testAcc@cluster0.ywwyyyo.mongodb.net/?retryWrites=true&w=majority");
            database = dbClient.GetDatabase("NetflixDB");

            stopwatch = new Stopwatch();
        }

        // Replace <Method>() with any CRUD method
        public async void Run(int loop)
        {
            stopwatch.Start();
            for (int i = 1; i < loop; i++)
            {
                await updateSeries();
            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        public async void createSeries(int seriesId, int contentId, string title)
        {
            var collection = database.GetCollection<BsonDocument>("test");
            var document = new BsonDocument { { "seriesId", seriesId }, { "contentId", contentId }, { "title", title } };
            stopwatch.Start();
            collection.InsertOneAsync(document);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        public async Task<int> readSeries()
        {
            var collection = database.GetCollection<BsonDocument>("Series");
            var firstdocument = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(firstdocument);
            return 0;
        } 

        public void updateSeries()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("seriesId", 121);
            var update = Builders<BsonDocument>.Update.Set("title", "Nieuws");
            var collection = database.GetCollection<BsonDocument>("Series");
            collection.UpdateOneAsync(filter, update);
        }

        public void deleteSeries()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("seriesId", 121);
            var collection = database.GetCollection<BsonDocument>("Series");
            collection.DeleteOne(filter);
        }
    }
}
