using QuanLyCuaHangMyPham.BLL;
using QuanLyCuaHangMyPham.DTO;
using QuanLyCuaHangMyPham.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; // Thêm using cho ImageFormat
using System.IO;
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
        private DonHangDTO createdDonHang = null;

        public FormDonHang(TaiKhoanDTO acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            this.cbbSanPham.SelectedIndexChanged += new System.EventHandler(this.cbbSanPham_SelectedIndexChanged);
        }

        // --- Sự kiện được kích hoạt khi Form được tải lên lần đầu tiên ---
        private void FormDonHang_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình các cột cho bảng giỏ hàng (DataGridView).
            SetupDataGridView();

            // 2. Đặt form về trạng thái ban đầu (xóa trắng các ô, tạo mã đơn hàng mới).
            ResetForm();

            // 3. Tải dữ liệu cho các ComboBox "Sản phẩm" và "Nhân viên".
            // Việc này được thực hiện sau ResetForm để sự kiện SelectedIndexChanged có thể
            // tải hình ảnh cho sản phẩm đầu tiên trong danh sách.
            LoadComboBoxes();
        }


        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        void LoadComboBoxes()
        {
            cbbSanPham.DataSource = DonHangBLL.Instance.GetListSanPhamTrongKho();
            cbbSanPham.DisplayMember = "Display";
            cbbSanPham.ValueMember = "MaSP";

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
            float giaBan = spKho.DonGia;

            if (soLuongMua > spKho.SoLuongTon)
            {
                MessageBox.Show("Số lượng mua vượt quá số lượng tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var itemInCart = gioHang.FirstOrDefault(item => item.MaSP == spKho.MaSP);
            if (itemInCart != null)
            {
                if (itemInCart.SoLuong + soLuongMua > spKho.SoLuongTon)
                {
                    MessageBox.Show("Tổng số lượng mua vượt quá số lượng tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    itemInCart.SoLuong += soLuongMua;
                    itemInCart.ThanhTien = itemInCart.SoLuong * itemInCart.GiaBan;
                    gioHang.ResetBindings();
                }
            }
            else
            {
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
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnTaoDonHang.Enabled = false;
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
                    item.MaDH = dh.MaDH;
                    listChiTiet.Add(item);
                }

                if (DonHangBLL.Instance.CreateDonHang(dh, listChiTiet))
                {
                    MessageBox.Show("Tạo đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    createdDonHang = dh;
                    LoadComboBoxes();
                }
                else
                {
                    MessageBox.Show("Tạo đơn hàng thất bại! Mã đơn hàng có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    createdDonHang = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                createdDonHang = null;
            }
            finally
            {
                btnTaoDonHang.Enabled = true;
            }
        }

        void ResetForm()
        {
            txtMaDH.Text = DonHangBLL.Instance.GenerateNextMaDH();
            txtTenKH.Clear();
            txtSDTKH.Clear();
            txtDiaChi.Clear();
            txtGiaBan.Clear();
            numSoLuong.Value = 1;
            gioHang.Clear();
            UpdateTongTien();
            txtTenKH.Focus();
            createdDonHang = null;
            picHinhAnhSP.Image = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadComboBoxes();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (createdDonHang != null)
            {
                FormChiTietDonHang f = new FormChiTietDonHang(createdDonHang);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn cần tạo một đơn hàng thành công trước khi xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Sự kiện được kích hoạt mỗi khi người dùng chọn một sản phẩm khác trong ComboBox.
        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chỉ thực hiện nếu có một mục đang được chọn.
            if (cbbSanPham.SelectedItem != null)
            {
                // Lấy đối tượng SanPhamKhoDTO tương ứng với mục được chọn.
                SanPhamKhoDTO selectedProduct = cbbSanPham.SelectedItem as SanPhamKhoDTO;
                if (selectedProduct != null)
                {
                    // Tự động điền đơn giá vào ô txtGiaBan.
                    txtGiaBan.Text = selectedProduct.DonGia.ToString("N0");
                    // Tự động hiển thị hình ảnh của sản phẩm.
                    picHinhAnhSP.Image = ByteArrayToImage(selectedProduct.HinhAnh);
                }
            }
        }
    }
}
