using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class KhuyenMai_Model
    {
        
        

        
        public string TenKM { get; set; }

        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string? MoTa { get; set; }
        public Guid? MaNV { get; set; }

        


    }
}
