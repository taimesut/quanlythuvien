using MySql.Data.MySqlClient;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DATA_ACCESS
{
    public class TacGiaDAL
    {
        private readonly DbConnection db;

        public TacGiaDAL()
        {
            db = new DbConnection();
        }

        public List<TacGiaDTO> GetAll()
        {
            var list = new List<TacGiaDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM TacGia";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TacGiaDTO
                        {
                            MaTacGia = Convert.ToInt32(reader["MaTacGia"]),
                            HoVaTen = reader["HoVaTen"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DiaChi = reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(TacGiaDTO tg)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO TacGia (HoVaTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai)
                                 VALUES (@HoVaTen, @GioiTinh, @NgaySinh, @DiaChi, @SoDienThoai)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoVaTen", tg.HoVaTen);
                cmd.Parameters.AddWithValue("@GioiTinh", tg.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", tg.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", tg.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", tg.SoDienThoai ?? "");

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(TacGiaDTO tg)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"UPDATE TacGia SET
                                 HoVaTen = @HoVaTen,
                                 GioiTinh = @GioiTinh,
                                 NgaySinh = @NgaySinh,
                                 DiaChi = @DiaChi,
                                 SoDienThoai = @SoDienThoai
                                 WHERE MaTacGia = @MaTacGia";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoVaTen", tg.HoVaTen);
                cmd.Parameters.AddWithValue("@GioiTinh", tg.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", tg.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", tg.DiaChi);
                cmd.Parameters.AddWithValue("@GhiChu", tg.SoDienThoai ?? "");
                cmd.Parameters.AddWithValue("@MaTacGia", tg.MaTacGia);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maTacGia)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "DELETE FROM TacGia WHERE MaTacGia = @MaTacGia";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public TacGiaDTO GetById(int maTacGia)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM TacGia WHERE MaTacGia = @MaTacGia";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TacGiaDTO
                        {
                            MaTacGia = Convert.ToInt32(reader["MaTacGia"]),
                            HoVaTen = reader["HoVaTen"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DiaChi = reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString()
                        };
                    }
                    return null;
                }
            }
        }

        public List<TacGiaDTO> Search(string keyword)
        {
            var list = new List<TacGiaDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"SELECT * FROM TacGia 
                                 WHERE HoVaTen LIKE @keyword
                                    OR MaTacGia LIKE @keyword";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TacGiaDTO
                        {
                            MaTacGia = Convert.ToInt32(reader["MaTacGia"]),
                            HoVaTen = reader["HoVaTen"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DiaChi = reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
