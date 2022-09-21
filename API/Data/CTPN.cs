using System.ComponentModel.DataAnnotations;
namespace API.Data
{
    public class CTPN
    {
        public CTPN()
        {
        }
        
        public Guid MaPN { get; set; }
        public Guid MaNguyenLieu { get; set; }
        [Range(0,double.MaxValue)]
        public double KhoiLuong { get; set; }
        [Range(0,double.MaxValue)]
        public double Gia { get; set; }

        public virtual PhieuNhap PhieuNhap_owner { get; set; }
        public virtual NguyenLieu NguyenLieu_owner { get; set; }
    }
}
