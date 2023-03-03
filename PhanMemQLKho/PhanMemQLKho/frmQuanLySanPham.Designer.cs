namespace PhanMemQLKho
{
    partial class frmQuanLySanPham
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
            this.menuStripHeThong = new System.Windows.Forms.MenuStrip();
            this.sub_san_pham = new System.Windows.Forms.ToolStripMenuItem();
            this.sub_danh_muc = new System.Windows.Forms.ToolStripMenuItem();
            this.sub_nhan_hieu = new System.Windows.Forms.ToolStripMenuItem();
            this.sub_phu_tung = new System.Windows.Forms.ToolStripMenuItem();
            this.panelShowFormChild = new System.Windows.Forms.Panel();
            this.menuStripHeThong.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripHeThong
            // 
            this.menuStripHeThong.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripHeThong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sub_san_pham,
            this.sub_danh_muc,
            this.sub_nhan_hieu,
            this.sub_phu_tung});
            this.menuStripHeThong.Location = new System.Drawing.Point(0, 0);
            this.menuStripHeThong.Name = "menuStripHeThong";
            this.menuStripHeThong.Size = new System.Drawing.Size(1067, 30);
            this.menuStripHeThong.TabIndex = 0;
            this.menuStripHeThong.Text = "menuStrip1";
            // 
            // sub_san_pham
            // 
            this.sub_san_pham.Name = "sub_san_pham";
            this.sub_san_pham.Size = new System.Drawing.Size(88, 26);
            this.sub_san_pham.Text = "Sản Phẩm";
            this.sub_san_pham.Click += new System.EventHandler(this.sub_san_pham_Click);
            // 
            // sub_danh_muc
            // 
            this.sub_danh_muc.Name = "sub_danh_muc";
            this.sub_danh_muc.Size = new System.Drawing.Size(90, 26);
            this.sub_danh_muc.Text = "Danh Mục";
            this.sub_danh_muc.Click += new System.EventHandler(this.sub_danh_muc_Click);
            // 
            // sub_nhan_hieu
            // 
            this.sub_nhan_hieu.Name = "sub_nhan_hieu";
            this.sub_nhan_hieu.Size = new System.Drawing.Size(93, 26);
            this.sub_nhan_hieu.Text = "Nhãn Hiệu";
            this.sub_nhan_hieu.Click += new System.EventHandler(this.sub_nhan_hieu_Click);
            // 
            // sub_phu_tung
            // 
            this.sub_phu_tung.Name = "sub_phu_tung";
            this.sub_phu_tung.Size = new System.Drawing.Size(84, 26);
            this.sub_phu_tung.Text = "Phụ Tùng";
            this.sub_phu_tung.Click += new System.EventHandler(this.sub_phu_tung_Click);
            // 
            // panelShowFormChild
            // 
            this.panelShowFormChild.AutoScroll = true;
            this.panelShowFormChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowFormChild.Location = new System.Drawing.Point(0, 30);
            this.panelShowFormChild.Margin = new System.Windows.Forms.Padding(4);
            this.panelShowFormChild.Name = "panelShowFormChild";
            this.panelShowFormChild.Size = new System.Drawing.Size(1067, 524);
            this.panelShowFormChild.TabIndex = 1;
            // 
            // frmQuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panelShowFormChild);
            this.Controls.Add(this.menuStripHeThong);
            this.MainMenuStrip = this.menuStripHeThong;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuanLySanPham";
            this.Text = "Quản Lý Sản Phẩm";
            this.menuStripHeThong.ResumeLayout(false);
            this.menuStripHeThong.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripHeThong;
        private System.Windows.Forms.ToolStripMenuItem sub_san_pham;
        private System.Windows.Forms.ToolStripMenuItem sub_danh_muc;
        private System.Windows.Forms.ToolStripMenuItem sub_nhan_hieu;
        private System.Windows.Forms.ToolStripMenuItem sub_phu_tung;
        private System.Windows.Forms.Panel panelShowFormChild;
    }
}