using MongoDB.Driver;
using System;

namespace DB2Eindopdracht.MongoDB
{
    public class Program
    {
        CRUD Crud = new CRUD();
         public static void Main(String[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://testAcc:testAcc@cluster0.ywwyyyo.mongodb.net/?retryWrites=true&w=majority");

            // Create
            /*new CRUD().createSeries(1,2,"titleee");*/

            // Read
            new CRUD().readSeries();

            // Update
            //new CRUD().updateSeries();

            //Delete
            //new CRUD().deleteSeries();


            /*var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }*/
        }
    }
}
