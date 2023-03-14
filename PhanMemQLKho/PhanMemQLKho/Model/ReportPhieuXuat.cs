using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQLKho.Model
{
    public class ReportPhieuXuat
    {
        public PhieuXuat PhieuXuat { get; set; }
        public ChiTietPhieuXuat ChiTietPhieuXuat { get; set; }
      
        public KhachHang KhachHang { get; set; }
        public List<SanPham> SanPhams { get; set; } = new List<SanPham>();
        public List<PhuTung> PhuTungs { get; set; } = new List<PhuTung>();
    }
}
