using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CTDDH_Model
    {
        public Guid MaDonHang { get; set; }
        public Guid MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        
    }
}
