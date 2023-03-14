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
            string query = "SELECT DISTINCT SP.MaSanPham,SP.TenSanPham,DMSP.TenDanhMuc,convert(varchar, PN.NgayNhap, 111) AS 'NgayNhap',convert(varchar, PX.NgayXuat, 111) AS 'NgayXuat',SP.SoLuong,SP.SoLuongBan,SP.SoLuongCon,PN.TrangThai AS'LoaiHangNhap',PX.TrangThai AS'LoaiHangXuat',SP.TinhTrang AS'LoaiHangSP' FROM [SanPham] SP " +
                "INNER JOIN DanhMucSanPham DMSP ON DMSP.MaDanhMuc = SP.MaDanhMuc " +
                "Left join ChiTietPhieuNhap CTPN ON CTPN.MaSanPham = SP.MaSanPham " +
                "LEFT JOIN PhieuNhap PN ON PN.MaPhieuNhap = CTPN.MaPhieuNhap " +
                "Left join ChiTietPhieuXuat CTPX ON CTPX.MaSanPham = SP.MaSanPham " +
                "LEFT JOIN PhieuXuat PX ON PX.MaPhieuXuat = CTPX.MaPhieuXuat ";
            
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
                    dataGRV.Rows[n].Cells[3].Value = dr["NgayNhap"].ToString();
                    dataGRV.Rows[n].Cells[4].Value = dr["NgayXuat"].ToString();
                    dataGRV.Rows[n].Cells[5].Value = dr["SoLuong"].ToString();   
                    dataGRV.Rows[n].Cells[6].Value = dr["SoLuongBan"].ToString();
                    dataGRV.Rows[n].Cells[7].Value = dr["SoLuongCon"].ToString();
                    dataGRV.Rows[n].Cells[8].Value = dr["LoaiHangSP"].ToString();
                    //if (radioNgayNhap.Checked)
                    //{
                    //    dataGRV.Rows[n].Cells[8].Value = dr["LoaiHang"].ToString();
                    //}
                    //if (radioNgayXuat.Checked)
                    //{
                    //    dataGRV.Rows[n].Cells[8].Value = dr["TrangThaiXuat"].ToString();
                    //}
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var datestart = dateTimeBatDau.Value.AddDays(-1);
            var dateend = dateTimeKetThuc.Value.AddDays(1);
            string datestartStr = datestart.ToString("yyyy/MM/dd");
            string dateendStr = dateend.ToString("yyyy/MM/dd");
            if (radioNgayNhap.Checked)
            {
                string query = " where PN.NgayNhap >='" + datestartStr + "' and PN.NgayNhap <='" + dateendStr + "'";
                LoadData(query);
            }
            if (radioNgayXuat.Checked)
            {
                string query = " where PX.NgayXuat >='" + datestartStr + "' and PX.NgayXuat <='" + dateendStr + "'";
                LoadData(query);
            }
        }
    }
}
