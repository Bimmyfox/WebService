using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTaskKolgatina.Models;
using System.Linq;


namespace TestTaskKolgatina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePassportJoinedModelsController
    {
        readonly DataBase _context;


        public EmployeePassportJoinedModelsController(DataBase context)
        {
            _context = context;
        }


        //GET: api/employeePassportJoinedModels
        [HttpGet]
        public ActionResult<IEnumerable<EmployeePassportJoinedModels>> Get()
        {
            var employees = _context.Employees;
            var passports = _context.Passports;
           
            var query =
                    from employee in employees
                    join passport in passports
                    on employee.IdPassport equals passport.Id

                    select new EmployeePassportJoinedModels
                    {
                        Name = employee.Name,
                        Surname = employee.Surname,
                        Phone = employee.Phone,
                        CompanyId = employee.CompanyId,
                        Type = passport.Type,
                        Number = passport.Number
                    };

            return query.ToList();
        }

        //POST: api/employeePassportJoinedModels
        [HttpPost]
        public ActionResult<int> Post(EmployeePassportJoinedModels employeePassport)
        {
            AddPassport(employeePassport);
            AddEmployee(employeePassport);

            return employeePassport.Id;
        }


        void AddEmployee(EmployeePassportJoinedModels employeePassport)
        {
            Employee employee = new Employee();

            employee.Name = employeePassport.Name;
            employee.Surname = employeePassport.Surname;
            employee.Phone = employeePassport.Phone;
            employee.CompanyId = employeePassport.CompanyId;

            employee.IdPassport = _context.Passports.Where(p =>
                           p.Type == employeePassport.Type &&
                           p.Number == employeePassport.Number).First().Id;

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }


        void AddPassport(EmployeePassportJoinedModels employeePassport)
        {
            Passport passport = new Passport();

            passport.Type = employeePassport.Type;
            passport.Number = employeePassport.Number;

            _context.Passports.Add(passport);
            _context.SaveChanges();
        }
    }
}
