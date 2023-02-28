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
    public partial class frmQuanLySanPham_PhieuXuat : Form
    {
        public frmQuanLySanPham_PhieuXuat()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        public void LoadData(string query = "")
        {           
            if (string.IsNullOrEmpty(query))
            {
                query = "SELECT [MaPhieuXuat] ,[MaNhanVien] ,U.TenUser ,PX.[MaKH] ,KH.TenKhachHang ,convert(varchar, [NgayXuat], 111) ,[TinhTrang] ,[GhiChu] FROM [PhieuXuat] PX " +
                    "left join KhachHang KH on KH.MaKH = PX.MaKH " +
                    "left join [User] U on U.MaUser = PX.MaNhanVien";
            }            
            common.LoadData(query, dgvPhieuNhap);
        }
        // Load Nhân viên 
        public void CmbNhanVien()
        {
            DataTable dt;
            string query = "SELECT * FROM [User] ";
            dt = common.docdulieu(query);
            cmbNhanVien.DisplayMember = "TenUser";
            cmbNhanVien.ValueMember = "MaUser";
            cmbNhanVien.DataSource = dt;
        }
        // Load khách hàng
        public void CmbKhachHang()
        {
            DataTable dt;
            string query = "SELECT * FROM KhachHang ";
            dt = common.docdulieu(query);
            cmbKhachHang.DisplayMember = "TenKhachHang";
            cmbKhachHang.ValueMember = "MaKH";
            cmbKhachHang.DataSource = dt;
        }
        public PhieuNhap GetValue()
        {
            var model = new PhieuNhap();
            model.MaPhieuNhap = txtMa.Text;
            model.MaNhanVien = cmbNhanVien.SelectedValue.ToString();
            model.GhiChu = txtGhiChu.Text;
            model.TinhTrang = cmbTinhTrang.SelectedItem.ToString();
            model.NgayNhap = dateTimeNgayNhap.Value;
            return model;
        }
        public void SetValue(PhieuNhap model)
        {
            txtMa.Text = model.MaPhieuNhap;
            cmbNhanVien.SelectedValue = model.MaNhanVien;
            txtGhiChu.Text = model.GhiChu;
            cmbTinhTrang.SelectedItem = model.TinhTrang;
            dateTimeNgayNhap.Value = model.NgayNhap;
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
                txtMa.Enabled = true;
                txtGhiChu.Enabled = true;
                //txtSoDienThoai.Enabled = true;
                //txtEmail.Enabled = true;
                //cmbGioiTinh.Enabled = true;
                //dateTimeNgaySinh.Enabled = true;
                //txtTenDangNhap.Enabled = true;
                //txtMatKhau.Enabled = true;
                //txtDiaChi.Enabled = true;
            }
            else
            {
                txtMa.Text = "";
                //txtTenDangNhap.Text = "";
                //txtTenUser.Text = "";
                //txtSoDienThoai.Text = "";
                //txtEmail.Text = "";
                //cmbGioiTinh.Text = "";
                //dateTimeNgaySinh.Text = "";
                //txtTenDangNhap.Text = "";
                //txtMatKhau.Text = "";
                //txtDiaChi.Text = "";
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
                        string query = "DELETE FROM [PhieuNhap] WHERE MaPhieuNhap='" + txtMa.Text + "'";
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
            string qry = "Update [PhieuNhap] set " +
                "MaNhanVien ='" + model.MaNhanVien.Trim() + "', " +
                "NgayNhap ='" + model.NgayNhap.ToString("yyyy-MM-dd") + "', " +
                "GhiChu =N'" + model.GhiChu + "', " +
                "TinhTrang =N'" + model.TinhTrang + "' " +
                " Where MaPhieuNhap='" + model.MaPhieuNhap + "'";
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
                string ma = common.tangMaTuDong("PhieuNhap", "PN");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into [PhieuNhap](" +
                    "MaPhieuNhap, " +
                    "MaNhanVien, " +
                    "NgayNhap, " +
                    "GhiChu, " +
                    "TinhTrang " +
                    " ) values('" + ma.Trim() + "'," +
                    "'" + model.MaNhanVien.Trim()  +"'"+
                    ",'" + model.NgayNhap.ToString("yyyy-MM-dd") + "'" +
                    ",N'" + model.GhiChu.Trim() + "'" +
                    ",N'" + model.TinhTrang.Trim() + "' " +                    
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

        //private void dataGRV_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    txtMa.Text = dataGRV.CurrentRow.Cells[0].Value.ToString();
        //    txtTenUser.Text = dataGRV.CurrentRow.Cells[1].Value.ToString();
        //    txtTenDangNhap.Text = dataGRV.CurrentRow.Cells[2].Value.ToString();
        //    cmbLoaiQuyen.SelectedItem = dataGRV.CurrentRow.Cells[3].Value.ToString().Trim();
        //    cmbGioiTinh.SelectedItem = dataGRV.CurrentRow.Cells[4].Value.ToString().Trim();
        //    dateTimeNgaySinh.Value = Convert.ToDateTime(dataGRV.CurrentRow.Cells[5].Value.ToString());
        //    txtEmail.Text = dataGRV.CurrentRow.Cells[6].Value.ToString();
        //    txtSoDienThoai.Text = dataGRV.CurrentRow.Cells[7].Value.ToString();
        //    txtDiaChi.Text = dataGRV.CurrentRow.Cells[8].Value.ToString();
        //    SetControl("table-click");
        //}

        private void btnLoadDS_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            cmbNhanVien.SelectedValue = dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            dateTimeNgayNhap.Value = Convert.ToDateTime(dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString());
            cmbTinhTrang.SelectedItem = dgvPhieuNhap.CurrentRow.Cells[4].Value.ToString().Trim();
            txtGhiChu.Text = dgvPhieuNhap.CurrentRow.Cells[5].Value.ToString().Trim();
           
           
            SetControl("table-click");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmQuanLySanPham_PhieuXuat_Load(object sender, EventArgs e)
        {
            CmbKhachHang();
            CmbNhanVien();
            txtMa.Enabled = false;
            LoadData();
            SetControl("load");
        }
    }
}
