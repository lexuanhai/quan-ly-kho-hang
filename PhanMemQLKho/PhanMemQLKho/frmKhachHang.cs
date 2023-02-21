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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        public void LoadData(string query = "")
        {
           
            if (string.IsNullOrEmpty(query))
            {
                query = "SELECT [MaKH] ,[TenKhachHang] ,[GioiTinh] ,[NgaySinh] ,[Email] ,[SoDienThoai] ,[DiaChi] FROM [KhachHang]";
            }
            
            common.LoadData(query, dataGRV);
        }
        public KhachHang GetValue()
        {
            var model = new KhachHang();
            model.MaKhachHang = txtMa.Text;
            model.TenKhachHang = txtTenUser.Text;
            model.SoDienThoai = txtSoDienThoai.Text;
            model.Email = txtEmail.Text;
            model.GioiTinh = cmbGioiTinh.SelectedItem.ToString();
            model.NgaySinh = dateTimeNgaySinh.Value;
            model.DiaChi = txtDiaChi.Text;
            return model;
        }
        public void SetValue(KhachHang model)
        {
            txtMa.Text = model.MaKhachHang;
            txtTenUser.Text = model.TenKhachHang;
            txtSoDienThoai.Text = model.SoDienThoai;
            txtEmail.Text = model.Email;
            cmbGioiTinh.SelectedText = model.GioiTinh;
            dateTimeNgaySinh.Value = model.NgaySinh;
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
                txtTenUser.Enabled = true;
                txtSoDienThoai.Enabled = true;
                txtEmail.Enabled = true;
                cmbGioiTinh.Enabled = true;
                dateTimeNgaySinh.Enabled = true;
                txtDiaChi.Enabled = true;
            }
            else
            {
                txtMa.Text = "";
                txtTenUser.Text = "";
                txtSoDienThoai.Text = "";
                txtEmail.Text = "";
                cmbGioiTinh.Text = "";
                dateTimeNgaySinh.Text = "";
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
                        string query = "DELETE FROM [KhachHang] WHERE [MaKH]='" + txtMa.Text + "'";
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
            string qry = "Update [KhachHang] set " +
                "TenKhachHang =N'" + model.TenKhachHang.Trim() + "', " +
                "SoDienThoai ='" + model.SoDienThoai.Trim() + "', " +
                "Email ='" + model.Email.Trim() + "', " +
                "GioiTinh =N'" + model.GioiTinh.Trim() + "', " +
                "NgaySinh ='" + model.NgaySinh.ToString("yyyy-MM-dd") + "', " +
                "DiaChi =N'" + model.DiaChi.Trim() + "'" +
                " Where MaKH='" + model.MaKhachHang + "'";
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
                string ma = common.tangMaTuDong("KhachHang", "KH");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into [KhachHang](" +
                    "MaKH, " +
                    "TenKhachHang, " +
                    "SoDienThoai, " +
                    "Email, " +
                    "GioiTinh, " +
                    "NgaySinh, " +                   
                    "DiaChi ) values('" + ma.Trim() + "'," +
                    "N'" + model.TenKhachHang.Trim() + "" +
                    "','" + model.SoDienThoai.Trim() + "'" +
                    ",'" + model.Email.Trim() + "'" +
                    ",N'" + model.GioiTinh.Trim() + "'" +
                    ",'" + model.NgaySinh.ToString("yyyy-MM-dd") + "'" +                    
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
                string timkiem = "SELECT [MaKH] ,[TenKhachHang] ,[GioiTinh] ,[NgaySinh] ,[Email] ,[SoDienThoai] ,[DiaChi] FROM [KhachHang] where MaKH like '%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTen.Checked)
            {
                string timkiem = "SELECT [MaKH] ,[TenKhachHang] ,[GioiTinh] ,[NgaySinh] ,[Email] ,[SoDienThoai] ,[DiaChi] FROM [KhachHang] where TenKhachHang like N'%" + txtSearch.Text + "%'";
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
            cmbGioiTinh.SelectedItem = dataGRV.CurrentRow.Cells[2].Value.ToString().Trim();
            dateTimeNgaySinh.Value = Convert.ToDateTime(dataGRV.CurrentRow.Cells[3].Value.ToString());
            txtEmail.Text = dataGRV.CurrentRow.Cells[4].Value.ToString();
            txtSoDienThoai.Text = dataGRV.CurrentRow.Cells[5].Value.ToString();
            txtDiaChi.Text = dataGRV.CurrentRow.Cells[6].Value.ToString();
            SetControl("table-click");
        }

        private void btnLoadDS_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            LoadData();
            SetControl("load");
        }
    }
}
