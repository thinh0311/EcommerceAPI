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
    public class LoaiNuocController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaiNuocController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/LoaiNuoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiNuoc>>> GetLoaiNuocs()
        {
          if (_context.LoaiNuocs == null)
          {
              return NotFound();
          }
            return await _context.LoaiNuocs.ToListAsync();
        }

        // GET: api/LoaiNuoc/5
        [HttpGet("{MaLoaiNuoc}")]
        public async Task<ActionResult<LoaiNuoc>> GetLoaiNuoc(Guid MaLoaiNuoc)
        {
          if (_context.LoaiNuocs == null)
          {
              return NotFound();
          }
            var loaiNuoc = await _context.LoaiNuocs.FindAsync(MaLoaiNuoc);

            if (loaiNuoc == null)
            {
                return NotFound();
            }

            return loaiNuoc;
        }

        // PUT: api/LoaiNuoc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{MaLoaiNuoc}")]
        public async Task<IActionResult> PutLoaiNuoc(Guid MaLoaiNuoc, LoaiNuoc_Model model)
        {
            try
            {
                var LoaiNuoc = _context.LoaiNuocs.SingleOrDefault(e => e.MaLoaiNuoc == MaLoaiNuoc);
                if (LoaiNuoc == null)
                {
                    return NotFound();
                }
                LoaiNuoc.TenLoaiNuoc = model.TenLoaiNuoc;
                LoaiNuoc.HinhAnh = model.HinhAnh;
                LoaiNuoc.MoTa = model.MoTa;
                _context.LoaiNuocs.Update(LoaiNuoc);
                _context.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/LoaiNuoc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoaiNuoc>> PostLoaiNuoc(LoaiNuoc_Model model)
        {
            try
            {
                LoaiNuoc danhMuc = new LoaiNuoc
                {
                    TenLoaiNuoc = model.TenLoaiNuoc,
                    MoTa = model.MoTa,
                    HinhAnh = model.HinhAnh,
                    list_SanPham = new HashSet<SanPham>()
                };
                _context.Add(danhMuc);
                _context.SaveChanges();
                return Ok(danhMuc);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/LoaiNuoc/5
        [HttpDelete("{MaLoaiNuoc}")]
        public IActionResult DeleteLoaiNuoc(Guid MaLoaiNuoc)
        {
            var danhMuc = _context.LoaiNuocs.SingleOrDefault(e => e.MaLoaiNuoc == MaLoaiNuoc);
            if (danhMuc == null)
            {
                return NotFound();
            }
            _context.Remove(danhMuc);
            _context.SaveChanges();
            return NoContent();
        }

        private bool LoaiNuocExists(Guid id)
        {
            return (_context.LoaiNuocs?.Any(e => e.MaLoaiNuoc == id)).GetValueOrDefault();
        }
    }
}
