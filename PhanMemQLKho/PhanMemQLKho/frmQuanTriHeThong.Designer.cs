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
            this.quanlynguoidung_sub = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelShowFormChild = new System.Windows.Forms.Panel();
            this.menuStripHeThong.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripHeThong
            // 
            this.menuStripHeThong.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripHeThong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanlynguoidung_sub,
            this.thayĐổiMậtKhẩuToolStripMenuItem});
            this.menuStripHeThong.Location = new System.Drawing.Point(0, 0);
            this.menuStripHeThong.Name = "menuStripHeThong";
            this.menuStripHeThong.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStripHeThong.Size = new System.Drawing.Size(1104, 24);
            this.menuStripHeThong.TabIndex = 0;
            this.menuStripHeThong.Text = "menuStrip1";
            // 
            // quanlynguoidung_sub
            // 
            this.quanlynguoidung_sub.Name = "quanlynguoidung_sub";
            this.quanlynguoidung_sub.Size = new System.Drawing.Size(130, 20);
            this.quanlynguoidung_sub.Text = "Quản Lý Người Dùng";
            this.quanlynguoidung_sub.Click += new System.EventHandler(this.quanlynguoidung_sub_Click);
            // 
            // thayĐổiMậtKhẩuToolStripMenuItem
            // 
            this.thayĐổiMậtKhẩuToolStripMenuItem.Name = "thayĐổiMậtKhẩuToolStripMenuItem";
            this.thayĐổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.thayĐổiMậtKhẩuToolStripMenuItem.Text = "Thay Đổi Mật Khẩu";
            this.thayĐổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.thayĐổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // panelShowFormChild
            // 
            this.panelShowFormChild.AutoScroll = true;
            this.panelShowFormChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowFormChild.Location = new System.Drawing.Point(0, 24);
            this.panelShowFormChild.Name = "panelShowFormChild";
            this.panelShowFormChild.Size = new System.Drawing.Size(1104, 538);
            this.panelShowFormChild.TabIndex = 1;
            this.panelShowFormChild.Paint += new System.Windows.Forms.PaintEventHandler(this.panelShowFormChild_Paint);
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
        private System.Windows.Forms.ToolStripMenuItem quanlynguoidung_sub;
        private System.Windows.Forms.ToolStripMenuItem thayĐổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.Panel panelShowFormChild;
    }
}