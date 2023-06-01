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
        List<BsonDocument> dblist;

        public CRUD()
        {
            dbClient = new MongoClient("mongodb+srv://testAcc:8CZl474X4xtz8Szl@cluster0.ywwyyyo.mongodb.net/?retryWrites=true&w=majority");
            database = dbClient.GetDatabase("NetflixDB");

            stopwatch = new Stopwatch();
        }

        // Replace <Method>() with any CRUD method
        public void Run()
        {
            stopwatch.Start();

            createSeries(2, "LOTR");
            Console.WriteLine("Created");

            //readSeries();

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        public void createSeries(int contentId, string title)
        {
            var collection = database.GetCollection<BsonDocument>("Series");
            var docList = new List<BsonDocument>();
            
            for(int x = 0; x<10; x++)
            {
                docList.Add(new BsonDocument { { "seriesId", x }, { "contentId", contentId }, { "title", title } });
            }

            // Start creating
            collection.InsertManyAsync(docList);
        }

/*        public async void readSeries()
        {
            var collection = database.GetCollection<BsonDocument>("Series");
            List<BsonDocument> list = collection.Find(new BsonDocument("seriesId", 7)).ToList();
            list.ForEach(x => 
               Console.WriteLine(x)
            );
        }*/

/*        public void updateSeries()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("seriesId", 121);
            var update = Builders<BsonDocument>.Update.Set("title", "Nieuws");
            var collection = database.GetCollection<BsonDocument>("Series");
            collection.UpdateOneAsync(filter, update);
        }{ "seriesId", seriesId
            }, { "contentId", contentId
        }, { "title", title }*/

/*public void deleteSeries()
{
    var filter = Builders<BsonDocument>.Filter.Eq("seriesId", 121);
    var collection = database.GetCollection<BsonDocument>("Series");
    collection.DeleteOne(filter);
}*/
    }
}
