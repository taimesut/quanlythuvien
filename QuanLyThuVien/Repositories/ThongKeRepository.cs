using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace QuanLyThuVien.Repositories
{
    public class ThongKeRepository
    {
        private readonly DbConnection _db;

        public ThongKeRepository()
        {
            _db = new DbConnection();
        }

        public int GetSoSachTonKho()
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT IFNULL(SUM(SoLuong), 0) FROM sach";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int GetSoSachDaMuon()
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT IFNULL(SUM(ct.SoLuong), 0)
                    FROM chitietmuonsach ct
                    JOIN phieumuon pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
                    WHERE pm.TrangThai = 0"; // 0 = chưa trả
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int GetSoSachQuaHan()
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT IFNULL(SUM(ct.SoLuong), 0)
                    FROM chitietmuonsach ct
                    JOIN phieumuon pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
                    WHERE pm.TrangThai = 0 AND pm.HanTra < CURDATE()";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int GetSoDocGia()
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM docgia";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int GetSoNhanVien()
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM nhanvien";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Thống kê theo thể loại (TenTheLoai, SoLuong)
        public List<(string TheLoai, int SoLuong)> GetThongKeTheoTheLoai()
        {
            var list = new List<(string, int)>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT tl.TenTheLoai, IFNULL(SUM(s.SoLuong), 0) AS SoLuong
                    FROM theloai tl
                    LEFT JOIN sach s ON s.MaTheLoai = tl.MaTheLoai
                    GROUP BY tl.MaTheLoai, tl.TenTheLoai
                    ORDER BY SoLuong DESC";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ten = reader.IsDBNull(0) ? "(Unknown)" : reader.GetString(0);
                        int so = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        list.Add((ten, so));
                    }
                }
            }
            return list;
        }

        // Top N sách được mượn nhiều nhất (TenSach, TongSoLuong)
        public List<(string TenSach, int Tong)> GetTopSachMuon(int topN = 10)
        {
            var list = new List<(string, int)>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT s.TenSach, IFNULL(SUM(ct.SoLuong),0) AS Tong
                    FROM chitietmuonsach ct
                    JOIN sach s ON ct.MaSach = s.MaSach
                    GROUP BY s.MaSach, s.TenSach
                    ORDER BY Tong DESC
                    LIMIT @topN";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@topN", topN);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add((reader.GetString(0), reader.GetInt32(1)));
                        }
                    }
                }
            }
            return list;
        }

        // Sách chưa từng được mượn
        public List<(int MaSach, string TenSach)> GetSachChuaMuon()
        {
            var list = new List<(int, string)>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT s.MaSach, s.TenSach
                    FROM sach s
                    LEFT JOIN chitietmuonsach ct ON s.MaSach = ct.MaSach
                    WHERE ct.MaSach IS NULL";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add((reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
            return list;
        }
    }
}
