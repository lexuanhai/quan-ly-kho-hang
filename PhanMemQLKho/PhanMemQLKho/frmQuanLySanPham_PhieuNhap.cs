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
using System.Windows.Media.Media3D;

namespace PhanMemQLKho
{
    public partial class frmQuanLySanPham_PhieuNhap : Form
    {
        public frmQuanLySanPham_PhieuNhap()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        public void LoadData(string str = "")
        {
            string query = "";
            if (string.IsNullOrEmpty(str))
            {
                query = "SELECT [MaPhieuNhap] ,[MaNhanVien] ,u.TenUser , convert(varchar, [NgayNhap], 111)  ,[TinhTrang] ,[GhiChu],TrangThai FROM [PhieuNhap] PN" +
                    " left join [User] U on PN.MaNhanVien = u.MaUser";
            }
            else
            {
                query = str;
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
        public PhieuNhap GetValue()
        {
            var model = new PhieuNhap();
            model.MaPhieuNhap = txtMa.Text;
            model.MaNhanVien = cmbNhanVien.SelectedValue.ToString();
            model.GhiChu = txtGhiChu.Text;
            model.TinhTrang = cmbLoaiHang.SelectedItem.ToString();
            model.TrangThai = cmbTrangThai.SelectedItem.ToString();
            model.NgayNhap = dateTimeNgayNhap.Value;
            return model;
        }
        public void SetValue(PhieuNhap model)
        {
            txtMa.Text = model.MaPhieuNhap;
            cmbNhanVien.SelectedValue = model.MaNhanVien;
            txtGhiChu.Text = model.GhiChu;
            cmbLoaiHang.SelectedItem = model.TinhTrang;
            cmbTrangThai.SelectedItem = model.TrangThai;
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
                SetAllNull();
            }
        }
        public void SetControlValue(bool edit)
        {
            txtGhiChu.Enabled = edit;
            cmbNhanVien.Enabled = edit;
            dateTimeNgayNhap.Enabled = edit;
            cmbLoaiHang.Enabled = edit;
            cmbTrangThai.Enabled = edit;
        }
        public void SetAllNull()
        {
            txtMa.Text = "";
            txtGhiChu.Text = "";
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
                "TinhTrang =N'" + model.TinhTrang + "', " +
                "TrangThai =N'" + model.TrangThai + "' " +
                " Where MaPhieuNhap='" + model.MaPhieuNhap + "'";
            if (cmbTrangThai.SelectedItem == "Đã Hoàn Thành")
            {
                // lấy thông tin các sản phẩm trong bảng chi tiết phiếu nhập
              string  qrystr = "select SP.MaSanPham,SP.SoLuong,CTPN.SoLuong AS 'SoLuongNhap',CTPN.GiaNhap from PhieuNhap PN " +
                    "inner join ChiTietPhieuNhap CTPN on CTPN.MaPhieuNhap = PN.MaPhieuNhap " +
                    "inner join SanPham SP on CTPN.MaSanPham = SP.MaSanPham " +
                    "where PN.MaPhieuNhap = '"+ model.MaPhieuNhap.Trim() + "'";
                var data = common.docdulieu(qrystr);
              
                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow dr in data.Rows)
                    {                       
                        string masp = dr["MaSanPham"].ToString();
                        int soluong = 0,soluongnhap = 0,gianhap=0;
                        if (dr["SoLuong"] != null && !string.IsNullOrEmpty(dr["SoLuong"].ToString()))
                        {
                            soluong = Convert.ToInt32(dr["SoLuong"].ToString());
                        }
                        if (dr["SoLuongNhap"] != null && !string.IsNullOrEmpty(dr["SoLuongNhap"].ToString()))
                        {
                            soluongnhap = Convert.ToInt32(dr["SoLuongNhap"].ToString());
                        }
                        if (dr["GiaNhap"] != null && !string.IsNullOrEmpty(dr["GiaNhap"].ToString()))
                        {
                            gianhap = Convert.ToInt32(dr["GiaNhap"].ToString());
                        }
                        soluong = soluong + soluongnhap;
                        UpdateSoLuong(masp, soluong, gianhap);
                    }
                }
            }
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
        public void UpdateSoLuong(string maSP,int soluong,int gianhap)
        {
            string qry = "Update [SanPham] set " +
                "SoLuong =" + soluong + ", "+
                "GiaNhap =" + gianhap + " " +
                " Where MaSanPham='" + maSP.Trim() + "'";
            common.thucthidulieu(qry);
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
                    "TinhTrang, " +
                     "TrangThai " +
                    " ) values('" + ma.Trim() + "'," +
                    "'" + model.MaNhanVien.Trim()  +"'"+
                    ",'" + model.NgayNhap.ToString("yyyy-MM-dd") + "'" +
                    ",N'" + model.GhiChu.Trim() + "'" +
                    ",N'" + model.TinhTrang.Trim() + "' " +
                    ",N'" + model.TrangThai.Trim() + "' " +
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
            if (cmbNhanVien.Text.Length > 0 &&
                dateTimeNgayNhap.Text.Length > 0 &&
                cmbLoaiHang.Text.Length > 0                
                )
            {
                if (xuly == 1)
                {
                    ThemMoi();
                }
                else if (xuly == 2)
                {
                    UpdataDatabase();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
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
                
                string timkiem = "SELECT[MaPhieuNhap] ,[MaNhanVien] ,u.TenUser , convert(varchar, [NgayNhap], 111) ,[TinhTrang] ,[GhiChu],TrangThai FROM[PhieuNhap] PN left join [User] U on PN.MaNhanVien = u.MaUser where MaPhieuNhap like '%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTen.Checked)
            {
                string timkiem = "SELECT[MaPhieuNhap] ,[MaNhanVien] ,u.TenUser , convert(varchar, [NgayNhap], 111) ,[TinhTrang] ,[GhiChu],TrangThai FROM[PhieuNhap] PN left join [User] U on PN.MaNhanVien = u.MaUser where TenUser like N'%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }           

        private void btnLoadDS_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmQuanLySanPham_PhieuNhap_Load(object sender, EventArgs e)
        {
            CmbNhanVien();
            txtMa.Enabled = false;
            LoadData();
            SetControl("load");
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            cmbNhanVien.SelectedValue = dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            dateTimeNgayNhap.Value = Convert.ToDateTime(dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString());
            cmbLoaiHang.SelectedItem = dgvPhieuNhap.CurrentRow.Cells[4].Value.ToString().Trim();
            txtGhiChu.Text = dgvPhieuNhap.CurrentRow.Cells[5].Value.ToString().Trim();
            cmbTrangThai.SelectedItem = dgvPhieuNhap.CurrentRow.Cells[6].Value.ToString().Trim();
            SetControl("table-click");
        }
    }
}
