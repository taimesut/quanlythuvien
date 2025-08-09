using MySql.Data.MySqlClient;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyThuVien.DATA_ACCESS
{
    public class DocGiaDAL
    {
        private readonly DbConnection db;

        public DocGiaDAL()
        {
            db = new DbConnection();
        }

        // Lấy tất cả độc giả
        public List<DocGiaDTO> GetAll()
        {
            var list = new List<DocGiaDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT MaDocGia, HoVaTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai FROM DocGia";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dg = new DocGiaDTO(
                            Convert.ToInt32(reader["MaDocGia"]),
                            reader["HoVaTen"].ToString(),
                            Convert.ToDateTime(reader["NgaySinh"]),
                            reader["DiaChi"].ToString(),
                            reader["GioiTinh"].ToString(),
                            reader["SoDienThoai"].ToString()
                        );
                        list.Add(dg);
                    }
                }
            }

            return list;
        }

        // Thêm độc giả
        public bool Insert(DocGiaDTO dg)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO DocGia (MaDocGia, HoVaTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai)
                                 VALUES (@MaDocGia, @HoVaTen, @GioiTinh, @NgaySinh, @DiaChi, @SoDienThoai)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDocGia", dg.MaDocGia);
                cmd.Parameters.AddWithValue("@HoVaTen", dg.HoVaTen);
                cmd.Parameters.AddWithValue("@GioiTinh", dg.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", dg.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", dg.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", dg.SoDienThoai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật độc giả
        public bool Update(DocGiaDTO dg)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"UPDATE DocGia 
                                 SET HoVaTen = @HoVaTen,
                                     GioiTinh = @GioiTinh,
                                     NgaySinh = @NgaySinh,
                                     DiaChi = @DiaChi,
                                     SoDienThoai = @SoDienThoai
                                 WHERE MaDocGia = @MaDocGia";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoVaTen", dg.HoVaTen);
                cmd.Parameters.AddWithValue("@GioiTinh", dg.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", dg.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", dg.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", dg.SoDienThoai);
                cmd.Parameters.AddWithValue("@MaDocGia", dg.MaDocGia);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa độc giả
        public bool Delete(int maDocGia)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "DELETE FROM DocGia WHERE MaDocGia = @MaDocGia";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy độc giả theo mã
        public DocGiaDTO GetById(int maDocGia)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT MaDocGia, HoVaTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai FROM DocGia WHERE MaDocGia = @MaDocGia";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DocGiaDTO(
                            Convert.ToInt32(reader["MaDocGia"]),
                            reader["HoVaTen"].ToString(),
                            Convert.ToDateTime(reader["NgaySinh"]),
                            reader["DiaChi"].ToString(),
                            reader["GioiTinh"].ToString(),
                            reader["SoDienThoai"].ToString()
                        );
                    }
                }
            }
            return null;
        }

        // Tìm kiếm độc giả
        public List<DocGiaDTO> Search(string keyword)
        {
            var list = new List<DocGiaDTO>();

            string query = @"SELECT MaDocGia, HoVaTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai
                             FROM DocGia
                             WHERE MaDocGia LIKE @keyword
                                OR HoVaTen LIKE @keyword
                                OR SoDienThoai LIKE @keyword";

            using (MySqlConnection conn = db.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dg = new DocGiaDTO(
                            Convert.ToInt32(reader["MaDocGia"]),
                            reader["HoVaTen"].ToString(),
                            Convert.ToDateTime(reader["NgaySinh"]),
                            reader["DiaChi"].ToString(),
                            reader["GioiTinh"].ToString(),
                            reader["SoDienThoai"].ToString()
                        );
                        list.Add(dg);
                    }
                }
            }

            return list;
        }
    }
}
