using Euroskills2018.Data;
using Euroskills2018.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EuroskillsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrszagController : ControllerBase
    {
        private readonly EuroskillsContext _context;

        public OrszagController(EuroskillsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orszag>>> GetAll()
            => await _context.Orszagok.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Orszag>> Get(string id)
        {
            var orszag = await _context.Orszagok.FindAsync(id);
            return orszag == null ? NotFound() : orszag;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Orszag o)
        {
            _context.Orszagok.Add(o);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = o.Id }, o);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, Orszag o)
        {
            if (id != o.Id) return BadRequest();
            _context.Entry(o).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var o = await _context.Orszagok.FindAsync(id);
            if (o == null) return NotFound();
            _context.Orszagok.Remove(o);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}