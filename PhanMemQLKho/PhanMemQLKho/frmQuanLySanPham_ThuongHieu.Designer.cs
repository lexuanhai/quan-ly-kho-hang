namespace PhanMemQLKho
{
    partial class frmQuanLySanPham_ThuongHieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLySanPham_ThuongHieu));
            this.btnLoadDS = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtNDTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioTenDanhMuc = new System.Windows.Forms.RadioButton();
            this.radioMaDanhMuc = new System.Windows.Forms.RadioButton();
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
            this.errTenNhaSanXuat = new System.Windows.Forms.ErrorProvider(this.components);
            this.errLoaiDG = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenThuongHieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaThuongHieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGRV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNhapGioiTinh = new System.Windows.Forms.Label();
            this.lblNhapDiaChi = new System.Windows.Forms.Label();
            this.lblNhapTenDG = new System.Windows.Forms.Label();
            this.errGT = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.tdMaThuongHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdThuongHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.errTenNhaSanXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLoaiDG)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRV)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGT)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadDS
            // 
            this.btnLoadDS.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadDS.Image")));
            this.btnLoadDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadDS.Location = new System.Drawing.Point(445, 141);
            this.btnLoadDS.Name = "btnLoadDS";
            this.btnLoadDS.Size = new System.Drawing.Size(145, 39);
            this.btnLoadDS.TabIndex = 10;
            this.btnLoadDS.Text = "Load Danh Sách";
            this.btnLoadDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadDS.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtSearch);
            this.groupBox5.Controls.Add(this.txtNDTimKiem);
            this.groupBox5.Location = new System.Drawing.Point(283, 23);
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
            this.groupBox4.Controls.Add(this.radioTenDanhMuc);
            this.groupBox4.Controls.Add(this.radioMaDanhMuc);
            this.groupBox4.Controls.Add(this.radTenDG);
            this.groupBox4.Controls.Add(this.radMaDG);
            this.groupBox4.Location = new System.Drawing.Point(26, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 60);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm Theo";
            // 
            // radioTenDanhMuc
            // 
            this.radioTenDanhMuc.AutoSize = true;
            this.radioTenDanhMuc.Location = new System.Drawing.Point(116, 26);
            this.radioTenDanhMuc.Name = "radioTenDanhMuc";
            this.radioTenDanhMuc.Size = new System.Drawing.Size(109, 17);
            this.radioTenDanhMuc.TabIndex = 3;
            this.radioTenDanhMuc.TabStop = true;
            this.radioTenDanhMuc.Text = "Tên Thương Hiệu";
            this.radioTenDanhMuc.UseVisualStyleBackColor = true;
            // 
            // radioMaDanhMuc
            // 
            this.radioMaDanhMuc.AutoSize = true;
            this.radioMaDanhMuc.Location = new System.Drawing.Point(14, 26);
            this.radioMaDanhMuc.Name = "radioMaDanhMuc";
            this.radioMaDanhMuc.Size = new System.Drawing.Size(105, 17);
            this.radioMaDanhMuc.TabIndex = 2;
            this.radioMaDanhMuc.TabStop = true;
            this.radioMaDanhMuc.Text = "Mã Thương Hiệu";
            this.radioMaDanhMuc.UseVisualStyleBackColor = true;
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
            this.groupBox3.Location = new System.Drawing.Point(196, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(658, 97);
            this.groupBox3.TabIndex = 9;
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
            this.btnSua.Location = new System.Drawing.Point(414, 325);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 39);
            this.btnSua.TabIndex = 13;
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
            this.btnLuu.Location = new System.Drawing.Point(596, 325);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(85, 39);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(505, 325);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(85, 39);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // errTenNhaSanXuat
            // 
            this.errTenNhaSanXuat.ContainerControl = this;
            // 
            // errLoaiDG
            // 
            this.errLoaiDG.ContainerControl = this;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(429, 29);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(201, 59);
            this.txtMoTa.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mô tả:";
            // 
            // txtTenThuongHieu
            // 
            this.txtTenThuongHieu.Location = new System.Drawing.Point(121, 69);
            this.txtTenThuongHieu.Name = "txtTenThuongHieu";
            this.txtTenThuongHieu.Size = new System.Drawing.Size(169, 20);
            this.txtTenThuongHieu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên thương hiệu";
            // 
            // txtMaThuongHieu
            // 
            this.txtMaThuongHieu.Location = new System.Drawing.Point(121, 29);
            this.txtMaThuongHieu.Name = "txtMaThuongHieu";
            this.txtMaThuongHieu.Size = new System.Drawing.Size(169, 20);
            this.txtMaThuongHieu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã thương hiệu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGRV);
            this.groupBox2.Location = new System.Drawing.Point(155, 372);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(759, 200);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách ";
            // 
            // dataGRV
            // 
            this.dataGRV.AllowUserToAddRows = false;
            this.dataGRV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGRV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tdMaThuongHieu,
            this.tdThuongHieu,
            this.tdGhiChu});
            this.dataGRV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGRV.Location = new System.Drawing.Point(3, 16);
            this.dataGRV.Name = "dataGRV";
            this.dataGRV.Size = new System.Drawing.Size(753, 181);
            this.dataGRV.TabIndex = 0;
            this.dataGRV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGRV_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNhapGioiTinh);
            this.groupBox1.Controls.Add(this.lblNhapDiaChi);
            this.groupBox1.Controls.Add(this.lblNhapTenDG);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTenThuongHieu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaThuongHieu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(196, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 120);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin ";
            // 
            // lblNhapGioiTinh
            // 
            this.lblNhapGioiTinh.AutoSize = true;
            this.lblNhapGioiTinh.Location = new System.Drawing.Point(449, 51);
            this.lblNhapGioiTinh.Name = "lblNhapGioiTinh";
            this.lblNhapGioiTinh.Size = new System.Drawing.Size(0, 13);
            this.lblNhapGioiTinh.TabIndex = 6;
            // 
            // lblNhapDiaChi
            // 
            this.lblNhapDiaChi.AutoSize = true;
            this.lblNhapDiaChi.Location = new System.Drawing.Point(449, 31);
            this.lblNhapDiaChi.Name = "lblNhapDiaChi";
            this.lblNhapDiaChi.Size = new System.Drawing.Size(0, 13);
            this.lblNhapDiaChi.TabIndex = 6;
            // 
            // lblNhapTenDG
            // 
            this.lblNhapTenDG.AutoSize = true;
            this.lblNhapTenDG.Location = new System.Drawing.Point(114, 76);
            this.lblNhapTenDG.Name = "lblNhapTenDG";
            this.lblNhapTenDG.Size = new System.Drawing.Size(0, 13);
            this.lblNhapTenDG.TabIndex = 6;
            // 
            // errGT
            // 
            this.errGT.ContainerControl = this;
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(687, 325);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(85, 39);
            this.btnHuy.TabIndex = 16;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(323, 325);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 39);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // tdMaThuongHieu
            // 
            this.tdMaThuongHieu.HeaderText = "Mã thương hiệu";
            this.tdMaThuongHieu.Name = "tdMaThuongHieu";
            this.tdMaThuongHieu.Width = 150;
            // 
            // tdThuongHieu
            // 
            this.tdThuongHieu.HeaderText = "Tên thương hiệu";
            this.tdThuongHieu.Name = "tdThuongHieu";
            this.tdThuongHieu.Width = 250;
            // 
            // tdGhiChu
            // 
            this.tdGhiChu.HeaderText = "Mô tả";
            this.tdGhiChu.Name = "tdGhiChu";
            this.tdGhiChu.Width = 300;
            // 
            // frmQuanLySanPham_ThuongHieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 627);
            this.Controls.Add(this.btnLoadDS);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);
            this.Name = "frmQuanLySanPham_ThuongHieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Thương Hiệu";
            this.Load += new System.EventHandler(this.frmQuanLySanPham_DanhMuc_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.errTenNhaSanXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLoaiDG)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGRV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errGT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDS;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtNDTimKiem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radTenDG;
        private System.Windows.Forms.RadioButton radMaDG;
        private System.Windows.Forms.ErrorProvider errTenDG;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGRV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNhapGioiTinh;
        private System.Windows.Forms.Label lblNhapDiaChi;
        private System.Windows.Forms.Label lblNhapTenDG;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenThuongHieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaThuongHieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ErrorProvider errDiaChi;
        private System.Windows.Forms.ErrorProvider errSoDienThoai;
        private System.Windows.Forms.ErrorProvider errTenTK;
        private System.Windows.Forms.ErrorProvider errMK;
        private System.Windows.Forms.ErrorProvider errDC;
        private System.Windows.Forms.ErrorProvider errEmail;
        private System.Windows.Forms.ErrorProvider errTenNhaSanXuat;
        private System.Windows.Forms.ErrorProvider errLoaiDG;
        private System.Windows.Forms.ErrorProvider errGT;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton radioTenDanhMuc;
        private System.Windows.Forms.RadioButton radioMaDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdMaThuongHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdThuongHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdGhiChu;
    }
}