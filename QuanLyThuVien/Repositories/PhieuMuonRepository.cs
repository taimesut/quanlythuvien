using MySql.Data.MySqlClient;
using QuanLyThuVien.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Repositories
{
    public class PhieuMuonRepository
    {
        private readonly DbConnection _db;

        public PhieuMuonRepository()
        {
            _db = new DbConnection();
        }

        public List<PhieuMuonDTO> GetAll()
        {
            var list = new List<PhieuMuonDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT MaPhieuMuon, MaNhanVien, MaDocGia, NgayMuon, HanTra, TrangThai 
                               FROM PhieuMuon";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhieuMuonDTO(
                            reader["MaPhieuMuon"].ToString(),
                            reader["MaNhanVien"].ToString(),
                            reader["MaDocGia"].ToString(),
                            reader.GetDateTime("NgayMuon"),
                            reader.GetDateTime("HanTra"),
                            reader.GetInt32("TrangThai")
                        ));
                    }
                }
            }

            return list;
        }

        public PhieuMuonDTO GetById(string id)
        {
            PhieuMuonDTO phieuMuon = null;

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT MaPhieuMuon, MaNhanVien, MaDocGia, NgayMuon, HanTra, TrangThai
                               FROM PhieuMuon
                               WHERE MaPhieuMuon = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            phieuMuon = new PhieuMuonDTO(
                                reader["MaPhieuMuon"].ToString(),
                                reader["MaNhanVien"].ToString(),
                                reader["MaDocGia"].ToString(),
                                reader.GetDateTime("NgayMuon"),
                                reader.GetDateTime("HanTra"),
                                reader.GetInt32("TrangThai")
                            );
                        }
                    }
                }
            }

            return phieuMuon;
        }

        public bool Add(PhieuMuonDTO pm)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO PhieuMuon (MaNhanVien, MaDocGia, NgayMuon, HanTra, TrangThai)
                               VALUES (@manv, @madg, @ngayMuon, @hanTra, @trangThai)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@manv", pm.MaNhanVien);
                    cmd.Parameters.AddWithValue("@madg", pm.MaDocGia);
                    cmd.Parameters.AddWithValue("@ngayMuon", pm.NgayMuon);
                    cmd.Parameters.AddWithValue("@hanTra", pm.HanTra);
                    cmd.Parameters.AddWithValue("@trangThai", pm.TrangThai);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(PhieuMuonDTO pm)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE PhieuMuon 
                               SET MaNhanVien = @manv,
                                   MaDocGia = @madg,
                                   NgayMuon = @ngayMuon,
                                   HanTra = @hanTra,
                                   TrangThai = @trangThai
                               WHERE MaPhieuMuon = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@manv", pm.MaNhanVien);
                    cmd.Parameters.AddWithValue("@madg", pm.MaDocGia);
                    cmd.Parameters.AddWithValue("@ngayMuon", pm.NgayMuon);
                    cmd.Parameters.AddWithValue("@hanTra", pm.HanTra);
                    cmd.Parameters.AddWithValue("@trangThai", pm.TrangThai);
                    cmd.Parameters.AddWithValue("@id", pm.MaPhieuMuon);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(string id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM PhieuMuon WHERE MaPhieuMuon = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<PhieuMuonDTO> GetByTrangThai(int trangThai)
        {
            var list = new List<PhieuMuonDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT MaPhieuMuon, MaNhanVien, MaDocGia, NgayMuon, HanTra, TrangThai 
                               FROM PhieuMuon
                               WHERE TrangThai = @tt";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tt", trangThai);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PhieuMuonDTO(
                                reader["MaPhieuMuon"].ToString(),
                                reader["MaNhanVien"].ToString(),
                                reader["MaDocGia"].ToString(),
                                reader.GetDateTime("NgayMuon"),
                                reader.GetDateTime("HanTra"),
                                reader.GetInt32("TrangThai")
                            ));
                        }
                    }
                }
            }

            return list;
        }
    }
}
