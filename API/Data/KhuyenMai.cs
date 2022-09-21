using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class KhuyenMai
    {
        public KhuyenMai()
        {
            list_CTKM = new HashSet<CTKM>();
        }
        public Guid MaKM { get; set; }

        [MaxLength(50)]
        public string TenKM { get; set; }

        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        
        public string? MoTa { get; set; }
        
        public virtual ICollection<CTKM> list_CTKM { get; set; }
        


    }
}
