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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoaDonHang = new QuanLyCuaHangMyPham.CustomControls.RoundedButton();
            this.btnXemChiTiet = new QuanLyCuaHangMyPham.CustomControls.RoundedButton();
            this.btnThongKe = new QuanLyCuaHangMyPham.CustomControls.RoundedButton();
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
            this.tabControlCharts = new System.Windows.Forms.TabControl();
            this.tabPageTopSP = new System.Windows.Forms.TabPage();
            this.chartTopSP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageDoanhThu = new System.Windows.Forms.TabPage();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.panelCards.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControlCharts.SuspendLayout();
            this.tabPageTopSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).BeginInit();
            this.tabPageDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.numYear);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.btnXoaDonHang);
            this.panelTop.Controls.Add(this.btnXemChiTiet);
            this.panelTop.Controls.Add(this.btnThongKe);
            this.panelTop.Controls.Add(this.dtpToDate);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.dtpFromDate);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(646, 57);
            this.panelTop.TabIndex = 0;
            // 
            // numYear
            // 
            this.numYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numYear.Location = new System.Drawing.Point(396, 18);
            this.numYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numYear.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(56, 23);
            this.numYear.TabIndex = 8;
            this.numYear.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(356, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Năm:";
            // 
            // btnXoaDonHang
            // 
            this.btnXoaDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnXoaDonHang.BorderRadius = 20;
            this.btnXoaDonHang.FlatAppearance.BorderSize = 0;
            this.btnXoaDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDonHang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaDonHang.ForeColor = System.Drawing.Color.White;
            this.btnXoaDonHang.Location = new System.Drawing.Point(461, 12);
            this.btnXoaDonHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoaDonHang.Name = "btnXoaDonHang";
            this.btnXoaDonHang.Size = new System.Drawing.Size(90, 32);
            this.btnXoaDonHang.TabIndex = 6;
            this.btnXoaDonHang.Text = "Xóa ĐH";
            this.btnXoaDonHang.UseVisualStyleBackColor = false;
            this.btnXoaDonHang.Click += new System.EventHandler(this.btnXoaDonHang_Click);
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnXemChiTiet.BorderRadius = 20;
            this.btnXemChiTiet.FlatAppearance.BorderSize = 0;
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(262, 12);
            this.btnXemChiTiet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(90, 32);
            this.btnXemChiTiet.TabIndex = 5;
            this.btnXemChiTiet.Text = "Xem Chi Tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnThongKe.BorderRadius = 20;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(556, 12);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(82, 32);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(184, 18);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(74, 23);
            this.dtpToDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(122, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(68, 18);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(50, 23);
            this.dtpFromDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày:";
            // 
            // panelCards
            // 
            this.panelCards.BackColor = System.Drawing.Color.White;
            this.panelCards.Controls.Add(this.panelCard2);
            this.panelCards.Controls.Add(this.panelCard1);
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCards.Location = new System.Drawing.Point(0, 57);
            this.panelCards.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCards.Name = "panelCards";
            this.panelCards.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.panelCards.Size = new System.Drawing.Size(646, 98);
            this.panelCards.TabIndex = 1;
            // 
            // panelCard2
            // 
            this.panelCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelCard2.Controls.Add(this.lblSoDonHang);
            this.panelCard2.Controls.Add(this.label5);
            this.panelCard2.Location = new System.Drawing.Point(330, 8);
            this.panelCard2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(300, 81);
            this.panelCard2.TabIndex = 1;
            // 
            // lblSoDonHang
            // 
            this.lblSoDonHang.AutoSize = true;
            this.lblSoDonHang.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDonHang.ForeColor = System.Drawing.Color.White;
            this.lblSoDonHang.Location = new System.Drawing.Point(15, 41);
            this.lblSoDonHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoDonHang.Name = "lblSoDonHang";
            this.lblSoDonHang.Size = new System.Drawing.Size(26, 30);
            this.lblSoDonHang.TabIndex = 1;
            this.lblSoDonHang.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số đơn hàng";
            // 
            // panelCard1
            // 
            this.panelCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelCard1.Controls.Add(this.lblTongDoanhThu);
            this.panelCard1.Controls.Add(this.label3);
            this.panelCard1.Location = new System.Drawing.Point(15, 8);
            this.panelCard1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(300, 81);
            this.panelCard1.TabIndex = 0;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.White;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(15, 41);
            this.lblTongDoanhThu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(80, 30);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "0 VNĐ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng doanh thu";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.tabControlCharts);
            this.panelMain.Controls.Add(this.dgvDonHang);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 155);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.panelMain.Size = new System.Drawing.Size(646, 311);
            this.panelMain.TabIndex = 2;
            // 
            // tabControlCharts
            // 
            this.tabControlCharts.Controls.Add(this.tabPageTopSP);
            this.tabControlCharts.Controls.Add(this.tabPageDoanhThu);
            this.tabControlCharts.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControlCharts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControlCharts.Location = new System.Drawing.Point(338, 0);
            this.tabControlCharts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControlCharts.Name = "tabControlCharts";
            this.tabControlCharts.SelectedIndex = 0;
            this.tabControlCharts.Size = new System.Drawing.Size(300, 303);
            this.tabControlCharts.TabIndex = 2;
            // 
            // tabPageTopSP
            // 
            this.tabPageTopSP.Controls.Add(this.chartTopSP);
            this.tabPageTopSP.Location = new System.Drawing.Point(4, 24);
            this.tabPageTopSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageTopSP.Name = "tabPageTopSP";
            this.tabPageTopSP.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageTopSP.Size = new System.Drawing.Size(292, 275);
            this.tabPageTopSP.TabIndex = 0;
            this.tabPageTopSP.Text = "Top Sản Phẩm";
            this.tabPageTopSP.UseVisualStyleBackColor = true;
            // 
            // chartTopSP
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTopSP.ChartAreas.Add(chartArea1);
            this.chartTopSP.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartTopSP.Legends.Add(legend1);
            this.chartTopSP.Location = new System.Drawing.Point(2, 2);
            this.chartTopSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartTopSP.Name = "chartTopSP";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTopSP.Series.Add(series1);
            this.chartTopSP.Size = new System.Drawing.Size(288, 271);
            this.chartTopSP.TabIndex = 1;
            this.chartTopSP.Text = "chart1";
            title1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Top 5 Sản phẩm Bán chạy";
            this.chartTopSP.Titles.Add(title1);
            // 
            // tabPageDoanhThu
            // 
            this.tabPageDoanhThu.Controls.Add(this.chartDoanhThu);
            this.tabPageDoanhThu.Location = new System.Drawing.Point(4, 24);
            this.tabPageDoanhThu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageDoanhThu.Name = "tabPageDoanhThu";
            this.tabPageDoanhThu.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageDoanhThu.Size = new System.Drawing.Size(292, 275);
            this.tabPageDoanhThu.TabIndex = 1;
            this.tabPageDoanhThu.Text = "Doanh Thu";
            this.tabPageDoanhThu.UseVisualStyleBackColor = true;
            // 
            // chartDoanhThu
            // 
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea2);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend2);
            this.chartDoanhThu.Location = new System.Drawing.Point(2, 2);
            this.chartDoanhThu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Doanh thu";
            series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chartDoanhThu.Series.Add(series2);
            this.chartDoanhThu.Size = new System.Drawing.Size(288, 271);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Text = "chart1";
            title2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "Doanh thu theo Tháng";
            this.chartDoanhThu.Titles.Add(title2);
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
            this.dgvDonHang.Location = new System.Drawing.Point(8, 0);
            this.dgvDonHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDonHang.MultiSelect = false;
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.RowHeadersVisible = false;
            this.dgvDonHang.RowHeadersWidth = 51;
            this.dgvDonHang.RowTemplate.Height = 30;
            this.dgvDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonHang.Size = new System.Drawing.Size(630, 303);
            this.dgvDonHang.TabIndex = 0;
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 466);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelCards);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormThongKe";
            this.Text = "BÁO CÁO & THỐNG KÊ";
            this.Load += new System.EventHandler(this.FormThongKe_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.panelCards.ResumeLayout(false);
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.tabControlCharts.ResumeLayout(false);
            this.tabPageTopSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).EndInit();
            this.tabPageDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel panelTop;
        private CustomControls.RoundedButton btnThongKe;
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
        private System.Windows.Forms.DataGridView dgvDonHang;
        private CustomControls.RoundedButton btnXemChiTiet;
        private CustomControls.RoundedButton btnXoaDonHang;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControlCharts;
        private System.Windows.Forms.TabPage tabPageTopSP;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSP;
        private System.Windows.Forms.TabPage tabPageDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
    }
}
