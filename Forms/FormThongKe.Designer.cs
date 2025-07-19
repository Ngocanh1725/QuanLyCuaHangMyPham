namespace QuanLyCuaHangMyPham
{ 
partial class FormThongKe
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
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        this.panelTop = new System.Windows.Forms.Panel();
        this.btnThongKe = new System.Windows.Forms.Button();
        this.dtpToDate = new System.Windows.Forms.DateTimePicker();
        this.label2 = new System.Windows.Forms.Label();
        this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
        this.label1 = new System.Windows.Forms.Label();
        this.panelCards = new System.Windows.Forms.Panel();
        this.panelCard2 = new System.Windows.Forms.Panel();
        this.lblSoDonHang = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.panelCard1 = new System.Windows.Forms.Panel();
        this.lblTongDoanhThu = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.panelMain = new System.Windows.Forms.Panel();
        this.chartTopSP = new System.Windows.Forms.DataVisualization.Charting.Chart();
        this.dgvDonHang = new System.Windows.Forms.DataGridView();
        this.panelTop.SuspendLayout();
        this.panelCards.SuspendLayout();
        this.panelCard2.SuspendLayout();
        this.panelCard1.SuspendLayout();
        this.panelMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
        this.SuspendLayout();
        // 
        // panelTop
        // 
        this.panelTop.BackColor = System.Drawing.Color.White;
        this.panelTop.Controls.Add(this.btnThongKe);
        this.panelTop.Controls.Add(this.dtpToDate);
        this.panelTop.Controls.Add(this.label2);
        this.panelTop.Controls.Add(this.dtpFromDate);
        this.panelTop.Controls.Add(this.label1);
        this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelTop.Location = new System.Drawing.Point(0, 0);
        this.panelTop.Name = "panelTop";
        this.panelTop.Size = new System.Drawing.Size(862, 70);
        this.panelTop.TabIndex = 0;
        // 
        // btnThongKe
        // 
        this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
        this.btnThongKe.FlatAppearance.BorderSize = 0;
        this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnThongKe.ForeColor = System.Drawing.Color.White;
        this.btnThongKe.Location = new System.Drawing.Point(690, 15);
        this.btnThongKe.Name = "btnThongKe";
        this.btnThongKe.Size = new System.Drawing.Size(150, 40);
        this.btnThongKe.TabIndex = 4;
        this.btnThongKe.Text = "Thống kê";
        this.btnThongKe.UseVisualStyleBackColor = false;
        this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
        // 
        // dtpToDate
        // 
        this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.dtpToDate.Location = new System.Drawing.Point(400, 22);
        this.dtpToDate.Name = "dtpToDate";
        this.dtpToDate.Size = new System.Drawing.Size(270, 27);
        this.dtpToDate.TabIndex = 3;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.label2.Location = new System.Drawing.Point(320, 25);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(77, 20);
        this.label2.TabIndex = 2;
        this.label2.Text = "Đến ngày:";
        // 
        // dtpFromDate
        // 
        this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.dtpFromDate.Location = new System.Drawing.Point(90, 22);
        this.dtpFromDate.Name = "dtpFromDate";
        this.dtpFromDate.Size = new System.Drawing.Size(220, 27);
        this.dtpFromDate.TabIndex = 1;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.label1.Location = new System.Drawing.Point(20, 25);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(67, 20);
        this.label1.TabIndex = 0;
        this.label1.Text = "Từ ngày:";
        // 
        // panelCards
        // 
        this.panelCards.BackColor = System.Drawing.Color.White;
        this.panelCards.Controls.Add(this.panelCard2);
        this.panelCards.Controls.Add(this.panelCard1);
        this.panelCards.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelCards.Location = new System.Drawing.Point(0, 70);
        this.panelCards.Name = "panelCards";
        this.panelCards.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
        this.panelCards.Size = new System.Drawing.Size(862, 120);
        this.panelCards.TabIndex = 1;
        // 
        // panelCard2
        // 
        this.panelCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.panelCard2.Controls.Add(this.lblSoDonHang);
        this.panelCard2.Controls.Add(this.label5);
        this.panelCard2.Location = new System.Drawing.Point(440, 10);
        this.panelCard2.Name = "panelCard2";
        this.panelCard2.Size = new System.Drawing.Size(400, 100);
        this.panelCard2.TabIndex = 1;
        // 
        // lblSoDonHang
        // 
        this.lblSoDonHang.AutoSize = true;
        this.lblSoDonHang.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblSoDonHang.ForeColor = System.Drawing.Color.White;
        this.lblSoDonHang.Location = new System.Drawing.Point(20, 50);
        this.lblSoDonHang.Name = "lblSoDonHang";
        this.lblSoDonHang.Size = new System.Drawing.Size(33, 38);
        this.lblSoDonHang.TabIndex = 1;
        this.lblSoDonHang.Text = "0";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label5.ForeColor = System.Drawing.Color.White;
        this.label5.Location = new System.Drawing.Point(20, 15);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(112, 23);
        this.label5.TabIndex = 0;
        this.label5.Text = "Số đơn hàng";
        // 
        // panelCard1
        // 
        this.panelCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
        this.panelCard1.Controls.Add(this.lblTongDoanhThu);
        this.panelCard1.Controls.Add(this.label3);
        this.panelCard1.Location = new System.Drawing.Point(20, 10);
        this.panelCard1.Name = "panelCard1";
        this.panelCard1.Size = new System.Drawing.Size(400, 100);
        this.panelCard1.TabIndex = 0;
        // 
        // lblTongDoanhThu
        // 
        this.lblTongDoanhThu.AutoSize = true;
        this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblTongDoanhThu.ForeColor = System.Drawing.Color.White;
        this.lblTongDoanhThu.Location = new System.Drawing.Point(20, 50);
        this.lblTongDoanhThu.Name = "lblTongDoanhThu";
        this.lblTongDoanhThu.Size = new System.Drawing.Size(103, 38);
        this.lblTongDoanhThu.TabIndex = 1;
        this.lblTongDoanhThu.Text = "0 VNĐ";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label3.ForeColor = System.Drawing.Color.White;
        this.label3.Location = new System.Drawing.Point(20, 15);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(142, 23);
        this.label3.TabIndex = 0;
        this.label3.Text = "Tổng doanh thu";
        // 
        // panelMain
        // 
        this.panelMain.BackColor = System.Drawing.Color.White;
        this.panelMain.Controls.Add(this.chartTopSP);
        this.panelMain.Controls.Add(this.dgvDonHang);
        this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain.Location = new System.Drawing.Point(0, 190);
        this.panelMain.Name = "panelMain";
        this.panelMain.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
        this.panelMain.Size = new System.Drawing.Size(862, 383);
        this.panelMain.TabIndex = 2;
        // 
        // chartTopSP
        // 
        chartArea1.Name = "ChartArea1";
        this.chartTopSP.ChartAreas.Add(chartArea1);
        this.chartTopSP.Dock = System.Windows.Forms.DockStyle.Right;
        legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
        legend1.Name = "Legend1";
        this.chartTopSP.Legends.Add(legend1);
        this.chartTopSP.Location = new System.Drawing.Point(452, 0);
        this.chartTopSP.Name = "chartTopSP";
        this.chartTopSP.Size = new System.Drawing.Size(400, 373);
        this.chartTopSP.TabIndex = 1;
        this.chartTopSP.Text = "chart1";
        // 
        // dgvDonHang
        // 
        this.dgvDonHang.AllowUserToAddRows = false;
        this.dgvDonHang.AllowUserToDeleteRows = false;
        this.dgvDonHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvDonHang.BackgroundColor = System.Drawing.Color.White;
        this.dgvDonHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvDonHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvDonHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvDonHang.ColumnHeadersHeight = 35;
        this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvDonHang.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvDonHang.EnableHeadersVisualStyles = false;
        this.dgvDonHang.Location = new System.Drawing.Point(10, 0);
        this.dgvDonHang.MultiSelect = false;
        this.dgvDonHang.Name = "dgvDonHang";
        this.dgvDonHang.ReadOnly = true;
        this.dgvDonHang.RowHeadersVisible = false;
        this.dgvDonHang.RowHeadersWidth = 51;
        this.dgvDonHang.RowTemplate.Height = 30;
        this.dgvDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvDonHang.Size = new System.Drawing.Size(842, 373);
        this.dgvDonHang.TabIndex = 0;
        // 
        // FormThongKe
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(862, 573);
        this.Controls.Add(this.panelMain);
        this.Controls.Add(this.panelCards);
        this.Controls.Add(this.panelTop);
        this.Name = "FormThongKe";
        this.Text = "BÁO CÁO & THỐNG KÊ";
        this.Load += new System.EventHandler(this.FormThongKe_Load);
        this.panelTop.ResumeLayout(false);
        this.panelTop.PerformLayout();
        this.panelCards.ResumeLayout(false);
        this.panelCard2.ResumeLayout(false);
        this.panelCard2.PerformLayout();
        this.panelCard1.ResumeLayout(false);
        this.panelCard1.PerformLayout();
        this.panelMain.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
        this.ResumeLayout(false);
    }
    #endregion
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Button btnThongKe;
    private System.Windows.Forms.DateTimePicker dtpToDate;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dtpFromDate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panelCards;
    private System.Windows.Forms.Panel panelCard2;
    private System.Windows.Forms.Label lblSoDonHang;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Panel panelCard1;
    private System.Windows.Forms.Label lblTongDoanhThu;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSP;
    private System.Windows.Forms.DataGridView dgvDonHang;
}
}