namespace PhanMemQLKho
{
    partial class frmQuanTriHeThong
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
            this.sub_quyen = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐăngNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelShowFormChild = new System.Windows.Forms.Panel();
            this.menuStripHeThong.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripHeThong
            // 
            this.menuStripHeThong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sub_quyen,
            this.quảnLýNgườiDùngToolStripMenuItem,
            this.thayĐổiMậtKhẩuToolStripMenuItem,
            this.quảnLýĐăngNhậpToolStripMenuItem});
            this.menuStripHeThong.Location = new System.Drawing.Point(0, 0);
            this.menuStripHeThong.Name = "menuStripHeThong";
            this.menuStripHeThong.Size = new System.Drawing.Size(1104, 24);
            this.menuStripHeThong.TabIndex = 0;
            this.menuStripHeThong.Text = "menuStrip1";
            // 
            // sub_quyen
            // 
            this.sub_quyen.Name = "sub_quyen";
            this.sub_quyen.Size = new System.Drawing.Size(100, 20);
            this.sub_quyen.Text = "Quản Lý Quyền";
            this.sub_quyen.Click += new System.EventHandler(this.sub_quyen_Click);
            // 
            // quảnLýNgườiDùngToolStripMenuItem
            // 
            this.quảnLýNgườiDùngToolStripMenuItem.Name = "quảnLýNgườiDùngToolStripMenuItem";
            this.quảnLýNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.quảnLýNgườiDùngToolStripMenuItem.Text = "Quản Lý Người Dùng";
            // 
            // thayĐổiMậtKhẩuToolStripMenuItem
            // 
            this.thayĐổiMậtKhẩuToolStripMenuItem.Name = "thayĐổiMậtKhẩuToolStripMenuItem";
            this.thayĐổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.thayĐổiMậtKhẩuToolStripMenuItem.Text = "Thay Đổi Mật Khẩu";
            // 
            // quảnLýĐăngNhậpToolStripMenuItem
            // 
            this.quảnLýĐăngNhậpToolStripMenuItem.Name = "quảnLýĐăngNhậpToolStripMenuItem";
            this.quảnLýĐăngNhậpToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.quảnLýĐăngNhậpToolStripMenuItem.Text = "Quản Lý Đăng Nhập";
            // 
            // panelShowFormChild
            // 
            this.panelShowFormChild.AutoScroll = true;
            this.panelShowFormChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowFormChild.Location = new System.Drawing.Point(0, 24);
            this.panelShowFormChild.Name = "panelShowFormChild";
            this.panelShowFormChild.Size = new System.Drawing.Size(1104, 538);
            this.panelShowFormChild.TabIndex = 1;
            // 
            // frmQuanTriHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 562);
            this.Controls.Add(this.panelShowFormChild);
            this.Controls.Add(this.menuStripHeThong);
            this.MainMenuStrip = this.menuStripHeThong;
            this.Name = "frmQuanTriHeThong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị hệ thống";
            this.menuStripHeThong.ResumeLayout(false);
            this.menuStripHeThong.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripHeThong;
        private System.Windows.Forms.ToolStripMenuItem sub_quyen;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNgườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thayĐổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýĐăngNhậpToolStripMenuItem;
        private System.Windows.Forms.Panel panelShowFormChild;
    }
}