using MySql.Data.MySqlClient;
using QuanLyThuVien.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Repositories
{
    public class ChiTietPhieuMuonRepository
    {
        private readonly DbConnection _db;

        public ChiTietPhieuMuonRepository()
        {
            _db = new DbConnection();
        }

        public List<ChiTietPhieuMuonDTO> GetAll()
        {
            var list = new List<ChiTietPhieuMuonDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT MaSach, MaPhieuMuon, SoLuong
                               FROM ChiTietMuonSach";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChiTietPhieuMuonDTO(
                            reader.GetInt32("MaSach"),
                            reader.GetInt32("MaPhieuMuon"),
                            reader.GetInt32("SoLuong")
                        ));
                    }
                }
            }

            return list;
        }

        public List<ChiTietPhieuMuonDTO> GetByPhieuMuon(int maPhieuMuon)
        {
            var list = new List<ChiTietPhieuMuonDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT MaSach, MaPhieuMuon, SoLuong
                               FROM ChiTietMuonSach
                               WHERE MaPhieuMuon = @maPM";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maPM", maPhieuMuon);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ChiTietPhieuMuonDTO(
                                reader.GetInt32("MaSach"),
                                reader.GetInt32("MaPhieuMuon"),
                                reader.GetInt32("SoLuong")
                            ));
                        }
                    }
                }
            }
            return list;
        }



        public bool Add(ChiTietPhieuMuonDTO ct)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO ChiTietMuonSach (MaSach, MaPhieuMuon, SoLuong)
                               VALUES (@maSach, @maPM, @soLuong)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maSach", ct.MaSach);
                    cmd.Parameters.AddWithValue("@maPM", ct.MaPhieuMuon);
                    cmd.Parameters.AddWithValue("@soLuong", ct.SoLuong);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(ChiTietPhieuMuonDTO ct)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE ChiTietMuonSach
                               SET SoLuong = @soLuong
                               WHERE MaSach = @maSach AND MaPhieuMuon = @maPM";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@soLuong", ct.SoLuong);
                    cmd.Parameters.AddWithValue("@maSach", ct.MaSach);
                    cmd.Parameters.AddWithValue("@maPM", ct.MaPhieuMuon);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int maSach, int maPhieuMuon)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"DELETE FROM ChiTietMuonSach
                               WHERE MaSach = @maSach AND MaPhieuMuon = @maPM";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maSach", maSach);
                    cmd.Parameters.AddWithValue("@maPM", maPhieuMuon);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
