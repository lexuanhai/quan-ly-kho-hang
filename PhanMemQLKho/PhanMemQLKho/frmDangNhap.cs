using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using PhanMemQLKho.Model;

namespace PhanMemQLKho
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
       // common common = new Common();
        private SqlConnection myConnection;
        private SqlCommand myCommand;

        private void DongForm(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        public NguoiDung GetUser(string tendangnhap, string matkhau)
        {
            DataTable dt;
            string query = "select * from [User] where TenDangNhap='"+ tendangnhap + "' and MatKhau ='"+ matkhau + "'";
            dt = common.docdulieu(query);
            var model = new NguoiDung();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model.TenUser = dr["TenUser"].ToString();
                    model.LoaiQuyen = dr["LoaiQuyen"].ToString();
                }
            }
            return model;
        }

        // Phương thức kiểm tra TKDG

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Length > 0 && txtMatKhau.Text.Length > 0)
            {
                try
                {
                    var data = GetUser(txtTenDangNhap.Text, txtMatKhau.Text);
                    if (data != null && !string.IsNullOrEmpty(data.TenUser))
                    {
                        LoginInfo.TenUser = data.TenUser;
                        LoginInfo.LoaiQuyen = data.LoaiQuyen;
                        MessageBox.Show("Đăng Nhập thành công.", "Thông Báo");
                        MainView GiaoDienChinh = new MainView();
                        GiaoDienChinh.FormClosed += new FormClosedEventHandler(DongForm);
                        this.Hide();
                        GiaoDienChinh.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai Tên Đăng Nhập hoặc Mật Khẩu.\nVui lòng nhập lại.", "Thông Báo");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Tài Khoản và Mật Khẩu.", "Thông Báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn chắc chắn muốn thoát.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                this.Close();
            }
        }

    }
}
