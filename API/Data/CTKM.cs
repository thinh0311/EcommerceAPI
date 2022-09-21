using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class CTKM
    {
        public CTKM()
        {

        }
        public Guid MaKM { get; set; }
        public Guid MaSanPham { get; set; }
        [Range(0, double.MaxValue)]
        public double PhanTramGiam { get; set; }

        public virtual SanPham SanPham_owner { get; set; }
        public virtual KhuyenMai KhuyenMai_owner { get; set; }
    }
}
