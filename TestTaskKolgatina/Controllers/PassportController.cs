using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTaskKolgatina.Models;
using Microsoft.EntityFrameworkCore;


namespace TestTaskKolgatina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController
    {
        readonly DataBase _context;

        public PassportController(DataBase context)
        {
            _context = context;
        }

        //GET: api/passport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passport>>> GetPassport()
        {
            return await _context.Passports.ToListAsync();
        }

        // GET: api/passport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passport>> GetPassport(int id)
        {
            var passport = await _context.Passports.FindAsync(id);

            if (passport == null)
            {
                return null;
            }

            return passport;
        }

        // DELETE: api/passport/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Passport>> DeletePassport(int id)
        {
            var passport = await _context.Passports.FindAsync(id);
            if (passport == null)
            {
                return null;
            }

            _context.Passports.Remove(passport);
            await _context.SaveChangesAsync();

            return passport;
        }


        // POST: api/passport
        [HttpPost]
        public async Task<ActionResult<int>> PostPassport(Passport passport)
        {
            _context.Passports.Add(passport);
            await _context.SaveChangesAsync();

            return passport.Id;
        }

        // PUT: api/passport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassport(int id, Passport passport)
        {
            if (id != passport.Id)
            {
                return null;
                //BadRequest();
            }

            _context.Entry(passport).State = EntityState.Modified;

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
