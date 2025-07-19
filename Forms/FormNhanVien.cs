using QuanLyCuaHangMyPham.BLL;
using System;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadNhanVienList();
            AddNhanVienBinding();
        }

        void SetupDataGridView()
        {
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Columns.Clear();

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNV", HeaderText = "Mã NV" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNV", HeaderText = "Họ và Tên" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SDT", HeaderText = "Số Điện Thoại" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QueQuan", HeaderText = "Quê Quán" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenTK", HeaderText = "Tên Tài Khoản" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MatKhau", HeaderText = "Mật Khẩu" });
        }

        void LoadNhanVienList()
        {
            // Clear existing bindings
            txtMaNV.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtQueQuan.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtTenTK.DataBindings.Clear();
            txtMatKhau.DataBindings.Clear();

            // Load data into the DataGridView
            dgvNhanVien.DataSource = NhanVienBLL.Instance.GetListNhanVien();

            // Do not call AddNhanVienBinding here
        }

        void AddNhanVienBinding()
        {
            txtMaNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txtTenNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "TenNV", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtQueQuan.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "QueQuan", true, DataSourceUpdateMode.Never));
            txtEmail.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txtTenTK.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "TenTK", true, DataSourceUpdateMode.Never));
            txtMatKhau.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "MatKhau", true, DataSourceUpdateMode.Never));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text) || string.IsNullOrWhiteSpace(txtTenTK.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Mã NV, Tên NV, Tên tài khoản và Mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (NhanVienBLL.Instance.InsertNhanVien(txtMaNV.Text, txtTenNV.Text, txtSDT.Text, txtQueQuan.Text, txtEmail.Text, txtTenTK.Text, txtMatKhau.Text))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVienList();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại! Mã nhân viên hoặc Tên tài khoản có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (NhanVienBLL.Instance.UpdateNhanVien(txtMaNV.Text, txtTenNV.Text, txtSDT.Text, txtQueQuan.Text, txtEmail.Text, txtTenTK.Text, txtMatKhau.Text))
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVienList();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{txtTenNV.Text}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (NhanVienBLL.Instance.DeleteNhanVien(txtMaNV.Text))
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhanVienList();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvNhanVien.DataSource = NhanVienBLL.Instance.SearchNhanVien(txtTimKiem.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtQueQuan.Clear();
            txtEmail.Clear();
            txtTenTK.Clear();
            txtMatKhau.Clear();
            txtTimKiem.Clear();
            LoadNhanVienList();
        }
    }
}
