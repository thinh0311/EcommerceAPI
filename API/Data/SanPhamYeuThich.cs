namespace API.Data
{
    public class SanPhamYeuThich
    {
        public Guid MaKH { get; set; }
        public Guid MaSanPham { get; set; }

        public virtual SanPham SanPham_owner { get; set; }
        public virtual KhachHang KhachHang_owner { get; set; }
    }
}
