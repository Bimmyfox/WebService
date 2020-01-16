using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTaskKolgatina.Data;
using TestTaskKolgatina.Models;

namespace TestTaskKolgatina.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        readonly EmployeeContext context;


        public EmployeeController(EmployeeContext context)
        {
            this.context = context;
        }


        // GET: api/employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = context.Employees
               .Include(s => s.Passport).ToList();

            if (employees.Count == 0) return NoContent();
            return employees;
        }


        // GET: api/employee/6
        [HttpGet("{companyId}")]
        public ActionResult<IEnumerable<Employee>> GetEmployeeByComanyId(int? companyId)
        {
            if (companyId == null) return NotFound();

            var employees = context.Employees
                .Where(emp => emp.CompanyId == companyId)
                .Include(s => s.Passport)
                .ToList();

            if (employees.Count == 0) return NotFound();
            return employees;
        }


        // DELETE: api/employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null) return NotFound();

            var employee = context.Employees.Find(id);
            if (employee == null) return NotFound();

            try
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            return Ok();
        }


        // POST: api/employee
        [HttpPost]
        public ActionResult<int> PostEmployee(Employee employee)
        {
            try
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            return employee.Id;
        }


        // PUT: api/employees/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            if (employee == null) return NotFound();

            var entity = context.Employees.Find(id);

            if (entity == null) return NotFound();

            try
            {
                entity.Id = id;
                entity.Name = employee.Name ?? entity.Name;
                entity.Surname = employee.Surname ?? entity.Surname;
                entity.Phone = employee.Phone ?? entity.Phone;
                entity.CompanyId = employee.CompanyId != 0 ? employee.CompanyId : entity.CompanyId;
                entity.PassportId = employee.PassportId != 0 ? employee.PassportId : entity.PassportId;
                entity.Passport = employee.Passport != null && employee.Passport.Number != null && employee.Passport.Type != null
                    ? employee.Passport
                    : entity.Passport;

                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }

            return Ok();
        }
    }
}