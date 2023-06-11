using DB2Eindopdracht.EntityFramework.Entities;
using DB2Eindopdracht.MongoDB;
using MongoDB.Driver;
using System;

namespace DB2Eindopdracht
{
    public class Program
    {
        static string version = "Mongo";
        static int loops = 10;
        // Action: CRUD op volgorde. 0 = Create, 1 = Read etc.
        static int action = 3;


        public static void Main(String[] args)
        {
            if (version == "ADO")
            {
                ADO.NET.ADONET ado = new ADO.NET.ADONET();
                ado.Run(loops,action);
            } 
            else if(version == "EF")
            {
                new EFCrud(loops, action);                
            }
            if (version == "Mongo")
            {
                CRUD crud = new CRUD(loops,action);
                crud.Run();
            }
        }
    }
}
