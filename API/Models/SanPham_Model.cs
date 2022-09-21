using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    
    public class SanPham_Model
    {



        public Guid MaLoaiNuoc { get; set; }
        public string TenSanPham { get; set; }

        public string? MoTa { get; set; }

        public double DonGia { get; set; }
               
        public string HinhAnh { get; set; }

        

        
    }
}
