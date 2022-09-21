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
    public class CTDDHController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CTDDHController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/CTDDH
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CTDDH>>> GetCTDDHs()
        {
          if (_context.CTDDHs == null)
          {
              return NotFound();
          }
            return await _context.CTDDHs.ToListAsync();
        }

        // GET: api/CTDDH/5
        [HttpGet("{MaDonHang}")]
        public async Task<ActionResult<CTDDH>> GetCTDDH(Guid MaDonHang)
        {
            var list = from ctddh in _context.CTDDHs
                       from sanPham in _context.SanPhams
                       where ctddh.MaDonHang == MaDonHang && sanPham.MaSanPham == ctddh.MaSanPham
                       select new { ctddh.SoLuong,ctddh.DonGia, sanPham, giamGia = (from ctkm in _context.CTKMs
                                                                                    from km in _context.KhuyenMais
                                                                                    where ctkm.MaSanPham == sanPham.MaSanPham &&
                                                                                          km.MaKM == ctkm.MaKM &&
                                                                                          km.NgayBatDau <= DateTime.Today &&
                                                                                          km.NgayKetThuc >= DateTime.Today
                                                                                    select ctkm.PhanTramGiam).ToList()
                       };
            if (list.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpGet("{MaDonHang}/{MaSanPham}")]
        public IActionResult GetChiTietDonHang(Guid MaDonHang, Guid MaSanPham)
        {
            var chiTietDonHang = _context.CTDDHs.SingleOrDefault(e => e.MaDonHang == MaDonHang && e.MaSanPham == MaSanPham);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(chiTietDonHang);
            }
        }

        // PUT: api/CTDDH/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{MaDonHang}/{MaSanPham}")]
        public async Task<IActionResult> PutCTDDH(Guid MaDonHang,Guid MaSanPham, CTDDH_Model model)
        {
            var ctddh = new CTDDH
            {
                
                SoLuong = model.SoLuong,
            };
            if (CTDDHExists(MaDonHang, MaSanPham))
            {
                _context.Update(ctddh);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/CTDDH
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{MaDonHang}/{MaSanPham}")]
        public async Task<ActionResult<CTDDH>> PostCTDDH(Guid MaDonHang, Guid MaSanPham, CTDDH_Model model)
        {
            var ctddh = new CTDDH
            {
                MaDonHang = MaDonHang,
                MaSanPham = MaSanPham,
                SoLuong = model.SoLuong,
                DonGia = model.DonGia,
            };
            var donHang = CheckMaDonHang(MaDonHang);
            var sanPham = CheckMaSanPham(MaSanPham);
            if (donHang == null || sanPham == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Add(ctddh);
                _context.SaveChanges();
                return Ok(ctddh);
            }
        }

        // DELETE: api/CTDDH/5
        [HttpDelete("{MaDonHang}")]
        public async Task<IActionResult> DeleteCTDDH(Guid MaDonHang)
        {
            var list = _context.CTDDHs.Where(e => e.MaDonHang == MaDonHang).ToList();
            if (list.Count > 0)
            {
                _context.RemoveRange(list);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool CTDDHExists(Guid maDonHang, Guid maSanPham)
        {
            var chiTietDonHang = _context.CTDDHs.SingleOrDefault(e => e.MaDonHang == maDonHang && e.MaSanPham == maSanPham);
            if (chiTietDonHang == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private SanPham CheckMaSanPham(Guid maSanPham)
        {
            return _context.SanPhams.Find(maSanPham);
        }

        private DonDatHang CheckMaDonHang(Guid maDonHang)
        {
            return _context.DonDatHangs.Find(maDonHang);
        }
    }
}
