USE [master]
GO
/****** Object:  Database [WarehouseDatabase]    Script Date: 2/27/2023 7:15:32 AM ******/
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
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 2/27/2023 7:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaChiTietPhieuNhap] [char](100) NOT NULL,
	[MaPhieuNhap] [char](100) NULL,
	[MaSanPham] [char](100) NULL,
	[SoLuong] [int] NULL,
	[GiaNhap] [decimal](18, 0) NULL,
	[TongGiaTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaChiTietPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 2/27/2023 7:15:33 AM ******/
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
/****** Object:  Table [dbo].[KhachHang]    Script Date: 2/27/2023 7:15:33 AM ******/
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
/****** Object:  Table [dbo].[NhaCC]    Script Date: 2/27/2023 7:15:33 AM ******/
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
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 2/27/2023 7:15:33 AM ******/
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
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 2/27/2023 7:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [char](100) NOT NULL,
	[MaNhanVien] [char](100) NULL,
	[NgayNhap] [date] NULL,
	[SoLuong] [int] NULL,
	[TongTien] [decimal](18, 0) NULL,
	[TinhTrang] [nvarchar](250) NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhuTung]    Script Date: 2/27/2023 7:15:33 AM ******/
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
	[Gia] [decimal](18, 0) NULL,
 CONSTRAINT [PK_PhuTung] PRIMARY KEY CLUSTERED 
(
	[MaPhuTung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 2/27/2023 7:15:33 AM ******/
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
/****** Object:  Table [dbo].[SanPham]    Script Date: 2/27/2023 7:15:33 AM ******/
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
 CONSTRAINT [PK_SanPham_1] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 2/27/2023 7:15:33 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 2/27/2023 7:15:33 AM ******/
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
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [GhiChu]) VALUES (N'DM001                                                                                               ', N'Danh mục 1', N'fdasfs')
INSERT [dbo].[DanhMucSanPham] ([MaDanhMuc], [TenDanhMuc], [GhiChu]) VALUES (N'DM002                                                                                               ', N'Danh mục 2', N'4444')
INSERT [dbo].[KhachHang] ([MaKH], [TenKhachHang], [SoDienThoai], [Email], [GioiTinh], [DiaChi], [NgaySinh]) VALUES (N'KH001                                                                                               ', N'Lê Xuân Hải332', N'423        ', N'4324', N'Nữ', N'hà nội', CAST(N'2023-02-22T00:00:00.000' AS DateTime))
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC001                                                                                              ', N'NCC 1', N'432        ', N'432', N'432')
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC002                                                                                              ', N'NCC 2', N'3423       ', N'432', N'432')
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NCC003                                                                                              ', N'NCC 3', N'23         ', N'32', N'32')
INSERT [dbo].[NhaSanXuat] ([MaSX], [TenNSX], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NSX001                                                                                              ', N'NSX 1', N'322        ', N'32', N'32')
INSERT [dbo].[NhaSanXuat] ([MaSX], [TenNSX], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NSX002                                                                                              ', N'NSX 2', N'333        ', N'333', N'333')
INSERT [dbo].[NhaSanXuat] ([MaSX], [TenNSX], [SoDienThoai], [Email], [DiaChi]) VALUES (N'NSX003                                                                                              ', N'NSX 3', N'444        ', N'444', N'444')
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [Gia]) VALUES (N'PT001                                                                                               ', N'Phụ Tùng 1', 1, N'TH001                                                                                               ', 1, CAST(111111 AS Decimal(18, 0)))
INSERT [dbo].[PhuTung] ([MaPhuTung], [TenPhuTung], [LoaiPhuTung], [MaThuongHieu], [SoLuong], [Gia]) VALUES (N'PT002                                                                                               ', N'Phụ tùng 2', 2, N'TH002                                                                                               ', 222, CAST(3333 AS Decimal(18, 0)))
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (N'Q001                                                                                                ', N'Admin', N'Quyền quản trị hệ thống')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (N'Q002                                                                                                ', N'Nhân Viên', N'Quyền dành cho nhân viên ')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (N'Q003                                                                                                ', N'quyền 2', N'dastess')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaDanhMuc], [MaNCC], [MaNSX], [MaThuongHieu], [NamSX], [SoCho], [HopSo], [MauSon], [KieuDang], [NhienLieu], [XuatXu], [SoLuong], [GiaBan], [GiaNhap], [BienSo], [PhanTramGiam], [TinhTrang]) VALUES (N'SP001                                                                                               ', N'sản phẩm 1', N'DM001                                                                                               ', N'NCC001                                                                                              ', N'NSX001                                                                                              ', N'TH001                                                                                               ', N'2020', 4, N'tự động', N'trắng', N'ds', N'fdsa', N'fdsa', 3, CAST(44444 AS Decimal(18, 0)), CAST(3333 AS Decimal(18, 0)), NULL, 0, N'Mới')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa]) VALUES (N'TH001                                                                                               ', N'Thương hiệu 1', N'111')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa]) VALUES (N'TH002                                                                                               ', N'Thương hiệu 2', N'2222')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa]) VALUES (N'TH003                                                                                               ', N'Thương hiệu 3', N'3333')
INSERT [dbo].[User] ([MaUser], [TenUser], [SoDienThoai], [Email], [GioiTinh], [NgaySinh], [LoaiQuyen], [TenDangNhap], [MatKhau], [DiaChi]) VALUES (N'User002                                                                                             ', N'456543333', N'4654       ', N'465', N'Nữ', CAST(N'2023-02-07' AS Date), N'Nhân Viên                                                                                           ', N'45', N'', N'4654')
INSERT [dbo].[User] ([MaUser], [TenUser], [SoDienThoai], [Email], [GioiTinh], [NgaySinh], [LoaiQuyen], [TenDangNhap], [MatKhau], [DiaChi]) VALUES (N'User003                                                                                             ', N'hailx', N'324234     ', N'423', N'Nam', CAST(N'2023-02-21' AS Date), N'Admin                                                                                               ', N'rewrew', N'rew', N'2342')
USE [master]
GO
ALTER DATABASE [WarehouseDatabase] SET  READ_WRITE 
GO
