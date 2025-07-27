using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions; // Thêm using cho Regex
using System.Windows.Forms; // For MessageBox

namespace QuanLyCuaHangMyPham.DAL
{
    public class DataProvider
    {
        private static string connectionString = @"Data Source=.;Initial Catalog=QuanLyCuaHangMyPham;Integrated Security=True";

        public string ConnectionString
        {
            get { return connectionString; }
        }

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider() { }

        // Tối ưu: Thêm try-catch để xử lý lỗi kết nối tập trung
        private DataTable ExecuteQueryInternal(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameters != null)
                    {
                        // Sửa lỗi: Sử dụng Regex để tìm tham số một cách chính xác
                        var paramNames = Regex.Matches(query, @"@\w+")
                                              .Cast<Match>()
                                              .Select(m => m.Value)
                                              .Distinct()
                                              .ToList();

                        for (int i = 0; i < paramNames.Count; i++)
                        {
                            if (i < parameters.Length)
                            {
                                command.Parameters.AddWithValue(paramNames[i], parameters[i]);
                            }
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return data;
        }

        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            return ExecuteQueryInternal(query, parameters);
        }

        // Tối ưu: Thêm try-catch để xử lý lỗi thực thi tập trung
        private int ExecuteNonQueryInternal(string query, object[] parameters = null)
        {
            int data = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameters != null)
                    {
                        // Sửa lỗi: Sử dụng Regex để tìm tham số một cách chính xác
                        var paramNames = Regex.Matches(query, @"@\w+")
                                              .Cast<Match>()
                                              .Select(m => m.Value)
                                              .Distinct()
                                              .ToList();

                        for (int i = 0; i < paramNames.Count; i++)
                        {
                            if (i < parameters.Length)
                            {
                                command.Parameters.AddWithValue(paramNames[i], parameters[i]);
                            }
                        }
                    }

                    data = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // Ném lại ngoại lệ để tầng BLL có thể bắt và xử lý lỗi nghiệp vụ
                // Ví dụ: Lỗi trùng khóa chính
                throw ex;
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            return ExecuteNonQueryInternal(query, parameters);
        }

        // Tối ưu: Thêm try-catch
        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameters != null)
                    {
                        // Sửa lỗi: Sử dụng Regex để tìm tham số một cách chính xác
                        var paramNames = Regex.Matches(query, @"@\w+")
                                              .Cast<Match>()
                                              .Select(m => m.Value)
                                              .Distinct()
                                              .ToList();

                        for (int i = 0; i < paramNames.Count; i++)
                        {
                            if (i < parameters.Length)
                            {
                                command.Parameters.AddWithValue(paramNames[i], parameters[i]);
                            }
                        }
                    }

                    data = command.ExecuteScalar();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return data;
        }
    }
}
