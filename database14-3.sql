USE [master]
GO
/****** Object:  Database [WarehouseDatabase]    Script Date: 3/14/2023 9:54:54 PM ******/
CREATE DATABASE [WarehouseDatabase] ON  PRIMARY 
( NAME = N'WarehouseDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\WarehouseDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WarehouseDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\WarehouseDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WarehouseDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WarehouseDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WarehouseDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WarehouseDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WarehouseDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WarehouseDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WarehouseDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [WarehouseDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [WarehouseDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WarehouseDatabase] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WarehouseDatabase', N'ON'
GO
USE [WarehouseDatabase]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaChiTietPhieuNhap] [char](100) NOT NULL,
	[MaPhieuNhap] [char](100) NULL,
	[MaSanPham] [char](100) NULL,
	[MaPhuTung] [char](100) NULL,
	[SoLuong] [int] NULL,
	[GiaNhap] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaChiTietPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuXuat]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuXuat](
	[MaChiTietPhieuXuat] [char](100) NOT NULL,
	[MaPhieuXuat] [char](100) NULL,
	[MaSanPham] [char](100) NULL,
	[MaPhuTung] [char](100) NULL,
	[SoLuong] [int] NULL,
	[GiaXuat] [decimal](18, 0) NULL,
	[TongGiaTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietPhieuXuat] PRIMARY KEY CLUSTERED 
(
	[MaChiTietPhieuXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSanPham](
	[MaDanhMuc] [char](100) NOT NULL,
	[TenDanhMuc] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_DanhMucSanPham] PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [char](100) NOT NULL,
	[TenKhachHang] [nvarchar](250) NULL,
	[SoDienThoai] [char](11) NULL,
	[Email] [varchar](250) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[NgaySinh] [datetime] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCC]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCC](
	[MaNCC] [char](100) NOT NULL,
	[TenNCC] [nvarchar](250) NULL,
	[SoDienThoai] [char](11) NULL,
	[Email] [varchar](250) NULL,
	[DiaChi] [nvarchar](500) NULL,
 CONSTRAINT [PK_NhaCC] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[MaSX] [char](100) NOT NULL,
	[TenNSX] [nvarchar](250) NULL,
	[SoDienThoai] [char](11) NULL,
	[Email] [varchar](250) NULL,
	[DiaChi] [nvarchar](250) NULL,
 CONSTRAINT [PK_NhaSanXuat] PRIMARY KEY CLUSTERED 
(
	[MaSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [char](100) NOT NULL,
	[MaNhanVien] [char](100) NULL,
	[NgayNhap] [date] NULL,
	[GhiChu] [nvarchar](250) NULL,
	[TinhTrang] [nvarchar](250) NULL,
	[TrangThai] [nvarchar](250) NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuXuat]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuat](
	[MaPhieuXuat] [char](100) NOT NULL,
	[MaNhanVien] [char](100) NULL,
	[MaKH] [char](100) NULL,
	[NgayXuat] [date] NULL,
	[GhiChu] [nvarchar](500) NULL,
	[LoaiHang] [nvarchar](500) NULL,
	[TrangThai] [nvarchar](250) NULL,
 CONSTRAINT [PK_PhieuXuat] PRIMARY KEY CLUSTERED 
(
	[MaPhieuXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhuTung]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuTung](
	[MaPhuTung] [char](100) NOT NULL,
	[TenPhuTung] [nvarchar](250) NULL,
	[LoaiPhuTung] [int] NULL,
	[MaThuongHieu] [char](100) NULL,
	[SoLuong] [int] NULL,
	[GiaNhap] [decimal](18, 0) NULL,
	[GiaBan] [decimal](18, 0) NULL,
	[SoLuongBan] [int] NULL,
	[SoLuongCon] [int] NULL,
 CONSTRAINT [PK_PhuTung] PRIMARY KEY CLUSTERED 
(
	[MaPhuTung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[MaQuyen] [char](100) NOT NULL,
	[TenQuyen] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [char](100) NOT NULL,
	[TenSanPham] [nvarchar](250) NULL,
	[MaDanhMuc] [char](100) NULL,
	[MaNCC] [char](100) NULL,
	[MaNSX] [char](100) NULL,
	[MaThuongHieu] [char](100) NULL,
	[NamSX] [varchar](250) NULL,
	[SoCho] [int] NULL,
	[HopSo] [nvarchar](250) NULL,
	[MauSon] [nvarchar](250) NULL,
	[KieuDang] [nvarchar](250) NULL,
	[NhienLieu] [nvarchar](250) NULL,
	[XuatXu] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[GiaBan] [decimal](18, 0) NOT NULL,
	[GiaNhap] [decimal](18, 0) NULL,
	[BienSo] [varchar](150) NULL,
	[PhanTramGiam] [int] NULL,
	[TinhTrang] [nvarchar](250) NULL,
	[SoLuongBan] [int] NULL,
	[NgayNhap] [datetime] NULL,
	[NgayXuat] [datetime] NULL,
	[SoLuongCon] [int] NULL,
 CONSTRAINT [PK_SanPham_1] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[MaThuongHieu] [char](100) NOT NULL,
	[TenThuongHieu] [nvarchar](250) NULL,
	[MoTa] [nvarchar](500) NULL,
 CONSTRAINT [PK_NhaHieu] PRIMARY KEY CLUSTERED 
(
	[MaThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/14/2023 9:54:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[MaUser] [char](100) NOT NULL,
	[TenUser] [nvarchar](250) NULL,
	[SoDienThoai] [char](11) NULL,
	[Email] [varchar](250) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[LoaiQuyen] [char](100) NULL,
	[TenDangNhap] [varchar](250) NULL,
	[MatKhau] [varchar](250) NULL,
	[DiaChi] [nvarchar](250) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[MaUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN001                                                                                             ', N'PN001                                                                                               ', N'SP001                                                                                               ', NULL, 20, CAST(40000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN002                                                                                             ', N'PN001                                                                                               ', N'SP002                                                                                               ', NULL, 30, CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN003                                                                                             ', N'PN001                                                                                               ', N'SP003                                                                                               ', NULL, 40, CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN004                                                                                             ', N'PN002                                                                                               ', N'SP004                                                                                               ', NULL, 20, CAST(7000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN005                                                                                             ', N'PN002                                                                                               ', N'SP005                                                                                               ', NULL, 30, CAST(6000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN006                                                                                             ', N'PN003                                                                                               ', N'SP006                                                                                               ', NULL, 30, CAST(6000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN007                                                                                             ', N'PN003                                                                                               ', N'SP007                                                                                               ', NULL, 70, CAST(8000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN008                                                                                             ', N'PN004                                                                                               ', N'SP008                                                                                               ', NULL, 12, CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN009                                                                                             ', N'PN005                                                                                               ', N'SP009                                                                                               ', NULL, 60, CAST(9000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN010                                                                                             ', N'PN006                                                                                               ', NULL, N'PT001                                                                                               ', 60, CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN011                                                                                             ', N'PN006                                                                                               ', NULL, N'PT002                                                                                               ', 65, CAST(800 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN012                                                                                             ', N'PN007                                                                                               ', NULL, N'PT003                                                                                               ', 90, CAST(600 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN013                                                                                             ', N'PN007                                                                                               ', NULL, N'PT004                                                                                               ', 70, CAST(680 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN014                                                                                             ', N'PN008                                                                                               ', NULL, N'PT005                                                                                               ', 22, CAST(900 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN015                                                                                             ', N'PN008                                                                                               ', NULL, N'PT006                                                                                               ', 50, CAST(600 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN016                                                                                             ', N'PN009                                                                                               ', NULL, N'PT007                                                                                               ', 50, CAST(700 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [MaPhuTung], [SoLuong], [GiaNhap]) VALUES (N'CTPN017                                                                                             ', N'PN009                                                                                               ', NULL, N'PT008                                                                                               ', 50, CAST(320 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaSanPham], [MaPhuTung], [SoLuong], [GiaXuat], [TongGiaTien]) VALUES (N'CTPX001                                                                                             ', N'PX001                                                                                               ', N'SP010                                                                                               ', N'PT001                                                                                               ', 2, CAST(40000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaSanPham], [MaPhuTung], [SoLuong], [GiaXuat], [TongGiaTien]) VALUES (N'CTPX002                                                                                             ', N'PX002                                                                                               ', N'SP002                                                                                               ', NULL, 2, CAST(500000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaSanPham], [MaPhuTung], [SoLuong], [GiaXuat], [TongGiaTien]) VALUES (N'CTPX003                                                                                             ', N'PX002                                                                                               ', N'SP003                                                                                               ', NULL, 6, CAST(600000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [GhiChu]) VALUES (N'DM001                                                                                               ', N'Dòng xe bán tải', N'Với lợi thế phí trước bị chỉ 2% cùng sự tiện dụng chời người, chở hàng giúp dòng xe này ngày càng được người tiêu dùng quan tâm.')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [GhiChu]) VALUES (N'DM002                                                                                               ', N'Dòng xe thể thao', N'Xe thể thao trên 2 tỷ đồng: Phân khúc xe thể theo trên hai tỷ đồng với các dòng xe chủ yếu là xe Đức sẽ được cập nhật sớm')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [GhiChu]) VALUES (N'DM003                                                                                               ', N'Dòng xe gầm cao', N'Lợi thế về kiểu dáng gầm cao và rộng rãi phù hợp với điều kiện đường xe')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [GhiChu]) VALUES (N'DM004                                                                                               ', N'Dòng xe cỡ nhỏ', N'Dòng xe cỡ nhỏ được nhiều người tiêu dùng Việt Nam lựa chọn và cũng thường thắc mắc về khả năng vận hành, đi đường trường của dòng xe này')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [GhiChu]) VALUES (N'DM005                                                                                               ', N'Dòng xe sedan', N'Dòng xe sedan có sự trải rộng các mẫu xe cũng như tầm tiền khác nhau. Thường thì ngân sách của người mua xe ')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [GhiChu]) VALUES (N'DM006                                                                                               ', N'Dòng xe Hatchback', N'Dòng xe Hatchback với kiểu dáng đuôi cụt thời trang thu hút khá nhiều sự lựa chọn của mọi người đặc biệt là tại các thành phố lớn. ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKhachHang], [SoDienThoai], [Email], [GioiTinh], [DiaChi], [NgaySinh]) VALUES (N'KH001                                                                                               ', N'Nguyễn Văn Mạnh', N'0345801988 ', N'manh@gmail.com', N'Nam', N'thanh xuân hà nội', CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [TenKhachHang], [SoDienThoai], [Email], [GioiTinh], [DiaChi], [NgaySinh]) VALUES (N'KH002                                                                                               ', N'Lê Thị Hạnh', N'0345801987 ', N'hanh@gmail.com', N'Nữ', N'nguyễn trãi thanh xuân', CAST(N'2022-02-08T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [TenKhachHang], [SoDienThoai], [Email], [GioiTinh], [DiaChi], [NgaySinh]) VALUES (N'KH003                                                                                               ', N'Nguyễn Văn Hưng', N'0345801687 ', N'hung@gmail.com', N'Nam', N'cổ nhuế hà nội', CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [TenKhachHang], [SoDienThoai], [Email], [GioiTinh], [DiaChi], [NgaySinh]) VALUES (N'KH004                                                                                               ', N'Trương Văn Thao', N'0345801652 ', N'thao@gmail.com', N'Nam', N'bà đình hà nội', CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [TenKhachHang], [SoDienThoai], [Email], [GioiTinh], [DiaChi], [NgaySinh]) VALUES (N'KH005                                                                                               ', N'Lê Mỹ Hồng', N'0345801687 ', N'hong@gmail.com', N'Nữ', N'thanh xuân hà nội', CAST(N'2023-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC001                                                                                              ', N'Xe Chuyên Dụng Cao Thanh Đạt', N'0985452109 ', N'sales@caothanhdat.com', N'Số 1 Cầu Bây, P. Phúc Lợi, Q. Long Biên, Hà Nội')
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC002                                                                                              ', N'Công ty Cổ Phần Xuất Nhập Khẩu An Phú Thành', N'0983565666 ', N'info@apt-auto.vn', N'56 Tố Hữu, P. Trung Văn, Q. Nam Từ Liêm, Hà Nội')
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC003                                                                                              ', N'Công Ty TNHH ô Tô Cheng Long', N'0985800200 ', N'hanguyen428@gmail.com', N'Đường Võ Nguyên Giáp, Phước Tân, Biên Hòa, Đồng Nai')
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC004                                                                                              ', N'Công Ty Cổ Phần HD Care', N'0767115115 ', N'ctyhdcare@gmail.com', N'700 Lê Hồng Phong, P. 12, Q. 10, Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC005                                                                                              ', N'Sabaco - CN Công Ty TNHH Ô Tô', N'02837261418', N'nguyenthuyvan@sabaco.vn', N'Số 325, QL 13, P. Hiệp Bình Phước, Q. Thủ Đức, Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC006                                                                                              ', N'Ô Tô Trường Long', N'02837543188', N'info@truonglong.com', N'KCN Tân Tạo, Lô 46, Đường Số 3, P. Tân Tạo A, Q. Bình Tân, Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC007                                                                                              ', N'Công Ty TNHH Thế Giới Xe Tải', N'0902888444 ', N'xetaimiennam@gmail.com', N'Số 62 Tân Thới Hiệp 07, KP. 3, P. Tân Thới Hiệp, Q. 12, TP. HCM')
INSERT [dbo].[NhaSanXuat] ([MaSX], [TenNSX], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NSX001                                                                                              ', N'Toyota Motor Coporation', N'1800 1524  ', N'tmv_cs@toyota.com.vn', N'Nhật Bản')
INSERT [dbo].[NhaSanXuat] ([MaSX], [TenNSX], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NSX002                                                                                              ', N'Volkswagen', N'1800 1523  ', N'volkswagen@gmail.com', N'Đức')
INSERT [dbo].[NhaSanXuat] ([MaSX], [TenNSX], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NSX003                                                                                              ', N'Daimler AG', N'1800 400110', N'daimlerag', N'Đức')
INSERT [dbo].[NhaSanXuat] ([MaSX], [TenNSX], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NSX004                                                                                              ', N'Honda Motor', N'1800 8001  ', N'hondamotor', N'Nhật Bản')
INSERT [dbo].[NhaSanXuat] ([MaSX], [TenNSX], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NSX005                                                                                              ', N'Bayerische Motoren Werke AG', N'1900 8235  ', N'bayerisch@gmail.com', N'Đức')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [NgayNhap], [GhiChu], [TinhTrang], [TrangThai]) VALUES (N'PN001                                                                                               ', N'User001                                                                                             ', CAST(N'2023-02-11' AS Date), N'', N'Hàng Mới', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [NgayNhap], [GhiChu], [TinhTrang], [TrangThai]) VALUES (N'PN002                                                                                               ', N'User002                                                                                             ', CAST(N'2023-03-08' AS Date), N'', N'Hàng Mới', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [NgayNhap], [GhiChu], [TinhTrang], [TrangThai]) VALUES (N'PN003                                                                                               ', N'User003                                                                                             ', CAST(N'2023-03-13' AS Date), N'', N'Hàng Mới', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [NgayNhap], [GhiChu], [TinhTrang], [TrangThai]) VALUES (N'PN004                                                                                               ', N'User004                                                                                             ', CAST(N'2023-03-09' AS Date), N'', N'Hàng Cũ', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [NgayNhap], [GhiChu], [TinhTrang], [TrangThai]) VALUES (N'PN005                                                                                               ', N'User004                                                                                             ', CAST(N'2023-03-10' AS Date), N'', N'Hàng Mới', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [NgayNhap], [GhiChu], [TinhTrang], [TrangThai]) VALUES (N'PN006                                                                                               ', N'User001                                                                                             ', CAST(N'2023-03-06' AS Date), N'', N'Phụ Tùng', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [NgayNhap], [GhiChu], [TinhTrang], [TrangThai]) VALUES (N'PN007                                                                                               ', N'User002                                                                                             ', CAST(N'2023-03-09' AS Date), N'', N'Phụ Tùng', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [NgayNhap], [GhiChu], [TinhTrang], [TrangThai]) VALUES (N'PN008                                                                                               ', N'User003                                                                                             ', CAST(N'2023-03-10' AS Date), N'', N'Phụ Tùng', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [NgayNhap], [GhiChu], [TinhTrang], [TrangThai]) VALUES (N'PN009                                                                                               ', N'User001                                                                                             ', CAST(N'2023-03-05' AS Date), N'', N'Phụ Tùng', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaNhanVien], [MaKH], [NgayXuat], [GhiChu], [LoaiHang], [TrangThai]) VALUES (N'PX001                                                                                               ', N'User001                                                                                             ', N'KH001                                                                                               ', CAST(N'2023-03-11' AS Date), N'', N'Sửa Chữa', N'Đã Hoàn Thành')
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaNhanVien], [MaKH], [NgayXuat], [GhiChu], [LoaiHang], [TrangThai]) VALUES (N'PX002                                                                                               ', N'User002                                                                                             ', N'KH002                                                                                               ', CAST(N'2023-03-11' AS Date), N'', N'Hàng Mới', N'Đã Hoàn Thành')
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [GiaNhap], [GiaBan], [SoLuongBan], [SoLuongCon]) VALUES (N'PT001                                                                                               ', N'Phuộc nhún trước Lexus T300H', 2, N'TH001                                                                                               ', 60, CAST(5000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), 2, 58)
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [GiaNhap], [GiaBan], [SoLuongBan], [SoLuongCon]) VALUES (N'PT002                                                                                               ', N'Giảm xóc trước', 2, N'TH002                                                                                               ', 115, CAST(800 AS Decimal(18, 0)), CAST(4500 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [GiaNhap], [GiaBan], [SoLuongBan], [SoLuongCon]) VALUES (N'PT003                                                                                               ', N'Công tắc điều hòa', 3, N'TH001                                                                                               ', 120, CAST(600 AS Decimal(18, 0)), CAST(700 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [GiaNhap], [GiaBan], [SoLuongBan], [SoLuongCon]) VALUES (N'PT004                                                                                               ', N'Cáp còi RX350', 3, N'TH001                                                                                               ', 70, CAST(680 AS Decimal(18, 0)), CAST(800 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [GiaNhap], [GiaBan], [SoLuongBan], [SoLuongCon]) VALUES (N'PT005                                                                                               ', N'Giá bắt biển số Prado', 4, N'TH004                                                                                               ', 22, CAST(900 AS Decimal(18, 0)), CAST(9000 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [GiaNhap], [GiaBan], [SoLuongBan], [SoLuongCon]) VALUES (N'PT006                                                                                               ', N'Giàn lạnh Mazda ', 4, N'TH004                                                                                               ', 50, CAST(600 AS Decimal(18, 0)), CAST(5000 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [GiaNhap], [GiaBan], [SoLuongBan], [SoLuongCon]) VALUES (N'PT007                                                                                               ', N'Dây curoa cam ', 1, N'TH004                                                                                               ', 50, CAST(700 AS Decimal(18, 0)), CAST(6000 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [GiaNhap], [GiaBan], [SoLuongBan], [SoLuongCon]) VALUES (N'PT008                                                                                               ', N'Cút nước dưới Innova ', 1, N'TH004                                                                                               ', 50, CAST(320 AS Decimal(18, 0)), CAST(4000 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (N'Q001                                                                                                ', N'Admin', N'Quyền quản trị hệ thống')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (N'Q002                                                                                                ', N'Nhân Viên', N'Quyền dành cho nhân viên ')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (N'Q003                                                                                                ', N'quyền 2', N'dastess')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP001                                                                                               ', N'Auto86 cực mới', N'DM005                                                                                               ', N'NCC001                                                                                              ', N'NSX001                                                                                              ', N'TH001                                                                                               ', N'2011', 5, N'Tự động', N'Trắng', N'Sedan', N'Xăng', NULL, 60, CAST(2000000 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), N'', 0, N'Mới', NULL, NULL, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP002                                                                                               ', N'TOYOTA FORTUNER 2.4c 2020', N'DM002                                                                                               ', N'NCC002                                                                                              ', N'NSX001                                                                                              ', N'TH001                                                                                               ', N'2020', 5, N'Tự động', N'Xám', N'SUV / Cross over', N'Dầu', NULL, 60, CAST(500000 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)), N'', 0, N'Mới', 2, NULL, NULL, 58)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP003                                                                                               ', N'Auto86 bán Audi A8L', N'DM005                                                                                               ', N'NCC002                                                                                              ', N'NSX004                                                                                              ', N'TH004                                                                                               ', N'2018', 5, N'Tự động', N'Đen', N'Sedan', N'Xăng', NULL, 80, CAST(600000 AS Decimal(18, 0)), CAST(5000 AS Decimal(18, 0)), N'', 0, N'Mới', 6, NULL, NULL, 74)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP004                                                                                               ', N'Toyota Camry 2.5Q sx 2019', N'DM005                                                                                               ', N'NCC002                                                                                              ', N'NSX004                                                                                              ', N'TH004                                                                                               ', N'2019', 5, N'Tự động', N'Đen', N'Xăng', N'Sedan', NULL, 20, CAST(400000 AS Decimal(18, 0)), CAST(7000 AS Decimal(18, 0)), N'', 0, N'Mới', NULL, NULL, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP005                                                                                               ', N'HONDA CIVIC G RS XÁM', N'DM006                                                                                               ', N'NCC005                                                                                              ', N'NSX004                                                                                              ', N'TH004                                                                                               ', N'2023', 5, N'Tự động', N'Xám', N'Sedan', N'Xăng', NULL, 30, CAST(60000 AS Decimal(18, 0)), CAST(6000 AS Decimal(18, 0)), N'', 0, N'Mới', NULL, NULL, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP006                                                                                               ', N'HONDA HRV G 2023', N'DM005                                                                                               ', N'NCC005                                                                                              ', N'NSX001                                                                                              ', N'TH001                                                                                               ', N'2023', 5, N'Tự động', N'Trắng', N'UV / Cross over', N'Xăng', NULL, 30, CAST(70000 AS Decimal(18, 0)), CAST(6000 AS Decimal(18, 0)), N'', 0, N'Mới', NULL, NULL, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP007                                                                                               ', N'HONDA HRV L 19', N'DM002                                                                                               ', N'NCC005                                                                                              ', N'NSX004                                                                                              ', N'TH004                                                                                               ', N'2019', 5, N'Tự động', N'Trắng', N'UV / Cross over', N'Xăng', NULL, 70, CAST(70000 AS Decimal(18, 0)), CAST(8000 AS Decimal(18, 0)), N'', 0, N'Mới', NULL, NULL, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP008                                                                                               ', N'HYUNDAI ELANTRA 2.0 SX 21', N'DM005                                                                                               ', N'NCC005                                                                                              ', N'NSX004                                                                                              ', N'TH004                                                                                               ', N'2021', 5, N'Tự động', N'Trắng', N'Sedan', N'Xăng', NULL, 12, CAST(80000 AS Decimal(18, 0)), CAST(5000 AS Decimal(18, 0)), N'29A-999.99', 0, N'Mới', NULL, NULL, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP009                                                                                               ', N'PEUGEOT 3008 SZ 21', N'DM003                                                                                               ', N'NCC004                                                                                              ', N'NSX002                                                                                              ', N'TH002                                                                                               ', N'2021', 5, N'Tự động', N'Trắng', N'SUV / Cross over', N'Xăng', NULL, 60, CAST(60000 AS Decimal(18, 0)), CAST(9000 AS Decimal(18, 0)), N'', 0, N'Mới', NULL, NULL, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang], [SoLuongBan], [NgayNhap], [NgayXuat], [SoLuongCon]) VALUES (N'SP010                                                                                               ', N'Mazada', N'DM001                                                                                               ', N'NCC001                                                                                              ', N'NSX001                                                                                              ', N'TH001                                                                                               ', N'2020', 5, N'tự động', N'trắng', N'UX', N'Xăng', NULL, NULL, CAST(0 AS Decimal(18, 0)), NULL, N'29A.888.88', 0, N'Sửa Chữa', NULL, NULL, NULL, NULL)
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa]) VALUES (N'TH001                                                                                               ', N'Toyota', N'Toyota Motor Corporation là một công ty đa quốc gia có trụ sở tại Nhật Bản')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa]) VALUES (N'TH002                                                                                               ', N'Volkswagen', N'Là một trong những hãng sản xuất xe ô tô lớn nhất thế và rất nổi tiếng tại Đức. ')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa]) VALUES (N'TH003                                                                                               ', N'Daimler AG', N' Daimler AG  là một công ty sản xuất ô tô của Đức và là nhà sản xuất ô tô lớn thứ 13 thế giới. ')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa]) VALUES (N'TH004                                                                                               ', N'Honda', N'Honda là nhà sản xuất động cơ lớn nhất thế giới với số lượng hơn 14 triệu chiếc/năm,')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa]) VALUES (N'TH005                                                                                               ', N'BMW', N'Là tên viết tắt của “Bayerische Motoren Werke AG” một công xưởng cơ khí Bayern, BMW là một công  ty sản xuất xe gắn máy và xe ô tô quan trọng của nước Đức.')
INSERT [dbo].[User] ([MaUser], [TenUser], [SoDienThoai], [Email], [GioiTinh], [NgaySinh], [LoaiQuyen], [TenDangNhap], [MatKhau], [DiaChi]) VALUES (N'User001                                                                                             ', N'Lê Xuân Hải', N'0345801653 ', N'hailx@gmail.com', N'Nam', CAST(N'2023-03-08' AS Date), N'Admin                                                                                               ', N'hailx', N'123456789', N'hà nội')
INSERT [dbo].[User] ([MaUser], [TenUser], [SoDienThoai], [Email], [GioiTinh], [NgaySinh], [LoaiQuyen], [TenDangNhap], [MatKhau], [DiaChi]) VALUES (N'User002                                                                                             ', N'Lại Thanh Bình', N'034581986  ', N'binh@gmail.com', N'Nam', CAST(N'2023-03-08' AS Date), N'Nhân Viên                                                                                           ', N'binhlt', N'123456789', N'hà đông hà nội')
INSERT [dbo].[User] ([MaUser], [TenUser], [SoDienThoai], [Email], [GioiTinh], [NgaySinh], [LoaiQuyen], [TenDangNhap], [MatKhau], [DiaChi]) VALUES (N'User003                                                                                             ', N'Nguyễn Văn Hiếu', N'0345801982 ', N'hieu@gmail.com', N'Nam', CAST(N'2023-03-08' AS Date), N'Nhân Viên                                                                                           ', N'hieunv', N'123456789', N'nguyễn trãi hà nội')
INSERT [dbo].[User] ([MaUser], [TenUser], [SoDienThoai], [Email], [GioiTinh], [NgaySinh], [LoaiQuyen], [TenDangNhap], [MatKhau], [DiaChi]) VALUES (N'User004                                                                                             ', N'Nguyễn Thị Huyền', N'0345801986 ', N'huyen@gmail.com', N'Nữ', CAST(N'2023-03-08' AS Date), N'Nhân Viên                                                                                           ', N'huyennt', N'123456789', N'phùng khoang hà nội')
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhuTung] FOREIGN KEY([MaPhuTung])
REFERENCES [dbo].[PhuTung] ([MaPhuTung])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhuTung]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_SanPham]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuXuat_PhieuXuat] FOREIGN KEY([MaPhieuXuat])
REFERENCES [dbo].[PhieuXuat] ([MaPhieuXuat])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK_ChiTietPhieuXuat_PhieuXuat]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuXuat_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK_ChiTietPhieuXuat_SanPham]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_User] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[User] ([MaUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_User]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK_PhieuXuat_KhachHang]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_User] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[User] ([MaUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK_PhieuXuat_User]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DanhMucSanPham] FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMucSanPham] ([MaDanhMuc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_DanhMucSanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaCC] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCC] ([MaNCC])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaCC]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaSanXuat] FOREIGN KEY([MaNSX])
REFERENCES [dbo].[NhaSanXuat] ([MaSX])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaSanXuat]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ThuongHieu] FOREIGN KEY([MaThuongHieu])
REFERENCES [dbo].[ThuongHieu] ([MaThuongHieu])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_ThuongHieu]
GO
USE [master]
GO
ALTER DATABASE [WarehouseDatabase] SET  READ_WRITE 
GO
