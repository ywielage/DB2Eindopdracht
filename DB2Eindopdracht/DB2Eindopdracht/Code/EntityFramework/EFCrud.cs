using DB2Eindopdracht.Entities;
using DB2Eindopdracht.EntityFramework.Entities;
using System.Data.Entity;


namespace DB2Eindopdracht
{
    public class EFCrud 
    {

        int loop;
        public EFCrud(int loop, int action)
        {
            this.loop = loop;
            if(action == 0)
            {
                CreateData();
            }
            else if(action == 1)
            {
                ReadData();
            }
            else if (action == 2)
            {
                UpdateData();
            }
            else if (action == 3)
            {
                DeleteData();
            }

            Console.ReadKey();
        }

        public void CreateData()
        {
            using (var dbContext = new DatabaseContext())
            {
                try
                {
                    var contents = dbContext.Contents.ToList();

                    for (int x = 1; x < loop; x++)
                    {

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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ReadData()
        {
            using (var dbContext = new DatabaseContext())
            {
                try
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
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdateData()
        {
            using (var dbContext = new DatabaseContext())
            {
                try
                {
                    var users = dbContext.Users.Take(loop).ToList();

                    foreach (var user in users)
                    {
                        user.EmailAdress = "invalid" + new Random().Next(100) + "@gmail.com";
                    };

                    dbContext.SaveChanges();
                    Console.WriteLine("Users updated: " + users.Count());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteData()
        {
            using (var dbContext = new DatabaseContext())
            {
                try
                {
                    var usersToDelete = dbContext.Users.Where(u => u.Active == true).Take(loop).ToList();

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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
