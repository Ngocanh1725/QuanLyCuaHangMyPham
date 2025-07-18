using QuanLyCuaHangMyPham.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham.Forms
{
    public partial class frmChiTietDonHang : Form
    {
        private readonly DonHang _donHang;
        private readonly List<SanPham> _allSanPhams;
        public frmChiTietDonHang(DonHang donHang, List<SanPham> allSanPhams)
        {
            InitializeComponent();
            _donHang = donHang;
            _allSanPhams = allSanPhams;
        }
        private void frmChiTietDonHang_Load(object sender, EventArgs e)
        {
            this.Text = $"Chi tiết đơn hàng: {_donHang.MaDH}";
            SetupDataGridView();
            PopulateGrid();
        }

        private void SetupDataGridView()
        {
            // Tương tự như trong frmDonHang
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSP", HeaderText = "Mã SP", DataPropertyName = "MaSP", ReadOnly = true });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSP", HeaderText = "Tên SP", DataPropertyName = "TenSP", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaBan", HeaderText = "Giá bán", DataPropertyName = "GiaBan", ReadOnly = true, DefaultCellStyle = { Format = "N0" } });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuong", HeaderText = "Số lượng", DataPropertyName = "SoLuong", ReadOnly = true });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThanhTien", HeaderText = "Thành tiền", DataPropertyName = "ThanhTien", ReadOnly = true, DefaultCellStyle = { Format = "N0" } });
        }

        private void PopulateGrid()
        {
            var displayList = _donHang.ChiTietDonHangList.Select(ct => new
            {
                ct.MaSP,
                TenSP = _allSanPhams.FirstOrDefault(sp => sp.MaSP == ct.MaSP)?.TenSP ?? "N/A",
                ct.GiaBan,
                ct.SoLuong,
                ct.ThanhTien
            }).ToList();
            dgvChiTiet.DataSource = displayList;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

