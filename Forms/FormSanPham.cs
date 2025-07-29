// --- Khai báo các thư viện cần thiết ---
using QuanLyCuaHangMyPham.BLL; // Sử dụng các lớp logic nghiệp vụ
using QuanLyCuaHangMyPham.DTO; // Sử dụng các lớp đối tượng dữ liệu
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; // Thêm using cho ImageFormat
using System.Globalization; // Cần thiết để xử lý chuỗi số có định dạng
using System.IO;            // Cần thiết để làm việc với luồng dữ liệu cho hình ảnh
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class FormSanPham : Form
    {
        private bool isDataLoading = false;

        // --- Hàm khởi tạo của Form ---
        public FormSanPham()
        {
            InitializeComponent();
        }

        // --- Sự kiện khi Form được tải lên ---
        private void FormSanPham_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadComboBoxes();
            LoadSanPhamList();
            ResetFields();
        }

        // --- Các phương thức trợ giúp (Helper Methods) ---
        private byte[] ImageToByteArray(Image image)
        {
            if (image == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image originalImage = Image.FromStream(ms);
                return new Bitmap(originalImage);
            }
        }

        // --- Các phương thức tải và thiết lập dữ liệu ---
        void SetupDataGridView()
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.Columns.Clear();

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSP", HeaderText = "Mã SP" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSP", HeaderText = "Tên Sản Phẩm" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HangSP", HeaderText = "Hãng / NCC" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenLoai", HeaderText = "Thể Loại" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "XuatXu", HeaderText = "Xuất Xứ" });

            var donGiaColumn = new DataGridViewTextBoxColumn { DataPropertyName = "DonGia", HeaderText = "Đơn Giá (VNĐ)" };
            donGiaColumn.DefaultCellStyle.Format = "N0";
            dgvSanPham.Columns.Add(donGiaColumn);

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNCC", Visible = false });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HinhAnh", Visible = false });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaLoai", Visible = false });
        }

        void LoadSanPhamList()
        {
            isDataLoading = true;
            dgvSanPham.DataSource = SanPhamBLL.Instance.GetListSanPham();
            isDataLoading = false;
        }

        void LoadComboBoxes()
        {
            cbbNhaCungCap.DataSource = NhaCungCapBLL.Instance.GetListNhaCungCap();
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "MaNCC";

            cbbTheLoai.DataSource = LoaiSanPhamBLL.Instance.GetListLoaiSanPham();
            cbbTheLoai.DisplayMember = "TenLoai";
            cbbTheLoai.ValueMember = "MaLoai";
        }

        void ResetFields()
        {
            isDataLoading = true;
            dgvSanPham.ClearSelection();

            txtMaSP.Text = SanPhamBLL.Instance.GenerateNextMaSP();

            txtTenSP.Clear();
            txtXuatXu.Clear();
            txtDonGia.Clear();
            txtTimKiem.Clear();
            picHinhAnh.Image = null;

            if (cbbNhaCungCap.Items.Count > 0) cbbNhaCungCap.SelectedIndex = 0;
            if (cbbTheLoai.Items.Count > 0) cbbTheLoai.SelectedIndex = 0;

            txtTenSP.Focus();
            isDataLoading = false;
        }

        // --- Các sự kiện của người dùng (Event Handlers) ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(txtDonGia.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out float donGia) || donGia < 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sửa lỗi: Kiểm tra SelectedValue trước khi sử dụng
                if (cbbTheLoai.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một thể loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbbNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                byte[] hinhAnh = ImageToByteArray(picHinhAnh.Image);
                string maLoai = cbbTheLoai.SelectedValue.ToString();
                string maNCC = cbbNhaCungCap.SelectedValue.ToString();

                if (SanPhamBLL.Instance.InsertSanPham(txtMaSP.Text, txtTenSP.Text, txtXuatXu.Text, maLoai, maNCC, donGia, hinhAnh))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadSanPhamList();
                    ResetFields();
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
                if (!float.TryParse(txtDonGia.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out float donGia) || donGia < 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sửa lỗi: Kiểm tra SelectedValue trước khi sử dụng
                if (cbbTheLoai.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một thể loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbbNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                byte[] hinhAnh = ImageToByteArray(picHinhAnh.Image);
                string maLoai = cbbTheLoai.SelectedValue.ToString();
                string maNCC = cbbNhaCungCap.SelectedValue.ToString();

                if (SanPhamBLL.Instance.UpdateSanPham(txtMaSP.Text, txtTenSP.Text, txtXuatXu.Text, maLoai, maNCC, donGia, hinhAnh))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    LoadSanPhamList();
                    ResetFields();
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
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{txtTenSP.Text}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SanPhamBLL.Instance.DeleteSanPham(txtMaSP.Text))
                {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    LoadSanPhamList();
                    ResetFields();
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (isDataLoading) return;

            if (dgvSanPham.SelectedRows.Count > 0)
            {
                DataRowView drv = dgvSanPham.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {
                    txtMaSP.Text = drv["MaSP"].ToString();
                    txtTenSP.Text = drv["TenSP"].ToString();
                    txtXuatXu.Text = drv["XuatXu"].ToString();
                    cbbTheLoai.SelectedValue = drv["MaLoai"];
                    cbbNhaCungCap.SelectedValue = drv["MaNCC"];
                    txtDonGia.Text = string.Format("{0:N0}", drv["DonGia"]);

                    if (drv.Row["HinhAnh"] != DBNull.Value)
                    {
                        byte[] hinhAnhData = (byte[])drv.Row["HinhAnh"];
                        picHinhAnh.Image = ByteArrayToImage(hinhAnhData);
                    }
                    else
                    {
                        picHinhAnh.Image = null;
                    }
                }
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] imageData = File.ReadAllBytes(openFile.FileName);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        using (Image originalImage = Image.FromStream(ms))
                        {
                            picHinhAnh.Image = new Bitmap(originalImage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSanPhamList();
            ResetFields();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = SanPhamBLL.Instance.SearchSanPham(txtTimKiem.Text);
        }
    }
}
