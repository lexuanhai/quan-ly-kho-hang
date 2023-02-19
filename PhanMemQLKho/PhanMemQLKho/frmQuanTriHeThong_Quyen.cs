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
    public partial class frmQuanTriHeThong_Quyen : Form
    {
        public frmQuanTriHeThong_Quyen()
        {
            InitializeComponent();
        }
        int xuly = 0; //1 là thêm mới, 2 là sửa
        public void LoadData(string query ="")
        {
            if (string.IsNullOrEmpty(query))
            {
                query = "select * from Quyen";
            }
            common.LoadData(query,dataGRV);
        }
        public Quyen GetValue()
        {
            var model = new Quyen();
            model.MaQuyen = txtMaQuyen.Text;
            model.TenQuyen = txtTenQuyen.Text;
            model.GhiChu = txtGhiChu.Text;
            return model;
        }
        public void SetValue(Quyen model)
        {
            txtMaQuyen.Text = model.MaQuyen;
            txtTenQuyen.Text = model.TenQuyen;
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
                txtTenQuyen.Enabled = false;
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
        //public void SetControl(bool edit)
        //{
        //    btnThem.Enabled = !edit;
        //    btnSua.Enabled = edit;
        //    btnLuu.Enabled = edit;
        //    btnXoa.Enabled = edit;
        //    btnHuy.Enabled = edit;
        //}

        private void frmQuanTriHeThong_Quyen_Load(object sender, EventArgs e)
        {
            txtMaQuyen.Enabled = false;
            LoadData();
            SetControl("load");
            //NewControl(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetControl("add");
            //NewControl(true);
            xuly = 1;
        }
        public void SetControlValue(bool edit)
        {
            if (edit)
            {
                txtTenQuyen.Enabled = true;
                txtGhiChu.Enabled = true;
            }
            else
            {
                txtTenQuyen.Enabled = false;
                txtGhiChu.Enabled = false;
                txtTenQuyen.Text = "";
                txtGhiChu.Text = "";
            }
          
        }
        public void NewControl(bool edit)
        {
            txtTenQuyen.Enabled = edit;
            txtGhiChu.Enabled = edit;
            if (
                (!edit && xuly == 0) // trường hợp khi click nút hủy
                || (!edit && xuly == 1) // trường hợp khi click nut thêm mới
                )
            {
                txtTenQuyen.Text = "";
                txtGhiChu.Text = "";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuly = 2;
            SetControlValue(true);
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
            if (!string.IsNullOrEmpty(txtMaQuyen.Text))
            {
                DialogResult dlr;
                dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM Quyen WHERE MaQuyen='" + txtMaQuyen.Text + "'";
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
            string qry = "Update Quyen set " +
                "TenQuyen =N'" + model.TenQuyen + "', " +
                "GhiChu =N'" + model.GhiChu + "' " +
                " Where MaQuyen='" + model.MaQuyen + "'";
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
                string ma = common.tangMaTuDong("Quyen", "Q");
                if (model != null && !string.IsNullOrEmpty(ma))
                {

                    var qry = "Insert into Quyen(MaQuyen, " +
                    "TenQuyen, " +
                    "GhiChu ) values('" + ma + "',N'" + model.TenQuyen + "',N'" + model.GhiChu + "')";
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
            txtMaQuyen.Text = dataGRV.CurrentRow.Cells[0].Value.ToString();
            txtTenQuyen.Text = dataGRV.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = dataGRV.CurrentRow.Cells[2].Value.ToString();
            SetControl("table-click");
        }
    }
}
