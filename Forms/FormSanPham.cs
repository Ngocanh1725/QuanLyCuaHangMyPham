using QuanLyCuaHangMyPham.BLL;
using QuanLyCuaHangMyPham.DTO;
using System;
using System.Windows.Forms;

// Thêm using cho custom control
using QuanLyCuaHangMyPham.CustomControls;

namespace QuanLyCuaHangMyPham
{
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadSanPhamList();
            LoadNhaCungCapComboBox();
        }

        void SetupDataGridView()
        {
            // Cấu hình các cột cho DataGridView
            dgvSanPham.AutoGenerateColumns = false; // Tắt tự động tạo cột
            dgvSanPham.Columns.Clear();

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSP", HeaderText = "Mã SP" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSP", HeaderText = "Tên Sản Phẩm" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HangSP", HeaderText = "Hãng" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "XuatXu", HeaderText = "Xuất Xứ" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TheLoai", HeaderText = "Thể Loại" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNCC", HeaderText = "Mã NCC" });
        }

        void LoadSanPhamList()
        {
            // Xóa binding cũ để tránh lỗi
            txtMaSP.DataBindings.Clear();
            txtTenSP.DataBindings.Clear();
            txtHangSP.DataBindings.Clear();
            txtXuatXu.DataBindings.Clear();
            txtTheLoai.DataBindings.Clear();
            cbbNhaCungCap.DataBindings.Clear();

            dgvSanPham.DataSource = SanPhamBLL.Instance.GetListSanPham();

            // Add lại binding sau khi load data
            AddSanPhamBinding();
        }

        void LoadNhaCungCapComboBox()
        {
            cbbNhaCungCap.DataSource = NhaCungCapBLL.Instance.GetListNhaCungCap();
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "MaNCC";
        }

        void AddSanPhamBinding()
        {
            txtMaSP.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "MaSP", true, DataSourceUpdateMode.Never));
            txtTenSP.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "TenSP", true, DataSourceUpdateMode.Never));
            txtHangSP.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "HangSP", true, DataSourceUpdateMode.Never));
            txtXuatXu.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "XuatXu", true, DataSourceUpdateMode.Never));
            txtTheLoai.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "TheLoai", true, DataSourceUpdateMode.Never));
            cbbNhaCungCap.DataBindings.Add(new Binding("SelectedValue", dgvSanPham.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    MessageBox.Show("Mã và Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (SanPhamBLL.Instance.InsertSanPham(txtMaSP.Text, txtTenSP.Text, txtHangSP.Text, txtXuatXu.Text, txtTheLoai.Text, cbbNhaCungCap.SelectedValue.ToString()))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSanPhamList();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại! Mã sản phẩm có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (SanPhamBLL.Instance.UpdateSanPham(txtMaSP.Text, txtTenSP.Text, txtHangSP.Text, txtXuatXu.Text, txtTheLoai.Text, cbbNhaCungCap.SelectedValue.ToString()))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSanPhamList();
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{txtTenSP.Text}' không? Hành động này không thể hoàn tác.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SanPhamBLL.Instance.DeleteSanPham(txtMaSP.Text))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSanPhamList();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = SanPhamBLL.Instance.SearchSanPham(txtTimKiem.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtHangSP.Clear();
            txtXuatXu.Clear();
            txtTheLoai.Clear();
            txtTimKiem.Clear();
            LoadSanPhamList();
            txtMaSP.Focus();
        }
    }
}