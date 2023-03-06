using PhanMemQLKho.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace PhanMemQLKho
{
    public partial class frmBaoCaoThongKe : Form
    {
        public frmBaoCaoThongKe()
        {
            InitializeComponent();
        }
        public void CountData(string table,Label label)
        {
            DataTable dt;
            string query = "select COUNT(*) AS 'Count' from " + table + "";
            dt = common.docdulieu(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    label.Text = dr["Count"].ToString();
                }
            }
            
        }
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
                query = qry;
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
                    dataGRV.Rows[n].Cells[6].Value = dr["SoLuong"].ToString();
                    dataGRV.Rows[n].Cells[7].Value = dr["TinhTrang"].ToString();
                }
            }
        }
        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            CountData("DanhMucSanPham", txtSoLuongDM);
            CountData("SanPham", txtSoLuongSP);
            CountData("KhachHang", txtSoLuongKH);
            CountData("[User]", txtSoLuongNV);
            CountData("[PhuTung]", txtPhuTung);
            LoadData();
        }

        public void search()
        {

            //if (radioMa.Checked)
            //{
            //    string timkiem = "SELECT * FROM [SanPham] SP " +
            //        " INNER JOIN NhaCC NCC ON NCC.MaNCC = SP.MaNCC" +
            //        " INNER JOIN NhaSanXuat NSX ON NSX.MaSX = SP.MaNSX " +
            //        " INNER JOIN DanhMucSanPham DMSP ON DMSP.MaDanhMuc = SP.MaDanhMuc" +
            //        " INNER JOIN ThuongHieu TH ON TH.MaThuongHieu = SP.MaThuongHieu where SP.MaSanPham like N'%" + txtSearch.Text + "%'";
            //    LoadData(timkiem);
            //}
            //else if (radioTen.Checked)
            //{
            //    string timkiem = "SELECT * FROM [SanPham] SP " +
            //        " INNER JOIN NhaCC NCC ON NCC.MaNCC = SP.MaNCC" +
            //        " INNER JOIN NhaSanXuat NSX ON NSX.MaSX = SP.MaNSX " +
            //        " INNER JOIN DanhMucSanPham DMSP ON DMSP.MaDanhMuc = SP.MaDanhMuc" +
            //        " INNER JOIN ThuongHieu TH ON TH.MaThuongHieu = SP.MaThuongHieu where SP.TenSanPham like N'%" + txtSearch.Text + "%'";
            //    LoadData(timkiem);
            //}else if (raDanhMuc.Checked)
            //{
            //    string timkiem = "SELECT * FROM [SanPham] SP " +
            //        " INNER JOIN NhaCC NCC ON NCC.MaNCC = SP.MaNCC" +
            //        " INNER JOIN NhaSanXuat NSX ON NSX.MaSX = SP.MaNSX " +
            //        " INNER JOIN DanhMucSanPham DMSP ON DMSP.MaDanhMuc = SP.MaDanhMuc" +
            //        " INNER JOIN ThuongHieu TH ON TH.MaThuongHieu = SP.MaThuongHieu where DMSP.TenDanhMuc like N'%" + txtSearch.Text + "%'";
            //    LoadData(timkiem);
            //}
            //else if (raThuongHieu.Checked)
            //{
            //    string timkiem = "SELECT * FROM [SanPham] SP " +
            //       " INNER JOIN NhaCC NCC ON NCC.MaNCC = SP.MaNCC" +
            //       " INNER JOIN NhaSanXuat NSX ON NSX.MaSX = SP.MaNSX " +
            //       " INNER JOIN DanhMucSanPham DMSP ON DMSP.MaDanhMuc = SP.MaDanhMuc" +
            //       " INNER JOIN ThuongHieu TH ON TH.MaThuongHieu = SP.MaThuongHieu where TH.TenThuongHieu like N'%" + txtSearch.Text + "%'";
            //    LoadData(timkiem);
            //}
            //else
            //{
            //    LoadData();
            //}
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}
