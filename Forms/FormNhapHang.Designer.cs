namespace QuanLyCuaHangMyPham
{
    partial class FormNhapHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbbSanPham = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sản phẩm:";
            // 
            // cbbSanPham
            // 
            this.cbbSanPham.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbSanPham.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbSanPham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbbSanPham.FormattingEnabled = true;
            this.cbbSanPham.Location = new System.Drawing.Point(130, 27);
            this.cbbSanPham.Name = "cbbSanPham";
            this.cbbSanPham.Size = new System.Drawing.Size(280, 28);
            this.cbbSanPham.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(30, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số lượng:";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numSoLuong.Location = new System.Drawing.Point(130, 73);
            this.numSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(280, 27);
            this.numSoLuong.TabIndex = 3;
            this.numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(30, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày nhập:";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayNhap.Location = new System.Drawing.Point(130, 115);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(280, 27);
            this.dtpNgayNhap.TabIndex = 5;
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnNhapHang.FlatAppearance.BorderSize = 0;
            this.btnNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapHang.ForeColor = System.Drawing.Color.White;
            this.btnNhapHang.Location = new System.Drawing.Point(260, 170);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(150, 40);
            this.btnNhapHang.TabIndex = 6;
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.UseVisualStyleBackColor = false;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightGray;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(100, 170);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(150, 40);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(442, 233);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnNhapHang);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbSanPham);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập hàng vào kho";
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbSanPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnHuy;
    }
}
