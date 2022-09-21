using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Revenue
    {
        [Key]
        public string ThangNam { get; set; }
        public double TongTien { get; set; }
    }
}
