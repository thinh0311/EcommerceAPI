using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class Quyen
    {
        public Quyen()
        {
            list_NhanVien = new HashSet<NhanVien>();
        }

        public Guid MaQuyen { get; set; }
        [MaxLength(30)]
        public string TenQuyen { get; set; } 

        public virtual ICollection<NhanVien> list_NhanVien { get; set; }
    }
}
