using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class Shipper
    {
        public Shipper()
        {
            list_DonDatHang = new HashSet<DonDatHang>();
        }
        public Guid MaShipper { get; set; }

        [MaxLength(50)]
        public string HoTen { get; set; }
        public string DiaChi { get; set; }

        [MaxLength(15)]
        public string SDT { get; set; }
        public string PassWord { get; set; }
        public Guid MaCongTy { get; set; }

        public virtual CongTyShip CongTyShip_owner { get; set; }

        public virtual ICollection<DonDatHang> list_DonDatHang { get; set; }

    }
}
