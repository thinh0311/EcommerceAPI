using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class NhanVien_Model
    {
       

        
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        
        public string SDT { get; set; }
        public string PassWord { get; set; }
        public Guid MaQuyen { get; set; }

       
    }
}
