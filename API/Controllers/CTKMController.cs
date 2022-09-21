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
    public class CTKMController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CTKMController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/CTKM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CTKM>>> GetCTKMs()
        {
          if (_context.CTKMs == null)
          {
              return NotFound();
          }
            return await _context.CTKMs.ToListAsync();
        }

        // GET: api/CTKM/5
        [HttpGet("{MaKM}")]
        public async Task<ActionResult<CTKM>> GetCTKM(Guid MaKM)
        {
            var list = from ctkm in _context.CTKMs
                       from sanPham in _context.SanPhams
                       where ctkm.MaKM == MaKM
                       select new { ctkm.PhanTramGiam, sanPham };
            if (list.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpGet("{MaKM}/{MaSanPham}")]
        public IActionResult GetChiTietDonHang(Guid MaKM, Guid MaSanPham)
        {
            var ctmk = _context.CTKMs.SingleOrDefault(e => e.MaKM == MaKM && e.MaSanPham == MaSanPham);
            if (ctmk == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ctmk);
            }
        }


        // PUT: api/CTKM/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{MaKM}/{MaSanPham}")]
        public IActionResult PutChiTietDonHang(Guid MaKM, Guid MaSanPham, CTKM_Model model)
        {
            var ctkm = new CTKM
            {
                PhanTramGiam = model.PhanTramGiam
            };
            if (CTKMExists(MaKM, MaSanPham))
            {
                _context.Update(ctkm);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest("Sai thong tin");
            }
        }

        // POST: api/CTKM
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{MaKM}/{MaSanPham}")]
        public async Task<ActionResult<CTKM>> PostCTKM(Guid MaKM, Guid MaSanPham, CTKM_Model model)
        {
            var ctkm = new CTKM
            {
                MaKM = MaKM,
                MaSanPham=MaSanPham,
                PhanTramGiam = model.PhanTramGiam
            };
            var km = CheckMaKM(MaKM);
            var sanPham = CheckMaSanPham(MaSanPham);
            if (km == null || sanPham == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Add(ctkm);
                _context.SaveChanges();
                return Ok(ctkm);
            }
        }

        // DELETE: api/CTKM/5
        [HttpDelete("{MaKM}")]
        public IActionResult DeleteChiTietDonHang(Guid MaKM)
        {
            var list = _context.CTKMs.Where(e => e.MaKM == MaKM).ToList();
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

        [HttpDelete("{MaKM}/{MaSanPham}")]
        public IActionResult DeleteChiTietDonHang(Guid MaKM, Guid MaSanPham)
        {
            var chiTietDonHang = _context.CTKMs.SingleOrDefault(e => e.MaKM == MaKM && e.MaSanPham == MaSanPham);
            if (chiTietDonHang != null)
            {
                _context.Remove(chiTietDonHang);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        private bool CTKMExists(Guid MaKM, Guid MaSanPham)
        {
            var ctkm = _context.CTKMs.SingleOrDefault(e => e.MaKM == MaKM && e.MaSanPham == MaSanPham);
            if (ctkm == null)
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

        private KhuyenMai CheckMaKM(Guid MaKM)
        {
            return _context.KhuyenMais.Find(MaKM);
        }
    }
}
