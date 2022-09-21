using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class CTDDH
    {
        public CTDDH()
        {
        }

        public Guid MaDonHang { get; set; }
        public Guid MaSanPham { get; set; }
        public int SoLuong { get; set; }

        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }

        public virtual DonDatHang DonDatHang_owner { get; set; }
        public virtual SanPham SanPham_owner { get; set; }
    }
}
