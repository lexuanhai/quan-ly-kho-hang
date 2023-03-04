using PhanMemQLKho.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
        public void LoadData(string qry = "")
        {
            string query = "";
            if (string.IsNullOrEmpty(query))
            {
                query = "SELECT [MaPhieuXuat] ,KH.[MaKH] ,KH.TenKhachHang ,[MaNhanVien] ,U.TenUser ,[NgayXuat] ,[TinhTrang] ,[GhiChu] FROM [PhieuXuat] PX " +
                    "left join [User] U on PX.MaNhanVien = u.MaUser " +
                    "left join [KhachHang] KH on PX.MaKH = KH.MaKH";
            }
            else
            {
                query = qry;
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
        public PhieuXuat GetValue()
        {
            var model = new PhieuXuat();
            model.MaPhieuXuat = txtMa.Text;
            model.MaKH = cmbKhachHang.SelectedValue.ToString();
            model.MaNhanVien = cmbNhanVien.SelectedValue.ToString();
            model.GhiChu = txtGhiChu.Text;
            model.TinhTrang = cmbTinhTrang.SelectedItem.ToString();
            model.NgayXuat = dateTimeNgayNhap.Value;
            return model;
        }
        public void SetValue(PhieuXuat model)
        {
            txtMa.Text = model.MaPhieuXuat;
            cmbNhanVien.SelectedValue = model.MaNhanVien;
            cmbKhachHang.SelectedValue = model.MaKH;
            txtGhiChu.Text = model.GhiChu;
            cmbTinhTrang.SelectedItem = model.TinhTrang;
            dateTimeNgayNhap.Value = model.NgayXuat;
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
            cmbNhanVien.Enabled = edit;
            cmbKhachHang.Enabled = edit;
            dateTimeNgayNhap.Enabled = edit;
            cmbTinhTrang.Enabled = edit;
            txtGhiChu.Enabled = edit;
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
                        string query = "DELETE FROM [PhieuXuat] WHERE [MaPhieuXuat]='" + txtMa.Text + "'";
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
            string qry = "Update [PhieuXuat] set " +
                "MaNhanVien ='" + model.MaNhanVien.Trim() + "', " +
                "MaKH ='" + model.MaKH.Trim() + "', " +
                "NgayXuat ='" + model.NgayXuat.ToString("yyyy-MM-dd") + "', " +
                "GhiChu =N'" + model.GhiChu + "', " +
                "TinhTrang =N'" + model.TinhTrang + "' " +
                " Where MaPhieuXuat='" + model.MaPhieuXuat + "'";
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
                string ma = common.tangMaTuDong("PhieuXuat", "PX");
                ma = Regex.Replace(ma, @"\s+", "");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into [PhieuXuat](" +
                    "MaPhieuXuat, " +
                    "MaNhanVien, " +
                    "MaKH, " +
                    "NgayXuat, " +
                     "TinhTrang, " +
                    "GhiChu " +                   
                    " ) values('" + ma.Trim() + "'," +
                    "'" + model.MaNhanVien.Trim()  +"'"+
                    ",'" + model.MaKH.Trim() + "'" +
                    ",'" + model.NgayXuat.ToString("yyyy-MM-dd") + "'" +
                    ",N'" + model.TinhTrang.Trim() + "' " +
                    ",N'" + model.GhiChu.Trim() + "'" +
                            
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
                string timkiem = "SELECT [MaPhieuXuat] ,KH.[MaKH] ,KH.TenKhachHang ,[MaNhanVien] ,U.TenUser ,[NgayXuat] ,[TinhTrang] ,[GhiChu] FROM [PhieuXuat] PX " +
                    "left join [User] U on PX.MaNhanVien = u.MaUser " +
                    "left join [KhachHang] KH on PX.MaKH = KH.MaKH where PX.MaPhieuXuat like '%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTen.Checked)
            {
                string timkiem = "SELECT [MaPhieuXuat] ,KH.[MaKH] ,KH.TenKhachHang ,[MaNhanVien] ,U.TenUser ,[NgayXuat] ,[TinhTrang] ,[GhiChu] FROM [PhieuXuat] PX " +
                    "left join [User] U on PX.MaNhanVien = u.MaUser " +
                    "left join [KhachHang] KH on PX.MaKH = KH.MaKH where PX.MaKH like N'%" + txtSearch.Text + "%'";
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
        //    cmbKhachHang.SelectedValue = dataGRV.CurrentRow.Cells[1].Value.ToString();
        //    cmbNhanVien.SelectedValue= dataGRV.CurrentRow.Cells[3].Value.ToString();
         
        //    dateTimeNgayNhap.Value = Convert.ToDateTime(dataGRV.CurrentRow.Cells[5].Value.ToString());
        //    cmbTinhTrang.SelectedItem = dataGRV.CurrentRow.Cells[6].Value.ToString().Trim();
        //    txtGhiChu.Text = dataGRV.CurrentRow.Cells[7].Value.ToString();         
        //    SetControl("table-click");
        //}

        private void btnLoadDS_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            cmbKhachHang.SelectedValue = dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            cmbNhanVien.SelectedValue = dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString();

            dateTimeNgayNhap.Value = Convert.ToDateTime(dgvPhieuNhap.CurrentRow.Cells[5].Value.ToString());
            cmbTinhTrang.SelectedItem = dgvPhieuNhap.CurrentRow.Cells[6].Value.ToString().Trim();
            txtGhiChu.Text = dgvPhieuNhap.CurrentRow.Cells[7].Value.ToString();
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
