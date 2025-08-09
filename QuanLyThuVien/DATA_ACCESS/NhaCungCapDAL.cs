using MySql.Data.MySqlClient;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyThuVien.DATA_ACCESS
{
    public class NhaCungCapDAL
    {
        private readonly DbConnection db;

        public NhaCungCapDAL()
        {
            db = new DbConnection();
        }

        public List<NhaCungCapDTO> GetAll()
        {
            var list = new List<NhaCungCapDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM NhaCungCap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhaCungCapDTO
                        {
                            MaNhaCungCap = Convert.ToInt32(reader["MaNhaCungCap"]),
                            TenNhaCungCap = reader["TenNhaCungCap"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Gmail = reader["Gmail"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(NhaCungCapDTO ncc)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, SoDienThoai, Gmail)
                                 VALUES (@TenNhaCungCap, @DiaChi, @SoDienThoai, @Gmail)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenNhaCungCap", ncc.TenNhaCungCap);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", ncc.SoDienThoai);
                cmd.Parameters.AddWithValue("@Gmail", ncc.Gmail);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(NhaCungCapDTO ncc)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"UPDATE NhaCungCap 
                                 SET TenNhaCungCap = @TenNhaCungCap, 
                                     DiaChi = @DiaChi, 
                                     SoDienThoai = @SoDienThoai, 
                                     Gmail = @Gmail
                                 WHERE MaNhaCungCap = @MaNhaCungCap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenNhaCungCap", ncc.TenNhaCungCap);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", ncc.SoDienThoai);
                cmd.Parameters.AddWithValue("@Gmail", ncc.Gmail);
                cmd.Parameters.AddWithValue("@MaNhaCungCap", ncc.MaNhaCungCap);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maNCC)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "DELETE FROM NhaCungCap WHERE MaNhaCungCap = @MaNhaCungCap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhaCungCap", maNCC);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public NhaCungCapDTO GetById(int maNCC)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM NhaCungCap WHERE MaNhaCungCap = @MaNhaCungCap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhaCungCap", maNCC);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NhaCungCapDTO
                        {
                            MaNhaCungCap = Convert.ToInt32(reader["MaNhaCungCap"]),
                            TenNhaCungCap = reader["TenNhaCungCap"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Gmail = reader["Gmail"].ToString()
                        };
                    }
                    return null;
                }
            }
        }

        public List<NhaCungCapDTO> Search(string keyword)
        {
            var list = new List<NhaCungCapDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"SELECT * FROM NhaCungCap 
                                 WHERE TenNhaCungCap LIKE @keyword 
                                    OR DiaChi LIKE @keyword 
                                    OR SoDienThoai LIKE @keyword 
                                    OR Gmail LIKE @keyword";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhaCungCapDTO
                        {
                            MaNhaCungCap = Convert.ToInt32(reader["MaNhaCungCap"]),
                            TenNhaCungCap = reader["TenNhaCungCap"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Gmail = reader["Gmail"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
