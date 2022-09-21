using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuyenController : ControllerBase
    {
        private readonly MyDbContext _context;

        public QuyenController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Quyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quyen>>> GetQuyens()
        {
          if (_context.Quyens == null)
          {
              return NotFound();
          }
            return await _context.Quyens.ToListAsync();
        }

        // GET: api/Quyen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quyen>> GetQuyen(Guid id)
        {
          if (_context.Quyens == null)
          {
              return NotFound();
          }
            var quyen = await _context.Quyens.FindAsync(id);

            if (quyen == null)
            {
                return NotFound();
            }

            return quyen;
        }

        // PUT: api/Quyen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuyen(Guid id, Quyen quyen)
        {
            if (id != quyen.MaQuyen)
            {
                return BadRequest();
            }

            _context.Entry(quyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuyenExists(id))
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

        // POST: api/Quyen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quyen>> PostQuyen(Quyen_Model model)
        {
            try
            {
                Quyen quyen = new Quyen
                {
                    TenQuyen = model.TenQuyen,
                    list_NhanVien = new HashSet<NhanVien>()
                };
                _context.Add(quyen);
                _context.SaveChanges();
                return Ok(quyen);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Quyen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuyen(Guid id)
        {
            if (_context.Quyens == null)
            {
                return NotFound();
            }
            var quyen = await _context.Quyens.FindAsync(id);
            if (quyen == null)
            {
                return NotFound();
            }

            _context.Quyens.Remove(quyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuyenExists(Guid id)
        {
            return (_context.Quyens?.Any(e => e.MaQuyen == id)).GetValueOrDefault();
        }
    }
}
