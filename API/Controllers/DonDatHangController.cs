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
    public class DonDatHangController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DonDatHangController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/DonDatHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonDatHang>>> GetDonDatHangs()
        {
          if (_context.DonDatHangs == null)
          {
              return NotFound();
          }
            return await _context.DonDatHangs.ToListAsync();
        }

        // GET: api/DonDatHang/5
        [HttpGet("{MaDonHang}")]
        public async Task<ActionResult<DonDatHang>> GetDonDatHang(Guid MaDonHang)
        {
            var donDatHang = await _context.DonDatHangs.FindAsync(MaDonHang);
            if (_context.DonDatHangs == null)
            {
              return NotFound();
            }
            

            if (donDatHang == null)
            {
                return NotFound();
            }

            return donDatHang;
        }

        [HttpGet("GetDonHangByKhachHang/{MaKH}")]
        public IActionResult GetDonHangByMaTaiKhoan(Guid MaKH)
        {
            return Ok(_context.DonDatHangs.Where(e => e.MaKH == MaKH).ToList());
        }

        [HttpGet("GetDonHangByTrangThai/{status}")]
        public IActionResult GetDonHangByTrangThai(int status)
        {
            var list = from DonHang in _context.DonDatHangs
                       where DonHang.TrangThai == (TrangThaiDonHang) status
                       select (new
                       {
                           DonHang,
                           NhanVien = (from nv in _context.NhanViens where nv.MaNV == DonHang.MaNV select nv.HoTen).ToList(),
                           KhachHang = (from kh in _context.KhachHangs where kh.MaKH == DonHang.MaKH select kh.HoTen).ToList(),
                           Shipper = (from shipper in _context.Shippers where shipper.MaShipper == DonHang.MaShipper select shipper.HoTen).ToList(),
                       });
            return Ok(list);
        }

        [HttpGet("GetAllDonHang")]
        public async Task<ActionResult<SanPham>> GetAllDonHang()
        {
            var list = from DonHang in _context.DonDatHangs
                       select (new
                       {
                           DonHang,
                           NhanVien = (from nv in _context.NhanViens where nv.MaNV == DonHang.MaNV select nv.HoTen).ToList(),
                           KhachHang = (from kh in _context.KhachHangs where kh.MaKH == DonHang.MaKH select kh.HoTen).ToList(),
                           Shipper = (from shipper in _context.Shippers where shipper.MaShipper == DonHang.MaShipper select shipper.HoTen).ToList(),
                       });
            return Ok(list);
        }

        // PUT: api/DonDatHang/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{MaDonHang}")]
        public async Task<IActionResult> PutDonDatHang(Guid MaDonHang, DonDatHang_Model model)
        {
            var ddh = new DonDatHang
            {
                MaNV = model.MaNV,
                MaShipper = model.MaShipper,
                
            };
            if (!DonDatHangExists(MaDonHang))
            {
                return NotFound();
            }
            else
            {
                _context.Update(ddh);
                _context.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut("DuyetDonHang/{MaDonHang}/{MaNV}")]
        public async Task<IActionResult> PutTrangThaiDatHang(Guid MaDonHang, Guid MaNV)
        {
            var ddh = _context.DonDatHangs.Find(MaDonHang);


            ddh.MaNV = MaNV;
            
            ddh.TrangThai = TrangThaiDonHang.DaDuyet;

            
            if (!DonDatHangExists(MaDonHang))
            {
                return NotFound();
            }
            else
            {
                _context.Update(ddh);
                _context.SaveChanges();
                return NoContent();
            }
        }
        
        [HttpPut("PhanCong/{MaDonHang}/{MaShipper}")]
        public async Task<IActionResult> PhanCong(Guid MaDonHang,  Guid MaShipper)
        {
            var ddh = _context.DonDatHangs.Find(MaDonHang);


            ddh.MaShipper = MaShipper;
            
            ddh.TrangThai = TrangThaiDonHang.DangGiao;

            
            if (!DonDatHangExists(MaDonHang))
            {
                return NotFound();
            }
            else
            {
                _context.Update(ddh);
                _context.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut("HoanThanh/{MaDonHang}")]
        public async Task<IActionResult> HoanThanh(Guid MaDonHang)
        {
            var ddh = _context.DonDatHangs.Find(MaDonHang);


           

            ddh.TrangThai = TrangThaiDonHang.HoanThanh;


            if (!DonDatHangExists(MaDonHang))
            {
                return NotFound();
            }
            else
            {
                _context.Update(ddh);
                _context.SaveChanges();
                return NoContent();
            }
        }

        // POST: api/DonDatHang
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostDonDatHang(DonDatHang_Model model)
        {
            DateTime today = new DateTime();
            today = DateTime.Now;
            var donHang = new DonDatHang
            {
                MaKH = model.MaKH,
                NguoiNhan = model.NguoiNhan,
                DiaChi = model.DiaChi,
                NgayLap = today,
                TrangThai = 0,
                list_CTDDH = new HashSet<CTDDH>(),
                HoaDon_owner =null,
            };
            var taiKhoan = CheckMaKH(model.MaKH);
            if (taiKhoan == null)
            {
                return BadRequest();
            }
            else
            {
                donHang.KhachHang_owner = taiKhoan;
                _context.Add(donHang);
                _context.SaveChanges();
                return Ok(donHang);
            }
        }

        [HttpPost("ChuyenGioHangThanhDonHang")]
        public IActionResult ChuyenGioHangThanhDonHang(DonDatHang_Model model)
        {
            if (CheckMaKH_bool(model.MaKH))
            {
                var list_gioHang = _context.GioHangs.Where(e => e.MaKH == model.MaKH).ToList();
                if (list_gioHang.Count > 0)
                {
                    DateTime today = new DateTime();
                    today = DateTime.Now;
                    var donHang = new DonDatHang
                    {
                        MaKH = model.MaKH,
                        NguoiNhan = model.NguoiNhan,
                        DiaChi = model.DiaChi,
                        NgayLap = today,
                        TrangThai = 0,
                        list_CTDDH = new HashSet<CTDDH>(),
                    };
                    try
                    {
                        donHang.list_CTDDH = GetDataFromOtherListGioHang(donHang.MaDonHang, list_gioHang);
                        _context.Add(donHang);
                        _context.RemoveRange(list_gioHang);
                        _context.SaveChanges();
                        return NoContent();
                    }
                    catch
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        private List<CTDDH> GetDataFromOtherListGioHang(Guid maDonHang, List<GioHang> list_gioHang)
        {
            List<CTDDH> list_chiTietDonHang = new List<CTDDH>();
            foreach (GioHang gioHang in list_gioHang)
            {
                CTDDH chiTietDonHang = new CTDDH
                {
                    MaDonHang = maDonHang,
                    MaSanPham = gioHang.MaSanPham,
                    SoLuong = gioHang.SoLuong,
                    DonGia = GetDonGiaByMaSanPham(gioHang.MaSanPham)
                };
                list_chiTietDonHang.Add(chiTietDonHang);
            }
            return list_chiTietDonHang;
        }

        private double GetDonGiaByMaSanPham(Guid maSanPham)
        {
            var sp = _context.SanPhams.Find(maSanPham);
            return sp.DonGia;
        }

        // DELETE: api/DonDatHang/5
        [HttpDelete("{MaDonHang}")]
        public async Task<IActionResult> DeleteDonDatHang(Guid MaDonHang)
        {
            if (_context.DonDatHangs == null)
            {
                return NotFound();
            }
            var donDatHang = await _context.DonDatHangs.FindAsync(MaDonHang);
            if (donDatHang == null)
            {
                return NotFound();
            }

            _context.DonDatHangs.Remove(donDatHang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonDatHangExists(Guid MaDonHang)
        {
            return (_context.DonDatHangs.Any(e => e.MaDonHang == MaDonHang));
        }

        private KhachHang CheckMaKH(Guid MaKH)
        {
            return _context.KhachHangs.Find(MaKH);
        }
        private bool CheckMaKH_bool(Guid MaKH)
        {
            return _context.KhachHangs.Any(e => e.MaKH == MaKH);
        }

        [HttpGet("GetHoaDon/{MaHoaDon}")]
        public async Task<ActionResult<SanPham>> GetHoaDon(string MaHoaDon)
        {
            var list = from hoadon in _context.HoaDons
                       from nhanvien in _context.NhanViens
                       where hoadon.MaHoaDon==MaHoaDon
                       select (new
                       {
                            hoadon,
                            NhanVien = (from nv in _context.NhanViens where nv.MaNV == hoadon.MaNV select nv.HoTen).ToList(),

                       });
            return Ok(list);
        }

        [HttpPost("HoaDon")]
        public IActionResult PosHoaDon(HoaDon_Model model)
        {

            var hoaDon = new HoaDon
            {
                MaHoaDon = model.MaHoaDon,
                MaDonHang = model.MaDonHang,
                MaNV = model.MaNV,
                NgayLap = DateTime.Today
            };
            var donhang = CheckMaDDH(model.MaDonHang);
            var nhanvien = CheckMaNV(model.MaNV);
            if (donhang == null || nhanvien == null)
            {
                return BadRequest();
            }
            else
            {
                hoaDon.DonDatHang_owner = donhang;
                hoaDon.NhanVien_owner = nhanvien;
                _context.Add(hoaDon);
                _context.SaveChanges();
                return Ok(hoaDon);
            }
        }

        private NhanVien CheckMaNV(Guid MaNV)
        {
            return _context.NhanViens.Find(MaNV);
        }

        private DonDatHang CheckMaDDH(Guid MaDonHang)
        {
            return _context.DonDatHangs.Find(MaDonHang);
        }
    }
}
