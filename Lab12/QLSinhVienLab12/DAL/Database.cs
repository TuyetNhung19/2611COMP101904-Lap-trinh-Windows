using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    /// <summary>Nơi duy nhất cấu hình kết nối. Đổi máy chỉ cần sửa ServerName.</summary>
    public static class Database
    {

        public const string ServerName = @".\SQLEXPRESS";
        public const string DatabaseName = "QLSinhVienLab12";

        public static string ConnectionString =>
            $"Data Source={ServerName};Initial Catalog={DatabaseName};" +
            "Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}