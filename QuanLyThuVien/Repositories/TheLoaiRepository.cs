using MySql.Data.MySqlClient;
using QuanLyThuVien.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Repositories
{
    public class TheLoaiRepository
    {
        private readonly DbConnection _db;

        public TheLoaiRepository()
        {
            _db = new DbConnection();
        }

        public List<TheLoaiDTO> GetAll()
        {
            var list = new List<TheLoaiDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT MaTheLoai, TenTheLoai FROM TheLoai";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TheLoaiDTO(
                            reader.GetInt32("MaTheLoai"),
                            reader.GetString("TenTheLoai")
                        ));
                    }
                }
            }

            return list;
        }

        public TheLoaiDTO GetById(int id)
        {
            TheLoaiDTO theLoai = null;

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT MaTheLoai, TenTheLoai FROM TheLoai WHERE MaTheLoai = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            theLoai = new TheLoaiDTO(
                                reader.GetInt32("MaTheLoai"),
                                reader.GetString("TenTheLoai")
                            );
                        }
                    }
                }
            }

            return theLoai;
        }

        public bool Add(TheLoaiDTO theLoai)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO TheLoai (TenTheLoai) VALUES (@ten)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", theLoai.TenTheLoai);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(TheLoaiDTO theLoai)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE TheLoai SET TenTheLoai = @ten WHERE MaTheLoai = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", theLoai.TenTheLoai);
                    cmd.Parameters.AddWithValue("@id", theLoai.MaTheLoai);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM TheLoai WHERE MaTheLoai = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
