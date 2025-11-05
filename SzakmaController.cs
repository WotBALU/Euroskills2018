using Euroskills2018.Data;
using Euroskills2018.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EuroskillsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SzakmaController : ControllerBase
    {
        private readonly EuroskillsContext _context;

        public SzakmaController(EuroskillsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Szakma>>> GetAll()
            => await _context.Szakmak.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Szakma>> Get(string id)
        {
            var s = await _context.Szakmak.FindAsync(id);
            return s == null ? NotFound() : s;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Szakma s)
        {
            _context.Szakmak.Add(s);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = s.Id }, s);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, Szakma s)
        {
            if (id != s.Id) return BadRequest();
            _context.Entry(s).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var s = await _context.Szakmak.FindAsync(id);
            if (s == null) return NotFound();
            _context.Szakmak.Remove(s);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

