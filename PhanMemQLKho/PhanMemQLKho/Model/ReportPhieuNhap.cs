using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQLKho.Model
{
    public class ReportPhieuNhap
    {
        public PhieuNhap PhieuNhap { get; set; }
        public ChiTietPhieuNhap ChiTietPhieuNhap { get; set; }
      
        public NguoiDung NhanVien { get; set; }
        public List<SanPham> SanPhams { get; set; } = new List<SanPham>();
        public List<PhuTung> PhuTungs { get; set; } = new List<PhuTung>();
    }
}
