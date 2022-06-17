using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace DB2Eindopdracht.ADO.NET
{
    public class ADONET
    {
        Stopwatch stopwatch;
        public ADONET()
        {
            stopwatch = new Stopwatch();
        }

        // Uncomment to use
/*        public static void Main(String[] args)
        {
            new ADONET().Run(100);
        }*/

        // Replace <Method>() with any CRUD method
        public async void Run(int loop)
        {
            stopwatch.Start();
            for (int i = 1; i < loop; i++)
            {
                await DeleteCustomer("mail" + i + "@gmail.com");
            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        public async Task<int> CreateCustomer(string emailAdress)
        {
            using (SqlConnection conn = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;Initial catalog=NetflixDB;"))
            {
                SqlCommand cmd = new SqlCommand("Insert into Customer (emailAdress, password, active, loginAttempts, blocked, createdDate) values ('" + emailAdress + "', 'password', 'TRUE', 12, 'FALSE', '2008-06-12')", conn);
                conn.Open();
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }

        public async Task<int> ReadCustomer(string emailAdress)
        {
            SqlConnection conn = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;Initial catalog=NetflixDB;User ID=;Password=");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE emailAdress = '" + emailAdress + "'", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["emailAdress"]));       
                }
            }
            return 0;
        }

        public async Task<int> DeleteCustomer(string emailAdress)
        {
            using (SqlConnection conn = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;Initial catalog=NetflixDB;"))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE emailAdress='" + emailAdress + "'", conn);
                conn.Open();
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }

        }


        public async Task<int> UpdateCustomer()
        {
            using (SqlConnection conn = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;Initial catalog=NetflixDB;"))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Customer SET active = ' TRUE' WHERE active = 'FALSE'", conn);
                conn.Open();
                var result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }

        }

    }
}
