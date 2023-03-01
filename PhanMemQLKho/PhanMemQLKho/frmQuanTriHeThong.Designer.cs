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
            this.quanlynguoidung_sub = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐăngNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelShowFormChild = new System.Windows.Forms.Panel();
            this.menuStripHeThong.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripHeThong
            // 
            this.menuStripHeThong.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripHeThong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sub_quyen,
            this.quanlynguoidung_sub,
            this.thayĐổiMậtKhẩuToolStripMenuItem,
            this.quảnLýĐăngNhậpToolStripMenuItem});
            this.menuStripHeThong.Location = new System.Drawing.Point(0, 0);
            this.menuStripHeThong.Name = "menuStripHeThong";
            this.menuStripHeThong.Size = new System.Drawing.Size(1840, 38);
            this.menuStripHeThong.TabIndex = 0;
            this.menuStripHeThong.Text = "menuStrip1";
            // 
            // sub_quyen
            // 
            this.sub_quyen.Name = "sub_quyen";
            this.sub_quyen.Size = new System.Drawing.Size(121, 24);
            this.sub_quyen.Text = "Quản Lý Quyền";
            this.sub_quyen.Click += new System.EventHandler(this.sub_quyen_Click);
            // 
            // quanlynguoidung_sub
            // 
            this.quanlynguoidung_sub.Name = "quanlynguoidung_sub";
            this.quanlynguoidung_sub.Size = new System.Drawing.Size(161, 24);
            this.quanlynguoidung_sub.Text = "Quản Lý Người Dùng";
            this.quanlynguoidung_sub.Click += new System.EventHandler(this.quanlynguoidung_sub_Click);
            // 
            // thayĐổiMậtKhẩuToolStripMenuItem
            // 
            this.thayĐổiMậtKhẩuToolStripMenuItem.Name = "thayĐổiMậtKhẩuToolStripMenuItem";
            this.thayĐổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.thayĐổiMậtKhẩuToolStripMenuItem.Text = "Thay Đổi Mật Khẩu";
            // 
            // quảnLýĐăngNhậpToolStripMenuItem
            // 
            this.quảnLýĐăngNhậpToolStripMenuItem.Name = "quảnLýĐăngNhậpToolStripMenuItem";
            this.quảnLýĐăngNhậpToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.quảnLýĐăngNhậpToolStripMenuItem.Text = "Quản Lý Đăng Nhập";
            // 
            // panelShowFormChild
            // 
            this.panelShowFormChild.AutoScroll = true;
            this.panelShowFormChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowFormChild.Location = new System.Drawing.Point(0, 48);
            this.panelShowFormChild.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelShowFormChild.Name = "panelShowFormChild";
            this.panelShowFormChild.Size = new System.Drawing.Size(1840, 818);
            this.panelShowFormChild.TabIndex = 1;
            this.panelShowFormChild.Paint += new System.Windows.Forms.PaintEventHandler(this.panelShowFormChild_Paint);
            // 
            // frmQuanTriHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 692);
            this.Controls.Add(this.panelShowFormChild);
            this.Controls.Add(this.menuStripHeThong);
            this.MainMenuStrip = this.menuStripHeThong;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.ToolStripMenuItem quanlynguoidung_sub;
        private System.Windows.Forms.ToolStripMenuItem thayĐổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýĐăngNhậpToolStripMenuItem;
        private System.Windows.Forms.Panel panelShowFormChild;
    }
}