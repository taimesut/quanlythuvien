using MySql.Data.MySqlClient;
using QuanLyThuVien.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Repositories
{
    public class SachRepository
    {
        private readonly DbConnection _db;

        public SachRepository()
        {
            _db = new DbConnection();
        }

        public List<SachDTO> GetAll()
        {
            var list = new List<SachDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT MaSach, MaTheLoai, NhaXuatBan, TacGia, TenSach, NamXuatBan, SoLuong FROM Sach";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SachDTO(
                            reader.GetInt32("MaSach"),
                            reader.GetInt32("MaTheLoai"),
                            reader.GetString("NhaXuatBan"),
                            reader.GetString("TacGia"),
                            reader.GetString("TenSach"),
                            reader.GetInt32("NamXuatBan"),
                            reader.GetInt32("SoLuong")
                        ));
                    }
                }
            }

            return list;
        }

        public SachDTO GetById(int id)
        {
            SachDTO sach = null;

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT MaSach, MaTheLoai, NhaXuatBan, TacGia, TenSach, NamXuatBan, SoLuong FROM Sach WHERE MaSach = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sach = new SachDTO(
                                reader.GetInt32("MaSach"),
                                reader.GetInt32("MaTheLoai"),
                                reader.GetString("NhaXuatBan"),
                                reader.GetString("TacGia"),
                                reader.GetString("TenSach"),
                                reader.GetInt32("NamXuatBan"),
                                reader.GetInt32("SoLuong")
                            );
                        }
                    }
                }
            }

            return sach;
        }

        public bool Add(SachDTO sach)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO Sach (MaTheLoai, NhaXuatBan, TacGia, TenSach, NamXuatBan, SoLuong)
                    VALUES (@maTheLoai, @nxb, @tacGia, @tenSach, @namXB, @soLuong)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maTheLoai", sach.MaTheLoai);
                    cmd.Parameters.AddWithValue("@nxb", sach.NhaXuatBan);
                    cmd.Parameters.AddWithValue("@tacGia", sach.TacGia);
                    cmd.Parameters.AddWithValue("@tenSach", sach.TenSach);
                    cmd.Parameters.AddWithValue("@namXB", sach.NamXuatBan);
                    cmd.Parameters.AddWithValue("@soLuong", sach.SoLuong);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(SachDTO sach)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    UPDATE Sach
                    SET MaTheLoai = @maTheLoai,
                        NhaXuatBan = @nxb,
                        TacGia = @tacGia,
                        TenSach = @tenSach,
                        NamXuatBan = @namXB,
                        SoLuong = @soLuong
                    WHERE MaSach = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maTheLoai", sach.MaTheLoai);
                    cmd.Parameters.AddWithValue("@nxb", sach.NhaXuatBan);
                    cmd.Parameters.AddWithValue("@tacGia", sach.TacGia);
                    cmd.Parameters.AddWithValue("@tenSach", sach.TenSach);
                    cmd.Parameters.AddWithValue("@namXB", sach.NamXuatBan);
                    cmd.Parameters.AddWithValue("@soLuong", sach.SoLuong);
                    cmd.Parameters.AddWithValue("@id", sach.MaSach);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Sach WHERE MaSach = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
