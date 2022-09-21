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
    public class NhanVienController : ControllerBase
    {
        private readonly MyDbContext _context;

        public NhanVienController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/NhanViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> GetNhanViens()
        {
          if (_context.NhanViens == null)
          {
              return NotFound();
          }
            return await _context.NhanViens.ToListAsync();
        }

        // GET: api/NhanViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien>> GetNhanVien(Guid id)
        {
          if (_context.NhanViens == null)
          {
              return NotFound();
          }
            var nhanVien = await _context.NhanViens.FindAsync(id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            return nhanVien;
        }

        // PUT: api/NhanViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien(Guid id, NhanVien nhanVien)
        {
            if (id != nhanVien.MaNV)
            {
                return BadRequest();
            }

            _context.Entry(nhanVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(id))
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

        // POST: api/NhanViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhanVien>> PostNhanVien(NhanVien_Model model)
        {
            var nhanVien = new NhanVien
            {
                HoTen = model.HoTen,
                SDT = model.SDT,
                PassWord = model.PassWord,
                MaQuyen = model.MaQuyen,
                DiaChi = model.DiaChi,
                list_DonDatHang = new HashSet<DonDatHang>(),
                list_HoaDon = new HashSet<HoaDon>(),
                list_PhieuNhap = new HashSet<PhieuNhap>(),
                Quyen_owner = null,
            };
            var role = CheckMaQuyen(model.MaQuyen);
            if (role == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Add(nhanVien);
                _context.SaveChanges();
                return Ok(nhanVien);
            }
        }

        // DELETE: api/NhanViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(Guid id)
        {
            if (_context.NhanViens == null)
            {
                return NotFound();
            }
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhanVienExists(Guid id)
        {
            return (_context.NhanViens?.Any(e => e.MaNV == id)).GetValueOrDefault();
        }

        private Quyen CheckMaQuyen(Guid MaQuyen)
        {
            return _context.Quyens.Find(MaQuyen);
        }

        [HttpGet("GetNhanVienByLogin/{sdt}/{password}")]
        public IActionResult GetTaiKhoanByLogin(string sdt, string password)
        {
            var taiKhoan = _context.NhanViens.SingleOrDefault(e => e.SDT == sdt && e.PassWord == password);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            return Ok(taiKhoan);
        }

        [HttpGet("ThongKeKhachHang")]
        public IActionResult ThongKeKhachHang()
        {
            var list = from khachHang in _context.KhachHangs
                      
                       select ( khachHang.MaKH) ;
           
            return Ok(list.Count());
        }

        [HttpGet("ThongKeSanPham")]
        public IActionResult ThongKeSanPham()
        {
            var list = from ctddh in _context.CTDDHs
                       group ctddh by ctddh.MaSanPham into temp
                       select (new { SoLuong = temp.Key });
                       

            return Ok(list.Count());
        }

        [HttpGet("ThongKeDonHang")]
        public IActionResult ThongKeDonHang()
        {
            var list = from donHang in _context.DonDatHangs
                      
                       select ( donHang.MaDonHang) ;
           
            return Ok(list.Count());
        }

        [HttpGet("ThongKeThuNhap")]
        public IActionResult ThongKeThuNhap()
        {
            var list = from ctddh in _context.CTDDHs
                       select (ctddh.SoLuong*ctddh.DonGia);

            return Ok(list.Sum());
        }

        [HttpGet("ThongKeTopKhachHang")]
        public IActionResult ThongKeTopKhachHang()
        {
            var list = from khachHang in _context.KhachHangs
                       from donHang in _context.DonDatHangs
                       from ctddh in _context.CTDDHs
                       where khachHang.MaKH == donHang.MaKH &&
                             donHang.MaDonHang == ctddh.MaDonHang
                       group new { khachHang, ctddh } by new { khachHang.MaKH, khachHang.HoTen, khachHang.DiaChi, khachHang.Email } into temp
                       orderby temp.Sum(x => (x.ctddh.SoLuong * x.ctddh.DonGia)) descending
                       select (new
                       {
                           TenKhachHang = temp.Key.HoTen,
                           DiaChi = temp.Key.DiaChi,
                           Email = temp.Key.Email,
                           SoTien = temp.Sum(x => (x.ctddh.SoLuong * x.ctddh.DonGia)),

                       });

            return Ok(list.Take(5));
        }


        [HttpGet("ThongKeTopDonHang")]
        public IActionResult ThongKeTopDonHang()
        {
            var list = from khachHang in _context.KhachHangs
                       from donHang in _context.DonDatHangs
                       from ctddh in _context.CTDDHs
                       where donHang.MaKH == khachHang.MaKH &&
                             donHang.MaDonHang == ctddh.MaDonHang 
                       group new { donHang, ctddh } by new { donHang.MaDonHang, khachHang.HoTen,donHang.NgayLap, donHang.TrangThai } into temp
                       orderby temp.Sum(x => (x.ctddh.SoLuong * x.ctddh.DonGia)) descending
                       select (new
                       {
                           MaDonHang = temp.Key.MaDonHang,
                           KhachHang = temp.Key.HoTen,
                           NgayLap = temp.Key.NgayLap,
                           TrangThai = temp.Key.TrangThai,
                           SoTien = temp.Sum(x => (x.ctddh.SoLuong * x.ctddh.DonGia)),
                       });

            return Ok(list.Take(5));
        }


    }
}
