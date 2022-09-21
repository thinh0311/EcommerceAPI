using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly AppSetting _appSetting;

        public UserController(MyDbContext context, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _context = context;
            _appSetting = optionsMonitor.CurrentValue;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHang>>> GetKhachHangs()
        {
          if (_context.KhachHangs == null)
          {
              return NotFound();
          }
            return await _context.KhachHangs.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{MaKH}")]
        public async Task<ActionResult<KhachHang>> GetKhachHang(Guid MaKH)
        {
            var khachHang = await _context.KhachHangs.FindAsync(MaKH);

            if (khachHang == null)
            {
                return NotFound();
            }

            

            return khachHang;
        }

        [HttpGet("CheckTaiKhoan/{email}")]
        public async Task<ActionResult<Guid>> GetKhachHangByEmail(String email)
        {
            var khachHang =  _context.KhachHangs.SingleOrDefault(e => e.Email==email);

            if (khachHang == null)
            {
                return NotFound();
            }



            return khachHang.MaKH;
        }

        [HttpGet("GetUserByLogin/{email}/{password}")]
        public async Task<ActionResult<KhachHang>> GetUser(string email, string password)
        {
            var user =  _context.KhachHangs.SingleOrDefault(e => e.Email == email && e.PassWord == password);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }


        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{MaKH}")]
        public async Task<IActionResult> PutKhachHang(Guid MaKH, KhachHang khachHang)
        {
            if (MaKH != khachHang.MaKH)
            {
                return BadRequest();
            }

            _context.Entry(khachHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachHangExists(MaKH))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostKhachHang(KhachHang_Model model)
        {
            try
            {
                KhachHang khachHang = new KhachHang
                {
                    HoTen = model.HoTen,
                    SDT = model.SDT,
                    DiaChi = model.DiaChi,
                    Email = model.Email,
                    PassWord = model.PassWord,
                    AnhDaiDien = model.AnhDaiDien,
                    list_BinhLuan = new HashSet<BinhLuan>(),
                    list_DonDatHang = new HashSet<DonDatHang>(),
                };
                _context.Add(khachHang);
                _context.SaveChanges();
                return Ok(khachHang);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{MaKH}")]
        public async Task<IActionResult> DeleteKhachHang(Guid MaKH)
        {
            var khachHang = _context.KhachHangs.Find(MaKH);
            if (khachHang == null)
            {
                return NotFound();
            }

            _context.KhachHangs.Remove(khachHang);
            _context.SaveChanges();

            return NoContent();
        }

        private bool KhachHangExists(Guid id)
        {
            return (_context.KhachHangs?.Any(e => e.MaKH == id)).GetValueOrDefault();
        }

        
    }
}
