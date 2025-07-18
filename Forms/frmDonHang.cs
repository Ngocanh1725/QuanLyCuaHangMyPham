using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangMyPham.Forms;
using QuanLyCuaHangMyPham.Models;
using QuanLyCuaHangMyPham.Database;

namespace QuanLyCuaHangMyPham
{
    public partial class frmDonHang : Form
    {
        //--KHAI BÁO BIẾN--
        private readonly TaiKhoan _loggedInUser;
        private DonHang _donHangHienTai; //Đơn hàng đang được thao tác (tạo mới hoặc sửa)
        private List<SanPham> _allSanPhams;
        public Action OnSaveSuccess {  get; set; } //Callback để form cha có thể làm mới
        public frmDonHang(TaiKhoan user, DonHang donHangToEdit = null)
        {
            InitializeComponent();
            _donHangManager = new DonHangManager();
            _loggedInUser = user;
            _allSanPhams = _donHangManager.LayTatCaSanPhams();

            if (donHangToEdit != null) //Chế độ tạo mới
            {
                _donHangHienTai = new DonHang { MaNV = _loggedInUser.Account };
                ConfigureFormForCreateMode();
            }
            else //Chế độ suẩw xem
            {
                _donHangHienTai = donHangToEdit;
                ConfigureFormForEditMode();
            }
        }
        private void frmDonHang_Load(object sender, EventArgs e)
        {
            SetupUI();
            if (_donHangHienTai.MaDH != null && !_donHangHienTai.MaDH.Contains("0000"))
            {
                LoadDataForEditing();
            }
        }
        // --CÀI ĐẶT GIAO DIỆN--
        private void SetupUI()
        {
            // Cài đặt DataGridView
            dgvChiTietSanPham.AutoGenerateColumns = false;
            dgvChiTietSanPham.Columns.Clear();
            dgvChiTietSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSP", HeaderText = "Mã SP", DataPropertyName = "MaSP", ReadOnly = true });
            dgvChiTietSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSP", HeaderText = "Tên SP", DataPropertyName = "TenSP", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvChiTietSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaBan", HeaderText = "Giá bán", DataPropertyName = "GiaBan", ReadOnly = true, DefaultCellStyle = { Format = "N0" } });
            dgvChiTietSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuong", HeaderText = "Số lượng", DataPropertyName = "SoLuong", ReadOnly = true });
            dgvChiTietSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThanhTien", HeaderText = "Thành tiền", DataPropertyName = "ThanhTien", ReadOnly = true, DefaultCellStyle = { Format = "N0" } });

            // Nạp dữ liệu vào các ComboBox
            cboMaNVXuLy.Items.Add(_loggedInUser.Account);
            cboMaNVXuLy.SelectedItem = _loggedInUser.Account;

            cboSanPham.DataSource = _allSanPhams;
            cboSanPham.DisplayMember = "TenSP"; // Hiển thị tên cho dễ chọn
            cboSanPham.ValueMember = "MaSP";
            cboSanPham.SelectedIndex = -1;
        }

        private void ConfigureFormForCreateMode()
        {
            this.Text = "Tạo Đơn Hàng Mới";
            btnTaoDonHang.Enabled = true;
            btnSuaDonHang.Enabled = false;
            btnHuyDonHang.Enabled = false;
            btnXemChiTiet.Enabled = false;
            btnXuatHoaDon.Enabled = false;
            txtMaDH.Text = "(Mã tự động)";
            txtMaDH.ReadOnly = true;
        }

        private void ConfigureFormForEditMode()
        {
            this.Text = "Chi Tiết/Sửa Đơn Hàng";
            btnTaoDonHang.Enabled = false;
            btnSuaDonHang.Enabled = true;
            btnHuyDonHang.Enabled = true;
            btnXemChiTiet.Enabled = true;
            btnXuatHoaDon.Enabled = true;
            txtMaDH.ReadOnly = true;
        }

        private void LoadDataForEditing()
        {
            txtMaDH.Text = _donHangHienTai.MaDH;
            txtTenKH.Text = _donHangHienTai.TenKH;
            txtSDTKH.Text = _donHangHienTai.SDTKH;
            txtDiaChi.Text = _donHangHienTai.Diachi;
            dtpThoiGian.Value = _donHangHienTai.NgayMua;
            cboMaNVXuLy.SelectedItem = _donHangHienTai.MaNV;
            RefreshChiTietGrid();
        }

        //--XỬ LÝ NGHIỆP VỤ--
        private void RefreshChiTietGrid()
        {
            dgvChiTietSanPham.DataSource = null;
            if (_donHangHienTai.ChiTietDonHangList != null && _donHangHienTai.ChiTietDonHangList.Any())
            {
                var displayList = _donHangHienTai.ChiTietDonHangList.Select(ct => new
                {
                    ct.MaSP,
                    TenSP = _allSanPhams.FirstOrDefault(sp => sp.MaSP == ct.MaSP)?.TenSP ?? "N/A",
                    ct.GiaBan,
                    ct.SoLuong,
                    ct.ThanhTien
                }).ToList();
                dgvChiTietSanPham.DataSource = displayList;
            }
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            _donHangHienTai.TinhTongTien();
            txtTongTien.Text = $"{_donHangHienTai.TongTien:N0} VNĐ";
        }

        private void ResetForm()
        {
            _donHangHienTai = new DonHang { MaNV = _loggedInUser.Account };
            txtTenKH.Clear();
            txtSDTKH.Clear();
            txtDiaChi.Clear();
            cboSanPham.SelectedIndex = -1;
            txtGiaBan.Clear();
            nudSoLuong.Value = 1;
            RefreshChiTietGrid();
            ConfigureFormForCreateMode();
        }
        // === SỰ KIỆN CÁC NÚT BẤM ===
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem is SanPham selectedSP)
            {
                txtGiaBan.Text = selectedSP.GiaBan.ToString("N0");
            }
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (!(cboSanPham.SelectedItem is SanPham selectedSP))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.", "Lỗi");
                return;
            }
            int soLuong = (int)nudSoLuong.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Cảnh báo");
                return;
            }

            var existingItem = _donHangHienTai.ChiTietDonHangList.FirstOrDefault(ct => ct.MaSP == selectedSP.MaSP);
            if (existingItem != null)
            {
                existingItem.SoLuong += soLuong;
                existingItem.ThanhTien = existingItem.GiaBan * existingItem.SoLuong;
            }
            else
            {
                var newItem = new ChiTietDonHang(string.Empty, selectedSP.MaSP, selectedSP.GiaBan, soLuong)
                {
                    TenSP = selectedSP.TenSP // Gán luôn TenSP để dùng cho hóa đơn
                };
                _donHangHienTai.ChiTietDonHangList.Add(newItem);
            }
            RefreshChiTietGrid();
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            if (dgvChiTietSanPham.SelectedRows.Count > 0)
            {
                string maSP = dgvChiTietSanPham.SelectedRows[0].Cells["MaSP"].Value.ToString();
                var itemToRemove = _donHangHienTai.ChiTietDonHangList.FirstOrDefault(ct => ct.MaSP == maSP);
                if (itemToRemove != null)
                {
                    _donHangHienTai.ChiTietDonHangList.Remove(itemToRemove);
                    RefreshChiTietGrid();
                }
            }
        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            // Validations
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) || !_donHangHienTai.ChiTietDonHangList.Any())
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng và thêm ít nhất một sản phẩm.", "Thiếu thông tin");
                return;
            }

            // Gán thông tin từ form vào đối tượng
            _donHangHienTai.TenKH = txtTenKH.Text;
            _donHangHienTai.SDTKH = txtSDTKH.Text;
            _donHangHienTai.Diachi = txtDiaChi.Text;
            _donHangHienTai.NgayMua = dtpThoiGian.Value;
            _donHangHienTai.MaNV = cboMaNVXuLy.Text;

            if (_donHangManager.ThemDonHang(_donHangHienTai))
            {
                MessageBox.Show("Tạo đơn hàng thành công!", "Thành công");
                OnSaveSuccess?.Invoke(); // Gọi callback để form cha làm mới
                // Mở hóa đơn sau khi tạo thành công
                btnXuatHoaDon_Click(sender, e);
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo đơn hàng thất bại.", "Lỗi");
            }
        }

        private void btnSuaDonHang_Click(object sender, EventArgs e)
        {
            // Gán thông tin từ form vào đối tượng
            _donHangHienTai.TenKH = txtTenKH.Text;
            _donHangHienTai.SDTKH = txtSDTKH.Text;
            _donHangHienTai.Diachi = txtDiaChi.Text;
            _donHangHienTai.NgayMua = dtpThoiGian.Value;
            _donHangHienTai.MaNV = cboMaNVXuLy.Text;

            if (_donHangManager.CapNhatDonHang(_donHangHienTai))
            {
                MessageBox.Show("Cập nhật đơn hàng thành công!", "Thành công");
                OnSaveSuccess?.Invoke(); // Gọi callback để form cha làm mới
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật đơn hàng thất bại.", "Lỗi");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnXemChiTietDH_Click(object sender, EventArgs e)
        {
            // Mở form chi tiết read-only
            frmChiTietDonHang formChiTiet = new frmChiTietDonHang(_donHangHienTai, _allSanPhams);
            formChiTiet.ShowDialog();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            // Mở form hóa đơn
            frmHoaDon formHoaDon = new frmHoaDon(_donHangHienTai, _allSanPhams);
            formHoaDon.ShowDialog();
        }
    }
}
