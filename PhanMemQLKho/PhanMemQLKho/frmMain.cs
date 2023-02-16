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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ribNguoiDung_Click(object sender, EventArgs e)
        {
            resetForm();
           
            var form = new frmNCC();
            form.TopLevel = false;
            form.Parent = this;
            this.panel1.Controls.Add(form);
            form.Show();
        }
        public void resetForm()
        {
            var controls = this.Controls;
            if (controls != null && controls.Count > 1)
            {
                for (int i = 1; i <= controls.Count; i++)
                {
                    this.Controls.RemoveAt(i);
                }
            }
        }
    }
}
