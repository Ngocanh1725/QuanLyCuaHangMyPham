namespace QuanLyCuaHangMyPham
{ 
  partial class FormSanPham
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
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        this.dgvSanPham = new System.Windows.Forms.DataGridView();
        this.panelTop = new System.Windows.Forms.Panel();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.cbbNhaCungCap = new System.Windows.Forms.ComboBox();
        this.txtTheLoai = new System.Windows.Forms.TextBox();
        this.txtXuatXu = new System.Windows.Forms.TextBox();
        this.txtHangSP = new System.Windows.Forms.TextBox();
        this.txtTenSP = new System.Windows.Forms.TextBox();
        this.txtMaSP = new System.Windows.Forms.TextBox();
        this.label6 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.panelActions = new System.Windows.Forms.Panel();
        this.btnReset = new System.Windows.Forms.Button();
        this.btnXoa = new System.Windows.Forms.Button();
        this.btnSua = new System.Windows.Forms.Button();
        this.btnThem = new System.Windows.Forms.Button();
        this.panelSearch = new System.Windows.Forms.Panel();
        this.btnTimKiem = new System.Windows.Forms.Button();
        this.txtTimKiem = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
        this.panelTop.SuspendLayout();
        this.groupBox1.SuspendLayout();
        this.panelActions.SuspendLayout();
        this.panelSearch.SuspendLayout();
        this.SuspendLayout();
        // 
        // dgvSanPham
        // 
        this.dgvSanPham.AllowUserToAddRows = false;
        this.dgvSanPham.AllowUserToDeleteRows = false;
        this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
        this.dgvSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvSanPham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvSanPham.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvSanPham.ColumnHeadersHeight = 35;
        this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvSanPham.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvSanPham.EnableHeadersVisualStyles = false;
        this.dgvSanPham.Location = new System.Drawing.Point(0, 260);
        this.dgvSanPham.MultiSelect = false;
        this.dgvSanPham.Name = "dgvSanPham";
        this.dgvSanPham.ReadOnly = true;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvSanPham.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        this.dgvSanPham.RowHeadersVisible = false;
        this.dgvSanPham.RowHeadersWidth = 51;
        this.dgvSanPham.RowTemplate.Height = 30;
        this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvSanPham.Size = new System.Drawing.Size(862, 313);
        this.dgvSanPham.TabIndex = 1;
        // 
        // panelTop
        // 
        this.panelTop.BackColor = System.Drawing.Color.White;
        this.panelTop.Controls.Add(this.groupBox1);
        this.panelTop.Controls.Add(this.panelActions);
        this.panelTop.Controls.Add(this.panelSearch);
        this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelTop.Location = new System.Drawing.Point(0, 0);
        this.panelTop.Name = "panelTop";
        this.panelTop.Padding = new System.Windows.Forms.Padding(10);
        this.panelTop.Size = new System.Drawing.Size(862, 260);
        this.panelTop.TabIndex = 0;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.cbbNhaCungCap);
        this.groupBox1.Controls.Add(this.txtTheLoai);
        this.groupBox1.Controls.Add(this.txtXuatXu);
        this.groupBox1.Controls.Add(this.txtHangSP);
        this.groupBox1.Controls.Add(this.txtTenSP);
        this.groupBox1.Controls.Add(this.txtMaSP);
        this.groupBox1.Controls.Add(this.label6);
        this.groupBox1.Controls.Add(this.label5);
        this.groupBox1.Controls.Add(this.label4);
        this.groupBox1.Controls.Add(this.label3);
        this.groupBox1.Controls.Add(this.label2);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.groupBox1.Location = new System.Drawing.Point(10, 10);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(652, 185);
        this.groupBox1.TabIndex = 0;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Thông tin sản phẩm";
        // 
        // cbbNhaCungCap
        // 
        this.cbbNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.cbbNhaCungCap.FormattingEnabled = true;
        this.cbbNhaCungCap.Location = new System.Drawing.Point(440, 140);
        this.cbbNhaCungCap.Name = "cbbNhaCungCap";
        this.cbbNhaCungCap.Size = new System.Drawing.Size(190, 28);
        this.cbbNhaCungCap.TabIndex = 11;
        // 
        // txtTheLoai
        // 
        this.txtTheLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtTheLoai.Location = new System.Drawing.Point(440, 90);
        this.txtTheLoai.Name = "txtTheLoai";
        this.txtTheLoai.Size = new System.Drawing.Size(190, 27);
        this.txtTheLoai.TabIndex = 10;
        // 
        // txtXuatXu
        // 
        this.txtXuatXu.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtXuatXu.Location = new System.Drawing.Point(440, 40);
        this.txtXuatXu.Name = "txtXuatXu";
        this.txtXuatXu.Size = new System.Drawing.Size(190, 27);
        this.txtXuatXu.TabIndex = 9;
        // 
        // txtHangSP
        // 
        this.txtHangSP.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtHangSP.Location = new System.Drawing.Point(130, 140);
        this.txtHangSP.Name = "txtHangSP";
        this.txtHangSP.Size = new System.Drawing.Size(190, 27);
        this.txtHangSP.TabIndex = 8;
        // 
        // txtTenSP
        // 
        this.txtTenSP.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtTenSP.Location = new System.Drawing.Point(130, 90);
        this.txtTenSP.Name = "txtTenSP";
        this.txtTenSP.Size = new System.Drawing.Size(190, 27);
        this.txtTenSP.TabIndex = 7;
        // 
        // txtMaSP
        // 
        this.txtMaSP.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtMaSP.Location = new System.Drawing.Point(130, 40);
        this.txtMaSP.Name = "txtMaSP";
        this.txtMaSP.Size = new System.Drawing.Size(190, 27);
        this.txtMaSP.TabIndex = 6;
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label6.Location = new System.Drawing.Point(340, 143);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(100, 20);
        this.label6.TabIndex = 5;
        this.label6.Text = "Nhà cung cấp:";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label5.Location = new System.Drawing.Point(340, 93);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(66, 20);
        this.label5.TabIndex = 4;
        this.label5.Text = "Thể loại:";
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label4.Location = new System.Drawing.Point(340, 43);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(62, 20);
        this.label4.TabIndex = 3;
        this.label4.Text = "Xuất xứ:";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label3.Location = new System.Drawing.Point(20, 143);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(46, 20);
        this.label3.TabIndex = 2;
        this.label3.Text = "Hãng:";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label2.Location = new System.Drawing.Point(20, 93);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(103, 20);
        this.label2.TabIndex = 1;
        this.label2.Text = "Tên sản phẩm:";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label1.Location = new System.Drawing.Point(20, 43);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(101, 20);
        this.label1.TabIndex = 0;
        this.label1.Text = "Mã sản phẩm:";
        // 
        // panelActions
        // 
        this.panelActions.Controls.Add(this.btnReset);
        this.panelActions.Controls.Add(this.btnXoa);
        this.panelActions.Controls.Add(this.btnSua);
        this.panelActions.Controls.Add(this.btnThem);
        this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
        this.panelActions.Location = new System.Drawing.Point(662, 10);
        this.panelActions.Name = "panelActions";
        this.panelActions.Size = new System.Drawing.Size(190, 185);
        this.panelActions.TabIndex = 1;
        // 
        // btnReset
        // 
        this.btnReset.BackColor = System.Drawing.Color.LightGray;
        this.btnReset.FlatAppearance.BorderSize = 0;
        this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnReset.Location = new System.Drawing.Point(20, 140);
        this.btnReset.Name = "btnReset";
        this.btnReset.Size = new System.Drawing.Size(150, 35);
        this.btnReset.TabIndex = 3;
        this.btnReset.Text = "Làm mới";
        this.btnReset.UseVisualStyleBackColor = false;
        this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
        // 
        // btnXoa
        // 
        this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
        this.btnXoa.FlatAppearance.BorderSize = 0;
        this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnXoa.ForeColor = System.Drawing.Color.White;
        this.btnXoa.Location = new System.Drawing.Point(20, 95);
        this.btnXoa.Name = "btnXoa";
        this.btnXoa.Size = new System.Drawing.Size(150, 35);
        this.btnXoa.TabIndex = 2;
        this.btnXoa.Text = "Xóa";
        this.btnXoa.UseVisualStyleBackColor = false;
        this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
        // 
        // btnSua
        // 
        this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
        this.btnSua.FlatAppearance.BorderSize = 0;
        this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnSua.ForeColor = System.Drawing.Color.White;
        this.btnSua.Location = new System.Drawing.Point(20, 50);
        this.btnSua.Name = "btnSua";
        this.btnSua.Size = new System.Drawing.Size(150, 35);
        this.btnSua.TabIndex = 1;
        this.btnSua.Text = "Sửa";
        this.btnSua.UseVisualStyleBackColor = false;
        this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
        // 
        // btnThem
        // 
        this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
        this.btnThem.FlatAppearance.BorderSize = 0;
        this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnThem.ForeColor = System.Drawing.Color.White;
        this.btnThem.Location = new System.Drawing.Point(20, 5);
        this.btnThem.Name = "btnThem";
        this.btnThem.Size = new System.Drawing.Size(150, 35);
        this.btnThem.TabIndex = 0;
        this.btnThem.Text = "Thêm";
        this.btnThem.UseVisualStyleBackColor = false;
        this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
        // 
        // panelSearch
        // 
        this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.panelSearch.Controls.Add(this.btnTimKiem);
        this.panelSearch.Controls.Add(this.txtTimKiem);
        this.panelSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panelSearch.Location = new System.Drawing.Point(10, 195);
        this.panelSearch.Name = "panelSearch";
        this.panelSearch.Size = new System.Drawing.Size(842, 55);
        this.panelSearch.TabIndex = 2;
        // 
        // btnTimKiem
        // 
        this.btnTimKiem.BackColor = System.Drawing.Color.RoyalBlue;
        this.btnTimKiem.FlatAppearance.BorderSize = 0;
        this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnTimKiem.ForeColor = System.Drawing.Color.White;
        this.btnTimKiem.Location = new System.Drawing.Point(440, 12);
        this.btnTimKiem.Name = "btnTimKiem";
        this.btnTimKiem.Size = new System.Drawing.Size(120, 30);
        this.btnTimKiem.TabIndex = 1;
        this.btnTimKiem.Text = "Tìm kiếm";
        this.btnTimKiem.UseVisualStyleBackColor = false;
        this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
        // 
        // txtTimKiem
        // 
        this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtTimKiem.Location = new System.Drawing.Point(20, 14);
        this.txtTimKiem.Name = "txtTimKiem";
        this.txtTimKiem.Size = new System.Drawing.Size(400, 27);
        this.txtTimKiem.TabIndex = 0;
        // 
        // FormSanPham
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(862, 573);
        this.Controls.Add(this.dgvSanPham);
        this.Controls.Add(this.panelTop);
        this.Name = "FormSanPham";
        this.Text = "QUẢN LÝ SẢN PHẨM";
        this.Load += new System.EventHandler(this.FormSanPham_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
        this.panelTop.ResumeLayout(false);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.panelActions.ResumeLayout(false);
        this.panelSearch.ResumeLayout(false);
        this.panelSearch.PerformLayout();
        this.ResumeLayout(false);
    }
    #endregion

    private System.Windows.Forms.DataGridView dgvSanPham;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtMaSP;
    private System.Windows.Forms.ComboBox cbbNhaCungCap;
    private System.Windows.Forms.TextBox txtTheLoai;
    private System.Windows.Forms.TextBox txtXuatXu;
    private System.Windows.Forms.TextBox txtHangSP;
    private System.Windows.Forms.TextBox txtTenSP;
    private System.Windows.Forms.Panel panelActions;
    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Panel panelSearch;
    private System.Windows.Forms.Button btnTimKiem;
    private System.Windows.Forms.TextBox txtTimKiem;
}
}
