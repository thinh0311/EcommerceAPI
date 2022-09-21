using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public enum TrangThai
    {
        ChuaNhap=0,
        DaNhap=1
    }
    public class PhieuNhap
    {
        public PhieuNhap()
        {
            list_CTPN = new HashSet<CTPN>();
        }

        [Key]
        public Guid MaPN { get; set; }
        public TrangThai TrangThai { get; set; }
        public Guid MaNV { get; set; }

        public virtual NhanVien NhanVien_owner { get; set; }
        public virtual ICollection<CTPN> list_CTPN { get; set; }
    }
}
