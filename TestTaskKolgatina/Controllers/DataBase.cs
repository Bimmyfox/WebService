using System;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using TestTaskKolgatina.Models;

namespace TestTaskKolgatina.Controllers
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }


        ////MySqlConnection
        //static void ConnectToDatabase()
        //{
        //    string connstr = string.Format("Server=localhost; database={0}; UID=root; password=root", "Employee");
        //    try
        //    {
        //        var conn = new MySqlConnection();
        //        conn.ConnectionString = connstr;
        //        conn.Open();

        //        string sql = "describe Employee.employee;";

        //        MySqlCommand cmd = new MySqlCommand(EmployeeController.DeleteEmployee(5), conn);

        //        MySqlDataReader rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            Console.WriteLine(rdr.GetString(0));
        //        }
        //        rdr.Close();

        //        conn.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}


        //public static void DisplayData(System.Data.DataTable table)
        //{
        //    foreach (System.Data.DataRow row in table.Rows)
        //    {
        //        foreach (System.Data.DataColumn col in table.Columns)
        //        {
        //            Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
        //        }
        //        Console.WriteLine("============================");
        //    }
        //}
    }
}
