using System.ComponentModel.DataAnnotations;
namespace API.Models
{
    public class PhaChe_Model
    {
       

        public Guid MaSanPham { get; set; }
        public Guid MaNguyenLieu { get; set; }
        
        public double KhoiLuong { get; set; }

        
    }
}
