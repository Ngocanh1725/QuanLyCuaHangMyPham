using QuanLyCuaHangMyPham.BLL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormDonHang : Form
    {
        private BindingList<ChiTietDonHangDTO> gioHang = new BindingList<ChiTietDonHangDTO>();
        private TaiKhoanDTO loginAccount;

        public FormDonHang(TaiKhoanDTO acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
        }

        private void FormDonHang_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            SetupDataGridView();
            ResetForm();
        }

        void LoadComboBoxes()
        {
            // Load sản phẩm
            cbbSanPham.DataSource = DonHangBLL.Instance.GetListSanPhamTrongKho();
            cbbSanPham.DisplayMember = "Display";
            cbbSanPham.ValueMember = "MaSP";

            // Load nhân viên
            cbbNhanVien.DataSource = DonHangBLL.Instance.GetListNhanVien();
            cbbNhanVien.DisplayMember = "TenNV";
            cbbNhanVien.ValueMember = "MaNV";
        }

        void SetupDataGridView()
        {
            dgvGioHang.DataSource = gioHang;
            dgvGioHang.Columns["MaCTDH"].Visible = false;
            dgvGioHang.Columns["MaDH"].Visible = false;
            dgvGioHang.Columns["MaSP"].HeaderText = "Mã SP";
            dgvGioHang.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvGioHang.Columns["GiaBan"].HeaderText = "Đơn giá";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvGioHang.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        void UpdateTongTien()
        {
            float tongTien = gioHang.Sum(item => item.ThanhTien);
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cbbSanPham.SelectedItem == null) return;

            SanPhamKhoDTO spKho = cbbSanPham.SelectedItem as SanPhamKhoDTO;
            int soLuongMua = (int)numSoLuong.Value;
            float giaBan;

            if (!float.TryParse(txtGiaBan.Text, out giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá bán hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soLuongMua > spKho.SoLuongTon)
            {
                MessageBox.Show("Số lượng mua vượt quá số lượng tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
            var itemInCart = gioHang.FirstOrDefault(item => item.MaSP == spKho.MaSP);
            if (itemInCart != null)
            {
                // Cập nhật số lượng
                if (itemInCart.SoLuong + soLuongMua > spKho.SoLuongTon)
                {
                    MessageBox.Show("Tổng số lượng mua vượt quá số lượng tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    itemInCart.SoLuong += soLuongMua;
                    itemInCart.ThanhTien = itemInCart.SoLuong * itemInCart.GiaBan;
                    gioHang.ResetBindings(); // Cập nhật lại DataGridView
                }
            }
            else
            {
                // Thêm mới
                ChiTietDonHangDTO newItem = new ChiTietDonHangDTO("", spKho.MaSP, soLuongMua, giaBan);
                gioHang.Add(newItem);
            }
            UpdateTongTien();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                var selectedItem = dgvGioHang.SelectedRows[0].DataBoundItem as ChiTietDonHangDTO;
                gioHang.Remove(selectedItem);
                UpdateTongTien();
            }
        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDH.Text) || string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Mã đơn hàng và Tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DonHangDTO dh = new DonHangDTO(
                    txtMaDH.Text,
                    txtTenKH.Text,
                    txtSDTKH.Text,
                    txtDiaChi.Text,
                    DateTime.Now,
                    cbbNhanVien.SelectedValue.ToString()
                );

                List<ChiTietDonHangDTO> listChiTiet = new List<ChiTietDonHangDTO>();
                foreach (var item in gioHang)
                {
                    item.MaDH = dh.MaDH; // Gán mã đơn hàng cho từng chi tiết
                    listChiTiet.Add(item);
                }

                if (DonHangBLL.Instance.CreateDonHang(dh, listChiTiet))
                {
                    MessageBox.Show("Tạo đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadComboBoxes(); // Load lại sản phẩm vì số lượng tồn đã thay đổi
                }
                else
                {
                    MessageBox.Show("Tạo đơn hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ResetForm()
        {
            txtMaDH.Clear();
            txtTenKH.Clear();
            txtSDTKH.Clear();
            txtDiaChi.Clear();
            txtGiaBan.Clear();
            numSoLuong.Value = 1;
            gioHang.Clear();
            UpdateTongTien();
            txtMaDH.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}