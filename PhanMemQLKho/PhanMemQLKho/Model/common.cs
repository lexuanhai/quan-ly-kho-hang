using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;

namespace PhanMemQLKho.Model
{
    public static class common
    {
        static string chuoiKetNoi = "Data Source=G07VNXDFVLTTI15;Initial Catalog=WarehouseDatabase;Integrated Security=True"; //ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        static SqlConnection con = new SqlConnection(chuoiKetNoi);
        public static void moketnoi()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public static void dongketnoi()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public static Boolean thucthidulieu(string cmd)
        {
            moketnoi();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            dongketnoi();
            return check;
        }
        public static DataTable docdulieu(string cmd)
        {
            moketnoi();
            DataTable da = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(da);
            }
            catch (Exception)
            {
                da = null;
            }
            dongketnoi();
            return da;
        }
        public static string tangMaTuDong(string table, string ma)
        {
            string cauTruyVan = "select * from [" + table+"]";
            DataTable dt = docdulieu(cauTruyVan);
            string maTuDong = ma;
            if (dt != null && dt.Rows.Count > 0)
            {
                string rowEnd = dt.Rows[dt.Rows.Count - 1][0].ToString();
                if (rowEnd.IndexOf(ma) >= 0)
                {
                    string number = rowEnd.Substring(ma.Length);
                    int k = Convert.ToInt32(number);
                    k = k + 1;
                    if (k < 10)
                    {
                        maTuDong = maTuDong + "00";
                    }
                    else if (k < 100)
                    {
                        maTuDong = maTuDong + "0";
                    }
                    maTuDong = maTuDong + k.ToString();
                }
                else
                {
                    maTuDong = maTuDong + "001";
                }

            }
            else
            {
                maTuDong = maTuDong + "001";
            }
           
            return maTuDong;
            
        }
        public static void OpenChildForm(Form childForm, Form parent,Panel panel)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
        public static void LoadData(string query,DataGridView datagrv)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(query))
            {
                dt = common.docdulieu(query);               
                if (dt != null && dt.Rows.Count > 0)
                {
                    datagrv.Rows.Clear();
                    int countCell = dt.Columns.Count;
                    foreach (DataRow dr in dt.Rows)
                    {
                        int n = datagrv.Rows.Add();
                        for (int i = 0; i < countCell; i++)
                        {
                            datagrv.Rows[n].Cells[i].Value = dr[i].ToString();
                        }
                    }
                }
                else
                {
                    datagrv.Rows.Clear();
                }
            }
        }
        public static List<LoaiPhuTung> GetLoaiPhuTung()
        {
            var lstData = new List<LoaiPhuTung>()
            {
                new LoaiPhuTung() {
                    MaLoaiPhuTung = 1,
                    TenLoaiPhuTung = "Động Cơ"
                },
                new LoaiPhuTung() {
                    MaLoaiPhuTung = 2,
                    TenLoaiPhuTung = "Gầm"
                },
                new LoaiPhuTung() {
                    MaLoaiPhuTung = 3,
                    TenLoaiPhuTung = "Điện - Điều Hòa"
                },
                new LoaiPhuTung() {
                    MaLoaiPhuTung = 4,
                    TenLoaiPhuTung = "Thân - Vỏ"
                },
            };
            return lstData;
        }
    }
    public class SelectItemCustom
    {
        public string MaDanhMuc { get; set; }
        public string MaNCC { get; set; }
        public string MaNSX { get; set; }
        public string MaThuongHieu { get; set; }
    }
    public static class LoginInfo
    {
        public static string UserID;
        public static string TenDangNhap;
        public static string TenUser;
        public static string LoaiQuyen;
    }
}
