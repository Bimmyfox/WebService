using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTaskKolgatina.Models;
using TestTaskKolgatina.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestTaskKolgatina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController
    {
        readonly EmployeeContext _context;


        public PassportController(EmployeeContext context)
        {
            _context = context;
        }


        //GET: api/passport
        [HttpGet]
        public ActionResult<IEnumerable<Passport>> GetPassport()
        {
            return _context.Passports.ToList();
        }


        // GET: api/passport/5
        [HttpGet("{id}")]
        public ActionResult<Passport> GetPassport(int id)
        {
            var passport =  _context.Passports.Find(id);

            if (passport == null)
            {
                return null;
            }

            return passport;
        }


        // DELETE: api/passport/5
        [HttpDelete("{id}")]
        public ActionResult<Passport> DeletePassport(int id)
        {
            var passport = _context.Passports.Find(id);
            if (passport == null)
            {
                return null;
            }

            _context.Passports.Remove(passport);
            _context.SaveChanges();

            return passport;
        }


        // POST: api/passport
        [HttpPost]
        public ActionResult<int> PostPassport(Passport passport)
        {
            _context.Passports.Add(passport);
            _context.SaveChanges();

            return passport.Id;
        }

        // PUT: api/passport/5
        [HttpPut("{id}")]
        public IActionResult PutPassport(int id, Passport passport)
        {
            if (id != passport.Id)
            {
                return null;
                //BadRequest();
            }

            _context.Entry(passport).State = EntityState.Modified;

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
