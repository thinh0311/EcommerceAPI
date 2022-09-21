using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class KhachHang_Model
    {
        
       
        
        public string HoTen { get; set; }
        public string DiaChi { get; set; }

        
        public string SDT { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string? AnhDaiDien { get; set; }

        

    }
}
