using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) {  }

        #region DbSet
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiNuoc> LoaiNuocs { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<CongTyShip> CongTyShips { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<DonDatHang> DonDatHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<CTDDH> CTDDHs { get; set; }
        public DbSet<BinhLuan> BinhLuans { get; set; }
        public DbSet<CTPN> CTPNs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<NguyenLieu> NguyenLieus { get; set; }
        public DbSet<PhaChe> PhaChes { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<SanPhamYeuThich> SanPhamYeuThichs { get; set; }
        public DbSet<CTKM> CTKMs { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LoaiNuoc>(entity =>
            {
                entity.ToTable("LoaiNuoc");
                entity.HasKey(e => e.MaLoaiNuoc);
            });
            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");
                entity.HasKey(e => e.MaSanPham);
                entity.HasOne(e => e.LoaiNuoc_owner)
                .WithMany(e => e.list_SanPham)
                .HasForeignKey(e => e.MaLoaiNuoc)
                .HasConstraintName("FK_SanPham_LoaiNuoc");
                entity.Property(e => e.TenSanPham).IsRequired();
                entity.Property(e => e.MaLoaiNuoc).IsRequired();
            });
            modelBuilder.Entity<NguyenLieu>(entity =>
            {
                entity.ToTable("NguyenLieu");
                entity.HasKey(e => e.MaNguyenLieu);
            });
            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.ToTable("Quyen");
                entity.HasKey(e => e.MaQuyen);
            });
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("NhanVien");
                entity.HasKey(e => e.MaNV);
                entity.HasOne(e => e.Quyen_owner)
                .WithMany(e => e.list_NhanVien)
                .HasForeignKey(e => e.MaQuyen)
                .HasConstraintName("FK_NhanVien_Quyen");
                entity.Property(e => e.HoTen).IsRequired();
                entity.Property(e => e.MaQuyen).IsRequired();
            });
            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.ToTable("KhuyenMai");
                entity.HasKey(e => e.MaKM);
                
            });
            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KhachHang");
                entity.HasKey(e => e.MaKH);
            });
            modelBuilder.Entity<CongTyShip>(entity =>
            {
                entity.ToTable("CongTyShip");
                entity.HasKey(e => e.MaCongTy);
            });
            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("Shipper");
                entity.HasKey(e => e.MaShipper);
                entity.HasOne(e => e.CongTyShip_owner)
                .WithMany(e => e.list_Shipper)
                .HasForeignKey(e => e.MaCongTy)
                .HasConstraintName("FK_Shipper_CongTyShip");
                entity.Property(e => e.HoTen).IsRequired();
                entity.Property(e => e.SDT).IsRequired();
                entity.Property(e => e.DiaChi).IsRequired();
                entity.Property(e => e.PassWord).IsRequired();
                entity.Property(e => e.MaCongTy).IsRequired();
            });
            modelBuilder.Entity<DonDatHang>(entity =>
            {
                entity.ToTable("DonDatHang");
                entity.HasKey(e => e.MaDonHang);
                entity.HasOne(e => e.NhanVien_owner)
                .WithMany(e => e.list_DonDatHang)
                .HasForeignKey(e => e.MaNV)
                .HasConstraintName("FK_DonDatHang_NhanVien");
                

                entity.HasOne(e => e.Shipper_owner)
                .WithMany(e => e.list_DonDatHang)
                .HasForeignKey(e => e.MaShipper)
                .HasConstraintName("FK_DonDatHang_Shipper");
                
                
                entity.HasOne(e => e.KhachHang_owner)
                .WithMany(e => e.list_DonDatHang)
                .HasForeignKey(e => e.MaKH)
                .HasConstraintName("FK_DonDatHang_KhachHang");
                entity.Property(e => e.MaKH).IsRequired();
            });
            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.ToTable("HoaDon");
                entity.HasKey(e => e.MaHoaDon);

                entity.HasOne(e => e.NhanVien_owner)
                .WithMany(e => e.list_HoaDon)
                .HasForeignKey(e => e.MaNV)
                .HasConstraintName("FK_HoaDon_NhanVien");
                entity.Property(e => e.MaNV).IsRequired();

                entity.HasOne(e => e.DonDatHang_owner)
                .WithOne(e => e.HoaDon_owner)
                .HasForeignKey<HoaDon>(e => e.MaDonHang)
                .HasConstraintName("FK_HoaDon_DonDatHang");
                entity.Property(e=>e.MaDonHang).IsRequired();
            });
            modelBuilder.Entity<CTDDH>(entity =>
            {
                entity.ToTable("CTDDH");
                entity.HasKey(e => new { e.MaDonHang, e.MaSanPham });
                entity.HasOne(e => e.SanPham_owner)
                .WithMany(e => e.list_CTDDH)
                .HasForeignKey(e => e.MaSanPham)
                .HasConstraintName("FK_CTDDH_SanPham");

                entity.HasOne(e => e.DonDatHang_owner)
                .WithMany(e => e.list_CTDDH)
                .HasForeignKey(e => e.MaDonHang)
                .HasConstraintName("FK_CTDDH_DonDatHang");
                
            });
            modelBuilder.Entity<BinhLuan>(entity =>
            {
                entity.ToTable("BinhLuan");
                entity.HasKey(e => e.MaBinhLuan);
                entity.HasOne(e => e.SanPham_owner)
                .WithMany(e => e.list_BinhLuan)
                .HasForeignKey(e => e.MaSanPham)
                .HasConstraintName("FK_BinhLuan_SanPham");

                entity.HasOne(e => e.KhachHang_owner)
                .WithMany(e => e.list_BinhLuan)
                .HasForeignKey(e => e.MaKH)
                .HasConstraintName("FK_BinhLuan_KhachHang");
            });
            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.ToTable("PhieuNhap");
                entity.HasKey(e => e.MaPN);
                entity.HasOne(e => e.NhanVien_owner)
                .WithMany(e => e.list_PhieuNhap)
                .HasForeignKey(e => e.MaNV)
                .HasConstraintName("FK_PhieuNhap_NhanVien");
            });
            modelBuilder.Entity<CTPN>(entity =>
            {
                entity.ToTable("CTPN");
                entity.HasKey(e => new {e.MaPN, e.MaNguyenLieu });
                entity.HasOne(e => e.PhieuNhap_owner)
                .WithMany(e => e.list_CTPN)
                .HasForeignKey(e => e.MaPN)
                .HasConstraintName("FK_CTPN_PhieuNhap");

                entity.HasOne(e => e.NguyenLieu_owner)
                .WithMany(e => e.list_CTPN)
                .HasForeignKey(e => e.MaNguyenLieu)
                .HasConstraintName("FK_CTPN_NguyenLieu");
            });
            modelBuilder.Entity<PhaChe>(entity =>
            {
                entity.ToTable("PhaChe");
                entity.HasKey(e => new {e.MaSanPham,e.MaNguyenLieu});
                entity.HasOne(e => e.SanPham_owner)
                .WithMany(e => e.list_PhaChe)
                .HasForeignKey(e => e.MaSanPham)
                .HasConstraintName("FK_PhaChe_SanPham");

                entity.HasOne(e => e.NguyenLieu_owner)
                .WithMany(e => e.list_PhaChe)
                .HasForeignKey(e => e.MaNguyenLieu)
                .HasConstraintName("FK_PhaChe_NguyenLieu");
            });
            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.ToTable("GioHang");
                entity.HasKey(e => new { e.MaKH, e.MaSanPham });
                entity.HasOne(e => e.KhachHang_owner)
                .WithMany(e => e.list_GioHang)
                .HasForeignKey(e => e.MaKH)
                .HasConstraintName("FK_GioHang_KhachHang");

                
            });
            modelBuilder.Entity<SanPhamYeuThich>(entity =>
            {
                entity.ToTable("SanPhamYeuThich");
                entity.HasKey(e => new { e.MaSanPham, e.MaKH });
                entity.HasOne(e => e.KhachHang_owner)
                .WithMany(e => e.list_SanPhamYeuThich)
                .HasForeignKey(e => e.MaKH)
                .HasConstraintName("FK_SanPhamYeuThich_KhachHang");
            });
            modelBuilder.Entity<CTKM>(entity =>
            {
                entity.ToTable("CTKM");
                entity.HasKey(e => new { e.MaKM, e.MaSanPham });
                entity.HasOne(e => e.SanPham_owner)
                .WithMany(e => e.list_CTKM)
                .HasForeignKey(e => e.MaSanPham)
                .HasConstraintName("FK_CTKM_SanPham");

                entity.HasOne(e => e.KhuyenMai_owner)
                .WithMany(e => e.list_CTKM)
                .HasForeignKey(e => e.MaKM)
                .HasConstraintName("FK_CTKM_KhuyenMai");
            });
        }
    }
}
