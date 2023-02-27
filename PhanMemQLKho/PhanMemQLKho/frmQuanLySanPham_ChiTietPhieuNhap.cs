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
    public partial class frmQuanLySanPham_ChiTietPhieuNhap : Form
    {
        public frmQuanLySanPham_ChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        public void LoadData(string query = "")
        {
           
            if (string.IsNullOrEmpty(query))
            {
                query = "select PN.MaPhieuNhap,SP.MaSanPham,SP.TenSanPham,PN.NgayNhap,CTPN.SoLuong,CTPN.GiaNhap,* from [ChiTietPhieuNhap] CTPN " +
                    "left join [PhieuNhap] PN on CTPN.MaPhieuNhap = PN.MaPhieuNhap" +
                    " left join [SanPham] SP on SP.MaSanPham = CTPN.MaSanPham";
            }
            
            common.LoadData(query, dataGRV);
        }
        // Load sản phẩm
        public void CmbSanPham()
        {
            DataTable dt;
            string query = "SELECT * FROM [SanPham] ";
            dt = common.docdulieu(query);
            cmbSanPham.DisplayMember = "TenSanPham";
            cmbSanPham.ValueMember = "MaSanPham";
            cmbSanPham.DataSource = dt;
        }
        // Load phiếu nhập
        public void CmbPhieuNhap()
        {
            DataTable dt;
            string query = "SELECT * FROM [PhieuNhap] ";
            dt = common.docdulieu(query);
            cmbPhieuNhap.DisplayMember = "MaPhieuNhap";
            cmbPhieuNhap.ValueMember = "MaPhieuNhap";
            cmbPhieuNhap.DataSource = dt;
        }
        public NguoiDung GetPhieuNhapId(string ma)
        {
            DataTable dt;
            string query = "SELECT [MaPhieuNhap] ,[TenUser],u.TenUser ,[NgayNhap]  ,[TinhTrang] ,[GhiChu] FROM [PhieuNhap] PN" +
                    " left join [User] U on PN.MaNhanVien = u.MaUser WHERE PN.MaPhieuNhap ='"+ ma + "'";
            dt = common.docdulieu(query);
            var model = new NguoiDung();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model.TenUser= dr["TenUser"].ToString();                    
                }
            }
            return model;
        }
        public void LoadCmb()
        {
            CmbSanPham();
            CmbPhieuNhap();
        }

        public ChiTietPhieuNhap GetValue()
        {
            var model = new ChiTietPhieuNhap();
            model.MaChiTietPhieuNhap = txtMa.Text;
            model.MaPhieuNhap = cmbPhieuNhap.SelectedValue.ToString();
            model.MaSanPham = cmbSanPham.SelectedValue.ToString();
            model.SoLuong = !string.IsNullOrEmpty(txtSoLuong.Text) ? Convert.ToInt32(txtSoLuong.Text) : 0;
            model.DonGia = !string.IsNullOrEmpty(txtDonGia.Text) ? Convert.ToInt32(txtDonGia.Text) : 0;          
            return model;
        }
        public void SetValue(ChiTietPhieuNhap model)
        {
            txtMa.Text = model.MaChiTietPhieuNhap;
            cmbPhieuNhap.SelectedValue = model.MaPhieuNhap;
            cmbSanPham.SelectedValue = model.MaSanPham;
            txtSoLuong.Text = model.SoLuong > 0 ? model.SoLuong.ToString() : "";
            txtDonGia.Text = model.DonGia > 0 ? model.DonGia.ToString() : "";          
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
                txtDonGia.Enabled = true;
                //txtTenUser.Enabled = true;
                //txtSoDienThoai.Enabled = true;
                //txtEmail.Enabled = true;
                //cmbTinhTrang.Enabled = true;
                //dateTimeNgayNhap.Enabled = true;
                //txtDonGia.Enabled = true;
                //txtSoLuong.Enabled = true;
                //txtDiaChi.Enabled = true;
            }
            else
            {
                txtMa.Text = "";
                txtDonGia.Text = "";
                //txtTenUser.Text = "";
                //txtSoDienThoai.Text = "";
                //txtEmail.Text = "";
                //cmbTinhTrang.Text = "";
                //dateTimeNgayNhap.Text = "";
                //txtDonGia.Text = "";
                //txtSoLuong.Text = "";
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
                        string query = "DELETE FROM [ChiTietPhieuNhap] WHERE MaChiTietPhieuNhap='" + txtMa.Text + "'";
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
            string qry = "Update [ChiTietPhieuNhap] set " +
                "MaPhieuNhap ='" + model.MaPhieuNhap.Trim() + "', " +
                "MaSanPham ='" + model.MaSanPham.Trim() + "', " +
                "SoLuong =" + model.SoLuong + ", " +
                "GiaNhap =" + model.DonGia + " " +
                " Where MaChiTietPhieuNhap='" + model.MaChiTietPhieuNhap + "'";
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
                string ma = common.tangMaTuDong("ChiTietPhieuNhap", "CTPN");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into [ChiTietPhieuNhap](" +
                    "MaChiTietPhieuNhap, " +
                    "MaPhieuNhap, " +
                    "MaSanPham, " +
                    "SoLuong, " +
                    "GiaNhap " +                   
                    " ) values('" + ma.Trim() + "'," +
                    "'" + model.MaPhieuNhap.Trim() + "" +
                    "','" + model.MaSanPham.Trim() + "'" +
                    "," + model.SoLuong + "" +
                    "," + model.DonGia + "" +
                    
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
            cmbPhieuNhap.SelectedValue = dataGRV.CurrentRow.Cells[1].Value.ToString();
            cmbSanPham.SelectedValue = dataGRV.CurrentRow.Cells[3].Value.ToString();
            txtDonGia.Text = dataGRV.CurrentRow.Cells[5].Value.ToString();
            txtSoLuong.Text = dataGRV.CurrentRow.Cells[6].Value.ToString();
            SetControl("table-click");
        }

        private void btnLoadDS_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmQuanLySanPham_ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadCmb();
            txtMa.Enabled = false;
            txtNhanVien.Enabled = false;
            LoadData();
            SetControl("load");
        }

        private void cmbPhieuNhap_SelectedValueChanged(object sender, EventArgs e)
        {
            string maPhieu = cmbPhieuNhap.SelectedValue != null ? cmbPhieuNhap.SelectedValue.ToString() : "";
            if (!string.IsNullOrEmpty(maPhieu))
            {
                var nhanVien = GetPhieuNhapId(maPhieu);

                txtNhanVien.Text = nhanVien.TenUser;
            }
        }
    }
}
