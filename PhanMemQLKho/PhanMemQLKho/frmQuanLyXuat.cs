using PhanMemQLKho.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQLKho
{
    public partial class frmQuanLyXuat : Form
    {
        public frmQuanLyXuat()
        {
            InitializeComponent();
        }     

        private void sub_chi_tiet_phieu_nhap_Click(object sender, EventArgs e)
        {
            common.OpenChildForm(new frmQuanLySanPham_ChiTietPhieuXuat(), new frmQuanLySanPham(), panelShowFormChild);
        }

        private void sub_phieu_nhap_Click(object sender, EventArgs e)
        {
            common.OpenChildForm(new frmQuanLySanPham_PhieuXuat(), new frmQuanLySanPham(), panelShowFormChild);
        }
    }
}
