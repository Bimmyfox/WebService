using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestTaskKolgatina.Models;
using TestTaskKolgatina.Data;

namespace TestTaskKolgatina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : Controller
    {
        readonly EmployeeContext context;


        public PassportController(EmployeeContext context)
        {
            this.context = context;
        }


        //GET: api/passport
        [HttpGet]
        public ActionResult<IEnumerable<Passport>> GetPassports()
        {
            var passports = context.Passports.ToList();

            if (passports.Count == 0) return NoContent(); ;

            return passports;
        }


        // GET: api/passport/4
        [HttpGet("{id}")]
        public ActionResult<Passport> GetPassport(int? id)
        {
            if (id == null) return NotFound();
            var passport = context.Passports.Find(id);

            if (passport == null) return NotFound();
            return passport;
        }


        // DELETE: api/passport/5
        [HttpDelete("{id}")]
        public IActionResult DeletePassport(int? id)
        {
            if (id == null) return NotFound();

            var passport = context.Passports.Find(id);
            if (passport == null) return NotFound();

            try
            {
                context.Passports.Remove(passport);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            return Ok();
        }


        // POST: api/passport
        [HttpPost]
        public ActionResult<int> PostPassport(Passport passport)
        {
            try
            {
                context.Passports.Add(passport);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            return passport.Id;
        }


        // PUT: api/passport/5
        [HttpPut("{id}")]
        public IActionResult PutPassport(int id, Passport passport)
        {
            if (passport == null) return NotFound();

            var entity = context.Passports.Find(id);

            if (entity == null) return NotFound();

            entity.Id = id;
            entity.Type = passport.Type ?? entity.Type;
            entity.Number = passport.Number ?? entity.Number;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            return Ok();
        }
    }
}