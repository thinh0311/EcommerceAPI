using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ShipperController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipper>>> GetShipper_DbSet()
        {
            return await _context.Shippers.ToListAsync();
        }

        [HttpPost]
        public IActionResult PostShipper(Shipper_Model model)
        {
            var shipper = new Shipper
            {
                MaCongTy = model.MaCongTy,
                HoTen = model.HoTen,
                DiaChi = model.DiaChi,
                SDT = model.SDT,
                PassWord = model.PassWord,
                CongTyShip_owner = null,
                list_DonDatHang= null
            };
            var cty = CheckMaCty(model.MaCongTy);
            if (cty == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Add(shipper);
                _context.SaveChanges();
                return Ok(shipper);
            }
        }

        private CongTyShip CheckMaCty(Guid MaCongTy)
        {
            return _context.CongTyShips.Find(MaCongTy);
        }
    }
}
