using DB2Eindopdracht.EntityFramework.Entities;
using MongoDB.Driver;
using System;

namespace DB2Eindopdracht
{
    public class Program
    {
        static string version = "EF";

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
                using (var dbContext = new DatabaseContext())
                {
                    try
                    {
                        var contents = dbContext.Contents.ToList();
                        Console.WriteLine("EF has been created");


                        var newCustomer = new User
                        {
                            EmailAdress = "1@gmail.com",
                            Password = "1pw",
                            Active = true,
                            LoginAttempts = 1,
                            Blocked = true,
                            Date = "762023"
                        };

                        dbContext.Users.Add(newCustomer);
                        dbContext.SaveChanges();
                        Console.WriteLine("Data has been inserted");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errorororororr: " + ex.Message);
                    }
                }

                
                Console.ReadKey();
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
