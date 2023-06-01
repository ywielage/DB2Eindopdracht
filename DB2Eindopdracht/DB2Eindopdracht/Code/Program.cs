using MongoDB.Driver;
using System;

namespace DB2Eindopdracht
{
    public class Program
    {
        static string version = "ADO";

        public static void Main(String[] args)
        {

            if(version == "ADO")
            {
                ADO.NET.ADONET ado = new ADO.NET.ADONET();
                // Parameters:
                // Amount of loops, Version (Create, Read, Delete, Update)
                ado.Run(1,0);
            } 
            else if(version == "EF")
            {

            }
            if (version == "Mongo")
            {
                MongoClient dbClient = new MongoClient("mongodb+srv://testAcc:testAcc@cluster0.ywwyyyo.mongodb.net/?retryWrites=true&w=majority");
                MongoDB.CRUD crud = new MongoDB.CRUD();
                crud.Run();
            }
        }
    }
}
