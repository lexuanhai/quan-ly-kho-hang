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
    public partial class frmQuanLySanPham_DanhMuc : Form
    {
        public frmQuanLySanPham_DanhMuc()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        public void LoadData(string query ="")
        {
            if (string.IsNullOrEmpty(query))
            {
                query = "select * from DanhMucSanPham";
            }
            common.LoadData(query,dataGRV);
        }
        public DanhMuc GetValue()
        {
            var model = new DanhMuc();
            model.MaDanhMuc = txtMaDanhMuc.Text;
            model.TenDanhMuc = txtTenDanhMuc.Text;
            model.GhiChu = txtGhiChu.Text;
            return model;
        }
        public void SetValue(DanhMuc model)
        {
            txtMaDanhMuc.Text = model.MaDanhMuc;
            txtTenDanhMuc.Text = model.TenDanhMuc;
            txtGhiChu.Text = model.GhiChu;
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
                txtTenDanhMuc.Enabled = false;
                txtGhiChu.Enabled = false;
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
                txtTenDanhMuc.Enabled = true;
                txtGhiChu.Enabled = true;
            }
            else
            {
                txtTenDanhMuc.Enabled = false;
                txtGhiChu.Enabled = false;
                txtTenDanhMuc.Text = "";
                txtGhiChu.Text = "";
            }
          
        }
        public void NewControl(bool edit)
        {
            txtTenDanhMuc.Enabled = edit;
            txtGhiChu.Enabled = edit;
            if (
                (!edit && xuly == 0) // trường hợp khi click nút hủy
                || (!edit && xuly == 1) // trường hợp khi click nut thêm mới
                )
            {
                txtTenDanhMuc.Text = "";
                txtGhiChu.Text = "";
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
            if (!string.IsNullOrEmpty(txtMaDanhMuc.Text))
            {
                DialogResult dlr;
                dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM DanhMucSanPham WHERE MaDanhMuc='" + txtMaDanhMuc.Text + "'";
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
            string qry = "Update DanhMucSanPham set " +
                "TenDanhMuc =N'" + model.TenDanhMuc + "', " +
                "GhiChu =N'" + model.GhiChu + "' " +
                " Where MaDanhMuc='" + model.MaDanhMuc + "'";
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
                string ma = common.tangMaTuDong("DanhMucSanPham", "DM");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into DanhMucSanPham(MaDanhMuc, " +
                    "TenDanhMuc, " +
                    "GhiChu ) values('" + ma + "',N'" + model.TenDanhMuc + "',N'" + model.GhiChu + "')";
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
            txtMaDanhMuc.Text = dataGRV.CurrentRow.Cells[0].Value.ToString();
            txtTenDanhMuc.Text = dataGRV.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = dataGRV.CurrentRow.Cells[2].Value.ToString();
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
                string timkiem = "select * from DanhMucSanPham where MaDanhMuc like '%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
            else if (radioTenDanhMuc.Checked)
            {
                string timkiem = "select * from DanhMucSanPham where TenDanhMuc like N'%" + txtSearch.Text + "%'";
                LoadData(timkiem);
            }
        }
        private void frmQuanLySanPham_DanhMuc_Load(object sender, EventArgs e)
        {
            txtMaDanhMuc.Enabled = false;
            LoadData();
            SetControl("load");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}
