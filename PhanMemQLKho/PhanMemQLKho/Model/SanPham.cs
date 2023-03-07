using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQLKho.Model
{
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MaDanhMuc { get; set; }
        public string MaNCC { get; set; }
        public string MaNSX { get; set; }
        public string MaThuongHieu { get; set; }
        public int NamSX { get; set; }
        public int SoCho { get; set; }
        public string HopSo { get; set; }
        public string MauSon { get; set; }
        public string KieuDang { get; set; }
        public string NhienLieu { get; set; }
        public string XuatXu { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongBan { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaNhap { get; set; }
        public string BienSo { get; set; }
        public int PhanTramGiam { get; set; }
        public string TinhTrang { get; set; }
        public DateTime NgayNhap { get; set; }
        public int SoLuongCon { get; set; }

    }
}
