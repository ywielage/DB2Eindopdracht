using MongoDB.Driver;
using MongoDB.Bson;
using System.Diagnostics;

namespace DB2Eindopdracht.MongoDB
{
    public class CRUD
    {
        MongoClient dbClient;
        IMongoDatabase database;
        Stopwatch stopwatch;

        int action;
        int loops;


        public CRUD(int loops, int action)
        {
            dbClient = new MongoClient("mongodb+srv://testAcc:8CZl474X4xtz8Szl@cluster0.ywwyyyo.mongodb.net/?retryWrites=true&w=majority");
            database = dbClient.GetDatabase("NetflixDB");

            var collectionNames = database.ListCollectionNames().ToList();

            if (collectionNames.Count > 0)
            {
                Console.WriteLine("Connection to MongoDB successful!");
            }
            else
            {
                Console.WriteLine("Failed to connect to MongoDB or no collections found.");
            }

            stopwatch = new Stopwatch();

            this.action = action;
            this.loops = loops;
        }

        public void Run()
        {
            stopwatch.Start();

            if(action == 0) 
            {
                createSeries(1, "TestTitle");
            }
            else if (action == 1)
            {
                readSeries(1);
            }
            else if(action == 2)
            {
                UpdateSeries();
            }
            else if(action == 3)
            {
                deleteSeries(1);
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        public void createSeries(int contentId, string title)
        {
            var collection = database.GetCollection<BsonDocument>("Series");
            var docList = new List<BsonDocument>();

            try
            { 
                for (int x = 0; x < loops; x++)
                {
                    docList.Add(new BsonDocument { { "seriesId", x }, { "contentId", contentId }, { "title", $"{x}{title}" } });

                    Console.WriteLine("Documents inserted");
                }
                collection.InsertManyAsync(docList);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Created {loops} documents!");
        }

        public void readSeries(int contentId)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("Series");
                List<BsonDocument> list = collection.Find(new BsonDocument("contentId", contentId)).Limit(loops).ToList();

                list.ForEach(x =>
                   Console.WriteLine(x)
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("readSeries error: " + ex.Message);
            }

            Console.WriteLine($"Read {loops} documents!");
        }

        public void UpdateSeries()
        {
            var collection = database.GetCollection<BsonDocument>("Series");
            

            for (int x = 0; x < loops; x++)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("seriesId", x);
                var update = Builders<BsonDocument>.Update.Set("title", "newTitle");
                collection.UpdateOne(filter, update);
            }

            Console.WriteLine($"Updated {loops} documents!");
        }

        public void deleteSeries(int contentId)
        {
            var collection = database.GetCollection<BsonDocument>("Series");
            var filter = Builders<BsonDocument>.Filter.Eq("contentId", contentId);

            for (int x = 0;x < loops; x++){
                collection.DeleteOne(filter);
            }

            Console.WriteLine($"Deleted {loops} documents!");
        }
    }
}
