using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
   
    [Table("SanPham")]
    public class SanPham
    {
        public SanPham()
        {
            list_CTDDH = new HashSet<CTDDH>();
            list_BinhLuan = new HashSet<BinhLuan>();
            list_PhaChe = new HashSet<PhaChe>();
            list_CTKM = new HashSet<CTKM>();
        }

        [Key]
        public Guid MaSanPham { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenSanPham { get; set; }

        public string? MoTa { get; set; }

        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }

        public string HinhAnh { get; set; }
      
        public Guid MaLoaiNuoc { get; set; }

        public virtual LoaiNuoc LoaiNuoc_owner { get; set; }

        public virtual ICollection<CTDDH> list_CTDDH { get; set; }
        public virtual ICollection<BinhLuan> list_BinhLuan { get; set; }
        public virtual ICollection<PhaChe> list_PhaChe { get; set; }
        public virtual ICollection<CTKM> list_CTKM { get; set; }
    }
}
