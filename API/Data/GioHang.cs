namespace API.Data
{
    public class GioHang
    {
        public Guid MaKH { get; set; }
        public Guid MaSanPham { get; set; }
        public int SoLuong { get; set; }

        public virtual KhachHang KhachHang_owner { get; set; }
        public virtual SanPham SanPham_owner { get; set; }
    }
}
