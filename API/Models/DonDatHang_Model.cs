namespace API.Models
{
    
    public class DonDatHang_Model
    {
        

        

        public string? MoTa { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayLap { get; set; }

        public Guid? MaNV { get; set; }
        public Guid MaKH { get; set; }
        public Guid? MaShipper { get; set; }

    }
}
