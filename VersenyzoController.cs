using Euroskills2018.Data;
using Euroskills2018.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EuroskillsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersenyzoController : ControllerBase
    {
        private readonly EuroskillsContext _context;

        public VersenyzoController(EuroskillsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Versenyzo>>> GetAll()
            => await _context.Versenyzok
                .Include(v => v.Szakma)
                .Include(v => v.Orszag)
                .ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Versenyzo>> Get(int id)
        {
            var v = await _context.Versenyzok
                .Include(v => v.Szakma)
                .Include(v => v.Orszag)
                .FirstOrDefaultAsync(x => x.Id == id);
            return v == null ? NotFound() : v;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Versenyzo v)
        {
            _context.Versenyzok.Add(v);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = v.Id }, v);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Versenyzo v)
        {
            if (id != v.Id) return BadRequest();
            _context.Entry(v).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var v = await _context.Versenyzok.FindAsync(id);
            if (v == null) return NotFound();
            _context.Versenyzok.Remove(v);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
