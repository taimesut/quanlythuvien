using MySql.Data.MySqlClient;
using QuanLyThuVien.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Repositories
{
    public class NhanVienRepository
    {
        private readonly DbConnection _db;

        public NhanVienRepository()
        {
            _db = new DbConnection();
        }

        public List<NhanVienDTO> GetAll()
        {
            var list = new List<NhanVienDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT MaNhanVien, TenTaiKhoan, MatKhau, HoVaTen, DiaChi, GioiTinh, SoDienThoai, ChucVu
                               FROM NhanVien";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVienDTO(
                            reader.GetInt32("MaNhanVien"),
                            reader["TenTaiKhoan"].ToString(),
                            reader["MatKhau"].ToString(),
                            reader["HoVaTen"].ToString(),
                            reader["DiaChi"].ToString(),
                            reader["GioiTinh"].ToString(),
                            reader["SoDienThoai"].ToString(),
                            reader["ChucVu"].ToString()
                        ));
                    }
                }
            }

            return list;
        }

        public NhanVienDTO GetById(int id)
        {
            NhanVienDTO nv = null;

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT MaNhanVien, TenTaiKhoan, MatKhau, HoVaTen, DiaChi, GioiTinh, SoDienThoai, ChucVu
                               FROM NhanVien
                               WHERE MaNhanVien = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nv = new NhanVienDTO(
                                reader.GetInt32("MaNhanVien"),
                                reader["TenTaiKhoan"].ToString(),
                                reader["MatKhau"].ToString(),
                                reader["HoVaTen"].ToString(),
                                reader["DiaChi"].ToString(),
                                reader["GioiTinh"].ToString(),
                                reader["SoDienThoai"].ToString(),
                                reader["ChucVu"].ToString()
                            );
                        }
                    }
                }
            }

            return nv;
        }

        public bool Add(NhanVienDTO nv)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO NhanVien (TenTaiKhoan, MatKhau, HoVaTen, DiaChi, GioiTinh, SoDienThoai, ChucVu)
                               VALUES (@tk, @mk, @hoten, @diaChi, @gioiTinh, @sdt, @chucVu)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tk", nv.TenTaiKhoan);
                    cmd.Parameters.AddWithValue("@mk", nv.MatKhau);
                    cmd.Parameters.AddWithValue("@hoten", nv.HoVaTen);
                    cmd.Parameters.AddWithValue("@diaChi", nv.DiaChi);
                    cmd.Parameters.AddWithValue("@gioiTinh", nv.GioiTinh);
                    cmd.Parameters.AddWithValue("@sdt", nv.SoDienThoai);
                    cmd.Parameters.AddWithValue("@chucVu", nv.ChucVu);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(NhanVienDTO nv)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE NhanVien
                               SET TenTaiKhoan = @tk,
                                   MatKhau = @mk,
                                   HoVaTen = @hoten,
                                   DiaChi = @diaChi,
                                   GioiTinh = @gioiTinh,
                                   SoDienThoai = @sdt,
                                   ChucVu = @chucVu
                               WHERE MaNhanVien = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tk", nv.TenTaiKhoan);
                    cmd.Parameters.AddWithValue("@mk", nv.MatKhau);
                    cmd.Parameters.AddWithValue("@hoten", nv.HoVaTen);
                    cmd.Parameters.AddWithValue("@diaChi", nv.DiaChi);
                    cmd.Parameters.AddWithValue("@gioiTinh", nv.GioiTinh);
                    cmd.Parameters.AddWithValue("@sdt", nv.SoDienThoai);
                    cmd.Parameters.AddWithValue("@chucVu", nv.ChucVu);
                    cmd.Parameters.AddWithValue("@id", nv.MaNhanVien);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<NhanVienDTO> SearchByName(string keyword)
        {
            var list = new List<NhanVienDTO>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT MaNhanVien, TenTaiKhoan, MatKhau, HoVaTen, DiaChi, GioiTinh, SoDienThoai, ChucVu
                               FROM NhanVien
                               WHERE HoVaTen LIKE @kw";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new NhanVienDTO(
                                reader.GetInt32("MaNhanVien"),
                                reader["TenTaiKhoan"].ToString(),
                                reader["MatKhau"].ToString(),
                                reader["HoVaTen"].ToString(),
                                reader["DiaChi"].ToString(),
                                reader["GioiTinh"].ToString(),
                                reader["SoDienThoai"].ToString(),
                                reader["ChucVu"].ToString()
                            ));
                        }
                    }
                }
            }

            return list;
        }

        public NhanVienDTO GetByUsername(string username)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM NhanVien WHERE TenTaiKhoan = @Username", conn);
                cmd.Parameters.AddWithValue("@Username", username);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new NhanVienDTO(
                        Convert.ToInt32(reader["MaNhanVien"]),
                        reader["TenTaiKhoan"].ToString(),
                        reader["MatKhau"].ToString(),
                        reader["HoVaTen"].ToString(),
                        reader["DiaChi"].ToString(),
                        reader["GioiTinh"].ToString(),
                        reader["SoDienThoai"].ToString(),
                        reader["ChucVu"].ToString()
                    );
                }
            }
            return null;
        }

    }
}
