namespace PhanMemQLKho
{
    partial class frmQuanLyXuat
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
            this.sub_phieu_nhap = new System.Windows.Forms.ToolStripMenuItem();
            this.sub_chi_tiet_phieu_nhap = new System.Windows.Forms.ToolStripMenuItem();
            this.panelShowFormChild = new System.Windows.Forms.Panel();
            this.menuStripHeThong.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripHeThong
            // 
            this.menuStripHeThong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sub_phieu_nhap,
            this.sub_chi_tiet_phieu_nhap});
            this.menuStripHeThong.Location = new System.Drawing.Point(0, 0);
            this.menuStripHeThong.Name = "menuStripHeThong";
            this.menuStripHeThong.Size = new System.Drawing.Size(800, 24);
            this.menuStripHeThong.TabIndex = 0;
            this.menuStripHeThong.Text = "menuStrip1";
            // 
            // sub_phieu_nhap
            // 
            this.sub_phieu_nhap.Name = "sub_phieu_nhap";
            this.sub_phieu_nhap.Size = new System.Drawing.Size(76, 20);
            this.sub_phieu_nhap.Text = "Phiếu Xuất";
            this.sub_phieu_nhap.Click += new System.EventHandler(this.sub_phieu_nhap_Click);
            // 
            // sub_chi_tiet_phieu_nhap
            // 
            this.sub_chi_tiet_phieu_nhap.Name = "sub_chi_tiet_phieu_nhap";
            this.sub_chi_tiet_phieu_nhap.Size = new System.Drawing.Size(119, 20);
            this.sub_chi_tiet_phieu_nhap.Text = "Chi Tiết Phiếu Xuất";
            this.sub_chi_tiet_phieu_nhap.Click += new System.EventHandler(this.sub_chi_tiet_phieu_nhap_Click);
            // 
            // panelShowFormChild
            // 
            this.panelShowFormChild.AutoScroll = true;
            this.panelShowFormChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowFormChild.Location = new System.Drawing.Point(0, 24);
            this.panelShowFormChild.Name = "panelShowFormChild";
            this.panelShowFormChild.Size = new System.Drawing.Size(800, 426);
            this.panelShowFormChild.TabIndex = 1;
            // 
            // frmQuanLyXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelShowFormChild);
            this.Controls.Add(this.menuStripHeThong);
            this.MainMenuStrip = this.menuStripHeThong;
            this.Name = "frmQuanLyXuat";
            this.Text = "Quản Lý Xuất";
            this.menuStripHeThong.ResumeLayout(false);
            this.menuStripHeThong.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripHeThong;
        private System.Windows.Forms.ToolStripMenuItem sub_phieu_nhap;
        private System.Windows.Forms.ToolStripMenuItem sub_chi_tiet_phieu_nhap;
        private System.Windows.Forms.Panel panelShowFormChild;
    }
}