using MySql.Data.MySqlClient;
using QuanLyThuVien.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Repositories
{
    public class QuyDinhRepository
    {
        private readonly DbConnection _db;

        public QuyDinhRepository()
        {
            _db = new DbConnection();
        }


        public QuyDinhDTO GetById(int id)
        {
            QuyDinhDTO quyDinh = null;

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT MaQuyDinh, SoNgayMuonToiDa, SoSachMuonToiDa FROM QuyDinh WHERE MaQuyDinh = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            quyDinh = new QuyDinhDTO(
                                reader.GetInt32("MaQuyDinh"),
                                reader.GetInt32("SoNgayMuonToiDa"),
                                reader.GetInt32("SoSachMuonToiDa")
                            );
                        }
                    }
                }
            }

            return quyDinh;
        }

        public bool Update(QuyDinhDTO quyDinh)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE QuyDinh SET SoNgayMuonToiDa = @soNgay, SoSachMuonToiDa = @soSach WHERE MaQuyDinh = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@soNgay", quyDinh.SoNgayMuonToiDa);
                    cmd.Parameters.AddWithValue("@soSach", quyDinh.SoSachMuonToiDa);
                    cmd.Parameters.AddWithValue("@id", quyDinh.MaQuyDinh);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        
    }
}
