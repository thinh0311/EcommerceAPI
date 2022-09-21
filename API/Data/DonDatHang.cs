namespace API.Data
{
    public enum TrangThaiDonHang
    {
        ChuaDuyet = 0,
        DaDuyet = 1,
        DangGiao = 2,
        HoanThanh = 3,
    }
    public class DonDatHang
    {
        public DonDatHang()
        {
            list_CTDDH=new HashSet<CTDDH>();
        }

        public Guid MaDonHang { get; set; }

        public DateTime NgayLap { get; set; }
        public string? MoTa { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChi { get; set; }

        public TrangThaiDonHang TrangThai { get; set; }

        public Guid? MaNV { get; set; }
        public Guid MaKH { get; set; }
        public Guid? MaShipper { get; set; }
        public Guid? MaHoaDon { get; set; }

        public virtual NhanVien NhanVien_owner { get; set; }
        public virtual KhachHang KhachHang_owner { get; set; }
        public virtual Shipper Shipper_owner { get; set; }
        public virtual HoaDon HoaDon_owner { get; set; }
        public virtual ICollection<CTDDH> list_CTDDH { get; set; }
        
    }
}
