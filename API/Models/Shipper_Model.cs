using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Shipper_Model
    {
        

        [MaxLength(50)]
        public string HoTen { get; set; }
        public string DiaChi { get; set; }

        [MaxLength(15)]
        public string SDT { get; set; }
        public string PassWord { get; set; }
        public Guid MaCongTy { get; set; }

        

    }
}
