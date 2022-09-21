using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamYeuThichController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SanPhamYeuThichController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/SanPhamYeuThich
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamYeuThich>>> GetSanPhamYeuThichs()
        {
          if (_context.SanPhamYeuThichs == null)
          {
              return NotFound();
          }
            return await _context.SanPhamYeuThichs.ToListAsync();
        }

        // GET: api/SanPhamYeuThich/5
        [HttpGet("{MaKH}")]
        public IActionResult GetSanPhamYeuThich(Guid MaKH)
        {
            var list = _context.SanPhamYeuThichs.Where(e => e.MaKH == MaKH).ToList();
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
        public IActionResult GetSanPhamYeuThich(Guid MaKH, Guid MaSanPham)
        {
            var sanPhamYeuThich = _context.SanPhamYeuThichs.Where(e => e.MaKH == MaKH && e.MaSanPham == MaSanPham);
            if (sanPhamYeuThich == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(sanPhamYeuThich);
            }
        }

        [HttpPost("{MaKH}/{MaSanPham}")]
        public IActionResult PostSanPhamYeuThich(Guid MaKH, Guid MaSanPham)
        {
            var sanPhamYeuThich = new SanPhamYeuThich
            {
                MaKH = MaKH,
                MaSanPham = MaSanPham
            };
            var taiKhoan = CheckMaTaiKhoan(MaKH);
            var sanPham = CheckMaSanPham(MaSanPham);
            if (taiKhoan == null || sanPham == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Add(sanPhamYeuThich);
                _context.SaveChanges();
                return Ok(sanPhamYeuThich);
            }
        }

        [HttpDelete("{MaKH}")]
        public IActionResult DeleteSanPhamYeuThich(Guid MaKH)
        {
            var list = _context.SanPhamYeuThichs.Where(e => e.MaKH == MaKH).ToList();
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
        public IActionResult DeleteSanPhamYeuThich(Guid MaKH, Guid MaSanPham)
        {
            var sanPhamYeuThich = _context.SanPhamYeuThichs.SingleOrDefault(e => e.MaKH == MaKH && e.MaSanPham == MaSanPham);
            if (sanPhamYeuThich == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(sanPhamYeuThich);
                _context.SaveChanges();
                return NoContent();
            }
        }

        private KhachHang CheckMaTaiKhoan(Guid maTaiKhoan)
        {
            return _context.KhachHangs.Find(maTaiKhoan);
        }

        private SanPham CheckMaSanPham(Guid maSanPham)
        {
            return _context.SanPhams.Find(maSanPham);
        }
    }
}
