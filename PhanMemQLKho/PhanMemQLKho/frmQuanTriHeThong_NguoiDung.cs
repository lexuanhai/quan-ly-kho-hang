using PhanMemQLKho.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQLKho
{
    public partial class frmQuanTriHeThong_NguoiDung : Form
    {
        public frmQuanTriHeThong_NguoiDung()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        public void LoadData(string query = "")
        {
           
            if (string.IsNullOrEmpty(query))
            {
                query = "select [MaUser] ,[TenUser] ,[TenDangNhap],[LoaiQuyen],[GioiTinh] ,[NgaySinh] ,[Email]  ,[SoDienThoai] ,[DiaChi] from [User]";
            }
            
            common.LoadData(query, dataGRV);
        }
        public NguoiDung GetValue()
        {
            var model = new NguoiDung();
            model.MaUser = txtMa.Text;
            model.TenDangNhap = txtTenDangNhap.Text;
            model.TenUser = txtTenUser.Text;
            model.SoDienThoai = txtSoDienThoai.Text;
            model.Email = txtEmail.Text;
            model.GioiTinh = cmbGioiTinh.SelectedItem.ToString();
            model.LoaiQuyen = cmbLoaiQuyen.SelectedItem.ToString();
            model.NgaySinh = dateTimeNgaySinh.Value;
            model.TenDangNhap = txtTenDangNhap.Text;
            model.MatKhau = txtMatKhau.Text;
            model.DiaChi = txtDiaChi.Text;
            return model;
        }
        public void SetValue(NguoiDung model)
        {
            txtMa.Text = model.MaUser;
            txtTenDangNhap.Text = model.TenDangNhap;
            txtTenUser.Text = model.TenUser;
            txtSoDienThoai.Text = model.SoDienThoai;
            txtEmail.Text = model.Email;
            cmbGioiTinh.SelectedText = model.GioiTinh;
            dateTimeNgaySinh.Value = model.NgaySinh;
            txtTenDangNhap.Text = model.TenDangNhap;
            txtMatKhau.Text = model.MatKhau;
            txtDiaChi.Text = model.DiaChi;
        }
        public void SetControl(string edit)
        {
            if (edit == "add")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                SetControlValue(true);
            }
            if (edit == "table-click")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;              
            }
            if (edit == "edit")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
                SetControlValue(true);
            }
            if (edit == "load")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                SetControlValue(false);
            }
        }
        public void SetControlValue(bool edit)
        {
            if (edit)
            {                              
                txtTenDangNhap.Enabled = true;
                txtTenUser.Enabled = true;
                txtSoDienThoai.Enabled = true;
                txtEmail.Enabled = true;
                cmbGioiTinh.Enabled = true;
                dateTimeNgaySinh.Enabled = true;
                txtTenDangNhap.Enabled = true;
                txtMatKhau.Enabled = true;
                txtDiaChi.Enabled = true;
            }
            else
            {
                txtMa.Text = "";
                txtTenDangNhap.Text = "";
                txtTenUser.Text = "";
                txtSoDienThoai.Text = "";
                txtEmail.Text = "";
                cmbGioiTinh.Text = "";
                dateTimeNgaySinh.Text = "";
                txtTenDangNhap.Text = "";
                txtMatKhau.Text = "";
                txtDiaChi.Text = "";
            }

        }
        private void Xoa()
        {
            if (!string.IsNullOrEmpty(txtMa.Text))
            {
                DialogResult dlr;
                dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM [User] WHERE MaUser='" + txtMa.Text + "'";
                        var status = common.thucthidulieu(query);
                        if (status)
                        {
                            MessageBox.Show("Xóa thành công.", "Thông Báo");
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại.", "Thông Báo");
                        }

                        LoadData();
                        SetControl("load");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa thất bại.", "Thông Báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã nhà sản xuất.", "Thông Báo");
            }
        }
        private void frmQuanTriHeThong_NguoiDung_Load(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            LoadData();
            SetControl("load");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetControl("add");
            xuly = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuly = 2;
            SetControlValue(true);
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }
        public void UpdataDatabase()
        {
            var model = GetValue();
            string qry = "Update [User] set " +
                "TenUser =N'" + model.TenUser.Trim() + "', " +
                "SoDienThoai ='" + model.SoDienThoai.Trim() + "', " +
                "Email ='" + model.Email.Trim() + "', " +
                "GioiTinh =N'" + model.GioiTinh.Trim() + "', " +
                "LoaiQuyen =N'" + model.LoaiQuyen.Trim() + "', " +
                "TenDangNhap ='" + model.TenDangNhap.Trim() + "', " +
                "MatKhau ='" + model.MatKhau.Trim() + "', " +
                "DiaChi =N'" + model.DiaChi.Trim() + "'" +
                " Where MaUser='" + model.MaUser + "'";
            var status = common.thucthidulieu(qry);
            if (status)
            {
                MessageBox.Show("Sửa thành công.");
            }
            else
            {
                MessageBox.Show("Sửa không thành công.");
            }
        }

        private void ThemMoi()
        {
            try
            {
                var model = GetValue();
                string ma = common.tangMaTuDong("User", "User");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into [User]("+
                    "MaUser, " +
                    "TenUser, " +
                    "SoDienThoai, " +
                    "Email, " +
                    "GioiTinh, " +
                    "NgaySinh, " +
                    "LoaiQuyen, " +
                    "TenDangNhap, " +
                    "MatKhau, " +
                    "DiaChi ) values('" + ma.Trim() + "'," +
                    "N'" + model.TenUser.Trim() + "" +
                    "','" + model.SoDienThoai.Trim() + "'" +
                    ",'" + model.Email.Trim() + "'" +
                    ",N'" + model.GioiTinh.Trim() + "'" +
                    ",'" + model.NgaySinh.ToString("yyyy-MM-dd") + "'" +
                    ",N'" + model.LoaiQuyen.Trim() + "'" +
                    ",'" + model.TenDangNhap.Trim() + "'" +
                    ",'" + model.MatKhau.Trim() + "'" +
                    ",N'" + model.DiaChi.Trim() + "'" +
                    ")";
                    var status = common.thucthidulieu(qry);
                    if (status)
                    {
                        MessageBox.Show("Thêm mới thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới không thành công.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm mới không thành công.");
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (xuly == 1)
            {

                ThemMoi();
            }
            else if (xuly == 2)
            {
                UpdataDatabase();
            }
            xuly = 0;
            LoadData();
            SetControl("load");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuly = 0;
            SetControl("load");
            SetControlValue(false);
        }
        public void search()
        {

            if (radioMa.Checked)
            {
                string timkiem = "select [MaUser] ,[TenUser] ,[TenDangNhap],[LoaiQuyen],[GioiTinh] ,[NgaySinh] ,[Email]  ,[SoDienThoai] ,[DiaChi] from [User] where MaUser like '%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTen.Checked)
            {
                string timkiem = "select [MaUser] ,[TenUser] ,[TenDangNhap],[LoaiQuyen],[GioiTinh] ,[NgaySinh] ,[Email]  ,[SoDienThoai] ,[DiaChi] from [User] where TenUser like N'%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }    

        private void dataGRV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGRV.CurrentRow.Cells[0].Value.ToString();
            txtTenUser.Text = dataGRV.CurrentRow.Cells[1].Value.ToString();
            txtTenDangNhap.Text = dataGRV.CurrentRow.Cells[2].Value.ToString();
            cmbLoaiQuyen.SelectedItem = dataGRV.CurrentRow.Cells[3].Value.ToString().Trim();
            cmbGioiTinh.SelectedItem = dataGRV.CurrentRow.Cells[4].Value.ToString().Trim();
            dateTimeNgaySinh.Value = Convert.ToDateTime(dataGRV.CurrentRow.Cells[5].Value.ToString());
            txtEmail.Text = dataGRV.CurrentRow.Cells[6].Value.ToString();
            txtSoDienThoai.Text = dataGRV.CurrentRow.Cells[7].Value.ToString();
            txtDiaChi.Text = dataGRV.CurrentRow.Cells[8].Value.ToString();
            SetControl("table-click");
        }

        private void btnLoadDS_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
