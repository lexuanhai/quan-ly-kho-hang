using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQLKho.Model
{
    public class ChiTietPhieuNhap
    {
        public string MaChiTietPhieuNhap { get; set; }
        public string MaPhieuNhap { get; set; }
        public string MaSanPham { get; set; }
        public string MaPhuTung { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
