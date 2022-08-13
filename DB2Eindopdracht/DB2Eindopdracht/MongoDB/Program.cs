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

            new CRUD().Run();
        }
    }
}
