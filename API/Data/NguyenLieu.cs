using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class NguyenLieu
    {
        public NguyenLieu()
        {
            list_CTPN = new HashSet<CTPN>();
            list_PhaChe = new HashSet<PhaChe>();
        }

        public Guid MaNguyenLieu { get; set; }
        [MaxLength(50)]
        public string TenNguyenLieu { get; set; }

        public virtual ICollection<CTPN> list_CTPN { get; set; }
        public virtual ICollection<PhaChe> list_PhaChe { get; set; }

    }
}
