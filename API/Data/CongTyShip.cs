using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class CongTyShip
    {
        public CongTyShip()
        {
            list_Shipper=new HashSet<Shipper>();
        }
        public Guid MaCongTy { get; set; }

        [MaxLength(50)]
        public string TenCongTy { get; set; }
        public string DiaChi { get; set; }

        [MaxLength(15)]
        public string SDT { get; set; }
        public string? MoTa { get; set; }

        public virtual ICollection<Shipper> list_Shipper { get; set; }
    }
}
