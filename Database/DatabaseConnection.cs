using System.Data.SqlClient;

namespace QuanLyCuaHangMyPham
{
    public class DatabaseConnection
    {
        // Thay đổi 'YOUR_SERVER_NAME' thành tên SQL Server của bạn.
        // Ví dụ: "Data Source=DESKTOP-12345\\SQLEXPRESS;Initial Catalog=QL_MyPham;Integrated Security=True"
        private const string connectionString = "Data Source=ADMIN-PC;Initial Catalog=QL_MyPham;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}