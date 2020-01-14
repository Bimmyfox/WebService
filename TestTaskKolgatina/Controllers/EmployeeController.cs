using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTaskKolgatina.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return null;
            }
            
            return employee;
        }

        // DELETE: api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }


        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<int>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            
            return employee.Id;
        }

        // PUT: api/employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
         {
            if (id != employee.Id)
            {
                return null;
                //BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return null;
        }
    }
}
