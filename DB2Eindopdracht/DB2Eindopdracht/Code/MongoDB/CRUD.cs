using MongoDB.Driver;
using MongoDB.Bson;
using System.Diagnostics;
using System;
using DB2Eindopdracht.EntityFramework.Entities;

namespace DB2Eindopdracht.MongoDB
{
    public class CRUD
    {
        MongoClient dbClient;
        IMongoDatabase database;
        Stopwatch stopwatch;
        List<BsonDocument> dblist;

        int action;
        int loops;


        public CRUD(int loops, int action)
        {
            try
            {
                dbClient = new MongoClient("mongodb+srv://testAcc:8CZl474X4xtz8Szl@cluster0.ywwyyyo.mongodb.net/?retryWrites=true&w=majority");
                database = dbClient.GetDatabase("NetflixDB");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cannot connect to MongoDB" + ex.Message);
            }


            stopwatch = new Stopwatch();

            this.action = action;
            this.loops = loops;
        }

        public async void Run()
        {
            stopwatch.Start();


            if(action == 0) 
            {
                await createSeries(1, "TestTitle");
            }
            else if (action == 1)
            {
                readSeries(1);
            }
            else if(action == 2)
            {
                UpdateSeries(1);
            }
            else if(action == 3)
            {
                deleteSeries(1);
            }


            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        public async Task createSeries(int contentId, string title)
        {
            var collection = database.GetCollection<BsonDocument>("Series");
            var docList = new List<BsonDocument>();


            try
            {
                for (int x = 0; x < loops; x++)
                {
                    docList.Add(new BsonDocument { { "seriesId", x }, { "contentId", contentId }, { "title", $"{x}{title}" } });

                    await collection.InsertManyAsync(docList);
                    Console.WriteLine("Documents inserted");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void readSeries(int contentId)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("Series");
                List<BsonDocument> list = collection.Find(new BsonDocument("contentId", contentId)).ToList();

                list.ForEach(x =>
                   Console.WriteLine(x)
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("readSeries error: " + ex.Message);
            }
        }


        public async void UpdateSeries(int contentId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("contentId", contentId);
            var update = Builders<BsonDocument>.Update.Set("title", "Nieuws");
            var collection = database.GetCollection<BsonDocument>("Series");

            try
            {
                await collection.UpdateManyAsync(filter, update);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        /*        public void updateSeries()
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("seriesId", 121);
                    var update = Builders<BsonDocument>.Update.Set("title", "Nieuws");
                    var collection = database.GetCollection<BsonDocument>("Series");
                    collection.UpdateOneAsync(filter, update);
                }{ "seriesId", seriesId
            }, { "contentId", contentId
        }, { "title", title }
        **/

        public void deleteSeries(int contentId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("contentId", contentId);
            var collection = database.GetCollection<BsonDocument>("Series");
            collection.DeleteOne(filter);
        }
    }
}
