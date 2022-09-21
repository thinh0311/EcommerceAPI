using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class BinhLuan
    {
        public BinhLuan()
        {
        }

        public Guid MaBinhLuan { get; set; }
        public DateTime NgayBinhLuan { get; set; }
        public string NoiDung { get; set; }
        public Guid MaSanPham { get; set; }
        public Guid MaKH { get; set; }

        public virtual KhachHang KhachHang_owner { get; set; }
        public virtual SanPham SanPham_owner { get; set; }
    }
}
