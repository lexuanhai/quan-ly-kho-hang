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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                query = "select CTPN.MaChiTietPhieuNhap, PN.MaPhieuNhap,convert(varchar, PN.NgayNhap, 111) ,SP.MaSanPham, SP.TenSanPham,PT.MaPhuTung,PT.TenPhuTung ,CTPN.GiaNhap, CTPN.SoLuong,(CTPN.SoLuong*CTPN.GiaNhap) from [ChiTietPhieuNhap] CTPN " +
                    " left join [PhieuNhap] PN on CTPN.MaPhieuNhap = PN.MaPhieuNhap" +
                    " left join [SanPham] SP on SP.MaSanPham = CTPN.MaSanPham " +
                    " left join [PhuTung] PT on PT.MaPhuTung = CTPN.MaPhuTung order by PN.MaPhieuNhap desc";
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
            string query = "SELECT * FROM [PhieuNhap] order by PhieuNhap.MaPhieuNhap desc";
            //string query = "SELECT * FROM [PhieuNhap] where TrangThai =N'Đang Nhập'";
            dt = common.docdulieu(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["MaPhieuNhap"] = dr["MaPhieuNhap"].ToString().Trim();
                }
            }
            cmbMaPhieuNhap.DisplayMember = "MaPhieuNhap";
            cmbMaPhieuNhap.ValueMember = "MaPhieuNhap";
            cmbMaPhieuNhap.DataSource = dt;
        }
        public bool SanPhamExist(string maPN,string maSP)
        {
            string query = "select * from PhieuNhap PN " +
                "inner join ChiTietPhieuNhap CTPN on CTPN.MaPhieuNhap = PN.MaPhieuNhap " +               
                "where PN.MaPhieuNhap = '" + maPN.Trim() + "' and (CTPN.MaSanPham = '" + maSP.Trim() + "' OR CTPN.MaPhuTung ='" + maSP.Trim() + "')";
           var dt = common.docdulieu(query);
            if (dt != null && dt.Rows.Count > 0)            
                return true;            
            return false;
        }
        public PhieuNhap GetPhieuNhapId(string ma)
        {
            DataTable dt;
            string query = "SELECT [MaPhieuNhap] ,[TenUser],u.TenUser ,[NgayNhap]  ,[TinhTrang] ,[GhiChu] FROM [PhieuNhap] PN" +
                    " left join [User] U on PN.MaNhanVien = u.MaUser WHERE PN.MaPhieuNhap ='"+ ma + "'";
            dt = common.docdulieu(query);
            var model = new PhieuNhap();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model.TenNhanVien= dr["TenUser"].ToString();
                    model.TinhTrang = dr["TinhTrang"].ToString();
                    if (model.TinhTrang == "Phụ Tùng")
                    {
                        IsShowPhuTung(true);
                    }
                    else
                    {
                        IsShowPhuTung(false);
                    }
                }
            }
            return model;
        }
        public void IsShowPhuTung(bool edit)
        {
            lbPhuTung.Enabled = edit;
            cmbMaPhuTung.Enabled = edit;
            lbSanPham.Enabled = !edit;
            cmbSanPham.Enabled = !edit;
        }

        // Load Phụ Tùng
        public void CmbPhuTung()
        {
            DataTable dt;
            string query = "SELECT * FROM [PhuTung] ";
            dt = common.docdulieu(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["TenPhuTung"] = dr["TenPhuTung"].ToString().Trim();
                    dr["MaPhuTung"] = dr["MaPhuTung"].ToString().Trim();
                }
            }
            cmbMaPhuTung.DisplayMember = "TenPhuTung";
            cmbMaPhuTung.ValueMember = "MaPhuTung";
            cmbMaPhuTung.DataSource = dt;
        }
        public void LoadCmb()
        {
            CmbSanPham();
            CmbPhieuNhap();
            CmbPhuTung();
        }

        public ChiTietPhieuNhap GetValue()
        {
            var model = new ChiTietPhieuNhap();
            model.MaChiTietPhieuNhap = txtMa.Text;
            model.MaPhieuNhap = cmbMaPhieuNhap.SelectedValue.ToString();
            if (txtTinhTrang.Text == "Phụ Tùng")
            {
                model.MaPhuTung = cmbMaPhuTung.SelectedValue.ToString();
                model.MaSanPham = null;
            }
            else
            {
                model.MaSanPham = cmbSanPham.SelectedValue.ToString();
                model.MaPhuTung = null;
            }
           
            model.SoLuong = !string.IsNullOrEmpty(txtSoLuong.Text) ? Convert.ToInt32(txtSoLuong.Text) : 0;
            model.DonGia = !string.IsNullOrEmpty(txtDonGia.Text) ? Convert.ToInt32(txtDonGia.Text) : 0;          
            return model;
        }
        public void SetValue(ChiTietPhieuNhap model)
        {
            txtMa.Text = model.MaChiTietPhieuNhap;
            cmbMaPhieuNhap.SelectedValue = model.MaPhieuNhap;
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
                if (txtTinhTrang.Text == "Phụ Tùng")
                {
                    IsShowPhuTung(true);
                }
                else
                {
                    IsShowPhuTung(false);
                }
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
                cmbMaPhuTung.Enabled = false;
                SetControlValue(false);
                SetAllNull();
                

            }
        }
        public void SetControlValue(bool edit)
        {
            txtDonGia.Enabled = edit;
            cmbMaPhieuNhap.Enabled = edit;
            cmbSanPham.Enabled = edit;
            txtSoLuong.Enabled = edit;
            
        }
        public void SetAllNull()
        {
            txtDonGia.Text = "";
            txtSoLuong.Text = "";           
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
                "GiaNhap =" + model.DonGia + ", " +
                 "MaPhuTung ='" + model.MaPhuTung + "' " +
                " Where MaChiTietPhieuNhap='" + model.MaChiTietPhieuNhap + "'";
            var status = common.thucthidulieu(qry);
            if (status)
            {
               // UpdateSanPhamPhuTung(model);
                MessageBox.Show("Sửa thành công.");
            }
            else
            {
                MessageBox.Show("Sửa không thành công.");
            }
        }
        public void UpdateSanPhamPhuTung(ChiTietPhieuNhap model)
        {
            if (txtTinhTrang.Text == "Phụ Tùng")
            {
                // update mới số phụ tùng;
                string query = "Update [PhuTung] set " +
                "SoLuong =" + model.SoLuong + ", " +
                "Gia =" + model.DonGia + " " +
                " Where MaPhuTung='" + model.MaPhuTung.Trim() + "'";
                common.thucthidulieu(query);               
            }
            else
            {
                // update mới số lượng sản phẩm;
                string query = "Update [SanPham] set " +
                "SoLuong =" + model.SoLuong + ", " +
                "GiaNhap =" + model.DonGia + " " +
                " Where MaSanPham='" + model.MaSanPham.Trim() + "'";
                common.thucthidulieu(query);
            }
        }
        private void ThemMoi()
        {
            try
            {
                var model = GetValue();
                bool isExist = SanPhamExist(model.MaPhieuNhap,!string.IsNullOrEmpty(model.MaSanPham)? model.MaSanPham: model.MaPhuTung);
                if (isExist)
                {
                    MessageBox.Show("Sản phẩm đã tồn tại trong.");
                    return;
                }

                string ma = common.tangMaTuDong("ChiTietPhieuNhap", "CTPN");
                if (model != null)
                {
                    bool status = false;
                    if (txtTinhTrang.Text == "Phụ Tùng")
                    {
                        var qry = "Insert into [ChiTietPhieuNhap](" +
                    "MaChiTietPhieuNhap, " +
                    "MaPhieuNhap, " +
                    "SoLuong, " +
                    "GiaNhap, " +
                    "MaPhuTung " +
                    " ) values('" + ma + "'," +
                    "'" + model.MaPhieuNhap.Trim() + "'" +
                   
                    "," + model.SoLuong + "" +
                    "," + model.DonGia + "" +
                    ",'" + (!string.IsNullOrEmpty(model.MaPhuTung) ? model.MaPhuTung.Trim() : "") + "'" +

                    " )";
                       status = common.thucthidulieu(qry);
                    }
                    else
                    {
                        var qry = "Insert into [ChiTietPhieuNhap](" +
                    "MaChiTietPhieuNhap, " +
                    "MaPhieuNhap, " +
                    "MaSanPham, " +
                    "SoLuong, " +
                    "GiaNhap " +
                    " ) values('" + ma + "'," +
                    "'" + model.MaPhieuNhap.Trim() + "" +
                    "','" + (!string.IsNullOrEmpty(model.MaSanPham) ? model.MaSanPham.Trim() : "") + "'" +
                    "," + model.SoLuong + "" +
                    "," + model.DonGia + "" +                    
                    " )";
                        status = common.thucthidulieu(qry);
                    }

                    if (status)
                    {
                        //UpdateSanPhamPhuTung(model);
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
            if (cmbMaPhieuNhap.Text.Length > 0 &&
                txtDonGia.Text.Length > 0 &&
                txtSoLuong.Text.Length > 0 
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
                string timkiem = "select CTPN.MaChiTietPhieuNhap, PN.MaPhieuNhap,convert(varchar, PN.NgayNhap, 111) ,SP.MaSanPham, SP.TenSanPham, CTPN.GiaNhap, CTPN.SoLuong,(CTPN.SoLuong*CTPN.GiaNhap) from [ChiTietPhieuNhap] CTPN left join [PhieuNhap] PN on CTPN.MaPhieuNhap = PN.MaPhieuNhap left join [SanPham] SP on SP.MaSanPham = CTPN.MaSanPham where CTPN.MaChiTietPhieuNhap like '%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTen.Checked)
            {
                string timkiem = "select CTPN.MaChiTietPhieuNhap, PN.MaPhieuNhap,convert(varchar, PN.NgayNhap, 111) ,SP.MaSanPham, SP.TenSanPham, CTPN.GiaNhap, CTPN.SoLuong,(CTPN.SoLuong*CTPN.GiaNhap) from [ChiTietPhieuNhap] CTPN left join [PhieuNhap] PN on CTPN.MaPhieuNhap = PN.MaPhieuNhap left join [SanPham] SP on SP.MaSanPham = CTPN.MaSanPham where  PN.MaPhieuNhap like N'%" + txtSearch.Text + "%'";
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
            cmbMaPhieuNhap.SelectedValue = dataGRV.CurrentRow.Cells[1].Value.ToString().Trim();
            string maPhieu = cmbMaPhieuNhap.SelectedValue != null ? cmbMaPhieuNhap.SelectedValue.ToString() : "";
            var nhanVien = GetPhieuNhapId(maPhieu);

            txtNhanVien.Text = nhanVien.TenNhanVien;
            txtTinhTrang.Text = nhanVien.TinhTrang;

            cmbSanPham.SelectedValue = dataGRV.CurrentRow.Cells[3].Value.ToString().Trim();
            cmbMaPhuTung.SelectedValue = dataGRV.CurrentRow.Cells[5].Value.ToString().Trim();
            txtDonGia.Text = dataGRV.CurrentRow.Cells[7].Value.ToString().Trim();
            txtSoLuong.Text = dataGRV.CurrentRow.Cells[8].Value.ToString().Trim();
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
            txtTinhTrang.Enabled = false;
            //dataGRV.Enabled = false;
            LoadData();
            SetControl("load");

        }

        //private void cmbPhieuNhap_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    string maPhieu = cmbMaPhieuNhap.SelectedValue != null ? cmbMaPhieuNhap.SelectedValue.ToString() : "";
        //    if (!string.IsNullOrEmpty(maPhieu))
        //    {
        //        var phieu = GetPhieuNhapId(maPhieu);

        //        txtNhanVien.Text = phieu.TenNhanVien;
        //        txtTinhTrang.Text = phieu.TinhTrang;
        //    }
        //}

        private void cmbMaPhieuNhap_SelectedValueChanged(object sender, EventArgs e)
        {
            string maPhieu = cmbMaPhieuNhap.SelectedValue != null ? cmbMaPhieuNhap.SelectedValue.ToString() : "";
            if (!string.IsNullOrEmpty(maPhieu))
            {
                var phieu = GetPhieuNhapId(maPhieu);

                txtNhanVien.Text = phieu.TenNhanVien;
                txtTinhTrang.Text = phieu.TinhTrang;
            }
        }
        public ReportPhieuNhap GetChiTietPhieu(string maphieunhap)
        {
            if (!string.IsNullOrEmpty(maphieunhap))
            {
                string query = "select CTPN.MaChiTietPhieuNhap," +
                    " PN.MaPhieuNhap," +
                    "convert(varchar, PN.NgayNhap, 111) AS 'NgayNhap'," +
                    "SP.MaSanPham, " +
                    "SP.TenSanPham, " +
                    "CTPN.GiaNhap AS 'GiaNhap', " +
                    "CTPN.SoLuong AS 'SoLuong'," +
                    "(CTPN.SoLuong*CTPN.GiaNhap)," +
                    "U.TenUser," +
                    "U.MaUser," +
                    "PT.MaPhuTung," +
                    "PT.TenPhuTung, " +
                    "PN.TinhTrang from [ChiTietPhieuNhap] CTPN " +
                    "inner join [PhieuNhap] PN on CTPN.MaPhieuNhap = PN.MaPhieuNhap " +
                    "left join [SanPham] SP on SP.MaSanPham = CTPN.MaSanPham " +
                    "inner join [User] U on U.MaUser = PN.MaNhanVien " +
                    "left join [PhuTung] PT on PT.MaPhuTung = CTPN.MaPhuTung " +
                    "where PN.MaPhieuNhap = '" + maphieunhap + "'";
                DataTable dt;
                dt = common.docdulieu(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 0;
                    var ReportPN = new ReportPhieuNhap();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (i == 0)
                        {
                            var NhanVien = new NguoiDung();
                            NhanVien.TenUser = dr["TenUser"].ToString();
                            NhanVien.MaUser = dr["MaUser"].ToString();
                            ReportPN.NhanVien = NhanVien;

                            var phieunhap = new PhieuNhap();
                            phieunhap.MaPhieuNhap = dr["MaPhieuNhap"].ToString();
                            phieunhap.NgayNhap = Convert.ToDateTime(dr["NgayNhap"].ToString());
                            phieunhap.TinhTrang = dr["TinhTrang"].ToString();
                            ReportPN.PhieuNhap = phieunhap;
                            i++;
                        }

                        if (ReportPN.PhieuNhap.TinhTrang == "Phụ Tùng")
                        {
                            var sanpham = new PhuTung();
                            sanpham.MaPhuTung = dr["MaPhuTung"].ToString();
                            sanpham.TenPhuTung = dr["TenPhuTung"].ToString();
                            sanpham.Gia = Convert.ToDecimal(dr["GiaNhap"].ToString());
                            sanpham.SoLuong = Convert.ToInt32(dr["SoLuong"].ToString());

                            ReportPN.PhuTungs.Add(sanpham);
                        }
                        else
                        {
                            var sanpham = new SanPham();
                            sanpham.MaSanPham = dr["MaSanPham"].ToString();
                            sanpham.TenSanPham = dr["TenSanPham"].ToString();
                            sanpham.GiaNhap = Convert.ToDecimal(dr["GiaNhap"].ToString());
                            sanpham.SoLuong = Convert.ToInt32(dr["SoLuong"].ToString());

                            ReportPN.SanPhams.Add(sanpham);
                        }



                       

                    }
                    return ReportPN;
                }
            }
            return null;

        }



        private void printDocumentNhap_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string maPhieu = cmbMaPhieuNhap.SelectedValue != null ? cmbMaPhieuNhap.SelectedValue.ToString() : "";
            if (!string.IsNullOrEmpty(maPhieu))
            {
                //var phieu =  GetOrderImportByCode(string codeOrder);
                var phieu = GetChiTietPhieu(maPhieu);
                if (phieu != null)
                {
                    string day = DateTime.Now.Day > 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
                    string month = DateTime.Now.Month > 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
                    var w = printDocumentNhap.DefaultPageSettings.PaperSize.Width;
                    string date = "Ngày " + day + " tháng " + month + " năm " + DateTime.Now.Year;
                    e.Graphics.DrawString("PHIẾU NHẬP HÀNG", new Font("Courier New", 25, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 140, 40));
                    e.Graphics.DrawString(date, new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 120, 90));
                    int y = 150;
                    int x = 20;
                    e.Graphics.DrawString("Mã phiếu       : " + phieu.PhieuNhap.MaPhieuNhap, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    y += 40;                    
                    e.Graphics.DrawString("Mã nhân viên   : " + phieu.NhanVien.MaUser, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    y += 40;
                    e.Graphics.DrawString("Tên nhân viên  : " + phieu.NhanVien.TenUser, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    y += 40;
                    e.Graphics.DrawString("Loại hàng     : " + phieu.PhieuNhap.TinhTrang, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    y += 40;
                    e.Graphics.DrawString("Danh sách sản phẩm : ", new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(x, y));

                    y += 30;

                    e.Graphics.DrawString("STT", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    x += 50;
                    e.Graphics.DrawString("Tên sản phẩm", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    x += 250;
                    e.Graphics.DrawString("Giá ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    x += 100;
                    e.Graphics.DrawString("Số lượng", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    x += 130;
                    e.Graphics.DrawString("Thành tiền", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    //x += 140;
                    //e.Graphics.DrawString("Ghi chú", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    //x += 70;
                    //e.Graphics.DrawString("Ghi chú", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));

                    
                    decimal totalPrice = 0;
                    if (phieu.SanPhams != null && phieu.SanPhams.Count > 0)
                    {
                        int i = 0;
                        foreach (var item in phieu.SanPhams)
                        {
                            i++;
                            y += 30;
                            int ix = 20;
                            decimal total = item.GiaNhap * item.SoLuong;
                            totalPrice += total;
                            e.Graphics.DrawString(i.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            ix += 50;
                            e.Graphics.DrawString(item.TenSanPham, new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            ix += 250;
                            e.Graphics.DrawString(item.GiaNhap.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            ix += 100;
                            e.Graphics.DrawString(item.SoLuong.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            ix += 130;
                            e.Graphics.DrawString(total.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            //ix += 140;
                            //e.Graphics.DrawString(item.Note, new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                        }
                    }
                    else if(phieu.PhuTungs != null && phieu.PhuTungs.Count > 0)
                    {
                        int i = 0;
                        foreach (var item in phieu.PhuTungs)
                        {
                            i++;
                            y += 30;
                            int ix = 20;
                            decimal total = item.Gia * item.SoLuong;
                            totalPrice += total;
                            e.Graphics.DrawString(i.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            ix += 50;
                            e.Graphics.DrawString(item.TenPhuTung, new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            ix += 250;
                            e.Graphics.DrawString(item.Gia.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            ix += 100;
                            e.Graphics.DrawString(item.SoLuong.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            ix += 130;
                            e.Graphics.DrawString(total.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                            //ix += 140;
                            //e.Graphics.DrawString(item.Note, new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                        }
                    }
                    y += 40;
                    Pen blackpen = new Pen(Color.Black, 1);
                    Point p1 = new Point(10, y);
                    Point p2 = new Point(w - 10, y);
                    e.Graphics.DrawLine(blackpen, p1, p2);
                    y += 10;
                    e.Graphics.DrawString("Tổng tiền ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(20, y));
                    e.Graphics.DrawString(totalPrice.ToString("#,###"), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(550, y));
                    y += 80;
                    e.Graphics.DrawString("Ngày.... tháng....năm.... ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(500, y));

                    y += 40;
                    e.Graphics.DrawString("         NGƯỜI LẬP PHIẾU ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(-50, y));
                    //y += 30;
                    e.Graphics.DrawString("             (Ký, họ tên) ", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(-50, y + 30));

                    //y += 40;
                    e.Graphics.DrawString("         NGƯỜI GIAO HÀNG ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(200, y));
                    //y += 30;
                    e.Graphics.DrawString("             (Ký, họ tên) ", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(200, y + 30));


                    //y += 40;
                    e.Graphics.DrawString("         THỦ KHO ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(450, y));
                    //y += 30;
                    e.Graphics.DrawString("          (Ký, họ tên) ", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(450, y + 30));

                    //y += 40;
                    e.Graphics.DrawString("         GIÁM ĐỐC ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(600, y));
                    //y += 30;
                    e.Graphics.DrawString("           (Ký, họ tên) ", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(600, y + 30));
                }

            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            printPreviewNhap.Document = printDocumentNhap;
            printPreviewNhap.ShowDialog();
        }
    }
}
