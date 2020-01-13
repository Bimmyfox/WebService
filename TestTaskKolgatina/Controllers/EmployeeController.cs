using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using TestTaskKolgatina.Models;
using TestTaskKolgatina.Controllers;
using Microsoft.EntityFrameworkCore;

/*
1. Добавлять сотрудников, в ответ должен приходить Id добавленного сотрудника.
2. Удалять сотрудников по Id.
3. Выводить список сотрудников для указанной компании. Все доступные поля.
4. Изменять сотрудника по его Id. Изменения должно быть только тех полей, которые указаны в запросе.
     */


namespace TestTaskKolgatina.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController
    {
        readonly DataBase _context;

        public EmployeeController(DataBase context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var todoItem = await _context.Employees.FindAsync(id);

            if (todoItem == null)
            {
                return null;
            }

            return todoItem;
        }

        //// GET api/asd/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return id.ToString();
        //}

        //// Returns JSON string
        //[HttpGet]
        //string Get(string url)
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    try
        //    {
        //        WebResponse response = request.GetResponse();
        //        using (Stream responseStream = response.GetResponseStream())
        //        {
        //            StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
        //            return reader.ReadToEnd();
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        WebResponse errorResponse = ex.Response;
        //        using (Stream responseStream = errorResponse.GetResponseStream())
        //        {
        //            StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
        //            String errorText = reader.ReadToEnd();
        //            // log errorText
        //        }
        //        throw;
        //    }
        //}

        //[HttpPut]
        //public static string AddEmployee()
        //{
        //    return "INSERT INTO employee (name, surname, Phone, CompanyId, Passport) VALUES ('Mike','Buganoff','5830948350', '3', '3593874')";

        //    //return Id;
        //}

        //public static string DeleteEmployee(int IdEmployee)
        //{
        //    return String.Format("DELETE from employee where Id = {0}", IdEmployee);

        //}

        //public static MySqlDataAdapter CreateCustomerAdapter(MySqlConnection conn)
        //{
        //    MySqlDataAdapter da = new MySqlDataAdapter();
        //    MySqlCommand cmd;
        //    MySqlParameter parm;

        //    // Create the SelectCommand.
        //    cmd = new MySqlCommand("SELECT * FROM employee WHERE id=@id AND name=@name", conn);

        //    cmd.Parameters.Add("@id", MySqlDbType.VarChar, 8);
        //    //cmd.Parameters.Add("@name", MySqlDbType.VarChar, 8);

        //    da.SelectCommand = cmd;

        //    // Create the DeleteCommand.
        //    cmd = new MySqlCommand("DELETE FROM employee WHERE id=@id", conn);

        //    parm = cmd.Parameters.Add("@id", MySqlDbType.VarChar, 5, "id");
        //    parm.SourceVersion = DataRowVersion.Original;

        //    da.DeleteCommand = cmd;

        //    return da;
        //}

        //[HttpGet]
        //public string PrintAListOfEmployees()
        //{
        //    return "SELECT * from employee";
        //}

        //public void EditEmployeeInfo(int IdEmployee)
        //{
        //}
    }
}
