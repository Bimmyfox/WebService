using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTaskKolgatina.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


/*
1. Добавлять сотрудников, в ответ должен приходить Id добавленного сотрудника. +
2. Удалять сотрудников по Id. +
3. Выводить список сотрудников для указанной компании. Все доступные поля. +
4. Изменять сотрудника по его Id. Изменения должно быть только тех полей, которые указаны в запросе. +
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
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return null;
            }

            return employee;

        }

        // DELETE: api/employee/5
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            //using (var context = CreateContext())
            {
            }
                var employee = _context.Employees.Find(id);
            //var employee =  _context.Employees

            if (employee == null)
            {
                return null;
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return employee;
        }


        // POST: api/employees
        [HttpPost]
        public ActionResult<int> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            
            return employee.Id;
        }

        // PUT: api/employees/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
         {
            if (id != employee.Id)
            {
                return null;
                //BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return null;
        }
    }
}
