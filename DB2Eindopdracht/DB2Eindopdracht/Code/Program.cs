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
                        String crud = "U";
                        int loop = 100;

                        if (crud == "C")
                        {
                            var contents = dbContext.Contents.ToList();

                            for(int x = 1; x < loop; x++) { 
                            
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
                            }
                            dbContext.SaveChanges();
                            Console.WriteLine("Data has been inserted");
                        }
                        else if (crud == "R")
                        {
                            Console.WriteLine("Reading:");
                            var users = dbContext.Users.Take(loop).ToList();

                            Console.WriteLine("Users read: " + users.Count());
                            foreach (var user in users)
                            {
                                int UserID = user.UserId;
                                String EmailAdress = user.EmailAdress;
                                String Password = user.Password;
                                bool Active = user.Active;
                                int LoginAttempts = user.LoginAttempts;
                                bool Blocked = user.Blocked;
                                String Date = user.Date;

                                Console.WriteLine("Gebruiker:");
                                Console.WriteLine($"UserID: {UserID}" +
                                $"  EmailAdress: {EmailAdress}" +
                                $"  Active: {Active}");
                            };
                        }
                        else if (crud == "U")
                        {
                            var users = dbContext.Users.Take(loop).ToList();

                            foreach (var user in users)
                            {
                                user.EmailAdress = "invalid@gmail.com";
                            };

                            dbContext.SaveChanges();
                            Console.WriteLine("Users updated: " + users.Count());
                        }
                        else if (crud == "D")
                        {
                            var usersToDelete = dbContext.Users.Where(u => u.Active == true).ToList();

                            if (usersToDelete.Count > 0)
                            {
                                
                                dbContext.Users.RemoveRange(usersToDelete);

                                
                                dbContext.SaveChanges();
                                Console.WriteLine($"{usersToDelete.Count} records have been deleted");
                            }
                            else
                            {
                                Console.WriteLine("No records found to delete");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Database failed: : " + ex.Message);
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
