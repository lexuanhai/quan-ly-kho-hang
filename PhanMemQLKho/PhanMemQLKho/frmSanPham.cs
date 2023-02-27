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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        public void LoadData(string qry = "")
        {

            DataTable dt;
            string query = "SELECT * FROM [SanPham] SP " +
                    " INNER JOIN NhaCC NCC ON NCC.MaNCC = SP.MaNCC" +
                    " INNER JOIN NhaSanXuat NSX ON NSX.MaSX = SP.MaNSX " +
                    " INNER JOIN DanhMucSanPham DMSP ON DMSP.MaDanhMuc = SP.MaDanhMuc" +
                    " INNER JOIN ThuongHieu TH ON TH.MaThuongHieu = SP.MaThuongHieu";
            if (!string.IsNullOrEmpty(qry))
            {
                query += qry;
            }

            dt = common.docdulieu(query);

            dataGRV.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGRV.Rows.Add();
                    dataGRV.Rows[n].Cells[0].Value = dr["MaSanPham"].ToString();
                    dataGRV.Rows[n].Cells[1].Value = dr["TenSanPham"].ToString();
                    dataGRV.Rows[n].Cells[2].Value = dr["TenDanhMuc"].ToString();
                    dataGRV.Rows[n].Cells[3].Value = dr["TenThuongHieu"].ToString();
                    dataGRV.Rows[n].Cells[4].Value = dr["TenNCC"].ToString();
                    dataGRV.Rows[n].Cells[5].Value = dr["TenNSX"].ToString();
                    dataGRV.Rows[n].Cells[6].Value = dr["XuatXu"].ToString();
                    dataGRV.Rows[n].Cells[7].Value = dr["NamSX"].ToString();
                    dataGRV.Rows[n].Cells[8].Value = dr["HopSo"].ToString();
                    dataGRV.Rows[n].Cells[9].Value = dr["MauSon"].ToString();
                    dataGRV.Rows[n].Cells[10].Value = dr["KieuDang"].ToString();
                    dataGRV.Rows[n].Cells[11].Value = dr["NhienLieu"].ToString();
                    dataGRV.Rows[n].Cells[12].Value = dr["SoCho"].ToString();
                    dataGRV.Rows[n].Cells[13].Value = dr["GiaNhap"].ToString();
                    dataGRV.Rows[n].Cells[14].Value = dr["GiaBan"].ToString();
                    dataGRV.Rows[n].Cells[15].Value = dr["SoLuong"].ToString();
                    dataGRV.Rows[n].Cells[16].Value = dr["PhanTramGiam"].ToString();
                    dataGRV.Rows[n].Cells[17].Value = dr["TinhTrang"].ToString();
                }
            }
        }
        // Load thương hiệu
        public void CmbThuongHieu()
        {
            DataTable dt;
            string query = "SELECT * FROM ThuongHieu ";
            dt = common.docdulieu(query);
            cmbThuongHieu.DisplayMember = "TenThuongHieu";
            cmbThuongHieu.ValueMember = "MaThuongHieu";
            cmbThuongHieu.DataSource = dt;
        }
        public SelectItemCustom GetCmbValue(string ma)
        {
            DataTable dt;
            string query = "SELECT SP.MaDanhMuc,SP.MaNCC,SP.MaNSX,SP.MaThuongHieu,* FROM [SanPham] SP " +
                    " INNER JOIN NhaCC NCC ON NCC.MaNCC = SP.MaNCC" +
                    " INNER JOIN NhaSanXuat NSX ON NSX.MaSX = SP.MaNSX " +
                    " INNER JOIN DanhMucSanPham DMSP ON DMSP.MaDanhMuc = SP.MaDanhMuc" +
                    " INNER JOIN ThuongHieu TH ON TH.MaThuongHieu = SP.MaThuongHieu" +
                    " WHERE SP.MaSanPham = '"+ma+"'";
            dt = common.docdulieu(query);
            var model = new SelectItemCustom();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {                    
                    model.MaThuongHieu = dr["MaThuongHieu"].ToString();
                    model.MaDanhMuc = dr["MaDanhMuc"].ToString();
                    model.MaNCC = dr["MaNCC"].ToString();
                    model.MaNSX = dr["MaNSX"].ToString();
                }
            }
            return model;
        }
        // Load NCC
        public void CmbNCC()
        {
            DataTable dt;
            string query = "SELECT * FROM NhaCC ";
            dt = common.docdulieu(query);
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.ValueMember = "MaNCC";
            cmbNCC.DataSource = dt;
        }
        // Load NSX
        public void CmbNSX()
        {
            DataTable dt;
            string query = "SELECT * FROM NhaSanXuat ";
            dt = common.docdulieu(query);
            cmbNSX.DisplayMember = "TenNSX";
            cmbNSX.ValueMember = "MaSX";
            cmbNSX.DataSource = dt;
        }
        // Load Danh Mục
        public void CmbDanhMuc()
        {
            DataTable dt;
            string query = "SELECT * FROM DanhMucSanPham ";
            dt = common.docdulieu(query);
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.ValueMember = "MaDanhMuc";
            cmbDanhMuc.DataSource = dt;
        }
        public void LoadCmb()
        {
            CmbThuongHieu();
            CmbNCC();
            CmbNSX();
            CmbDanhMuc();
        }

        public SanPham GetValue()
        {
            var model = new SanPham();
            model.MaSanPham = txtMa.Text;
            model.TenSanPham = txtTenXe.Text;
            model.MaDanhMuc = cmbDanhMuc.SelectedValue.ToString();
            model.MaNCC = cmbNCC.SelectedValue.ToString();
            model.MaNSX = cmbNSX.SelectedValue.ToString();
            model.MaThuongHieu = cmbThuongHieu.SelectedValue.ToString();
            model.NamSX = Convert.ToInt32(txtNamSX.Text.ToString());
            model.SoCho = Convert.ToInt32(txtSoCho.Text.ToString());
            model.HopSo = txtHopSo.Text;
            model.MauSon = txtMauSon.Text;
            model.KieuDang = txtKieuDang.Text;
            model.NhienLieu = txtNhienLieu.Text;
            model.XuatXu = txtXuatXu.Text;
            model.SoLuong = Convert.ToInt32(txtSoLuong.Text.ToString());
            model.GiaBan = Convert.ToDecimal(txtGiaBan.Text.ToString());
            model.GiaNhap = Convert.ToDecimal(txtGiaNhap.Text.ToString());
            model.PhanTramGiam = Convert.ToInt32(txtGiaGiam.Text.ToString());
            model.TinhTrang = cmbTinhTrang.SelectedItem.ToString();
            return model;
        }
        public void SetValue(SanPham model)
        {
            txtMa.Text = model.MaSanPham;
            txtTenXe.Text = model.TenSanPham;
            cmbDanhMuc.SelectedValue = model.MaDanhMuc;
            cmbNCC.SelectedValue = model.MaNCC;
            cmbNSX.SelectedValue = model.MaNSX;
            cmbThuongHieu.SelectedValue = model.MaThuongHieu;
            txtNamSX.Text = model.NamSX.ToString();
            txtSoCho.Text = model.SoCho.ToString();
            txtHopSo.Text = model.HopSo;
            txtMauSon.Text = model.MauSon;
            txtKieuDang.Text = model.KieuDang;
            txtNhienLieu.Text = model.NhienLieu;
            txtXuatXu.Text = model.XuatXu;
            txtSoLuong.Text = model.SoLuong.ToString();
            txtGiaBan.Text = model.GiaBan.ToString();
            txtGiaNhap.Text = model.GiaNhap.ToString();
            txtGiaGiam.Text = model.PhanTramGiam.ToString();
            cmbTinhTrang.SelectedItem = model.TinhTrang;            
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
                txtTenXe.Enabled = true;
                txtNamSX.Enabled = true;
                txtHopSo.Enabled = true;
                //txtDiaChi.Enabled = true;
            }
            else
            {
                txtMa.Text = "";
                txtTenXe.Text = "";
                txtNamSX.Text = "";
                txtHopSo.Text = "";
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
                        string query = "DELETE FROM [SanPham] WHERE [MaSanPham]='" + txtMa.Text + "'";
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
            btnLuu.Enabled = true;
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
            string qry = "Update [SanPham] set " +
                "TenSanPham =N'" + model.TenSanPham.Trim() + "', " +
                "MaDanhMuc ='" + model.MaDanhMuc.Trim() + "', " +
                "MaNCC ='" + model.MaNCC.Trim() + "', " +
                "MaNSX ='" + model.MaNSX.Trim() + "', " +
                "MaThuongHieu ='" + model.MaThuongHieu.Trim() + "', " +
                "NamSX =" + model.NamSX + ", " +
                "SoCho =" + model.SoCho + ", " +
                "HopSo ='" + model.HopSo.Trim() + "', " +
                "MauSon ='" + model.MauSon.Trim() + "', " +
                "KieuDang ='" + model.KieuDang.Trim() + "', " +
                "NhienLieu ='" + model.NhienLieu.Trim() + "', " +
                "XuatXu ='" + model.XuatXu.Trim() + "', " +
                "SoLuong =" + model.SoLuong + ", " +
                "GiaBan =" + model.GiaBan + ", " +
                "GiaNhap =" + model.GiaNhap + ", " +
                "BienSo ='" + model.BienSo + "', " +
                "PhanTramGiam =" + model.PhanTramGiam + ", " +
                "TinhTrang ='" + model.TinhTrang.Trim() + "' " +
                " Where MaSanPham='" + model.MaSanPham + "'";
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
                string ma = common.tangMaTuDong("SanPham", "SP");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into [SanPham](" +
                    "MaSanPham, " +
                    "TenSanPham, " +
                    "MaDanhMuc, " +
                    "MaNCC, " +
                    "MaNSX, " +
                    "MaThuongHieu, " +
                    "NamSX, " +
                    "SoCho, " +
                    "HopSo, " +
                    "MauSon, " +
                    "KieuDang, " +
                    "NhienLieu, " +
                    "XuatXu, " +
                    "SoLuong, " +
                    "GiaBan, " +
                    "GiaNhap, " +
                    //"BienSo, " +
                    "PhanTramGiam, " +
                    "TinhTrang " +
                    " ) values('" + ma.Trim() + "'," +
                    "N'" + model.TenSanPham.Trim() + "" +
                    "','" + model.MaDanhMuc.Trim() + "'" +
                    ",'" + model.MaNCC.Trim() + "'" +
                    ",'" + model.MaNSX.Trim() + "'" +
                    ",'" + model.MaThuongHieu.Trim() + "'" +
                    "," + model.NamSX + "" +
                    "," + model.SoCho + "" +
                    ",N'" + model.HopSo.Trim() + "'" +
                    ",N'" + model.MauSon.Trim() + "'" +
                    ",N'" + model.KieuDang.Trim() + "'" +
                    ",N'" + model.NhienLieu.Trim() + "'" +
                    ",N'" + model.XuatXu.Trim() + "'" +
                    "," + model.SoLuong + "" +
                    "," + model.GiaBan + "" +
                    "," + model.GiaNhap + "" +
                    "," + model.PhanTramGiam+ "" +
                    ",N'" + model.TinhTrang.Trim() + "'" +
                    " )";
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
                string timkiem = "SELECT [MaSX] ,[TenNSX] ,[SoDienThoai] ,[Email] ,[DiaChi]  FROM [NhaSanXuat] where MaSX like '%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTen.Checked)
            {
                string timkiem = "SELECT [MaSX] ,[TenNSX] ,[SoDienThoai] ,[Email] ,[DiaChi]  FROM [NhaSanXuat] where TenNSX like N'%" + txtSearch.Text + "%'";
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
            txtTenXe.Text = dataGRV.CurrentRow.Cells[1].Value.ToString();
            if (!string.IsNullOrEmpty(txtMa.Text))
            {
              var cmb = GetCmbValue(txtMa.Text);
                cmbDanhMuc.SelectedValue = cmb.MaDanhMuc;
                cmbThuongHieu.SelectedValue = cmb.MaThuongHieu;
                cmbNSX.SelectedValue = cmb.MaNSX;
                cmbNCC.SelectedValue = cmb.MaNCC;
            }


            txtXuatXu.Text = dataGRV.CurrentRow.Cells[6].Value.ToString();

            txtNamSX.Text = dataGRV.CurrentRow.Cells[7].Value.ToString();
            txtHopSo.Text = dataGRV.CurrentRow.Cells[8].Value.ToString();
            txtMauSon.Text = dataGRV.CurrentRow.Cells[9].Value.ToString();
            txtKieuDang.Text = dataGRV.CurrentRow.Cells[10].Value.ToString();
            txtNhienLieu.Text = dataGRV.CurrentRow.Cells[11].Value.ToString();
            txtSoCho.Text = dataGRV.CurrentRow.Cells[12].Value.ToString();
            txtGiaNhap.Text = dataGRV.CurrentRow.Cells[13].Value.ToString();
            txtGiaBan.Text = dataGRV.CurrentRow.Cells[14].Value.ToString();
            txtSoLuong.Text = dataGRV.CurrentRow.Cells[15].Value.ToString();
            txtGiaGiam.Text = dataGRV.CurrentRow.Cells[16].Value.ToString();
            cmbTinhTrang.SelectedItem = dataGRV.CurrentRow.Cells[17].Value.ToString();
            SetControl("table-click");
        }

        private void btnLoadDS_Click(object sender, EventArgs e)
        {
            LoadData();
        }            

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadCmb();
            txtMa.Enabled = false;
            LoadData();
            SetControl("load");
        }
    }
}
