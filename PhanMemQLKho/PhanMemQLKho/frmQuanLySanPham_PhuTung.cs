using PhanMemQLKho.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;

namespace PhanMemQLKho
{
    public partial class frmQuanLySanPham_PhuTung : Form
    {
        public frmQuanLySanPham_PhuTung()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
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
        public string GetMaThuongHieu(string ten)
        {
            DataTable dt;
            string ma = "";
            string query = "SELECT MaThuongHieu FROM ThuongHieu where TenThuongHieu Like'%" + ten + "%'";
            dt = common.docdulieu(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ma = dr["MaThuongHieu"].ToString();                   
                }
            }
            return ma;
        }
        // Load Loại Phụ Tùng
        public void CmbLoaiPhuTung()
        {
            var data = common.GetLoaiPhuTung();
            if (data != null && data.Count > 0)
            {
                cmbLoaiPhuTung.DataSource = data;
                cmbLoaiPhuTung.DisplayMember = "TenLoaiPhuTung";
                cmbLoaiPhuTung.ValueMember = "MaLoaiPhuTung";
            }           
        }
        public void SetNull()
        {
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    C.Text = "";
                }
            }
        }
        public void LoadCmb()
        {
            CmbThuongHieu();
            CmbLoaiPhuTung();
        }
        public void LoadData(string qry = "")
        {
            DataTable dt;
            string query = "SELECT TH.TenThuongHieu ,* FROM [PhuTung] PT INNER JOIN [ThuongHieu] TH ON PT.MaThuongHieu = TH.MaThuongHieu";
            if (!string.IsNullOrEmpty(qry))
            {
                query = qry;
            }

            dt = common.docdulieu(query);

            dataGRV.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGRV.Rows.Add();
                    dataGRV.Rows[n].Cells[0].Value = dr["MaPhuTung"].ToString();
                    dataGRV.Rows[n].Cells[1].Value = dr["TenPhuTung"].ToString();
                    if (dr["LoaiPhuTung"].ToString() != null)
                    {
                        var data = common.GetLoaiPhuTung();
                        if (data != null && data.Count > 0)
                        {
                            string tenLoaiPhuTung = data.FirstOrDefault(p => p.MaLoaiPhuTung == Convert.ToInt32(dr["LoaiPhuTung"].ToString())).TenLoaiPhuTung;
                            dataGRV.Rows[n].Cells[2].Value = tenLoaiPhuTung;
                        }
                    }
                    
                    dataGRV.Rows[n].Cells[3].Value = dr["TenThuongHieu"].ToString();
                    dataGRV.Rows[n].Cells[4].Value = dr["SoLuongNhap"].ToString();
                    dataGRV.Rows[n].Cells[5].Value = dr["SoLuongBan"].ToString();
                    dataGRV.Rows[n].Cells[6].Value = dr["SoLuongCon"].ToString();

                    dataGRV.Rows[n].Cells[7].Value = dr["GiaNhap"].ToString();
                    dataGRV.Rows[n].Cells[8].Value = dr["GiaBan"].ToString();

                    int soluong = dr["SoLuongCon"] != null && !string.IsNullOrEmpty(dr["SoLuongCon"].ToString()) ? Convert.ToInt32(dr["SoLuongCon"]):0;                    
                    if (soluong > 0)
                    {
                        dataGRV.Rows[n].Cells[9].Value = "Còn Hàng";
                    }
                    else
                    {
                        dataGRV.Rows[n].Cells[9].Value = "Hết Hàng";
                    }
                }
            }
        }
        public PhuTung GetValue()
        {
            var model = new PhuTung();
            model.MaPhuTung = txtMaPhuTung.Text;
            model.TenPhuTung = txtTenPhuTung.Text;
            model.MaLoaiPhuTung = Convert.ToInt32(cmbLoaiPhuTung.SelectedValue.ToString());
            model.MaThuongHieu = cmbThuongHieu.SelectedValue.ToString();
            //model.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            //model.Gia = Convert.ToDecimal(txtGiaNhap.Text);
            model.GiaBan = Convert.ToDecimal(txtGiaBan.Text);
            //model.MoTa = txtMoTa.Text;
            return model;
        }
        public void SetValue(PhuTung model)
        {
            txtMaPhuTung.Text = model.MaPhuTung;
            txtTenPhuTung.Text = model.TenPhuTung;
            cmbLoaiPhuTung.SelectedValue = model.MaLoaiPhuTung;
            cmbThuongHieu.SelectedValue = model.MaThuongHieu;
            //txtGia.Text = model.Gia != null ? model.Gia.ToString() : "";
            txtGiaBan.Text = model.GiaBan != null ? model.GiaBan.ToString() : "";
            txtSoLuongNhap.Text = model.SoLuong != null ? model.SoLuong.ToString() : "";
            //txtMoTa.Text = model.MoTa;
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
            if (edit=="table-click")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                txtTenPhuTung.Enabled = false;
                //txtMoTa.Enabled = false;
            }
            if (edit == "edit")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
                SetControlValue(true);
            }
            if(edit == "load")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                SetControlValue(false);
                SetAllNull();
            }
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetControl("add");
            xuly = 1;
        }
        public void SetControlValue(bool edit)
        {
            //if (edit)
            //{
            //    txtTenPhuTung.Enabled = true;
            //    //txtMoTa.Enabled = true;
            //}
            //else
            //{
            //    txtTenPhuTung.Enabled = false;
            //    //txtMoTa.Enabled = false;
            //    txtTenPhuTung.Text = "";
            //    //txtMoTa.Text = "";
            //}
            txtTenPhuTung.Enabled = edit;
            cmbLoaiPhuTung.Enabled = edit;
            cmbThuongHieu.Enabled = edit;
            txtGiaBan.Enabled = edit;
            //txtSoLuong.Enabled = edit;
            //txtGiaNhap.Enabled = edit;
        }
        public void SetAllNull()
        {
            txtTenPhuTung.Text = "";
            txtSoLuongNhap.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
        }
      
        private void btnSua_Click(object sender, EventArgs e)
        {
            xuly = 2;
            SetControlValue(true);
            btnLuu.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuly = 0;
            txtMaPhuTung.Text = "";
            SetControl("load");
            SetControlValue(false);
                 
            //NewControl(false);           
        }
        private void Xoa()
        {
            if (!string.IsNullOrEmpty(txtMaPhuTung.Text))
            {
                DialogResult dlr;
                dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM PhuTung WHERE MaPhuTung='" + txtMaPhuTung.Text + "'";
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
                        //NewControl(false);
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
        public void UpdataDatabase()
        {
            var model = GetValue();
            string qry = "Update PhuTung set " +
                "TenPhuTung =N'" + model.TenPhuTung + "', " +
                "LoaiPhuTung =" + model.MaLoaiPhuTung + ", " +
                "MaThuongHieu ='" + model.MaThuongHieu + "', " +
                //"SoLuong =" + model.SoLuong + ", " +
                "GiaBan =" + model.GiaBan + "" +
                " Where MaPhuTung='" + model.MaPhuTung + "'";
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
                string ma = common.tangMaTuDong("PhuTung", "PT");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into PhuTung(MaPhuTung, " +
                    "TenPhuTung, " +
                    "LoaiPhuTung, " +
                    "MaThuongHieu, " +
                    //"SoLuong, " +
                    "GiaBan ) values('" + ma + "',N'" + model.TenPhuTung + "'," + model.MaLoaiPhuTung + ",'"+model.MaThuongHieu+"',"+model.GiaBan+")";
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
            if (txtTenPhuTung.Text.Length > 0 &&
                    cmbLoaiPhuTung.Text.Length > 0 &&
                    cmbThuongHieu.Text.Length > 0 &&
                    //txtSoLuong.Text.Length > 0 &&
                    txtGiaBan.Text.Length > 0)
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

        private void dataGRV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhuTung.Text = dataGRV.CurrentRow.Cells[0].Value.ToString();
            txtTenPhuTung.Text = dataGRV.CurrentRow.Cells[1].Value.ToString();
            string thuonghieu = GetMaThuongHieu(dataGRV.CurrentRow.Cells[3].Value.ToString());
            cmbThuongHieu.SelectedValue = thuonghieu;
            cmbLoaiPhuTung.SelectedValue = common.GetLoaiPhuTung().Where(p => p.TenLoaiPhuTung.Contains(dataGRV.CurrentRow.Cells[2].Value.ToString())).FirstOrDefault().MaLoaiPhuTung;
            txtSoLuongNhap.Text = dataGRV.CurrentRow.Cells[4].Value.ToString();
            txtSoLuongBan.Text = dataGRV.CurrentRow.Cells[5].Value.ToString();
            txtSoLuongCon.Text = dataGRV.CurrentRow.Cells[6].Value.ToString();
            txtGiaNhap.Text = dataGRV.CurrentRow.Cells[7].Value.ToString();
            txtGiaBan.Text = dataGRV.CurrentRow.Cells[8].Value.ToString();
            SetControl("table-click");
        }

      
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }

       
        public void search()
        {           
            if (radioMaPhuTung.Checked)
            {
                string timkiem = "SELECT TH.TenThuongHieu ,* FROM [PhuTung] PT INNER JOIN [ThuongHieu] TH ON PT.MaThuongHieu = TH.MaThuongHieu where MaPhuTung like '%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTenPhuTung.Checked)
            {
                string timkiem = "SELECT TH.TenThuongHieu ,* FROM [PhuTung] PT INNER JOIN [ThuongHieu] TH ON PT.MaThuongHieu = TH.MaThuongHieu where TenPhuTung like N'%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
        }
        private void frmQuanLySanPham_DanhMuc_Load(object sender, EventArgs e)
        {
            txtMaPhuTung.Enabled = false;
            LoadData();
            SetControl("load");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void frmQuanLySanPham_PhuTung_Load(object sender, EventArgs e)
        {
            txtMaPhuTung.Enabled = false;
            LoadData();
            LoadCmb();
            SetControlValue(false);
            txtSoLuongNhap.Enabled = false;
            txtGiaNhap.Enabled = false;
        }
        
    }
}
