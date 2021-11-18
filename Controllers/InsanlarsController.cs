using DemirbasTakipApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemirbasTakipApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsanlarsController : ControllerBase
    {
        private readonly DemirbasTakipContext _context;

        public InsanlarsController(DemirbasTakipContext context)
        {
            _context = context;
        }

        // GET: api/insanlar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insanlar>>> GetInsan()
        {
            System.Threading.Thread.Sleep(1000);

            return await _context.Insanlar.ToListAsync();
        }

        // GET: api/insanlar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insanlar>> GetInsan(int id)
        {
            var insan = await _context.Insanlar.FindAsync(id);

            if (insan == null)
            {
                return NotFound();
            }

            return insan;
        }

        // PUT: api/insanlar/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsan(int id, Insanlar insan)
        {
            if (id != insan.Id)
            {
                return BadRequest();
            }

            _context.Entry(insan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsanExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/insanlar

        [HttpPost]
        public async Task<ActionResult<Insanlar>> PostInsan(Insanlar insan)
        {
            _context.Insanlar.Add(insan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsan", new { id = insan.Id }, insan);
        }

        // DELETE: api/insanlar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Insanlar>> DeleteInsan(int id)
        {
            var insan = await _context.Insanlar.FindAsync(id);
            if (insan == null)
            {
                return NotFound();
            }

            _context.Insanlar.Remove(insan);
            await _context.SaveChangesAsync();

            return insan;
        }

        private bool InsanExist(int id)
        {
            return _context.Insanlar.Any(e => e.Id == id);
        }
    }
}