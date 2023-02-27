using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQLKho.Model
{
    public class PhuTung
    {
        public string MaPhuTung { get; set; }
        public string TenPhuTung { get; set; }
        public LoaiPhuTung LoaiPhuTung { get; set; }
        public ThuongHieu ThuongHieu { get; set; }
        public int MaLoaiPhuTung { get; set; }
        public string MaThuongHieu { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
    }
   
}
