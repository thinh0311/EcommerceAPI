﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220802093109_initdb")]
    partial class initdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Data.BinhLuan", b =>
                {
                    b.Property<Guid>("MaBinhLuan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaKH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayBinhLuan")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaBinhLuan");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaSanPham");

                    b.ToTable("BinhLuan", (string)null);
                });

            modelBuilder.Entity("API.Data.CongTyShip", b =>
                {
                    b.Property<Guid>("MaCongTy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("TenCongTy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaCongTy");

                    b.ToTable("CongTyShip", (string)null);
                });

            modelBuilder.Entity("API.Data.CTDDH", b =>
                {
                    b.Property<Guid>("MaDonHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaDonHang", "MaSanPham");

                    b.HasIndex("MaSanPham");

                    b.ToTable("CTDDH", (string)null);
                });

            modelBuilder.Entity("API.Data.CTKM", b =>
                {
                    b.Property<Guid>("MaKM")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("PhanTramGiam")
                        .HasColumnType("float");

                    b.HasKey("MaKM", "MaSanPham");

                    b.HasIndex("MaSanPham");

                    b.ToTable("CTKM", (string)null);
                });

            modelBuilder.Entity("API.Data.CTPN", b =>
                {
                    b.Property<Guid>("MaPN")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaNguyenLieu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<double>("KhoiLuong")
                        .HasColumnType("float");

                    b.HasKey("MaPN", "MaNguyenLieu");

                    b.HasIndex("MaNguyenLieu");

                    b.ToTable("CTPN", (string)null);
                });

            modelBuilder.Entity("API.Data.DonDatHang", b =>
                {
                    b.Property<Guid>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MaKH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaNV")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaShipper")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaDonHang");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaNV");

                    b.HasIndex("MaShipper");

                    b.ToTable("DonDatHang", (string)null);
                });

            modelBuilder.Entity("API.Data.GioHang", b =>
                {
                    b.Property<Guid>("MaKH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaKH", "MaSanPham");

                    b.HasIndex("MaSanPham");

                    b.ToTable("GioHang", (string)null);
                });

            modelBuilder.Entity("API.Data.HoaDon", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("MaDonHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaNV")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaDonHang")
                        .IsUnique();

                    b.HasIndex("MaNV");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("API.Data.KhachHang", b =>
                {
                    b.Property<Guid>("MaKH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("MaKH");

                    b.ToTable("KhachHang", (string)null);
                });

            modelBuilder.Entity("API.Data.KhuyenMai", b =>
                {
                    b.Property<Guid>("MaKM")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhanTramGiam")
                        .HasColumnType("int");

                    b.Property<string>("TenKM")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaKM");

                    b.ToTable("KhuyenMai", (string)null);
                });

            modelBuilder.Entity("API.Data.LoaiNuoc", b =>
                {
                    b.Property<Guid>("MaLoaiNuoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoaiNuoc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoaiNuoc");

                    b.ToTable("LoaiNuoc", (string)null);
                });

            modelBuilder.Entity("API.Data.NguyenLieu", b =>
                {
                    b.Property<Guid>("MaNguyenLieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenNguyenLieu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaNguyenLieu");

                    b.ToTable("NguyenLieu", (string)null);
                });

            modelBuilder.Entity("API.Data.NhanVien", b =>
                {
                    b.Property<Guid>("MaNV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("MaQuyen")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("MaNV");

                    b.HasIndex("MaQuyen");

                    b.ToTable("NhanVien", (string)null);
                });

            modelBuilder.Entity("API.Data.PhaChe", b =>
                {
                    b.Property<Guid>("MaSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaNguyenLieu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("KhoiLuong")
                        .HasColumnType("float");

                    b.HasKey("MaSanPham", "MaNguyenLieu");

                    b.HasIndex("MaNguyenLieu");

                    b.ToTable("PhaChe", (string)null);
                });

            modelBuilder.Entity("API.Data.PhieuNhap", b =>
                {
                    b.Property<Guid>("MaPN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaNV")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaPN");

                    b.HasIndex("MaNV");

                    b.ToTable("PhieuNhap", (string)null);
                });

            modelBuilder.Entity("API.Data.Quyen", b =>
                {
                    b.Property<Guid>("MaQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MaQuyen");

                    b.ToTable("Quyen", (string)null);
                });

            modelBuilder.Entity("API.Data.SanPham", b =>
                {
                    b.Property<Guid>("MaSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MaLoaiNuoc")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaSanPham");

                    b.HasIndex("MaLoaiNuoc");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("API.Data.SanPhamYeuThich", b =>
                {
                    b.Property<Guid>("MaSanPham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaKH")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MaSanPham", "MaKH");

                    b.HasIndex("MaKH");

                    b.ToTable("SanPhamYeuThich", (string)null);
                });

            modelBuilder.Entity("API.Data.Shipper", b =>
                {
                    b.Property<Guid>("MaShipper")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("MaCongTy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("MaShipper");

                    b.HasIndex("MaCongTy");

                    b.ToTable("Shipper", (string)null);
                });

            modelBuilder.Entity("API.Data.BinhLuan", b =>
                {
                    b.HasOne("API.Data.KhachHang", "KhachHang_owner")
                        .WithMany("list_BinhLuan")
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BinhLuan_KhachHang");

                    b.HasOne("API.Data.SanPham", "SanPham_owner")
                        .WithMany("list_BinhLuan")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BinhLuan_SanPham");

                    b.Navigation("KhachHang_owner");

                    b.Navigation("SanPham_owner");
                });

            modelBuilder.Entity("API.Data.CTDDH", b =>
                {
                    b.HasOne("API.Data.DonDatHang", "DonDatHang_owner")
                        .WithMany("list_CTDDH")
                        .HasForeignKey("MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CTDDH_DonDatHang");

                    b.HasOne("API.Data.SanPham", "SanPham_owner")
                        .WithMany("list_CTDDH")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CTDDH_SanPham");

                    b.Navigation("DonDatHang_owner");

                    b.Navigation("SanPham_owner");
                });

            modelBuilder.Entity("API.Data.CTKM", b =>
                {
                    b.HasOne("API.Data.KhuyenMai", "KhuyenMai_owner")
                        .WithMany("list_CTKM")
                        .HasForeignKey("MaKM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CTKM_KhuyenMai");

                    b.HasOne("API.Data.SanPham", "SanPham_owner")
                        .WithMany("list_CTKM")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CTKM_SanPham");

                    b.Navigation("KhuyenMai_owner");

                    b.Navigation("SanPham_owner");
                });

            modelBuilder.Entity("API.Data.CTPN", b =>
                {
                    b.HasOne("API.Data.NguyenLieu", "NguyenLieu_owner")
                        .WithMany("list_CTPN")
                        .HasForeignKey("MaNguyenLieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CTPN_NguyenLieu");

                    b.HasOne("API.Data.PhieuNhap", "PhieuNhap_owner")
                        .WithMany("list_CTPN")
                        .HasForeignKey("MaPN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CTPN_PhieuNhap");

                    b.Navigation("NguyenLieu_owner");

                    b.Navigation("PhieuNhap_owner");
                });

            modelBuilder.Entity("API.Data.DonDatHang", b =>
                {
                    b.HasOne("API.Data.KhachHang", "KhachHang_owner")
                        .WithMany("list_DonDatHang")
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DonDatHang_KhachHang");

                    b.HasOne("API.Data.NhanVien", "NhanVien_owner")
                        .WithMany("list_DonDatHang")
                        .HasForeignKey("MaNV")
                        .HasConstraintName("FK_DonDatHang_NhanVien");

                    b.HasOne("API.Data.Shipper", "Shipper_owner")
                        .WithMany("list_DonDatHang")
                        .HasForeignKey("MaShipper")
                        .HasConstraintName("FK_DonDatHang_Shipper");

                    b.Navigation("KhachHang_owner");

                    b.Navigation("NhanVien_owner");

                    b.Navigation("Shipper_owner");
                });

            modelBuilder.Entity("API.Data.GioHang", b =>
                {
                    b.HasOne("API.Data.KhachHang", "KhachHang_owner")
                        .WithMany("list_GioHang")
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_GioHang_KhachHang");

                    b.HasOne("API.Data.SanPham", "SanPham_owner")
                        .WithMany()
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang_owner");

                    b.Navigation("SanPham_owner");
                });

            modelBuilder.Entity("API.Data.HoaDon", b =>
                {
                    b.HasOne("API.Data.DonDatHang", "DonDatHang_owner")
                        .WithOne("hoaDon")
                        .HasForeignKey("API.Data.HoaDon", "MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_HoaDon_DonDatHang");

                    b.HasOne("API.Data.NhanVien", "NhanVien_owner")
                        .WithMany("list_HoaDon")
                        .HasForeignKey("MaNV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_HoaDon_NhanVien");

                    b.Navigation("DonDatHang_owner");

                    b.Navigation("NhanVien_owner");
                });

            modelBuilder.Entity("API.Data.NhanVien", b =>
                {
                    b.HasOne("API.Data.Quyen", "Quyen_owner")
                        .WithMany("list_NhanVien")
                        .HasForeignKey("MaQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_NhanVien_Quyen");

                    b.Navigation("Quyen_owner");
                });

            modelBuilder.Entity("API.Data.PhaChe", b =>
                {
                    b.HasOne("API.Data.NguyenLieu", "NguyenLieu_owner")
                        .WithMany("list_PhaChe")
                        .HasForeignKey("MaNguyenLieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PhaChe_NguyenLieu");

                    b.HasOne("API.Data.SanPham", "SanPham_owner")
                        .WithMany("list_PhaChe")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PhaChe_SanPham");

                    b.Navigation("NguyenLieu_owner");

                    b.Navigation("SanPham_owner");
                });

            modelBuilder.Entity("API.Data.PhieuNhap", b =>
                {
                    b.HasOne("API.Data.NhanVien", "NhanVien_owner")
                        .WithMany("list_PhieuNhap")
                        .HasForeignKey("MaNV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PhieuNhap_NhanVien");

                    b.Navigation("NhanVien_owner");
                });

            modelBuilder.Entity("API.Data.SanPham", b =>
                {
                    b.HasOne("API.Data.LoaiNuoc", "LoaiNuoc_owner")
                        .WithMany("list_SanPham")
                        .HasForeignKey("MaLoaiNuoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SanPham_LoaiNuoc");

                    b.Navigation("LoaiNuoc_owner");
                });

            modelBuilder.Entity("API.Data.SanPhamYeuThich", b =>
                {
                    b.HasOne("API.Data.KhachHang", "KhachHang_owner")
                        .WithMany("list_SanPhamYeuThich")
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SanPhamYeuThich_KhachHang");

                    b.HasOne("API.Data.SanPham", "SanPham_owner")
                        .WithMany()
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang_owner");

                    b.Navigation("SanPham_owner");
                });

            modelBuilder.Entity("API.Data.Shipper", b =>
                {
                    b.HasOne("API.Data.CongTyShip", "CongTyShip_owner")
                        .WithMany("list_Shipper")
                        .HasForeignKey("MaCongTy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Shipper_CongTyShip");

                    b.Navigation("CongTyShip_owner");
                });

            modelBuilder.Entity("API.Data.CongTyShip", b =>
                {
                    b.Navigation("list_Shipper");
                });

            modelBuilder.Entity("API.Data.DonDatHang", b =>
                {
                    b.Navigation("hoaDon")
                        .IsRequired();

                    b.Navigation("list_CTDDH");
                });

            modelBuilder.Entity("API.Data.KhachHang", b =>
                {
                    b.Navigation("list_BinhLuan");

                    b.Navigation("list_DonDatHang");

                    b.Navigation("list_GioHang");

                    b.Navigation("list_SanPhamYeuThich");
                });

            modelBuilder.Entity("API.Data.KhuyenMai", b =>
                {
                    b.Navigation("list_CTKM");
                });

            modelBuilder.Entity("API.Data.LoaiNuoc", b =>
                {
                    b.Navigation("list_SanPham");
                });

            modelBuilder.Entity("API.Data.NguyenLieu", b =>
                {
                    b.Navigation("list_CTPN");

                    b.Navigation("list_PhaChe");
                });

            modelBuilder.Entity("API.Data.NhanVien", b =>
                {
                    b.Navigation("list_DonDatHang");

                    b.Navigation("list_HoaDon");

                    b.Navigation("list_PhieuNhap");
                });

            modelBuilder.Entity("API.Data.PhieuNhap", b =>
                {
                    b.Navigation("list_CTPN");
                });

            modelBuilder.Entity("API.Data.Quyen", b =>
                {
                    b.Navigation("list_NhanVien");
                });

            modelBuilder.Entity("API.Data.SanPham", b =>
                {
                    b.Navigation("list_BinhLuan");

                    b.Navigation("list_CTDDH");

                    b.Navigation("list_CTKM");

                    b.Navigation("list_PhaChe");
                });

            modelBuilder.Entity("API.Data.Shipper", b =>
                {
                    b.Navigation("list_DonDatHang");
                });
#pragma warning restore 612, 618
        }
    }
}