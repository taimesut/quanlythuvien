using MySql.Data.MySqlClient;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DATA_ACCESS
{
    public class TheLoaiDAL
    {
        private readonly DbConnection db;

        public TheLoaiDAL()
        {
            db = new DbConnection();
        }

        public List<TheLoaiDTO> GetAll()
        {
            var list = new List<TheLoaiDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM TheLoai";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TheLoaiDTO
                        {
                            MaTheLoai = Convert.ToInt32(reader["MaTheLoai"]),
                            TenTheLoai = reader["TenTheLoai"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(TheLoaiDTO tl)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "INSERT INTO TheLoai (TenTheLoai) VALUES (@TenTheLoai)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenTheLoai", tl.TenTheLoai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(TheLoaiDTO tl)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "UPDATE TheLoai SET TenTheLoai = @TenTheLoai WHERE MaTheLoai = @MaTheLoai";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenTheLoai", tl.TenTheLoai);
                cmd.Parameters.AddWithValue("@MaTheLoai", tl.MaTheLoai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maTheLoai)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "DELETE FROM TheLoai WHERE MaTheLoai = @MaTheLoai";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public TheLoaiDTO GetById(int maTheLoai)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM TheLoai WHERE MaTheLoai = @MaTheLoai";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TheLoaiDTO
                        {
                            MaTheLoai = Convert.ToInt32(reader["MaTheLoai"]),
                            TenTheLoai = reader["TenTheLoai"].ToString(),
                        };
                    }
                    return null;
                }
            }
        }

        public List<TheLoaiDTO> Search(string keyword)
        {
            var list = new List<TheLoaiDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM TheLoai WHERE TenTheLoai LIKE @keyword OR MoTa LIKE @keyword";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TheLoaiDTO
                        {
                            MaTheLoai = Convert.ToInt32(reader["MaTheLoai"]),
                            TenTheLoai = reader["TenTheLoai"].ToString(),
                        });
                    }
                }
            }
            return list;
        }
    }
}
