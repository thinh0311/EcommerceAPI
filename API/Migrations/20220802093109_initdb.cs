using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CongTyShip",
                columns: table => new
                {
                    MaCongTy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenCongTy = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongTyShip", x => x.MaCongTy);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    MaKM = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.MaKM);
                });

            migrationBuilder.CreateTable(
                name: "LoaiNuoc",
                columns: table => new
                {
                    MaLoaiNuoc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenLoaiNuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiNuoc", x => x.MaLoaiNuoc);
                });

            migrationBuilder.CreateTable(
                name: "NguyenLieu",
                columns: table => new
                {
                    MaNguyenLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNguyenLieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguyenLieu", x => x.MaNguyenLieu);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    MaQuyen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenQuyen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.MaQuyen);
                });

            migrationBuilder.CreateTable(
                name: "Shipper",
                columns: table => new
                {
                    MaShipper = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    MaCongTy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipper", x => x.MaShipper);
                    table.ForeignKey(
                        name: "FK_Shipper_CongTyShip",
                        column: x => x.MaCongTy,
                        principalTable: "CongTyShip",
                        principalColumn: "MaCongTy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaLoaiNuoc = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiNuoc",
                        column: x => x.MaLoaiNuoc,
                        principalTable: "LoaiNuoc",
                        principalColumn: "MaLoaiNuoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    MaQuyen = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanVien_Quyen",
                        column: x => x.MaQuyen,
                        principalTable: "Quyen",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuan",
                columns: table => new
                {
                    MaBinhLuan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayBinhLuan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuan", x => x.MaBinhLuan);
                    table.ForeignKey(
                        name: "FK_BinhLuan_KhachHang",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BinhLuan_SanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTKM",
                columns: table => new
                {
                    MaKM = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhanTramGiam = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKM", x => new { x.MaKM, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_CTKM_KhuyenMai",
                        column: x => x.MaKM,
                        principalTable: "KhuyenMai",
                        principalColumn: "MaKM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTKM_SanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => new { x.MaKH, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_GioHang_KhachHang",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHang_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhaChe",
                columns: table => new
                {
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNguyenLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KhoiLuong = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaChe", x => new { x.MaSanPham, x.MaNguyenLieu });
                    table.ForeignKey(
                        name: "FK_PhaChe_NguyenLieu",
                        column: x => x.MaNguyenLieu,
                        principalTable: "NguyenLieu",
                        principalColumn: "MaNguyenLieu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhaChe_SanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamYeuThich",
                columns: table => new
                {
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamYeuThich", x => new { x.MaSanPham, x.MaKH });
                    table.ForeignKey(
                        name: "FK_SanPhamYeuThich_KhachHang",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamYeuThich_SanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonDatHang",
                columns: table => new
                {
                    MaDonHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiNhan = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MaNV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaShipper = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDatHang", x => x.MaDonHang);
                    table.ForeignKey(
                        name: "FK_DonDatHang_KhachHang",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonDatHang_NhanVien",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                    table.ForeignKey(
                        name: "FK_DonDatHang_Shipper",
                        column: x => x.MaShipper,
                        principalTable: "Shipper",
                        principalColumn: "MaShipper");
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    MaPN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MaNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhap", x => x.MaPN);
                    table.ForeignKey(
                        name: "FK_PhieuNhap_NhanVien",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTDDH",
                columns: table => new
                {
                    MaDonHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTDDH", x => new { x.MaDonHang, x.MaSanPham });
                    table.ForeignKey(
                        name: "FK_CTDDH_DonDatHang",
                        column: x => x.MaDonHang,
                        principalTable: "DonDatHang",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTDDH_SanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaDonHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_DonDatHang",
                        column: x => x.MaDonHang,
                        principalTable: "DonDatHang",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTPN",
                columns: table => new
                {
                    MaPN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNguyenLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KhoiLuong = table.Column<double>(type: "float", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTPN", x => new { x.MaPN, x.MaNguyenLieu });
                    table.ForeignKey(
                        name: "FK_CTPN_NguyenLieu",
                        column: x => x.MaNguyenLieu,
                        principalTable: "NguyenLieu",
                        principalColumn: "MaNguyenLieu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTPN_PhieuNhap",
                        column: x => x.MaPN,
                        principalTable: "PhieuNhap",
                        principalColumn: "MaPN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_MaKH",
                table: "BinhLuan",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_MaSanPham",
                table: "BinhLuan",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_CTDDH_MaSanPham",
                table: "CTDDH",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_CTKM_MaSanPham",
                table: "CTKM",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_CTPN_MaNguyenLieu",
                table: "CTPN",
                column: "MaNguyenLieu");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHang_MaKH",
                table: "DonDatHang",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHang_MaNV",
                table: "DonDatHang",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatHang_MaShipper",
                table: "DonDatHang",
                column: "MaShipper");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_MaSanPham",
                table: "GioHang",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaDonHang",
                table: "HoaDon",
                column: "MaDonHang",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaNV",
                table: "HoaDon",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaQuyen",
                table: "NhanVien",
                column: "MaQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_PhaChe_MaNguyenLieu",
                table: "PhaChe",
                column: "MaNguyenLieu");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaNV",
                table: "PhieuNhap",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaLoaiNuoc",
                table: "SanPham",
                column: "MaLoaiNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamYeuThich_MaKH",
                table: "SanPhamYeuThich",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_Shipper_MaCongTy",
                table: "Shipper",
                column: "MaCongTy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinhLuan");

            migrationBuilder.DropTable(
                name: "CTDDH");

            migrationBuilder.DropTable(
                name: "CTKM");

            migrationBuilder.DropTable(
                name: "CTPN");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "PhaChe");

            migrationBuilder.DropTable(
                name: "SanPhamYeuThich");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "DonDatHang");

            migrationBuilder.DropTable(
                name: "NguyenLieu");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Shipper");

            migrationBuilder.DropTable(
                name: "LoaiNuoc");

            migrationBuilder.DropTable(
                name: "Quyen");

            migrationBuilder.DropTable(
                name: "CongTyShip");
        }
    }
}
