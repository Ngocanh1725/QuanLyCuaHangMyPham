using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyCuaHangMyPham.DAL
{
    public class DataProvider
    {
        // !!! QUAN TRỌNG: Thay đổi chuỗi kết nối này để phù hợp với SQL Server của bạn.
        // Data Source: Tên Server SQL của bạn (có thể tìm trong SSMS).
        // Initial Catalog: Tên cơ sở dữ liệu bạn đã tạo (QuanLyCuaHangMyPham).
        // Integrated Security=True: Sử dụng xác thực Windows.
        // Nếu dùng xác thực SQL Server, chuỗi sẽ là: "Data Source=TEN_SERVER;Initial Catalog=QuanLyCuaHangMyPham;User ID=sa;Password=MATKHAUCUABAN"
        private static string connectionString = @"Data Source=ADMIN-PC.;Initial Catalog=QuanLyCuaHangMyPham;Integrated Security=True";

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider() { }

        /// <summary>
        /// Thực thi câu lệnh query và trả về một DataTable.
        /// </summary>
        /// <param name="query">Câu lệnh SQL.</param>
        /// <param name="parameters">Các tham số cho câu lệnh SQL.</param>
        /// <returns>DataTable chứa kết quả.</returns>
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// Thực thi câu lệnh không trả về kết quả (INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="query">Câu lệnh SQL.</param>
        /// <param name="parameters">Các tham số cho câu lệnh SQL.</param>
        /// <returns>Số dòng bị ảnh hưởng.</returns>
        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// Thực thi câu lệnh và trả về giá trị của cột đầu tiên, dòng đầu tiên.
        /// </summary>
        /// <param name="query">Câu lệnh SQL.</param>
        /// <param name="parameters">Các tham số cho câu lệnh SQL.</param>
        /// <returns>Đối tượng chứa kết quả.</returns>
        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
