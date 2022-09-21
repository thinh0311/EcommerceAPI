using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongTyShipController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CongTyShipController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongTyShip>>> GetAll()
        {
            return await _context.CongTyShips.ToListAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{MaCongTy}")]
        public IActionResult GetCongTy(Guid MaCongTy)
        {
            var cty = _context.CongTyShips.Find(MaCongTy);

            if (cty == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cty);
            }
        }
        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult PostCongTy(CongTyShip_Model model)
        {
            try
            {
                CongTyShip cty = new CongTyShip
                {
                    TenCongTy = model.TenCongTy,
                    DiaChi = model.DiaChi,
                    SDT = model.SDT,
                    MoTa = model.MoTa,
                    list_Shipper = new HashSet<Shipper>()
                };
                _context.Add(cty);
                _context.SaveChanges();
                return Ok(cty);
            }
            catch
            {
                return BadRequest();
            }
        }
        // PUT api/<ValuesController>/5
        [HttpDelete("{MaCongTy}")]
        public IActionResult DeleteCongTy(Guid MaCongTy)
        {
            var cty = _context.CongTyShips.SingleOrDefault(e => e.MaCongTy == MaCongTy);
            if (cty == null)
            {
                return NotFound();
            }
            _context.Remove(cty);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
