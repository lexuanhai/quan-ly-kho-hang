
namespace PhanMemQLKho
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribHeThong = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribNguoiDung = new System.Windows.Forms.RibbonButton();
            this.ribSanPham = new System.Windows.Forms.RibbonTab();
            this.ribKhoHang = new System.Windows.Forms.RibbonTab();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribBaoCaoThongKe = new System.Windows.Forms.RibbonTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbVisible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(880, 107);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribHeThong);
            this.ribbon1.Tabs.Add(this.ribSanPham);
            this.ribbon1.Tabs.Add(this.ribKhoHang);
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribBaoCaoThongKe);
            this.ribbon1.TabStop = false;
            this.ribbon1.Text = "ribbon1";
            // 
            // ribHeThong
            // 
            this.ribHeThong.Name = "ribHeThong";
            this.ribHeThong.Panels.Add(this.ribbonPanel1);
            this.ribHeThong.Text = "Quản lý hệ thống";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribNguoiDung);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "";
            // 
            // ribNguoiDung
            // 
            this.ribNguoiDung.Image = ((System.Drawing.Image)(resources.GetObject("ribNguoiDung.Image")));
            this.ribNguoiDung.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribNguoiDung.LargeImage")));
            this.ribNguoiDung.MinimumSize = new System.Drawing.Size(80, 0);
            this.ribNguoiDung.Name = "ribNguoiDung";
            this.ribNguoiDung.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribNguoiDung.SmallImage")));
            this.ribNguoiDung.Text = "Người Dùng";
            this.ribNguoiDung.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.ribNguoiDung.Click += new System.EventHandler(this.ribNguoiDung_Click);
            // 
            // ribSanPham
            // 
            this.ribSanPham.Name = "ribSanPham";
            this.ribSanPham.Text = "Quản lý sản phẩm";
            // 
            // ribKhoHang
            // 
            this.ribKhoHang.Name = "ribKhoHang";
            this.ribKhoHang.Text = "Quản lý kho hàng";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // ribBaoCaoThongKe
            // 
            this.ribBaoCaoThongKe.Name = "ribBaoCaoThongKe";
            this.ribBaoCaoThongKe.Text = "Báo cáo thống kê";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(269, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 140);
            this.panel1.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribHeThong;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab ribSanPham;
        private System.Windows.Forms.RibbonTab ribKhoHang;
        private System.Windows.Forms.RibbonTab ribBaoCaoThongKe;
        private System.Windows.Forms.RibbonButton ribNguoiDung;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        public System.Windows.Forms.Panel panel1;
    }
}

