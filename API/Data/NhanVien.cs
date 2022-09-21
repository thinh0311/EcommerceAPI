using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class NhanVien
    {
        public NhanVien()
        {            
            list_DonDatHang = new HashSet<DonDatHang>();
            list_HoaDon = new HashSet<HoaDon>();
            list_PhieuNhap = new HashSet<PhieuNhap>();
        }
        public Guid MaNV { get; set; }

        [MaxLength(50)]
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        [MaxLength(15)]
        public string SDT { get; set; }
        public string PassWord { get; set; }
        public Guid MaQuyen { get; set; }

        public virtual Quyen Quyen_owner { get; set; }
        public virtual ICollection<DonDatHang> list_DonDatHang { get; set; }
        public virtual ICollection<HoaDon> list_HoaDon { get; set; }
        public virtual ICollection<PhieuNhap> list_PhieuNhap { get; set; }
    }
}
