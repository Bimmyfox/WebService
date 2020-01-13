using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTaskKolgatina.Models;
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

      
        //TODO: [HttpPut]
        //public static string AddEmployee()
        //{
        //    return "INSERT INTO employee (name, surname, Phone, CompanyId, Passport) VALUES ('Mike','Buganoff','5830948350', '3', '3593874')";
        //}

        //TODOpublic static string DeleteEmployee(int IdEmployee)
        //{
        //    return String.Format("DELETE from employee where Id = {0}", IdEmployee);
        //}

        //TODO:[]
        //public void EditEmployeeInfo(int IdEmployee)
        //{
        //}
    }
}
