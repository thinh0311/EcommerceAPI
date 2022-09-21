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
    public class BinhLuanController : ControllerBase
    {
        private readonly MyDbContext _context;

        public BinhLuanController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BinhLuan>>> GetBinhLuan()
        {
            if (_context.BinhLuans == null)
            {
                return NotFound();
            }
            return await _context.BinhLuans.ToListAsync();
        }

        [HttpGet("GetBinhLuanByKhachHang/{MaKH}")]
        public IActionResult GetBinhLuanByKhachHang(Guid MaKH)
        {
            return Ok(_context.BinhLuans.Where(e => e.MaKH == MaKH).ToList());

        }
        
        [HttpGet("GetBinhLuanBySanPham/{MaSanPham}")]
        public IActionResult GetBinhLuanBySanPham(Guid MaSanPham)
        {
            var list = from BinhLuan in _context.BinhLuans
                       where BinhLuan.MaSanPham == MaSanPham
                       select (new
                       {
                           BinhLuan,
                           KhachHang = (from kh in _context.KhachHangs where kh.MaKH == BinhLuan.MaKH select new { kh.HoTen, kh.AnhDaiDien }).ToList(),

                       });
            return Ok(list);

        }

        [HttpGet("GetBinhLuan/{MaBinhLuan}")]
        public IActionResult GetBinhLuan(Guid MaBinhLuan)
        {
            return Ok(_context.BinhLuans.Where(e => e.MaBinhLuan == MaBinhLuan).ToList());

        }

        [HttpGet("GetBinhLuanBySanPham/{MaKH}/{MaSanPham}")]
        public IActionResult GetBinhLuanByKhachHang(Guid MaKH, Guid MaSanPham)
        {
            return Ok(_context.BinhLuans.Where(e => e.MaKH == MaKH && e.MaSanPham == MaSanPham).ToList());
        }

        [HttpPut("{MaBinhLuan}")]
        public async Task<IActionResult> PutBinhLuan(Guid MaBinhLuan, BinhLuan_Model model)
        {
            var cmt = _context.BinhLuans.Find(MaBinhLuan);
            cmt.NoiDung = model.NoiDung;
            cmt.NgayBinhLuan = DateTime.Now;
            if (!BinhLuanExists(MaBinhLuan))
            {
                return NotFound();
            }
            else
            {
                _context.Update(cmt);
                _context.SaveChanges();
                return NoContent();
            }
        }

        private bool BinhLuanExists(Guid MaBinhLuan)
        {
            return (_context.BinhLuans.Any(e => e.MaBinhLuan == MaBinhLuan));
        }

        [HttpPost]
        public IActionResult PostBinhLuan(BinhLuan_Model model)
        {
            DateTime today = new DateTime();
            today = DateTime.Now;
            var cmt = new BinhLuan
            {
                MaKH = model.MaKH,
                MaSanPham = model.MaSanPham,
                NoiDung = model.NoiDung,
                NgayBinhLuan = today,
                SanPham_owner = null,
                KhachHang_owner = null,
            };
            var taiKhoan = CheckMaKH(model.MaKH);
            var sanpham = CheckMaSanPham(model.MaSanPham);
            if (taiKhoan == null || sanpham == null)
            {
                return BadRequest();
            }
            else
            {
                cmt.KhachHang_owner = taiKhoan;
                cmt.SanPham_owner = sanpham;
                _context.Add(cmt);             
                _context.Add(cmt);             
                _context.SaveChanges();
                return Ok(cmt);
            }
        }
        private KhachHang CheckMaKH(Guid MaKH)
        {
            return _context.KhachHangs.Find(MaKH);
        }

        private SanPham CheckMaSanPham(Guid MaSanPham)
        {
            return _context.SanPhams.Find(MaSanPham);
        }

        [HttpDelete("{MaBinhLuan}")]
        public async Task<IActionResult> DeleteDonDatHang(Guid MaBinhLuan)
        {
            if (_context.BinhLuans == null)
            {
                return NotFound();
            }
            var cmt = await _context.BinhLuans.FindAsync(MaBinhLuan);
            if (cmt == null)
            {
                return NotFound();
            }

            _context.BinhLuans.Remove(cmt);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
