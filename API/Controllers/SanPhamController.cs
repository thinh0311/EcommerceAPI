using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SanPhamController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/SanPham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSanPhams()
        {
          if (_context.SanPhams == null)
          {
              return NotFound();
          }
            return await _context.SanPhams.ToListAsync();
        }

        // GET: api/SanPham/5
        [HttpGet("{MaSanPham}")]
        public async Task<ActionResult<SanPham>> GetSanPham(Guid MaSanPham)
        {
          if (_context.SanPhams == null)
          {
              return NotFound();
          }
            var sanPham = await _context.SanPhams.FindAsync(MaSanPham);

            if (sanPham == null)
            {
                return NotFound();
            }

            return sanPham;
        }

        [HttpGet("GetSanPhamYeuThich/{MaKH}")]
        public async Task<ActionResult<SanPham>> GetSanPhamYeuThichByMaTaiKhoan(Guid MaKH)
        {
            var list = from sanPham in _context.SanPhams
                       from spYeuThich in _context.SanPhamYeuThichs
                       where spYeuThich.MaKH == MaKH && spYeuThich.MaSanPham == sanPham.MaSanPham
                       select (new
                       {
                           sanPham,
                           giamGia = (from ctkm in _context.CTKMs
                                      from km in _context.KhuyenMais
                                      where ctkm.MaSanPham == sanPham.MaSanPham &&
                                            km.MaKM == ctkm.MaKM &&
                                            km.NgayBatDau <= DateTime.Today &&
                                            km.NgayKetThuc >= DateTime.Today
                                      select ctkm.PhanTramGiam).ToList()
                       });
            return Ok(list);
        }

        [HttpGet("GetSanPhamTrongGioHang/{MaKH}")]
        public IActionResult GetSanPhamTrongGioHangByMaTaiKhoan(Guid MaKH)
        {
            var returnList = from sanPham in _context.SanPhams
                             from gioHang in _context.GioHangs
                             where gioHang.MaKH == MaKH && gioHang.MaSanPham == sanPham.MaSanPham
                             select new
                             {
                                 sanPham,
                                 gioHang.SoLuong,
                                 giamGia = (from ctkm in _context.CTKMs
                                            from km in _context.KhuyenMais
                                            where ctkm.MaSanPham == sanPham.MaSanPham &&
                                                  km.MaKM == ctkm.MaKM &&
                                                  km.NgayBatDau <= DateTime.Today &&
                                                  km.NgayKetThuc >= DateTime.Today
                                            select ctkm.PhanTramGiam).ToList()
                             };
            return Ok(returnList);
        }

        // PUT: api/SanPham/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{MaSanPham}")]
        public IActionResult PutSanPham(Guid MaSanPham, SanPham_Model model)
        {
            var sanPham = _context.SanPhams.SingleOrDefault(e => e.MaSanPham == MaSanPham);
            if (sanPham == null)
            {
                return NotFound();
            }
            sanPham.TenSanPham = model.TenSanPham;
            sanPham.MoTa = model.MoTa;
            sanPham.DonGia = model.DonGia;
            sanPham.HinhAnh = model.HinhAnh;
            
            _context.Update(sanPham);
            _context.SaveChanges();
            return NoContent();
        }

        // POST: api/SanPham
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<SanPham> PostSanPham(SanPham_Model model)
        {
            SanPham sanPham = new SanPham
            {
                MaLoaiNuoc = model.MaLoaiNuoc,
                TenSanPham = model.TenSanPham,
                DonGia = model.DonGia,
                MoTa = model.MoTa,
                HinhAnh = model.HinhAnh,

                LoaiNuoc_owner = null,
                list_CTDDH = new HashSet<CTDDH>(),
                list_BinhLuan = new HashSet<BinhLuan>(),
                list_PhaChe = new HashSet<PhaChe>(),
                list_CTKM = new HashSet<CTKM>(),
            };
            var loaiNuoc = CheckMaLoaiNuoc(model.MaLoaiNuoc);
            if (loaiNuoc == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Add(sanPham);
                _context.SaveChanges();
                return Ok(sanPham);
            }
        }
        private LoaiNuoc CheckMaLoaiNuoc(Guid MaLoaiNuoc)
        {
            return _context.LoaiNuocs.Find(MaLoaiNuoc);
        }

        // DELETE: api/SanPham/5
        [HttpDelete("{MaSanPham}")]
        public IActionResult DeleteSanPham(Guid MaSanPham)
        {
            var sanPham = _context.SanPhams.Find(MaSanPham);
            if (sanPham == null)
            {
                return NotFound();
            }

            _context.SanPhams.Remove(sanPham);
            _context.SaveChanges();

            return NoContent();
        }

        private bool SanPhamExists(Guid id)
        {
            return (_context.SanPhams?.Any(e => e.MaSanPham == id)).GetValueOrDefault();
        }

        [HttpGet("GetSanPhamByMaLoaiNuoc/{MaLoaiNuoc}")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSanPhamByMaDanhMuc(Guid MaLoaiNuoc)
        {
            //return await _context.SanPhams.Where(e => e.MaLoaiNuoc == MaLoaiNuoc).ToListAsync();
            var list = from sanPham in _context.SanPhams

                       where sanPham.MaLoaiNuoc == MaLoaiNuoc
                       select (new { sanPham, giamGia = (from ctkm in _context.CTKMs
                                                         from km in _context.KhuyenMais
                                                         where ctkm.MaSanPham == sanPham.MaSanPham &&
                                                               km.MaKM == ctkm.MaKM &&
                                                               km.NgayBatDau <= DateTime.Today &&
                                                               km.NgayKetThuc >= DateTime.Today
                                                         select ctkm.PhanTramGiam).ToList()
                       });
            list.ToList();
            return Ok(list);
        }

        [HttpGet("GetSanPhamByTen/{TenSanPham}")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSanPhamByTen(string TenSanPham)
        {
            return await _context.SanPhams.Where(e => e.TenSanPham.Contains(TenSanPham)).ToListAsync();
        }

        [HttpGet("TimKiemSanPham/{text}")]
        public ActionResult<SanPham> TimKiemSanPham(string text)
        {
            var list = from sanPham in _context.SanPhams
                       where EF.Functions.Like(sanPham.TenSanPham, "%" + text + "%")
                       select (new {sanPham, giamGia = (from ctkm in _context.CTKMs
                                                        from km in _context.KhuyenMais
                                                        where ctkm.MaSanPham == sanPham.MaSanPham &&
                                                              km.MaKM == ctkm.MaKM &&
                                                              km.NgayBatDau <= DateTime.Today &&
                                                              km.NgayKetThuc >= DateTime.Today
                                                        select ctkm.PhanTramGiam).ToList()
                       });
            return Ok(list);
        }
        [HttpGet("GetSanPhamSaleKhung")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSanPhamSaleKhung()
        {
            var list = from sanPham in _context.SanPhams
                       from ctkm in _context.CTKMs
                       from km in _context.KhuyenMais
                       where ctkm.MaSanPham==sanPham.MaSanPham &&
                             km.MaKM==ctkm.MaKM &&
                             km.NgayBatDau <= DateTime.Today && km.NgayKetThuc >= DateTime.Today &&
                             ctkm.PhanTramGiam >= 30
                       orderby ctkm.PhanTramGiam descending
                       select (new { sanPham, ctkm.PhanTramGiam });
            return Ok(list.Take(6));

        }

        [HttpGet("GetSanPhamBanChay")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSanPhamBanChay()
        {
            var list = from sanPham in _context.SanPhams
                       from ddh in _context.DonDatHangs
                       from ctddh in _context.CTDDHs
                       where sanPham.MaSanPham == ctddh.MaSanPham
                       && ddh.MaDonHang == ctddh.MaDonHang
                       && ddh.NgayLap > DateTime.Today.AddDays(-180)
                       group new { sanPham, ctddh} by new { sanPham.MaSanPham, sanPham.TenSanPham, sanPham.DonGia, sanPham.MoTa, sanPham.HinhAnh } into temp
                       orderby temp.Sum(x => x.ctddh.SoLuong) descending
                       select (new 
                       {
                           MaSanPham = temp.Key.MaSanPham,
                           TenSanPham = temp.Key.TenSanPham,
                           DonGia = temp.Key.DonGia,
                           HinhAnh = temp.Key.HinhAnh,
                           MoTa = temp.Key.MoTa,
                           giamGia = (from ctkm in _context.CTKMs
                                      from km in _context.KhuyenMais
                                      where ctkm.MaSanPham == temp.Key.MaSanPham &&
                                            km.MaKM == ctkm.MaKM &&
                                            km.NgayBatDau <= DateTime.Today &&
                                            km.NgayKetThuc >= DateTime.Today
                                      select ctkm.PhanTramGiam).ToList()
                       });
            return Ok(list.Take(6));

        }

        [HttpGet("GetKMSanPham/{MaSanPham}")]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetKMSanPham(Guid MaSanPham)
        {
            var list = from sanPham in _context.SanPhams
                       from ctkm in _context.CTKMs
                       from km in _context.KhuyenMais
                       where ctkm.MaSanPham == sanPham.MaSanPham &&
                             km.MaKM == ctkm.MaKM &&
                             km.NgayBatDau <= DateTime.Today && km.NgayKetThuc >= DateTime.Today &&
                             ctkm.MaSanPham==MaSanPham
                       select (ctkm.PhanTramGiam);
            if (list.Any())
                return Ok(list);
            else
                return Ok(0);

        }

        //[HttpGet("Get/{MaLoaiNuoc}")]
        //public async Task<ActionResult<IEnumerable<SanPham>>> a(Guid MaLoaiNuoc)
        //{
        //    var list = from sanPham in _context.SanPhams
                      
        //               where sanPham.MaLoaiNuoc==MaLoaiNuoc
        //               select (new { sanPham, giamGia = (from ctkm in _context.CTKMs where ctkm.MaSanPham==sanPham.MaSanPham select ctkm.PhanTramGiam).ToList() });
        //    list.ToList();
        //    return Ok(list);

        //}
    }
}
