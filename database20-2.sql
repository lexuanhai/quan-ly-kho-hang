USE [master]
GO
/****** Object:  Database [WarehouseDatabase]    Script Date: 2/20/2023 6:49:16 AM ******/
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
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 2/20/2023 6:49:17 AM ******/
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
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 2/20/2023 6:49:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSanPham](
	[MaDanhMuc] [char](100) NOT NULL,
	[TenDanhMuc] [nvarchar](250) NULL,
	[TinhTrang] [nvarchar](250) NULL,
	[NgayTao] [date] NULL,
	[NgayUpdate] [date] NULL,
 CONSTRAINT [PK_DanhMucSanPham] PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 2/20/2023 6:49:17 AM ******/
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
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCC]    Script Date: 2/20/2023 6:49:17 AM ******/
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
/****** Object:  Table [dbo].[NhaHieu]    Script Date: 2/20/2023 6:49:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaHieu](
	[MaNhaHieu] [char](100) NOT NULL,
	[TenNhanHieu] [nvarchar](250) NULL,
	[TinhTrang] [nvarchar](250) NULL,
 CONSTRAINT [PK_NhaHieu] PRIMARY KEY CLUSTERED 
(
	[MaNhaHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 2/20/2023 6:49:17 AM ******/
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
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 2/20/2023 6:49:17 AM ******/
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
/****** Object:  Table [dbo].[Quyen]    Script Date: 2/20/2023 6:49:17 AM ******/
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
/****** Object:  Table [dbo].[SanPham]    Script Date: 2/20/2023 6:49:17 AM ******/
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
	[MaNhanHieu] [char](100) NULL,
	[NamSX] [varchar](250) NULL,
	[SoCho] [int] NULL,
	[HopSo] [nvarchar](250) NULL,
	[MauSon] [nvarchar](250) NULL,
	[KieuDang] [nvarchar](250) NULL,
	[NhienLieu] [nvarchar](250) NULL,
	[GiaBan] [decimal](18, 0) NULL,
	[PhanTramGiam] [int] NULL,
	[TinhTrang] [nvarchar](250) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/20/2023 6:49:17 AM ******/
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
	[MaQuyen] [char](100) NULL,
	[TenDangNhap] [varchar](250) NULL,
	[MatKhau] [varchar](250) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[MaUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (N'Q001                                                                                                ', N'Admin', N'Quyền quản trị hệ thống')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (N'Q002                                                                                                ', N'Nhân Viên', N'Quyền dành cho nhân viên ')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (N'Q003                                                                                                ', N'quyền 2', N'dastess')
USE [master]
GO
ALTER DATABASE [WarehouseDatabase] SET  READ_WRITE 
GO
