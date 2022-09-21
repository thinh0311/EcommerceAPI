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
    public class KhuyenMaiController : ControllerBase
    {
        private readonly MyDbContext _context;

        public KhuyenMaiController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/KhuyenMai
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhuyenMai>>> GetKhuyenMais()
        {
          if (_context.KhuyenMais == null)
          {
              return NotFound();
          }
            return await _context.KhuyenMais.Where(e=>e.NgayBatDau < DateTime.Now && e.NgayKetThuc > DateTime.Now).ToListAsync();
        }

        // GET: api/KhuyenMai/5
        [HttpGet("{MaKM}")]
        public IActionResult getPhieuGiamGia(Guid MaKM)
        {
            var khuyenMai = _context.KhuyenMais.SingleOrDefault(e => e.MaKM == MaKM);
            if (khuyenMai == null)
            {
                return NotFound();
            }
            return Ok(khuyenMai);
        }

        // PUT: api/KhuyenMai/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhuyenMai(Guid id, KhuyenMai khuyenMai)
        {
            if (id != khuyenMai.MaKM)
            {
                return BadRequest();
            }

            _context.Entry(khuyenMai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhuyenMaiExists(id))
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

        // POST: api/KhuyenMai
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KhuyenMai>> PostKhuyenMai(KhuyenMai_Model model)
        {
            
            if (model == null)
            {
                return BadRequest();
            }
			if(model.NgayBatDau > model.NgayKetThuc){
				return BadRequest();
			}
            var khuyenMai = new KhuyenMai
            {
                
                TenKM = model.TenKM,
                NgayBatDau = model.NgayBatDau,
                NgayKetThuc = model.NgayKetThuc,
                MoTa = model.MoTa,
               
            };
            _context.Add(khuyenMai);
            _context.SaveChanges();
            return Ok(khuyenMai);
        }

        // DELETE: api/KhuyenMai/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhuyenMai(Guid id)
        {
            if (_context.KhuyenMais == null)
            {
                return NotFound();
            }
            var khuyenMai = await _context.KhuyenMais.FindAsync(id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            _context.KhuyenMais.Remove(khuyenMai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhuyenMaiExists(Guid id)
        {
            return (_context.KhuyenMais?.Any(e => e.MaKM == id)).GetValueOrDefault();
        }
    }
}
