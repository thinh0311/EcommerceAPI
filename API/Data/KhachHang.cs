using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class KhachHang
    {
        public KhachHang()
        {
            list_DonDatHang = new HashSet<DonDatHang>();
            list_BinhLuan = new HashSet<BinhLuan>();
            list_GioHang = new HashSet<GioHang>();
            list_SanPhamYeuThich = new HashSet<SanPhamYeuThich>();
        }
        public Guid MaKH { get; set; }

        [MaxLength(50)]
        public string HoTen { get; set; }
        public string DiaChi { get; set; }

        [MaxLength(15)]
        public string SDT { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string? AnhDaiDien { get; set; }

        public virtual ICollection<DonDatHang> list_DonDatHang { get; set; }
        public virtual ICollection<BinhLuan> list_BinhLuan { get; set; }
        public virtual ICollection<GioHang> list_GioHang { get; set; }
        public virtual ICollection<SanPhamYeuThich> list_SanPhamYeuThich { get; set; }

    }
}
