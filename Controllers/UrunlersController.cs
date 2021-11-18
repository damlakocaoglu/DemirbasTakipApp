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
    public class UrunlersController : ControllerBase
    {
        private readonly DemirbasTakipContext _context;

        public UrunlersController(DemirbasTakipContext context)
        {
            _context = context;
        }

        // GET: api/urunler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urunler>>> GetUrun()
        {
            System.Threading.Thread.Sleep(1000);

            return await _context.Urunler.ToListAsync();
        }

        // GET: api/urunler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Urunler>> GetUrun(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);

            if (urun == null)
            {
                return NotFound();
            }

            return urun;
        }

        // PUT: api/urunler/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrun(int id, Urunler urun)
        {
            if (id != urun.Id)
            {
                return BadRequest();
            }

            _context.Entry(urun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunExist(id))
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

        // POST: api/urunler

        [HttpPost]
        public async Task<ActionResult<Urunler>> PostUrun(Urunler urun)
        {
            _context.Urunler.Add(urun);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUrun", new { id = urun.Id }, urun);
        }

        // DELETE: api/urunler/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Urunler>> DeleteUrun(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }

            _context.Urunler.Remove(urun);
            await _context.SaveChangesAsync();

            return urun;
        }

        private bool UrunExist(int id)
        {
            return _context.Urunler.Any(e => e.Id == id);
        }
    }
}
