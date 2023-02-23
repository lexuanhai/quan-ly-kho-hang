namespace PhanMemQLKho
{
    partial class frmNSX
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNSX));
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGRV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenUser = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNhapTenDG = new System.Windows.Forms.Label();
            this.errGT = new System.Windows.Forms.ErrorProvider(this.components);
            this.errLoaiDG = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnThem = new System.Windows.Forms.Button();
            this.errTenNhaSanXuat = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnLoadDS = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtNDTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioTen = new System.Windows.Forms.RadioButton();
            this.radioMa = new System.Windows.Forms.RadioButton();
            this.radTenDG = new System.Windows.Forms.RadioButton();
            this.radMaDG = new System.Windows.Forms.RadioButton();
            this.errTenDG = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.errDiaChi = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSua = new System.Windows.Forms.Button();
            this.errSoDienThoai = new System.Windows.Forms.ErrorProvider(this.components);
            this.errTenTK = new System.Windows.Forms.ErrorProvider(this.components);
            this.errMK = new System.Windows.Forms.ErrorProvider(this.components);
            this.errDC = new System.Windows.Forms.ErrorProvider(this.components);
            this.errEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.tdMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRV)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLoaiDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTenNhaSanXuat)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errTenDG)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errDiaChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSoDienThoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTenTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(651, 315);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(85, 39);
            this.btnHuy.TabIndex = 26;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(104, 22);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(139, 20);
            this.txtMa.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhà sản xuất";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGRV);
            this.groupBox2.Location = new System.Drawing.Point(125, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 230);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách ";
            // 
            // dataGRV
            // 
            this.dataGRV.AllowUserToAddRows = false;
            this.dataGRV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGRV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tdMa,
            this.tdTen,
            this.tdSoDienThoai,
            this.tdEmail,
            this.tdDiaChi});
            this.dataGRV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGRV.Location = new System.Drawing.Point(3, 16);
            this.dataGRV.Name = "dataGRV";
            this.dataGRV.RowHeadersVisible = false;
            this.dataGRV.Size = new System.Drawing.Size(741, 211);
            this.dataGRV.TabIndex = 0;
            this.dataGRV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGRV_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenUser);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSoDienThoai);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblNhapTenDG);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(125, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 110);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin ";
            // 
            // txtTenUser
            // 
            this.txtTenUser.Location = new System.Drawing.Point(104, 61);
            this.txtTenUser.Name = "txtTenUser";
            this.txtTenUser.Size = new System.Drawing.Size(139, 20);
            this.txtTenUser.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Tên nhà sản xuất";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(552, 23);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(167, 58);
            this.txtDiaChi.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(506, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Địa chỉ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(344, 59);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(140, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Email";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(344, 23);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(140, 20);
            this.txtSoDienThoai.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            // 
            // lblNhapTenDG
            // 
            this.lblNhapTenDG.AutoSize = true;
            this.lblNhapTenDG.Location = new System.Drawing.Point(323, -4);
            this.lblNhapTenDG.Name = "lblNhapTenDG";
            this.lblNhapTenDG.Size = new System.Drawing.Size(0, 13);
            this.lblNhapTenDG.TabIndex = 6;
            // 
            // errGT
            // 
            this.errGT.ContainerControl = this;
            // 
            // errLoaiDG
            // 
            this.errLoaiDG.ContainerControl = this;
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(287, 315);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 39);
            this.btnThem.TabIndex = 22;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // errTenNhaSanXuat
            // 
            this.errTenNhaSanXuat.ContainerControl = this;
            // 
            // btnLoadDS
            // 
            this.btnLoadDS.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadDS.Image")));
            this.btnLoadDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadDS.Location = new System.Drawing.Point(409, 136);
            this.btnLoadDS.Name = "btnLoadDS";
            this.btnLoadDS.Size = new System.Drawing.Size(145, 39);
            this.btnLoadDS.TabIndex = 20;
            this.btnLoadDS.Text = "Load Danh Sách";
            this.btnLoadDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadDS.UseVisualStyleBackColor = true;
            this.btnLoadDS.Click += new System.EventHandler(this.btnLoadDS_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtSearch);
            this.groupBox5.Controls.Add(this.txtNDTimKiem);
            this.groupBox5.Location = new System.Drawing.Point(270, 24);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(360, 60);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Nhập thông tin cần Tìm Kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(14, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(332, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtNDTimKiem
            // 
            this.txtNDTimKiem.Location = new System.Drawing.Point(11, 84);
            this.txtNDTimKiem.Name = "txtNDTimKiem";
            this.txtNDTimKiem.Size = new System.Drawing.Size(332, 20);
            this.txtNDTimKiem.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioTen);
            this.groupBox4.Controls.Add(this.radioMa);
            this.groupBox4.Controls.Add(this.radTenDG);
            this.groupBox4.Controls.Add(this.radMaDG);
            this.groupBox4.Location = new System.Drawing.Point(20, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(231, 60);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm Theo";
            // 
            // radioTen
            // 
            this.radioTen.AutoSize = true;
            this.radioTen.Location = new System.Drawing.Point(116, 26);
            this.radioTen.Name = "radioTen";
            this.radioTen.Size = new System.Drawing.Size(108, 17);
            this.radioTen.TabIndex = 3;
            this.radioTen.TabStop = true;
            this.radioTen.Text = "Tên nhà sản xuất";
            this.radioTen.UseVisualStyleBackColor = true;
            // 
            // radioMa
            // 
            this.radioMa.AutoSize = true;
            this.radioMa.Location = new System.Drawing.Point(7, 26);
            this.radioMa.Name = "radioMa";
            this.radioMa.Size = new System.Drawing.Size(104, 17);
            this.radioMa.TabIndex = 2;
            this.radioMa.TabStop = true;
            this.radioMa.Text = "Mã nhà sản xuất";
            this.radioMa.UseVisualStyleBackColor = true;
            // 
            // radTenDG
            // 
            this.radTenDG.AutoSize = true;
            this.radTenDG.Location = new System.Drawing.Point(106, 84);
            this.radTenDG.Name = "radTenDG";
            this.radTenDG.Size = new System.Drawing.Size(89, 17);
            this.radTenDG.TabIndex = 1;
            this.radTenDG.TabStop = true;
            this.radTenDG.Text = "Tên Thể Loại";
            this.radTenDG.UseVisualStyleBackColor = true;
            // 
            // radMaDG
            // 
            this.radMaDG.AutoSize = true;
            this.radMaDG.Location = new System.Drawing.Point(7, 84);
            this.radMaDG.Name = "radMaDG";
            this.radMaDG.Size = new System.Drawing.Size(85, 17);
            this.radMaDG.TabIndex = 0;
            this.radMaDG.TabStop = true;
            this.radMaDG.Text = "Mã Thẻ Loại";
            this.radMaDG.UseVisualStyleBackColor = true;
            // 
            // errTenDG
            // 
            this.errTenDG.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(160, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(658, 97);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm ";
            // 
            // errDiaChi
            // 
            this.errDiaChi.ContainerControl = this;
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(378, 315);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 39);
            this.btnSua.TabIndex = 23;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // errSoDienThoai
            // 
            this.errSoDienThoai.ContainerControl = this;
            // 
            // errTenTK
            // 
            this.errTenTK.ContainerControl = this;
            // 
            // errMK
            // 
            this.errMK.ContainerControl = this;
            // 
            // errDC
            // 
            this.errDC.ContainerControl = this;
            // 
            // errEmail
            // 
            this.errEmail.ContainerControl = this;
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(560, 315);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(85, 39);
            this.btnLuu.TabIndex = 25;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(469, 315);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(85, 39);
            this.btnXoa.TabIndex = 24;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // tdMa
            // 
            this.tdMa.FillWeight = 27.60152F;
            this.tdMa.HeaderText = "Mã NSX";
            this.tdMa.Name = "tdMa";
            this.tdMa.Width = 120;
            // 
            // tdTen
            // 
            this.tdTen.FillWeight = 27.60152F;
            this.tdTen.HeaderText = "Tên nhà sản xuất";
            this.tdTen.Name = "tdTen";
            this.tdTen.Width = 150;
            // 
            // tdSoDienThoai
            // 
            this.tdSoDienThoai.FillWeight = 27.60152F;
            this.tdSoDienThoai.HeaderText = "Số điện thoại";
            this.tdSoDienThoai.Name = "tdSoDienThoai";
            this.tdSoDienThoai.Width = 150;
            // 
            // tdEmail
            // 
            this.tdEmail.FillWeight = 27.60152F;
            this.tdEmail.HeaderText = "Email";
            this.tdEmail.Name = "tdEmail";
            this.tdEmail.Width = 150;
            // 
            // tdDiaChi
            // 
            this.tdDiaChi.FillWeight = 27.60152F;
            this.tdDiaChi.HeaderText = "Địa chỉ";
            this.tdDiaChi.Name = "tdDiaChi";
            this.tdDiaChi.Width = 150;
            // 
            // frmNSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 660);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnLoadDS);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Name = "frmNSX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Nhà Sản Xuất";
            this.Load += new System.EventHandler(this.frmNCC_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGRV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLoaiDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTenNhaSanXuat)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errTenDG)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errDiaChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSoDienThoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTenTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEmail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGRV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNhapTenDG;
        private System.Windows.Forms.ErrorProvider errGT;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLoadDS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtNDTimKiem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioTen;
        private System.Windows.Forms.RadioButton radioMa;
        private System.Windows.Forms.RadioButton radTenDG;
        private System.Windows.Forms.RadioButton radMaDG;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ErrorProvider errLoaiDG;
        private System.Windows.Forms.ErrorProvider errTenNhaSanXuat;
        private System.Windows.Forms.ErrorProvider errTenDG;
        private System.Windows.Forms.ErrorProvider errDiaChi;
        private System.Windows.Forms.ErrorProvider errSoDienThoai;
        private System.Windows.Forms.ErrorProvider errTenTK;
        private System.Windows.Forms.ErrorProvider errMK;
        private System.Windows.Forms.ErrorProvider errDC;
        private System.Windows.Forms.ErrorProvider errEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdDiaChi;
    }
}