﻿using PhanMemQLKho.Model;
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
        //public common _common;
        private void sub_quyen_Click(object sender, EventArgs e)
        {
            common.OpenChildForm(new frmQuanTriHeThong_Quyen(), new frmQuanTriHeThong_Quyen(),panelShowFormChild);
        }
    }
}
