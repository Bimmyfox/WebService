using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

namespace TestTaskKolgatina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConnectToDatabase();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //MySqlConnection
        static void ConnectToDatabase()
        {
            string connstr = string.Format("Server=localhost; database={0}; UID=root; password=root", "Employee");
            try
            {
                var conn = new MySqlConnection();
                conn.ConnectionString = connstr;
                conn.Open();

                string sql = "describe Employee.employee;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr.GetString(0));
                }
                rdr.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

  
    }
}
