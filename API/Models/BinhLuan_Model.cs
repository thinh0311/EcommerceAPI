using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class BinhLuan_Model
    { 
        public DateTime NgayBinhLuan { get; set; }
        public string NoiDung { get; set; }
        public Guid MaSanPham { get; set; }
        public Guid MaKH { get; set; }
    }
}
