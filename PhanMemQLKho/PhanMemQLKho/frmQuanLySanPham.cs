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
    public partial class frmQuanLySanPham : Form
    {
        public frmQuanLySanPham()
        {
            InitializeComponent();
        }
        private void sub_san_pham_Click(object sender, EventArgs e)
        {
            
        }

        private void sub_danh_muc_Click(object sender, EventArgs e)
        {
            common.OpenChildForm(new frmQuanLySanPham_DanhMuc(), new frmQuanLySanPham(), panelShowFormChild);
        }

        private void sub_nhan_hieu_Click(object sender, EventArgs e)
        {
            common.OpenChildForm(new frmQuanLySanPham_ThuongHieu(), new frmQuanLySanPham(), panelShowFormChild);
        }
    }
}
