
using PhanMemQLKho.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQLKho
{
    public partial class MainView : Form
    {
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public MainView()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            //Form
            //this.Text = string.Empty;
            //this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //Default Value
            //this.lblReleaseDateData.Text = VersionApp.DATE_RELEASE;
            //this.lblVersionData.Text = VersionApp.VERSION;
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 128, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                //button
                //currentBtn = (IconButton)senderBtn;
                //currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                //currentBtn.ForeColor = color;
                //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                //currentBtn.IconColor = color;
                //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //left border button
                leftBorderBtn.BackColor = color;
               /// leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                // icon home
                //iconcurrentChildForm.IconChar = currentBtn.IconChar;
                //iconcurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            //if (currentBtn != null)
            //{
            //    currentBtn.BackColor = Color.FromArgb(31, 30, 68);
            //    currentBtn.ForeColor = Color.Gainsboro;
            //    currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            //    currentBtn.IconColor = Color.Gainsboro;
            //    currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            //    currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            //}
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;

            //iconcurrentChildForm.IconChar = IconChar.Home;
            //iconcurrentChildForm.IconColor = Color.MediumPurple;
            lblcurrentChildForm.Text = "Màn hình chính";
        }

        private void btnFinishedTrip_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new FinishedTripForm());
        }

        private void btnRunningTrip_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
           // OpenChildForm(new RunningTripForm());
        }

        private void btnBusInfo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
           // OpenChildForm(new BusForm());
        }

        private void btnSettingDatabase_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
           // OpenChildForm(new SettingDatabaseForm());
        }

        private void btnSettingPlace_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
           // OpenChildForm(new SettingPlaceForm());
        }

        private void btnFindTrip_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
           // OpenChildForm(new FindTripForm());
        }

        private void btnConvertFromJsonData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
          //  OpenChildForm(new ConvertJsonToData());
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                // open only form
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblcurrentChildForm.Text = childForm.Text;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelSideBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Close-Maximize-Minimize
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Remove transparent border in maximized state
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void btnQuanTriHeThong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanTriHeThong());
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
        }

        private void btnQuanLyNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNCC());
        }

        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLySanPham());
        }

        private void btnQuanLyNhaSanXuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNSX());
            
        }

        private void btnQuanLyNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyNhap());
        }

        private void btnQuanLyXuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyXuat());
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBaoCaoThongKe());
        }

        private void panelSideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainView_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginInfo.TenUser))
            {
                lableTenUser.Text = LoginInfo.TenUser;
                if (LoginInfo.LoaiQuyen.ToLower().Trim() == "Admin".ToLower().Trim())
                {
                    btnQuanTriHeThong.Visible = true;
                }
                else
                {
                    btnQuanTriHeThong.Visible = false;
                }
                
            }
            else
            {
                lableTenUser.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn chắc chắn muốn thoát.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                this.Close();
                frmDangNhap form = new frmDangNhap();
                form.Show();
            }
        }
    }
}
