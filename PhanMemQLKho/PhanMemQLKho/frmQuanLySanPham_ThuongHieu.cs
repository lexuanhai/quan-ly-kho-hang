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

namespace PhanMemQLKho
{
    public partial class frmQuanLySanPham_ThuongHieu : Form
    {
        public frmQuanLySanPham_ThuongHieu()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        public void LoadData(string query ="")
        {
            if (string.IsNullOrEmpty(query))
            {
                query = "select * from ThuongHieu";
            }
            common.LoadData(query,dataGRV);
        }
        public ThuongHieu GetValue()
        {
            var model = new ThuongHieu();
            model.MaThuongHieu = txtMaThuongHieu.Text;
            model.TenThuongHieu = txtTenThuongHieu.Text;
            model.MoTa = txtMoTa.Text;
            return model;
        }
        public void SetValue(ThuongHieu model)
        {
            txtMaThuongHieu.Text = model.MaThuongHieu;
            txtTenThuongHieu.Text = model.TenThuongHieu;
            txtMoTa.Text = model.MoTa;
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
                txtTenThuongHieu.Enabled = false;
                txtMoTa.Enabled = false;
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
            }
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetControl("add");
            xuly = 1;
        }
        public void SetControlValue(bool edit)
        {
            if (edit)
            {
                txtTenThuongHieu.Enabled = true;
                txtMoTa.Enabled = true;
            }
            else
            {
                txtTenThuongHieu.Enabled = false;
                txtMoTa.Enabled = false;
                txtTenThuongHieu.Text = "";
                txtMoTa.Text = "";
                txtMaThuongHieu.Text = "";
            }
          
        }
        public void NewControl(bool edit)
        {
            txtTenThuongHieu.Enabled = edit;
            txtMoTa.Enabled = edit;
            if (
                (!edit && xuly == 0) // trường hợp khi click nút hủy
                || (!edit && xuly == 1) // trường hợp khi click nut thêm mới
                )
            {
                txtTenThuongHieu.Text = "";
                txtMoTa.Text = "";
            }
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
            SetControl("load");
            SetControlValue(false);
           
            //NewControl(false);           
        }
        private void Xoa()
        {
            if (!string.IsNullOrEmpty(txtMaThuongHieu.Text))
            {
                DialogResult dlr;
                dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM ThuongHieu WHERE MaThuongHieu='" + txtMaThuongHieu.Text + "'";
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
            string qry = "Update ThuongHieu set " +
                "TenThuongHieu =N'" + model.TenThuongHieu + "', " +
                "MoTa =N'" + model.MoTa + "' " +
                " Where MaThuongHieu='" + model.MaThuongHieu + "'";
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
                string ma = common.tangMaTuDong("ThuongHieu", "TH");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into ThuongHieu(MaThuongHieu, " +
                    "TenThuongHieu, " +
                    "MoTa ) values('" + ma + "',N'" + model.TenThuongHieu + "',N'" + model.MoTa + "')";
                    var status = common.thucthidulieu(qry);
                    if (status)
                    {
                        MessageBox.Show("Thêm mới thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới không thành công.");
                    }
                    //LoadData();
                    //SetControl("");
                    //xuly = 0;
                    //NewControl(false);
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

        private void dataGRV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaThuongHieu.Text = dataGRV.CurrentRow.Cells[0].Value.ToString();
            txtTenThuongHieu.Text = dataGRV.CurrentRow.Cells[1].Value.ToString();
            txtMoTa.Text = dataGRV.CurrentRow.Cells[2].Value.ToString();
            SetControl("table-click");
        }

      
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }

       
        public void search()
        {           
            if (radioMaDanhMuc.Checked)
            {
                string timkiem = "select * from ThuongHieu where MaThuongHieu like '%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTenDanhMuc.Checked)
            {
                string timkiem = "select * from ThuongHieu where TenThuongHieu like N'%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
        }
        private void frmQuanLySanPham_DanhMuc_Load(object sender, EventArgs e)
        {
            txtMaThuongHieu.Enabled = false;
            LoadData();
            SetControl("load");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}
