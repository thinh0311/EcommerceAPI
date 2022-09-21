using System.ComponentModel.DataAnnotations;
namespace API.Models
{
    public class CTPN_Model
    {
        
        public Guid MaPN { get; set; }
        public Guid MaNguyenLieu { get; set; }
        
        public double KhoiLuong { get; set; }
        public double Gia { get; set; }

        
    }
}
