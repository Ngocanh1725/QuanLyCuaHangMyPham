namespace QuanLyCuaHangMyPham
{
    partial class FormDonHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.gbThongTinChung = new System.Windows.Forms.GroupBox();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSDTKH = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaDH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.gbThemSanPham = new System.Windows.Forms.GroupBox();
            this.picHinhAnhSP = new System.Windows.Forms.PictureBox();
            this.btnXoaSP = new QuanLyCuaHangMyPham.CustomControls.RoundedButton();
            this.btnThemSP = new QuanLyCuaHangMyPham.CustomControls.RoundedButton();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbSanPham = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnXemChiTiet = new QuanLyCuaHangMyPham.CustomControls.RoundedButton();
            this.btnReset = new QuanLyCuaHangMyPham.CustomControls.RoundedButton();
            this.btnTaoDonHang = new QuanLyCuaHangMyPham.CustomControls.RoundedButton();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.gbThongTinChung.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.gbThemSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnhSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.gbThongTinChung);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panelLeft.Size = new System.Drawing.Size(262, 401);
            this.panelLeft.TabIndex = 0;
            // 
            // gbThongTinChung
            // 
            this.gbThongTinChung.Controls.Add(this.cbbNhanVien);
            this.gbThongTinChung.Controls.Add(this.txtDiaChi);
            this.gbThongTinChung.Controls.Add(this.txtSDTKH);
            this.gbThongTinChung.Controls.Add(this.txtTenKH);
            this.gbThongTinChung.Controls.Add(this.txtMaDH);
            this.gbThongTinChung.Controls.Add(this.label5);
            this.gbThongTinChung.Controls.Add(this.label4);
            this.gbThongTinChung.Controls.Add(this.label3);
            this.gbThongTinChung.Controls.Add(this.label2);
            this.gbThongTinChung.Controls.Add(this.label1);
            this.gbThongTinChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbThongTinChung.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongTinChung.Location = new System.Drawing.Point(8, 8);
            this.gbThongTinChung.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbThongTinChung.Name = "gbThongTinChung";
            this.gbThongTinChung.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbThongTinChung.Size = new System.Drawing.Size(246, 385);
            this.gbThongTinChung.TabIndex = 0;
            this.gbThongTinChung.TabStop = false;
            this.gbThongTinChung.Text = "Thông tin đơn hàng";
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Location = new System.Drawing.Point(15, 317);
            this.cbbNhanVien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(218, 23);
            this.cbbNhanVien.TabIndex = 9;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiaChi.Location = new System.Drawing.Point(15, 195);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(218, 82);
            this.txtDiaChi.TabIndex = 8;
            // 
            // txtSDTKH
            // 
            this.txtSDTKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSDTKH.Location = new System.Drawing.Point(15, 138);
            this.txtSDTKH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSDTKH.Name = "txtSDTKH";
            this.txtSDTKH.Size = new System.Drawing.Size(218, 23);
            this.txtSDTKH.TabIndex = 7;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenKH.Location = new System.Drawing.Point(15, 89);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(218, 23);
            this.txtTenKH.TabIndex = 6;
            // 
            // txtMaDH
            // 
            this.txtMaDH.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaDH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaDH.Location = new System.Drawing.Point(15, 41);
            this.txtMaDH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaDH.Name = "txtMaDH";
            this.txtMaDH.ReadOnly = true;
            this.txtMaDH.Size = new System.Drawing.Size(218, 23);
            this.txtMaDH.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(15, 292);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nhân viên xử lý:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(15, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Địa chỉ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn hàng:";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.dgvGioHang);
            this.panelRight.Controls.Add(this.gbThemSanPham);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(262, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.panelRight.Size = new System.Drawing.Size(384, 401);
            this.panelRight.TabIndex = 1;
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AllowUserToDeleteRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGioHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGioHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGioHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGioHang.ColumnHeadersHeight = 35;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGioHang.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.EnableHeadersVisualStyles = false;
            this.dgvGioHang.Location = new System.Drawing.Point(0, 138);
            this.dgvGioHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvGioHang.MultiSelect = false;
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.RowHeadersVisible = false;
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.RowTemplate.Height = 30;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(376, 255);
            this.dgvGioHang.TabIndex = 1;
            // 
            // gbThemSanPham
            // 
            this.gbThemSanPham.Controls.Add(this.picHinhAnhSP);
            this.gbThemSanPham.Controls.Add(this.btnXoaSP);
            this.gbThemSanPham.Controls.Add(this.btnThemSP);
            this.gbThemSanPham.Controls.Add(this.txtGiaBan);
            this.gbThemSanPham.Controls.Add(this.label8);
            this.gbThemSanPham.Controls.Add(this.numSoLuong);
            this.gbThemSanPham.Controls.Add(this.label7);
            this.gbThemSanPham.Controls.Add(this.cbbSanPham);
            this.gbThemSanPham.Controls.Add(this.label6);
            this.gbThemSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbThemSanPham.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThemSanPham.Location = new System.Drawing.Point(0, 8);
            this.gbThemSanPham.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbThemSanPham.Name = "gbThemSanPham";
            this.gbThemSanPham.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbThemSanPham.Size = new System.Drawing.Size(376, 130);
            this.gbThemSanPham.TabIndex = 0;
            this.gbThemSanPham.TabStop = false;
            this.gbThemSanPham.Text = "Giỏ hàng";
            // 
            // picHinhAnhSP
            // 
            this.picHinhAnhSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnhSP.Location = new System.Drawing.Point(279, 28);
            this.picHinhAnhSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picHinhAnhSP.Name = "picHinhAnhSP";
            this.picHinhAnhSP.Size = new System.Drawing.Size(90, 87);
            this.picHinhAnhSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnhSP.TabIndex = 8;
            this.picHinhAnhSP.TabStop = false;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnXoaSP.BorderRadius = 20;
            this.btnXoaSP.FlatAppearance.BorderSize = 0;
            this.btnXoaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaSP.ForeColor = System.Drawing.Color.White;
            this.btnXoaSP.Location = new System.Drawing.Point(172, 89);
            this.btnXoaSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(90, 28);
            this.btnXoaSP.TabIndex = 7;
            this.btnXoaSP.Text = "Xóa SP";
            this.btnXoaSP.UseVisualStyleBackColor = false;
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnThemSP.BorderRadius = 20;
            this.btnThemSP.FlatAppearance.BorderSize = 0;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemSP.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.Location = new System.Drawing.Point(78, 89);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(90, 28);
            this.btnThemSP.TabIndex = 6;
            this.btnThemSP.Text = "Thêm SP";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaBan.Location = new System.Drawing.Point(78, 61);
            this.txtGiaBan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.ReadOnly = true;
            this.txtGiaBan.Size = new System.Drawing.Size(91, 23);
            this.txtGiaBan.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(15, 63);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Giá bán:";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numSoLuong.Location = new System.Drawing.Point(207, 61);
            this.numSoLuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(55, 23);
            this.numSoLuong.TabIndex = 3;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(181, 64);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "SL :";
            // 
            // cbbSanPham
            // 
            this.cbbSanPham.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbSanPham.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbSanPham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbbSanPham.FormattingEnabled = true;
            this.cbbSanPham.Location = new System.Drawing.Point(78, 28);
            this.cbbSanPham.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbSanPham.Name = "cbbSanPham";
            this.cbbSanPham.Size = new System.Drawing.Size(186, 23);
            this.cbbSanPham.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(15, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sản phẩm:";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBottom.Controls.Add(this.btnXemChiTiet);
            this.panelBottom.Controls.Add(this.btnReset);
            this.panelBottom.Controls.Add(this.btnTaoDonHang);
            this.panelBottom.Controls.Add(this.lblTongTien);
            this.panelBottom.Controls.Add(this.label9);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 401);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(646, 65);
            this.panelBottom.TabIndex = 2;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemChiTiet.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnXemChiTiet.BorderRadius = 20;
            this.btnXemChiTiet.FlatAppearance.BorderSize = 0;
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(394, 16);
            this.btnXemChiTiet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(112, 32);
            this.btnXemChiTiet.TabIndex = 4;
            this.btnXemChiTiet.Text = "Chi tiết ĐH";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.LightGray;
            this.btnReset.BorderRadius = 20;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(278, 16);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 32);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTaoDonHang
            // 
            this.btnTaoDonHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnTaoDonHang.BorderRadius = 20;
            this.btnTaoDonHang.FlatAppearance.BorderSize = 0;
            this.btnTaoDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDonHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoDonHang.ForeColor = System.Drawing.Color.White;
            this.btnTaoDonHang.Location = new System.Drawing.Point(519, 16);
            this.btnTaoDonHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTaoDonHang.Name = "btnTaoDonHang";
            this.btnTaoDonHang.Size = new System.Drawing.Size(112, 32);
            this.btnTaoDonHang.TabIndex = 2;
            this.btnTaoDonHang.Text = "Tạo đơn hàng";
            this.btnTaoDonHang.UseVisualStyleBackColor = false;
            this.btnTaoDonHang.Click += new System.EventHandler(this.btnTaoDonHang_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.DeepPink;
            this.lblTongTien.Location = new System.Drawing.Point(90, 20);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(70, 25);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "0 VNĐ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tổng tiền:";
            // 
            // FormDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 466);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelBottom);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDonHang";
            this.Text = "TẠO ĐƠN HÀNG";
            this.Load += new System.EventHandler(this.FormDonHang_Load);
            this.panelLeft.ResumeLayout(false);
            this.gbThongTinChung.ResumeLayout(false);
            this.gbThongTinChung.PerformLayout();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.gbThemSanPham.ResumeLayout(false);
            this.gbThemSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnhSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.GroupBox gbThongTinChung;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbNhanVien;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSDTKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtMaDH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.GroupBox gbThemSanPham;
        private CustomControls.RoundedButton btnXoaSP;
        private CustomControls.RoundedButton btnThemSP;
        private CustomControls.RoundedButton btnReset;
        private CustomControls.RoundedButton btnTaoDonHang;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbSanPham;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label9;
        private CustomControls.RoundedButton btnXemChiTiet;
        private System.Windows.Forms.PictureBox picHinhAnhSP;
    }
}
