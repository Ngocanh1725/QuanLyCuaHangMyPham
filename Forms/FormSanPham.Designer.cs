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
        this.dgvSanPham = new System.Windows.Forms.DataGridView();
        this.panel1 = new System.Windows.Forms.Panel();
        this.btnReset = new System.Windows.Forms.Button();
        this.btnTimKiem = new System.Windows.Forms.Button();
        this.txtTimKiem = new System.Windows.Forms.TextBox();
        this.btnXoa = new System.Windows.Forms.Button();
        this.btnSua = new System.Windows.Forms.Button();
        this.btnThem = new System.Windows.Forms.Button();
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
        ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
        this.panel1.SuspendLayout();
        this.groupBox1.SuspendLayout();
        this.SuspendLayout();
        // 
        // dgvSanPham
        // 
        this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvSanPham.Location = new System.Drawing.Point(0, 250);
        this.dgvSanPham.Name = "dgvSanPham";
        this.dgvSanPham.RowHeadersWidth = 51;
        this.dgvSanPham.RowTemplate.Height = 24;
        this.dgvSanPham.Size = new System.Drawing.Size(862, 323);
        this.dgvSanPham.TabIndex = 1;
        // 
        // panel1
        // 
        this.panel1.Controls.Add(this.btnReset);
        this.panel1.Controls.Add(this.btnTimKiem);
        this.panel1.Controls.Add(this.txtTimKiem);
        this.panel1.Controls.Add(this.btnXoa);
        this.panel1.Controls.Add(this.btnSua);
        this.panel1.Controls.Add(this.btnThem);
        this.panel1.Controls.Add(this.groupBox1);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel1.Location = new System.Drawing.Point(0, 0);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(862, 250);
        this.panel1.TabIndex = 0;
        // 
        // groupBox1
        // ... (Code thiết kế cho GroupBox và các control bên trong)
        // ... (Bạn có thể tự thiết kế phần này bằng cách kéo thả)
        // 
        // FormSanPham
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(862, 573);
        this.Controls.Add(this.dgvSanPham);
        this.Controls.Add(this.panel1);
        this.Name = "FormSanPham";
        this.Text = "QUẢN LÝ SẢN PHẨM";
        this.Load += new System.EventHandler(this.FormSanPham_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.ResumeLayout(false);
    }
    #endregion

    private System.Windows.Forms.DataGridView dgvSanPham;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnThem;
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
    private System.Windows.Forms.Button btnTimKiem;
    private System.Windows.Forms.TextBox txtTimKiem;
    private System.Windows.Forms.Button btnReset;
}
}
