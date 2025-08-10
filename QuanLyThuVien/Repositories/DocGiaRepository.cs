using MySql.Data.MySqlClient;
using QuanLyThuVien.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Repositories
{
    public class DocGiaRepository
    {
        private readonly DbConnection _db;

        public DocGiaRepository()
        {
            _db = new DbConnection();
        }

        public List<DocGiaDTO> GetAll()
        {
            var list = new List<DocGiaDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT *
                               FROM DocGia";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DocGiaDTO(
                            reader.GetInt32("MaDocGia"),
                            reader["HoVaTen"].ToString(),
                            reader["DiaChi"].ToString(),
                            reader["GioiTinh"].ToString(),
                            reader["SoDienThoai"].ToString()
                        ));
                    }
                }
            }

            return list;
        }

        public DocGiaDTO GetById(int id)
        {
            DocGiaDTO dg = null;

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT *
                               FROM DocGia
                               WHERE MaDocGia = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dg = new DocGiaDTO(
                                reader.GetInt32("MaDocGia"),
                                reader["HoVaTen"].ToString(),
                                reader["DiaChi"].ToString(),
                                reader["GioiTinh"].ToString(),
                                reader["SoDienThoai"].ToString()
                            );
                        }
                    }
                }
            }

            return dg;
        }

        public bool Add(DocGiaDTO dg)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO DocGia (HoVaTen, DiaChi, GioiTinh, SoDienThoai)
                               VALUES (@hoten, @diaChi, @gioiTinh, @sdt)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hoten", dg.HoVaTen);
                    cmd.Parameters.AddWithValue("@diaChi", dg.DiaChi);
                    cmd.Parameters.AddWithValue("@gioiTinh", dg.GioiTinh);
                    cmd.Parameters.AddWithValue("@sdt", dg.SoDienThoai);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(DocGiaDTO dg)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE DocGia
                               SET HoVaTen = @hoten,
                                   DiaChi = @diaChi,
                                   GioiTinh = @gioiTinh,
                                   SoDienThoai = @sdt
                               WHERE MaDocGia = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hoten", dg.HoVaTen);
                    cmd.Parameters.AddWithValue("@diaChi", dg.DiaChi);
                    cmd.Parameters.AddWithValue("@gioiTinh", dg.GioiTinh);
                    cmd.Parameters.AddWithValue("@sdt", dg.SoDienThoai);
                    cmd.Parameters.AddWithValue("@id", dg.MaDocGia);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM DocGia WHERE MaDocGia = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<DocGiaDTO> SearchByName(string keyword)
        {
            var list = new List<DocGiaDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT *
                               FROM DocGia
                               WHERE HoVaTen LIKE @kw";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DocGiaDTO(
                                reader.GetInt32("MaDocGia"),
                                reader["HoVaTen"].ToString(),
                                reader["DiaChi"].ToString(),
                                reader["GioiTinh"].ToString(),
                                reader["SoDienThoai"].ToString()
                            ));
                        }
                    }
                }
            }

            return list;
        }
    }
}
