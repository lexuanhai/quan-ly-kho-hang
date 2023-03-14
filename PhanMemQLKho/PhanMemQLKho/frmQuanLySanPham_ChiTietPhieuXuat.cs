using PhanMemQLKho.Model;
using System;
using System.Collections;
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
    public partial class frmQuanLySanPham_ChiTietPhieuXuat : Form
    {
        public frmQuanLySanPham_ChiTietPhieuXuat()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        bool isSuaChua;
        public void LoadData(string query = "")
        {
           
            if (string.IsNullOrEmpty(query))
            {
                //query = "select CTPX.MaChiTietPhieuXuat, PX.MaPhieuXuat, convert(varchar, PX.NgayXuat, 111) AS 'NgayXuat' , SP.MaSanPham, SP.TenSanPham, CTPX.GiaXuat, CTPX.SoLuong, (CTPX.SoLuong*CTPX.GiaXuat) from [ChiTietPhieuXuat] CTPX " +
                //    "inner join [PhieuXuat] PX on PX.MaPhieuXuat = CTPX.MaPhieuXuat " +
                //    "inner join [SanPham] SP on SP.MaSanPham = CTPX.MaSanPham " +
                //    "inner join [User] NV on NV.MaUser = PX.MaNhanVien " +
                //    "inner join [KhachHang] KH on KH.MaKH = PX.MaKH " +
                //    "where PX.TrangThai = N'Chưa Hoàn Thành'";
                query = "select CTPX.MaChiTietPhieuXuat, PX.MaPhieuXuat, convert(varchar, PX.NgayXuat, 111) AS 'NgayXuat' , SP.MaSanPham, SP.TenSanPham,PT.MaPhuTung,PT.TenPhuTung ,CTPX.GiaXuat, CTPX.SoLuong, (CTPX.SoLuong*CTPX.GiaXuat) from [ChiTietPhieuXuat] CTPX " +
                    "inner join [PhieuXuat] PX on PX.MaPhieuXuat = CTPX.MaPhieuXuat " +
                    "inner join [SanPham] SP on SP.MaSanPham = CTPX.MaSanPham " +
                    "inner join [User] NV on NV.MaUser = PX.MaNhanVien " +
                    "inner join [KhachHang] KH on KH.MaKH = PX.MaKH " +
                    "left join [PhuTung] PT on PT.MaPhuTung = CTPX.MaPhuTung";

            }
            
            common.LoadData(query, dataGRV);
        }
        // Load sản phẩm
        public void CmbSanPham()
        {
            DataTable dt;
            string query = "SELECT * FROM [SanPham]";
            dt = common.docdulieu(query);
            cmbSanPham.DisplayMember = "TenSanPham";
            cmbSanPham.ValueMember = "MaSanPham";
            cmbSanPham.DataSource = dt;
        }
        public void CmbPhuTung()
        {
            DataTable dt;
            string query = "SELECT * FROM [PhuTung]";
            dt = common.docdulieu(query);
            cmbPhuTung.DisplayMember = "TenPhuTung";
            cmbPhuTung.ValueMember = "MaPhuTung";
            cmbPhuTung.DataSource = dt;
        }
        // Load phiếu nhập
        public void CmbPhieuXuat()
        {
            DataTable dt;
            string query = "SELECT * FROM [PhieuXuat]";
            //string query = "SELECT * FROM [PhieuXuat] where PhieuXuat.TrangThai = N'Chưa Hoàn Thành'";
            dt = common.docdulieu(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["MaPhieuXuat"] = dr["MaPhieuXuat"].ToString().Trim();
                    string loaihang = dr["LoaiHang"].ToString().Trim();
                    if (loaihang == "Sửa Chữa")
                    {
                        isSuaChua = true;
                    }
                }
            }

            cmbMaPhieuXuat.DisplayMember = "MaPhieuXuat";
            cmbMaPhieuXuat.ValueMember = "MaPhieuXuat";
            cmbMaPhieuXuat.DataSource = dt;
        }
        public bool SanPhamExist(string maPX, string maSP)
        {
            string query = "select * from PhieuXuat PX " +
                "inner join ChiTietPhieuXuat CTPX on CTPX.MaPhieuXuat = PX.MaPhieuXuat " +
                "where PX.MaPhieuXuat = '" + maPX.Trim() + "' and (CTPX.MaSanPham = '" + maSP.Trim() + "' OR CTPX.MaPhuTung ='"+ maSP.Trim() + "')";
            var dt = common.docdulieu(query);
            if (dt != null && dt.Rows.Count > 0)
                return true;
            return false;
        }
        public bool PhuTungExist(string maPX, string maSP)
        {
            string query = "select * from PhieuXuat PX " +
                "inner join ChiTietPhieuXuat CTPX on CTPX.MaPhieuXuat = PX.MaPhieuXuat " +
                "where PX.MaPhieuXuat = '" + maPX.Trim() + "' and  CTPX.MaPhuTung ='" + maSP.Trim() + "'";
            var dt = common.docdulieu(query);
            if (dt != null && dt.Rows.Count > 0)
                return true;
            return false;
        }
        public SanPham GetSanPhamId(string ma)
        {
            DataTable dt;
            string query = "SELECT * FROM [SanPham] where MaSanPham ='"+ ma + "'";
            dt = common.docdulieu(query);
            var model = new SanPham();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model.GiaBan = dr["GiaBan"] != null && !string.IsNullOrEmpty(dr["GiaBan"].ToString()) ? Convert.ToDecimal(dr["GiaBan"]): 0;
                    model.SoLuong = dr["SoLuong"] != null && !string.IsNullOrEmpty(dr["SoLuong"].ToString()) ? Convert.ToInt32(dr["SoLuong"]) : 0;
                    model.SoLuongBan = dr["SoLuongBan"] != null && !string.IsNullOrEmpty(dr["SoLuongBan"].ToString()) ? Convert.ToInt32(dr["SoLuongBan"]) : 0;
                    model.SoLuongCon = dr["SoLuongCon"] != null && !string.IsNullOrEmpty(dr["SoLuongCon"].ToString()) ? Convert.ToInt32(dr["SoLuongCon"]) : 0;
                }
            }
            return model;
        }
        public PhieuXuat GetPhieuNhapId(string ma)
        {
            DataTable dt;
            string query = "SELECT [LoaiHang]  FROM [PhieuXuat] PX " +
                    "where  MaPhieuXuat ='"+ ma + "'";
            dt = common.docdulieu(query);
            var model = new PhieuXuat();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model.LoaiHang= dr["LoaiHang"].ToString();                    
                }
            }
            return model;
        }
        public void ShowSuaChua()
        {
            if (isSuaChua)
            {
                cmbPhuTung.Enabled = true;
                txtDonGiaPhuTung.Enabled = true;

                cmbSanPham.Enabled = false;
                txtDonGia.Enabled = false;
            }
            else
            {
                cmbPhuTung.Enabled = false;
                txtDonGiaPhuTung.Enabled = false;

                cmbSanPham.Enabled = true;
                txtDonGia.Enabled = true;
            }
        }
        public PhuTung GetPhuTungId(string ma)
        {
            DataTable dt;
            string query = "SELECT * FROM [PhuTung] PT " +
                    "where  MaPhuTung ='" + ma + "'";
            dt = common.docdulieu(query);
            var model = new PhuTung();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["SoLuongBan"] != null && !string.IsNullOrEmpty(dr["SoLuongBan"].ToString()))
                    {
                        model.SoLuongBan = Convert.ToInt32(dr["SoLuongBan"].ToString());
                        model.SoLuongCon = Convert.ToInt32(dr["SoLuongCon"].ToString());
                    }
                    if (dr["SoLuongCon"] != null && !string.IsNullOrEmpty(dr["SoLuongCon"].ToString()))
                    {                       
                        model.SoLuongCon = Convert.ToInt32(dr["SoLuongCon"].ToString());
                    }
                    if (dr["SoLuong"] != null && !string.IsNullOrEmpty(dr["SoLuong"].ToString()))
                    {
                        model.SoLuong = Convert.ToInt32(dr["SoLuong"].ToString());
                    }
                    model.GiaBan = dr["GiaBan"] != null && !string.IsNullOrEmpty(dr["GiaBan"].ToString()) ? Convert.ToDecimal(dr["GiaBan"]) : 0;
                }
            }
            return model;
        }
        public void LoadCmb()
        {
            CmbSanPham();
            CmbPhieuXuat();
            CmbPhuTung();
        }

        public ChiTietPhieuXuat GetValue()
        {
            var model = new ChiTietPhieuXuat();
            model.MaChiTietPhieuXuat = txtMa.Text;
            model.MaPhieuXuat = cmbMaPhieuXuat.SelectedValue.ToString();
            model.MaSanPham = cmbSanPham.SelectedValue.ToString();
            model.MaPhuTung = cmbPhuTung.SelectedValue.ToString();
            model.SoLuong = !string.IsNullOrEmpty(txtSoLuong.Text) ? Convert.ToInt32(txtSoLuong.Text) : 0;
           
            model.DonGia = !string.IsNullOrEmpty(txtDonGia.Text) ? Convert.ToInt32(txtDonGia.Text) : 0;
            if (model.DonGia == 0)
            {
                model.DonGia = !string.IsNullOrEmpty(txtDonGiaPhuTung.Text) ? Convert.ToInt32(txtDonGiaPhuTung.Text) : 0;
            }

            return model;
        }
        public void SetValue(ChiTietPhieuNhap model)
        {
            txtMa.Text = model.MaChiTietPhieuNhap;
            cmbMaPhieuXuat.SelectedValue = model.MaPhieuNhap;
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
            //txtDonGia.Enabled = edit;
            //cmbMaPhieuXuat.Enabled = edit;
            cmbMaPhieuXuat.Enabled = edit;
            if (isSuaChua)
            {
                cmbSanPham.Enabled = true;
                txtDonGia.Enabled = true;
                txtSoLuongCon.Text = "";
                txtDonGia.Text = "";
                txtDonGia.Enabled = false;

                cmbPhuTung.Enabled = true;
                txtDonGiaPhuTung.Enabled = true;
            }else if (txtLoaiHang.Text =="Phụ Tùng")
            {
                cmbSanPham.Enabled = false;
                txtDonGia.Enabled = false;
                txtSoLuongCon.Enabled = false;
            }
            else
            {
                cmbSanPham.Enabled = true;
                txtDonGia.Enabled = true;
                cmbPhuTung.Enabled = false;
                txtDonGiaPhuTung.Enabled = false;
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
                        string query = "DELETE FROM [ChiTietPhieuXuat] WHERE MaChiTietPhieuXuat='" + txtMa.Text + "'";
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
            //SetControlValue(true);
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }
        public void UpdataDatabase()
        {
            var model = GetValue();
            string qry = "Update [ChiTietPhieuXuat] set " +
                "MaPhieuXuat ='" + model.MaPhieuXuat.Trim() + "', " +
                "MaSanPham ='" + model.MaSanPham.Trim() + "', " +
                "SoLuong =" + model.SoLuong + ", " +
                "GiaXuat =" + model.DonGia + " " +
                " Where MaChiTietPhieuXuat='" + model.MaChiTietPhieuXuat + "'";
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


                if (!string.IsNullOrEmpty(model.MaSanPham))
                {
                    bool isExist = SanPhamExist(model.MaPhieuXuat, model.MaSanPham);                    
                    if (txtLoaiHang.Text =="Sửa Chữa")
                    {
                        isExist = PhuTungExist(model.MaPhieuXuat, model.MaPhuTung);
                        if (isExist)
                        {
                            MessageBox.Show("Phụ tùng đã tồn tại trong.");
                            return;
                        }
                        int soluongcon = !string.IsNullOrEmpty(txtSoLuongConPT.Text) ? Convert.ToInt32(txtSoLuongConPT.Text) : 0;
                        if (soluongcon == 0)
                        {
                            MessageBox.Show("Phụ tùng đã hết hàng vui lòng chọn Phụ tùng khác khác.");
                            return;
                        }

                        int soluongmua = !string.IsNullOrEmpty(txtSoLuong.Text) ? Convert.ToInt32(txtSoLuong.Text) : 0;
                        if (soluongmua > 0)
                        {                            
                            int soluongton = soluongcon - soluongmua;
                            if (soluongton < 0)
                            {
                                MessageBox.Show(" Vui lòng chọn lại số lượng.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(" vui lòng chọn số lượng lớn hơn 0.");
                            return;
                        }
                    }
                    else
                    {
                        if (isExist)
                        {
                            MessageBox.Show("Sản phẩm đã tồn tại trong.");
                            return;
                        }
                        int soluongcon = !string.IsNullOrEmpty(txtSoLuongCon.Text) ? Convert.ToInt32(txtSoLuongCon.Text) : 0;
                        if (soluongcon == 0)
                        {
                            MessageBox.Show("Sản phẩm đã hết hàng vui lòng chọn sản phẩm khác.");
                            return;
                        }

                        int soluongmua = !string.IsNullOrEmpty(txtSoLuong.Text) ? Convert.ToInt32(txtSoLuong.Text) : 0;
                        if (soluongmua > 0)
                        {
                            var sanPham = GetSanPhamId(model.MaSanPham);
                            int soluongton = sanPham.SoLuong - soluongmua;
                            if (soluongton < 0)
                            {
                                MessageBox.Show(" Vui lòng chọn lại số lượng.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(" vui lòng chọn số lượng lớn hơn 0.");
                            return;
                        }
                    }
                   
                }

                string ma = common.tangMaTuDong("ChiTietPhieuXuat", "CTPX");
                if (model != null && !string.IsNullOrEmpty(ma))
                {
                    var qry = "Insert into [ChiTietPhieuXuat](" +
                    "MaChiTietPhieuXuat, " +
                    "MaPhieuXuat, " +
                    "MaSanPham, " +
                    "SoLuong, " +
                    "GiaXuat " +                   
                    " ) values('" + ma.Trim() + "'," +
                    "'" + model.MaPhieuXuat.Trim() + "'" +
                    ",'" + model.MaSanPham.Trim() + "'" +
                    "," + model.SoLuong + "" +
                    "," + model.DonGia + "" +
                    
                    ")";

                    if (txtLoaiHang.Text == "Sửa Chữa")
                    {
                        qry = "Insert into [ChiTietPhieuXuat](" +
                    "MaChiTietPhieuXuat, " +
                    "MaPhieuXuat, " +
                    "MaSanPham, " +
                    "MaPhuTung, " +
                    "SoLuong, " +
                    "GiaXuat " +
                    " ) values('" + ma.Trim() + "'," +
                    "'" + model.MaPhieuXuat.Trim() + "'" +
                    ",'" + model.MaSanPham.Trim() + "'" +
                    ",'" + model.MaPhuTung.Trim() + "'" +
                    "," + model.SoLuong + "" +
                    "," + model.DonGia + "" +

                    ")";
                    }


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
            //SetControlValue(false);
        }
        public void search()
        {

            if (radioMa.Checked)
            {
                string timkiem = "select CTPX.MaChiTietPhieuXuat, PX.MaPhieuXuat,convert(varchar, PX.NgayXuat, 111) ," +
                    "SP.MaSanPham, SP.TenSanPham,PT.MaPhuTung,PT.TenPhuTung ,CTPX.GiaXuat, CTPX.SoLuong,(CTPX.SoLuong*CTPX.GiaXuat) from [ChiTietPhieuXuat] CTPX " +
                    "left join [PhieuXuat] PX on CTPX.MaPhieuXuat = PX.MaPhieuXuat " +
                    "left join [SanPham] SP on SP.MaSanPham = CTPX.MaSanPham " +
                    "left join [PhuTung] PT on PT.MaPhuTung = CTPX.MaPhuTung " +
                    "where CTPX.MaChiTietPhieuXuat like '%"+ txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTen.Checked)
            {
                string timkiem = "select CTPX.MaChiTietPhieuXuat, PX.MaPhieuXuat,convert(varchar, PX.NgayXuat, 111) ," +
                     "SP.MaSanPham, SP.TenSanPham, PT.MaPhuTung,PT.TenPhuTung, CTPX.GiaXuat, CTPX.SoLuong,(CTPX.SoLuong*CTPX.GiaXuat) from [ChiTietPhieuXuat] CTPX " +
                     "left join [PhieuXuat] PX on CTPX.MaPhieuXuat = PX.MaPhieuXuat " +
                     "left join [SanPham] SP on SP.MaSanPham = CTPX.MaSanPham " +
                     "left join [PhuTung] PT on PT.MaPhuTung = CTPX.MaPhuTung " +
                     "where CTPX.MaPhieuXuat like '%" + txtSearch.Text + "%'";
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
            cmbMaPhieuXuat.SelectedValue = dataGRV.CurrentRow.Cells[1].Value.ToString().Trim();
            cmbSanPham.SelectedValue = dataGRV.CurrentRow.Cells[3].Value.ToString().Trim();
           
            txtDonGia.Text = dataGRV.CurrentRow.Cells[5].Value.ToString().Trim();
            txtSoLuong.Text = dataGRV.CurrentRow.Cells[6].Value.ToString().Trim();
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
            txtSoLuongCon.Enabled = false;
            txtLoaiHang.Enabled = false;
            //txtTinhTrang.Enabled = false;
            LoadData();
            SetControl("load");
            //cmbPhuTung.Enabled = false;
            //cmbSanPham.Enabled = false;
            //ShowSuaChua();

        }

        //private void cmbPhieuNhap_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    string maPhieu = cmbMaPhieuXuat.SelectedValue != null ? cmbMaPhieuXuat.SelectedValue.ToString() : "";
        //    if (!string.IsNullOrEmpty(maPhieu))
        //    {
        //        var nhanVien = GetPhieuNhapId(maPhieu);

        //        txtNhanVien.Text = nhanVien.TenUser;
        //    }
        //}

        private void cmbSanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            string maPhieu = cmbSanPham.SelectedValue != null ? cmbSanPham.SelectedValue.ToString() : "";
            if (!string.IsNullOrEmpty(maPhieu))
            {
                var sanpham = GetSanPhamId(maPhieu);
                txtDonGia.Text = sanpham.GiaBan.ToString();                

                txtSoLuongCon.Text = (sanpham.SoLuong - sanpham.SoLuongBan).ToString();
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            printPreviewXuat.Document = printDocumentXuat;
            printPreviewXuat.ShowDialog();
        }
        public ReportPhieuXuat GetChiTietPhieu(string maphieuxuat)
        {
            if (!string.IsNullOrEmpty(maphieuxuat))
            {
                string query = "select CTPX.MaChiTietPhieuXuat, " +
                    "PX.MaPhieuXuat, " +
                    "convert(varchar, PX.NgayXuat, 111) AS 'NgayXuat' ," +
                    " SP.MaSanPham, " +
                    "SP.TenSanPham, " +
                    "CTPX.GiaXuat, " +
                    "CTPX.SoLuong, " +
                    "(CTPX.SoLuong*CTPX.GiaXuat) , " +
                    "KH.TenKhachHang, " +
                    "PX.LoaiHang," +
                    "KH.SoDienThoai, " +
                    "KH.DiaChi from [ChiTietPhieuXuat] CTPX " +
                   "inner join [PhieuXuat] PX on PX.MaPhieuXuat = CTPX.MaPhieuXuat " +
                   "inner join [SanPham] SP on SP.MaSanPham = CTPX.MaSanPham " +
                   "inner join [User] NV on NV.MaUser = PX.MaNhanVien " +
                   "inner join [KhachHang] KH on KH.MaKH = PX.MaKH " +
                   "where PX.MaPhieuXuat = '"+ maphieuxuat + "'";
                if (txtLoaiHang.Text == "Sửa Chữa")
                {
                     query = "select CTPX.MaChiTietPhieuXuat, " +
                    "PX.MaPhieuXuat, " +
                    "convert(varchar, PX.NgayXuat, 111) AS 'NgayXuat' ," +
                    " SP.MaSanPham, " +
                    "SP.TenSanPham, " +
                    "PT.MaPhuTung, " +
                    "PT.TenPhuTung, " +
                    "CTPX.GiaXuat, " +
                    "CTPX.SoLuong, " +
                    "(CTPX.SoLuong*CTPX.GiaXuat) , " +
                    "KH.TenKhachHang, " +
                    "PX.LoaiHang," +
                    "KH.SoDienThoai, " +
                    "KH.DiaChi from [ChiTietPhieuXuat] CTPX " +
                   "inner join [PhieuXuat] PX on PX.MaPhieuXuat = CTPX.MaPhieuXuat " +
                   "inner join [SanPham] SP on SP.MaSanPham = CTPX.MaSanPham " +
                   "inner join [PhuTung] PT on PT.MaPhuTung = CTPX.MaPhuTung " +
                   "inner join [User] NV on NV.MaUser = PX.MaNhanVien " +
                   "inner join [KhachHang] KH on KH.MaKH = PX.MaKH " +
                   "where PX.MaPhieuXuat = '" + maphieuxuat + "'";
                }
                DataTable dt;             
                dt = common.docdulieu(query);               
                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 0;
                    var ReportPX = new ReportPhieuXuat();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (i == 0)
                        {
                            var khachhang = new KhachHang();
                            khachhang.TenKhachHang = dr["TenKhachHang"].ToString();
                            khachhang.SoDienThoai = dr["SoDienThoai"].ToString();
                            khachhang.DiaChi = dr["DiaChi"].ToString();
                            ReportPX.KhachHang = khachhang;

                            var phieuxuat = new PhieuXuat();
                            phieuxuat.MaPhieuXuat = dr["MaPhieuXuat"].ToString();
                            phieuxuat.NgayXuat = Convert.ToDateTime(dr["NgayXuat"].ToString());
                            phieuxuat.LoaiHang = dr["LoaiHang"].ToString();
                            ReportPX.PhieuXuat = phieuxuat;
                            i++;
                        }
                        
                        var sanpham = new SanPham();
                        sanpham.TenSanPham = dr["TenSanPham"].ToString();
                        sanpham.GiaBan = Convert.ToDecimal(dr["GiaXuat"].ToString());
                        sanpham.SoLuong =Convert.ToInt32(dr["SoLuong"].ToString());
                        

                        ReportPX.SanPhams.Add(sanpham);

                        if (txtLoaiHang.Text == "Sửa Chữa")
                        {
                            var phutung = new PhuTung();
                            phutung.MaPhuTung = dr["MaPhuTung"].ToString();
                            phutung.TenPhuTung = dr["TenPhuTung"].ToString();
                            phutung.GiaBan = Convert.ToDecimal(dr["GiaXuat"].ToString());
                            phutung.SoLuong = Convert.ToInt32(dr["SoLuong"].ToString());
                            ReportPX.PhuTungs.Add(phutung);
                        }

                    }
                    return ReportPX;
                }
            }
            return null;

        }

        private void printDocumentXuat_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string maPhieu = cmbMaPhieuXuat.SelectedValue != null ? cmbMaPhieuXuat.SelectedValue.ToString() : "";
            if (!string.IsNullOrEmpty(maPhieu))
            {
                var phieu = GetChiTietPhieu(maPhieu);
                if (phieu != null)
                {
                    string day = DateTime.Now.Day > 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
                    string month = DateTime.Now.Month > 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
                    var w = printDocumentXuat.DefaultPageSettings.PaperSize.Width;
                    string date = "Ngày " + day + " tháng " + month + " năm " + DateTime.Now.Year;
                    e.Graphics.DrawString("PHIẾU XUẤT HÀNG", new Font("Courier New", 25, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 140, 40));
                    e.Graphics.DrawString(date, new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 120, 90));
                    int y = 150;
                    int x = 20;
                    e.Graphics.DrawString("Mã phiếu       : " + phieu.PhieuXuat.MaPhieuXuat, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    y += 40;
                    e.Graphics.DrawString("Ngày tạo       : " + phieu.PhieuXuat.NgayXuat.ToString("dd/MM/yyyy"), new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    if (phieu.PhieuXuat.LoaiHang =="Sửa Chữa")
                    {
                        y += 40;
                        e.Graphics.DrawString("Tên Xe         : " + phieu.SanPhams[0].TenSanPham, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    }
                    
                    y += 40;
                    e.Graphics.DrawString("Loại hàng      : " + phieu.PhieuXuat.LoaiHang, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    y += 40;
                    e.Graphics.DrawString("Thông tin khách hàng : ", new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    y += 40;
                    e.Graphics.DrawString("Tên khách hàng       : " + phieu.KhachHang.TenKhachHang, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    y += 40;
                    e.Graphics.DrawString("Số điện thoại        : " + phieu.KhachHang.SoDienThoai, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    y += 40;
                    e.Graphics.DrawString("Địa chỉ              : " + phieu.KhachHang.DiaChi, new Font("Courier New", 13, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    y += 50;

                    e.Graphics.DrawString("STT", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    if (phieu.PhieuXuat.LoaiHang == "Sửa Chữa")
                    {
                        x += 50;
                        e.Graphics.DrawString("Tên Phụ Tùng", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    }
                    else
                    {
                        x += 50;
                        e.Graphics.DrawString("Tên sản phẩm", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    }
                    
                    x += 430;
                    e.Graphics.DrawString("Giá ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    x += 90;
                    e.Graphics.DrawString("Số lượng", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));
                    x += 120;
                    e.Graphics.DrawString("Thành tiền", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(x, y));

                    decimal totalPrice = 0;
                    if (phieu.PhieuXuat.LoaiHang == "Sửa Chữa")
                    {
                        if (phieu.PhuTungs != null && phieu.PhuTungs.Count > 0)
                        {
                            int i = 0;
                            foreach (var item in phieu.PhuTungs)
                            {
                                i++;
                                y += 30;
                                int ix = 20;
                                decimal total = item.GiaBan * item.SoLuong;
                                totalPrice += total;
                                e.Graphics.DrawString(i.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                                ix += 50;
                                e.Graphics.DrawString(item.TenPhuTung, new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                                ix += 430;
                                e.Graphics.DrawString(item.GiaBan.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                                ix += 90;
                                e.Graphics.DrawString(item.SoLuong.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                                ix += 120;
                                e.Graphics.DrawString(total.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));

                            }
                        }
                    }
                    else
                    {
                        if (phieu.SanPhams != null && phieu.SanPhams.Count > 0)
                        {
                            int i = 0;
                            foreach (var item in phieu.SanPhams)
                            {
                                i++;
                                y += 30;
                                int ix = 20;
                                decimal total = item.GiaBan * item.SoLuong;
                                totalPrice += total;
                                e.Graphics.DrawString(i.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                                ix += 50;
                                e.Graphics.DrawString(item.TenSanPham, new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                                ix += 430;
                                e.Graphics.DrawString(item.GiaBan.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                                ix += 90;
                                e.Graphics.DrawString(item.SoLuong.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));
                                ix += 120;
                                e.Graphics.DrawString(total.ToString(), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(ix, y));

                            }
                        }
                    }
                    
                    y += 40;
                    Pen blackpen = new Pen(Color.Black, 1);
                    Point p1 = new Point(10, y);
                    Point p2 = new Point(w - 10, y);
                    e.Graphics.DrawLine(blackpen, p1, p2);
                    y += 10;
                    e.Graphics.DrawString("Tổng tiền ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(20, y));

                    e.Graphics.DrawString(totalPrice.ToString("#,###"), new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(710, y));
                    y += 80;
                    e.Graphics.DrawString("Ngày.... tháng....năm.... ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(500, y));

                    y += 40;
                    e.Graphics.DrawString("         NGƯỜI LẬP PHIẾU ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(-50, y));
                    //y += 30;
                    e.Graphics.DrawString("             (Ký, họ tên) ", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(-50, y + 30));

                    //y += 40;
                    e.Graphics.DrawString("         NGƯỜI NHẬN HÀNG ", new Font("Courier New", 13, FontStyle.Bold), Brushes.Black, new Point(200, y));
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

        //private void cmbMaPhieuNhap_SelectedValueChanged(object sender, EventArgs e)
        //{

        //}

        private void cmbMaPhieuXuat_SelectedValueChanged(object sender, EventArgs e)
        {
            string maPhieu = cmbMaPhieuXuat.SelectedValue != null ? cmbMaPhieuXuat.SelectedValue.ToString() : "";
            if (!string.IsNullOrEmpty(maPhieu))
            {
                var phieuXuat = GetPhieuNhapId(maPhieu);

                txtLoaiHang.Text = phieuXuat.LoaiHang;
                if (phieuXuat.LoaiHang == "Sửa Chữa")
                {
                    isSuaChua = true;                   
                }
                else
                {
                    isSuaChua = false;
                }
                SetControlValue(true);
            }
        }

        private void cmbPhuTung_SelectedValueChanged(object sender, EventArgs e)
        {
            string maPT = cmbPhuTung.SelectedValue != null ? cmbPhuTung.SelectedValue.ToString() : "";
            if (!string.IsNullOrEmpty(maPT))
            {
                var phuTung = GetPhuTungId(maPT);
                txtSoLuongConPT.Text = (phuTung.SoLuong - phuTung.SoLuongCon).ToString();
                txtDonGiaPhuTung.Text = phuTung.GiaBan.ToString();
            }
        }
    }
}
