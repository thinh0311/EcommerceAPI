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
    public class GioHangController : ControllerBase
    {
        private readonly MyDbContext _context;

        public GioHangController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/GioHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GioHang>>> GetGioHangs()
        {
          if (_context.GioHangs == null)
          {
              return NotFound();
          }
            return await _context.GioHangs.ToListAsync();
        }

        // GET: api/GioHang/5
        [HttpGet("{MaKH}")]
        public IActionResult GetGioHang(Guid MaKH)
        {
            var list = _context.GioHangs.Where(e => e.MaKH == MaKH).ToList();
            if (list.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpGet("{MaKH}/{MaSanPham}")]
        public IActionResult GetGioHang(Guid MaKH, Guid MaSanPham)
        {
            var gioHang = _context.GioHangs.SingleOrDefault(e => e.MaKH == MaKH && e.MaSanPham == MaSanPham);
            if (gioHang == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(gioHang);
            }
        }
        // PUT: api/GioHang/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{MaKH}/{MaSanPham}")]
        public IActionResult PutGioHang(Guid MaKH, Guid MaSanPham, GioHang_Model model)
        {
            var gioHang = new GioHang
            {
                MaKH = MaKH,
                MaSanPham = MaSanPham,
                SoLuong = model.SoLuong
            };
            if (!GioHangExists(MaKH, MaSanPham))
            {
                return NotFound();
            }
            else
            {
                _context.Update(gioHang);
                _context.SaveChanges();
                return NoContent();
            }
        }

        // POST: api/GioHang
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{MaKH}/{MaSanPham}")]
        public IActionResult PostGioHang(Guid MaKH, Guid MaSanPham, GioHang_Model model)
        {
            if (CheckMaTaiKhoan(MaKH) && CheckMaSanPham(MaSanPham))
            {
                var gioHang = new GioHang
                {
                    MaKH = MaKH,
                    MaSanPham = MaSanPham,
                    SoLuong = model.SoLuong
                };
                _context.Add(gioHang);
                _context.SaveChanges();
                return Ok(gioHang);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/GioHang/5
        [HttpDelete("{MaKH}")]
        public IActionResult DeleteGioHang(Guid MaKH)
        {
            var list = _context.GioHangs.Where(e => e.MaKH == MaKH).ToList();
            if (list.Count == 0)
            {
                return NotFound();
            }
            else
            {
                _context.RemoveRange(list);
                _context.SaveChanges();
                return NoContent();
            }
        }

        [HttpDelete("{MaKH}/{MaSanPham}")]
        public IActionResult DeleteGioHang(Guid MaKH, Guid MaSanPham)
        {
            var gioHang = _context.GioHangs.SingleOrDefault(e => e.MaKH == MaKH && e.MaSanPham == MaSanPham);
            if (gioHang == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(gioHang);
                _context.SaveChanges();
                return NoContent();
            }
        }
        private bool GioHangExists(Guid MaKH, Guid MaSanPham)
        {
            return (_context.GioHangs.Any(e => e.MaKH == MaKH && e.MaSanPham == MaSanPham));
        }
        private bool CheckMaTaiKhoan(Guid MaKH)
        {
            return _context.KhachHangs.Any(e => e.MaKH == MaKH);
        }

        private bool CheckMaSanPham(Guid MaSanPham)
        {
            return _context.SanPhams.Any(e => e.MaSanPham == MaSanPham);
        }
    }
}
