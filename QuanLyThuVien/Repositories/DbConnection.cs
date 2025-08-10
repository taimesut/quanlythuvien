using MySql.Data.MySqlClient;

namespace QuanLyThuVien.Repositories
{
    public class DbConnection
    {
        private readonly string connectionString;

        public DbConnection()
        {
            connectionString = "Server=localhost;Database=thu_vien;Uid=root;Pwd=123456;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
