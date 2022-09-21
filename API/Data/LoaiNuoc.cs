using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class LoaiNuoc
    {
        public LoaiNuoc()
        {
            list_SanPham = new HashSet<SanPham>();
        }

        [Key]
        public Guid MaLoaiNuoc { get; set; }
        [MaxLength(50)]
        public string TenLoaiNuoc { get; set; }
        public string? MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<SanPham> list_SanPham { get; set; }
    }
}
