using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class HoaDon
    {
        public HoaDon()
        {
            
        }

        [Key]
        [MaxLength(50)]
        public string MaHoaDon { get; set; }

        public DateTime NgayLap { get; set; }
  
        public Guid MaDonHang { get; set; }
        public Guid MaNV { get; set; }

        public virtual DonDatHang DonDatHang_owner { get; set; }
        public virtual NhanVien NhanVien_owner { get; set; }
        
    }
}
