using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MyDbContext _context;

        public WeatherForecastController(MyDbContext context)
        {
            _context = context;
        }

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("test")]
        public IActionResult PostDonDatHang(DonDatHang_Model model)
        {
            DateTime today = new DateTime();
            today = DateTime.Now.AddDays(-30);
            var donHang = new DonDatHang
            {
                MaKH = model.MaKH,
                NguoiNhan = model.NguoiNhan,
                DiaChi = model.DiaChi,
                NgayLap = today,
                TrangThai = 0,
                list_CTDDH = new HashSet<CTDDH>(),
                HoaDon_owner = null,
            };
            
               
                _context.Add(donHang);
                _context.SaveChanges();
                return Ok(donHang);
            
        }

        [HttpPost("Revenue")]
        public async Task<ActionResult<IEnumerable<Revenue>>> getRevenue(Revenue_Model model)
        {
            string proc = "EXEC [dbo].[sp_RevenueStatistics] " +
                            "@start = '" + model.start + "'" + "," +
                            "@end = '" + model.end + "'";
            return await _context.Revenues.FromSqlRaw(proc).ToListAsync();
        }
    }
}