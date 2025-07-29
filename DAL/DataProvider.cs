using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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

        public DataTable ExecuteQuery(string query, object[] parameters = null)
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
                        var paramNames = Regex.Matches(query, @"@\w+").Cast<Match>().Select(m => m.Value).Distinct().ToList();
                        for (int i = 0; i < paramNames.Count; i++)
                        {
                            if (i < parameters.Length)
                            {
                                command.Parameters.AddWithValue(paramNames[i], parameters[i] ?? DBNull.Value);
                            }
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameters = null)
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
                        var paramNames = Regex.Matches(query, @"@\w+").Cast<Match>().Select(m => m.Value).Distinct().ToList();
                        for (int i = 0; i < paramNames.Count; i++)
                        {
                            if (i < parameters.Length)
                            {
                                command.Parameters.AddWithValue(paramNames[i], parameters[i] ?? DBNull.Value);
                            }
                        }
                    }

                    data = command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return data;
        }

        // Overload mới để xử lý cả object[] và SqlParameter[]
        public int ExecuteNonQuery(string query, object[] objectParameters, SqlParameter[] sqlParameters)
        {
            int data = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (objectParameters != null)
                    {
                        var paramNames = Regex.Matches(query, @"@\w+").Cast<Match>().Select(m => m.Value).Distinct().ToList();
                        int objectParamIndex = 0;
                        foreach (var name in paramNames)
                        {
                            if (sqlParameters != null && sqlParameters.Any(p => p.ParameterName == name))
                            {
                                continue;
                            }
                            if (objectParamIndex < objectParameters.Length)
                            {
                                command.Parameters.AddWithValue(name, objectParameters[objectParamIndex] ?? DBNull.Value);
                                objectParamIndex++;
                            }
                        }
                    }

                    if (sqlParameters != null)
                    {
                        command.Parameters.AddRange(sqlParameters);
                    }

                    data = command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return data;
        }


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
                        var paramNames = Regex.Matches(query, @"@\w+").Cast<Match>().Select(m => m.Value).Distinct().ToList();
                        for (int i = 0; i < paramNames.Count; i++)
                        {
                            if (i < parameters.Length)
                            {
                                command.Parameters.AddWithValue(paramNames[i], parameters[i] ?? DBNull.Value);
                            }
                        }
                    }

                    data = command.ExecuteScalar();
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
