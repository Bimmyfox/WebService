using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTaskKolgatina.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestTaskKolgatina.Data;

/*
1. Добавлять сотрудников, в ответ должен приходить Id добавленного сотрудника. +
2. Удалять сотрудников по Id. +
4. Изменять сотрудника по его Id. Изменения должно быть только тех полей, которые указаны в запросе. +
 */

namespace TestTaskKolgatina.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController
    {
        readonly EmployeeContext _context;


        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }


        // GET: api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return _context.Employees.Include(s => s.Passport).ToList();
        }


        // GET: api/employees/6
        [HttpGet("{companyId}")]
        public IQueryable<Employee> GetEmployeeByComanyId(int companyId)
        {
            var employee = _context.Employees.Where(emp => emp.CompanyId == companyId).Include(s => s.Passport);

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
            var employee = _context.Employees.Find(id);

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
        public ActionResult<Employee> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return null;
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

            return employee;
        }

    }
}
