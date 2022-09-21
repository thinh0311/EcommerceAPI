using System.ComponentModel.DataAnnotations;
namespace API.Data
{
    public class PhaChe
    {
        public PhaChe()
        {
        }

        public Guid MaSanPham { get; set; }
        public Guid MaNguyenLieu { get; set; }
        [Range(0, double.MaxValue)]
        public double KhoiLuong { get; set; }

        public virtual NguyenLieu NguyenLieu_owner { get; set; }
        public virtual SanPham SanPham_owner { get; set; }
    }
}
