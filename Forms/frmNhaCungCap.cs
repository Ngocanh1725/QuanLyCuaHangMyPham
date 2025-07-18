using QuanLyCuaHangMyPham.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq; //Thêm thư viện Linq để sử dụng hàm .Any(), rất quan trọng trong việc tìm kiếm
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMyPham
{
    public partial class frmNhaCungCap : Form
    {
        //Khai báo danh sách để lưu trữ các nhà cung cấp.
        //Đây là nguồn dữ liệu (data source) cho form.
        List<NhaCungCap> listNCC = new List<NhaCungCap>();

        // Định nghĩa chuỗi placeholder
        private const string SearchPlaceholder = "Nhập mã hoặc tên nhà cung cấp..."; //Chúng ta định nghĩa một hằng số SearchPlaceholder để chứa chuỗi văn bản mờ. Việc sử dụng hằng số giúp dễ dàng quản lý và tránh lỗi gõ sai.



        public frmNhaCungCap()
        {
            InitializeComponent();
            // Gán các sự kiện cho TextBox tìm kiếm ngay sau khi khởi tạo component
            txtTimKiem.Enter += new EventHandler(txtTimKiem_Enter);
            txtTimKiem.Leave += new EventHandler(txtTimKiem_Leave);
        }




        //Thêm sự kiện Form_Load để thiết lập trạng thái ban đầu
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            //Thiết lập trạng thái ban đầu cho form
            ResetFields(); //Là một phương thức phụ trợ quan trọng. Nó gom tất cả các hành động để đưa form về trạng thái ban đầu vào một nơi, giúp tránh lặp lại code.
            
            // Thêm một vài nhà cung cấp mẫu để kiểm tra chức năng tìm kiếm
            listNCC.Add(new NhaCungCap { MaNCC = "NCC001", TenNCC = "Công ty A", SDTLH = "0901234567", Email = "a@example.com" });
            listNCC.Add(new NhaCungCap { MaNCC = "NCC002", TenNCC = "Công ty B", SDTLH = "0907654321", Email = "b@example.com" });
            listNCC.Add(new NhaCungCap { MaNCC = "NCC003", TenNCC = "Nhà cung cấp C", SDTLH = "0912345678", Email = "c@example.com" });
            LoadDataGridView();

            // Thiết lập placeholder khi form load
            SetSearchPlaceholder();
        }

        // Phương thức này có trách nhiệm duy nhất là lấy dữ liệu từ các control trên form
        //tạo ra một đối tượng NhaCungCap
        //Tạo hàm lấy dữ liệu
        private NhaCungCap ObjectNCC() //Lấy thông tin Nhà cung cấp từ Form
        {
            //Kiểm tra xem người dùng đã nhập đủ thông tin chưa.
            if (string.IsNullOrWhiteSpace(txtMaNhaCC.Text) ||
                string.IsNullOrWhiteSpace(txtTenNhaCC.Text) ||
                string.IsNullOrWhiteSpace(txtHotline.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                return null; //Trả về null nếu thông tin không đầy đủ
            }
            //Tạo và trả về một đối tượng NhaCungCap mới với dữ liệu đã được làm sạch (loại bỏ khoảng trắng thừa).
            return new NhaCungCap
            {
                MaNCC = txtMaNhaCC.Text.Trim(),
                TenNCC = txtTenNhaCC.Text.Trim(),
                SDTLH = txtHotline.Text.Trim(), //Model dùng SDTLH
                Email = txtEmail.Text.Trim(),
            };
        }

        // Phương thức này có trách nhiệm cập nhật giao diện (DataGridView) từ danh sách dữ liệu.
        private void LoadDataGridView()
        {
            dgvNhaCungCap.DataSource = null; //xoá datasource cũ
            dgvNhaCungCap.DataSource = listNCC; //Gán datasource mới
            dgvNhaCungCap.Refresh(); //Cập nhật lại lười
        }

        // Phương thức để reset các control trên form
        private void ResetFields()
        {
            //Xoá sạch nội dung trong các TextBox
            txtMaNhaCC.Clear();
            txtTenNhaCC.Clear();
            txtHotline.Clear();
            txtEmail.Clear();
            // Clear the search textbox and reset placeholder
            SetSearchPlaceholder();


            // Cho phép nhập Mã NCC khi thêm mới
            txtMaNhaCC.ReadOnly = false;

            // Thiết lập trạng thái các nút, kích hoạt nút Thêm, vô hiệu hoá nút Sửa, Xoá. Vì trạng thái reset là để chuân bị cho việc "Thêm mới"
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Bỏ chọn trên DataGridView
            dgvNhaCungCap.ClearSelection();
            //Đặt con trỏ chuột vào ô nhập liệu đầu tiên, sẵn sàng để nhập
            txtMaNhaCC.Focus();
        }

        //  Sự kiện khi người dùng click vào một ô trong DataGridView
        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Kiểm tra xem người dùng có click vào một hàng dữ liệu hợp lệ không
            // e.RowIndex >= 0 để đảm bảo người dùng không click vào tiêu đề cột
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của cả hàng mà người dùng vừa click
                DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];

                
                // Hiển thị dữ liệu từ hàng đó lên các TextBox
                //row.Cells["TenCot"].Value.ToString()
                txtMaNhaCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtTenNhaCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtHotline.Text = row.Cells["SDTLH"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();

                //Rất quan trọng:Khoá ô Mã NCC lại
                // Không cho phép sửa Mã NCC (khóa chính)
                txtMaNhaCC.ReadOnly = true;

                // Cập nhật trạng thái các nút
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        
        //Xử lý sự kiện khi người dùng nhấn nút "Thêm"
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //1.Lấy thông tin từ form và tạo đối tượng MỘT LẦN DUY NHẤT.
                NhaCungCap nccMoi = ObjectNCC();

                //2.Kiểm tra dữ liệu đầu vào.
                if (nccMoi == null) //Bỏ cặp dấu () sau nccMoi, biến này là một đối tượng, không phải hàm
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu của một nhà cung cấp!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; //Dừng thực thi nếu dữ liệu không hợp lệ.
                }

                //3.Kiểm tra xem mã nhà cung cấp đã tốn tại hay chưa.
                //Sử dụng LINQ .Any để kiểm tra hiệu quả hơn.
                if (listNCC.Any(ncc => ncc.MaNCC == nccMoi.MaNCC))
                {
                    MessageBox.Show("Mã nhà cung cấp này đã tồn tại","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    //4.Nếu mọi thứ hợp lệ, thêm nhà cung cấp mới vào danh sách.
                    listNCC.Add(nccMoi);

                    //5.Cập nhật lại DataGridView để hiển thị dữ liệu mới.
                    LoadDataGridView();

                    MessageBox.Show("Thêm nhà cung cấp thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFields();
                }
            }
            catch (Exception ex)
            {
                //Bắt các lỗi không lường trước được.
                MessageBox.Show("Có lỗi xảy ra trong quá trình thêm: " + ex.Message);
            }
        }
        //Sự kiện cho nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {   
            //Dùng LINQ.FirstOrDefault() để tìm đối tượng đầu tiên trong listNCC thoả mãn điều kiện MaNCC của nó bằng với mã trong TextBox
            //Tìm nhà cung cấp cho danh sách dựa vào Mã NCC đang hiện thỉ (không cho sửa)
            NhaCungCap nccCanSua = listNCC.FirstOrDefault(ncc => ncc.MaNCC == txtMaNhaCC.Text);

            //Nếu tìm thấy đối tượng (kp null)
            if (nccCanSua != null)
            {
                //Lấy các giá trị mới từ TextBox
                string tenMoi = txtTenNhaCC.Text.Trim();
                string hotlineMoi = txtHotline.Text.Trim();
                string emailMoi = txtEmail.Text.Trim();

                //Kiểm tra để đảm bảo người dùng không xoá trống thông tin
                if (string.IsNullOrEmpty(tenMoi) || string.IsNullOrEmpty(hotlineMoi) || string.IsNullOrEmpty(emailMoi))
                {
                    MessageBox.Show("Vui lòng không để trống thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Cập nhật thông tin đối tượng đã tìm thấy
                nccCanSua.TenNCC = tenMoi;
                nccCanSua.SDTLH = hotlineMoi;
                nccCanSua.Email = emailMoi;

                LoadDataGridView(); //Tải lại lưới để hiển thị dữ liệu đã cập nhật, vì listNCC đã thay đổi
                MessageBox.Show("Cập nhật thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFields(); //Reset form về trạng thái ban đầu để chuẩn bị cho lần tiếp theo.
            }
        }
        //Sự kiện cho nút Xoá
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Tìm nhà cung cấp cần xoá
            NhaCungCap nccCanXoa = listNCC.FirstOrDefault(ncc => ncc.MaNCC == txtMaNhaCC.Text);

            if (nccCanXoa != null)
            {
                //Hiển thị hộp thoại xác nhận trước khi xoá. Đây là bước quan trọng, để tránh người dùng vô tình xoá mất dữ liệu.
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nhà cung cấp này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                //Nếu người dùng nhấn "Yes"
                if (result == DialogResult.Yes)
                {
                    //Dùng phương thức .Remove() của List<> đẻ xoá đối tượng khỏi danh sách
                    listNCC.Remove(nccCanXoa); 
                    LoadDataGridView(); //Tải lại lưới
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFields() ;//Reset form
                }
                //Nếu người dùng nhấn No, không làm gì cả.
            }
        }
        //Sự kiện cho nút Làm Mới
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Lấy từ khoá tìm kiếm từ ô nhập liệu và loại bỏ khoảng trắng thừa
            //Đảm bảo không lấy placeholder làm từ khoá tìm kiếm thực tế
            string tuKhoa = txtTimKiem.Text.Trim();

            // Nếu text hiện tại là placeholder, coi như không có từ khóa nào được nhập
            if (tuKhoa.Equals(SearchPlaceholder, StringComparison.OrdinalIgnoreCase))
            {
                tuKhoa = string.Empty;
            }

            //Kiểm tra xem từ khoá có rỗng không?
            if (string.IsNullOrEmpty(tuKhoa) )
            {
                //Nếu từ khoá rỗng, hiển thị toàn bộ danh sách nhà cung cấp
                LoadDataGridView();
                MessageBox.Show("Vui lòng nhập từ khoá tìm kiếm!","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return; 
            }
            //Sử dụng LINQ để lọc danh sách nhà cung cấp
            // Tìm kiếm theo MaNCC hoặc TenNCC, không phân biệt hoa thường
            List<NhaCungCap> ketQuaTimKiem = listNCC.Where(ncc =>
                ncc.MaNCC.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                ncc.TenNCC.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();

            // Cập nhật DataGridView với kết quả tìm kiếm
            dgvNhaCungCap.DataSource = null;
            dgvNhaCungCap.DataSource = ketQuaTimKiem;
            dgvNhaCungCap.Refresh();

            // Hiển thị thông báo nếu không tìm thấy kết quả nào
            if (ketQuaTimKiem.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp nào phù hợp với từ khóa: '" + tuKhoa + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Tìm thấy {ketQuaTimKiem.Count} nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Phương thức thiết lập placeholder ban đầu
        private void SetSearchPlaceholder()
        {
            txtTimKiem.Text = SearchPlaceholder;
            txtTimKiem.ForeColor = System.Drawing.Color.LightGray; // Màu chữ mờ
        }

        // Sự kiện khi TextBox tìm kiếm được focus (người dùng click vào)
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == SearchPlaceholder)
            {
                txtTimKiem.Text = ""; // Xóa placeholder
                txtTimKiem.ForeColor = System.Drawing.SystemColors.WindowText; // Đặt lại màu chữ bình thường
            }
        }

        // Sự kiện khi TextBox tìm kiếm mất focus (người dùng click ra ngoài)
        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                SetSearchPlaceholder(); // Đặt lại placeholder nếu trống
            }
        }
    }



}
