using MySql.Data.MySqlClient;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyThuVien.DATA_ACCESS
{
    public class SachDAL
    {
        private readonly DbConnection db;

        public SachDAL()
        {
            db = new DbConnection();
        }

        public List<SachDTO> GetAll()
        {
            var list = new List<SachDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM Sach";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SachDTO
                        {
                            MaSach = Convert.ToInt32(reader["MaSach"]),
                            TenSach = reader["TenSach"].ToString(),
                            MaTacGia = Convert.ToInt32(reader["MaTacGia"]),
                            MaTheLoai = Convert.ToInt32(reader["MaTheLoai"]),
                            MaNhaXuatBan = Convert.ToInt32(reader["MaNhaXuatBan"]),
                            MaNhaCungCap = Convert.ToInt32(reader["MaNhaCungCap"]),
                            NamXuatBan = Convert.ToInt32(reader["NamXuatBan"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"])
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(SachDTO s)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO Sach 
                                (TenSach, MaTacGia, MaTheLoai, MaNhaXuatBan, MaNhaCungCap, NamXuatBan, SoLuong)
                                 VALUES 
                                (@TenSach, @MaTacGia, @MaTheLoai, @MaNhaXuatBan, @MaNhaCungCap, @NamXuatBan, @SoLuong)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSach", s.TenSach);
                cmd.Parameters.AddWithValue("@MaTacGia", s.MaTacGia);
                cmd.Parameters.AddWithValue("@MaTheLoai", s.MaTheLoai);
                cmd.Parameters.AddWithValue("@MaNhaXuatBan", s.MaNhaXuatBan);
                cmd.Parameters.AddWithValue("@MaNhaCungCap", s.MaNhaCungCap);
                cmd.Parameters.AddWithValue("@NamXuatBan", s.NamXuatBan);
                cmd.Parameters.AddWithValue("@SoLuong", s.SoLuong);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(SachDTO s)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"UPDATE Sach 
                                 SET TenSach = @TenSach, 
                                     MaTacGia = @MaTacGia, 
                                     MaTheLoai = @MaTheLoai, 
                                     MaNhaXuatBan = @MaNhaXuatBan, 
                                     MaNhaCungCap = @MaNhaCungCap,
                                     NamXuatBan = @NamXuatBan, 
                                     SoLuong = @SoLuong
                                 WHERE MaSach = @MaSach";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSach", s.TenSach);
                cmd.Parameters.AddWithValue("@MaTacGia", s.MaTacGia);
                cmd.Parameters.AddWithValue("@MaTheLoai", s.MaTheLoai);
                cmd.Parameters.AddWithValue("@MaNhaXuatBan", s.MaNhaXuatBan);
                cmd.Parameters.AddWithValue("@MaNhaCungCap", s.MaNhaCungCap);
                cmd.Parameters.AddWithValue("@NamXuatBan", s.NamXuatBan);
                cmd.Parameters.AddWithValue("@SoLuong", s.SoLuong);
                cmd.Parameters.AddWithValue("@MaSach", s.MaSach);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maSach)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "DELETE FROM Sach WHERE MaSach = @MaSach";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public SachDTO GetById(int maSach)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM Sach WHERE MaSach = @MaSach";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new SachDTO
                        {
                            MaSach = Convert.ToInt32(reader["MaSach"]),
                            TenSach = reader["TenSach"].ToString(),
                            MaTacGia = Convert.ToInt32(reader["MaTacGia"]),
                            MaTheLoai = Convert.ToInt32(reader["MaTheLoai"]),
                            MaNhaXuatBan = Convert.ToInt32(reader["MaNhaXuatBan"]),
                            MaNhaCungCap = Convert.ToInt32(reader["MaNhaCungCap"]),
                            NamXuatBan = Convert.ToInt32(reader["NamXuatBan"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"])
                        };
                    }
                    return null;
                }
            }
        }

        public List<SachDTO> Search(string keyword)
        {
            var list = new List<SachDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"SELECT * FROM Sach 
                                 WHERE TenSach LIKE @keyword";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SachDTO
                        {
                            MaSach = Convert.ToInt32(reader["MaSach"]),
                            TenSach = reader["TenSach"].ToString(),
                            MaTacGia = Convert.ToInt32(reader["MaTacGia"]),
                            MaTheLoai = Convert.ToInt32(reader["MaTheLoai"]),
                            MaNhaXuatBan = Convert.ToInt32(reader["MaNhaXuatBan"]),
                            MaNhaCungCap = Convert.ToInt32(reader["MaNhaCungCap"]),
                            NamXuatBan = Convert.ToInt32(reader["NamXuatBan"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"])
                        });
                    }
                }
            }
            return list;
        }
    }
}
