using QuanLyThuVien.DTO;
using QuanLyThuVien.DTO.QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace QuanLyThuVien.DATA_ACCESS
{
    public class NhanVienDAL
    {
        private readonly DbConnection db;

        public NhanVienDAL()
        {
            db = new DbConnection();
        }

        public List<NhanVienDTO> GetAll()
        {
            var list = new List<NhanVienDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM NguoiDung";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var nd = new NhanVienDTO
                        {
                            TenTaiKhoan = reader["TenTaiKhoan"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            HoVaTen = reader["HoVaTen"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DiaChi = reader["DiaChi"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            ChucVu = reader["ChucVu"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                        list.Add(nd);
                    }
                }
            }

            return list;
        }

        public bool Insert(NhanVienDTO nd)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO NguoiDung 
                    (TenTaiKhoan, MatKhau, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, ChucVu, Role)
                    VALUES (@TenTaiKhoan, @MatKhau, @HoVaTen, @NgaySinh, @DiaChi, @GioiTinh, @SoDienThoai, @ChucVu, @Role)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", nd.TenTaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", nd.MatKhau);
                cmd.Parameters.AddWithValue("@HoVaTen", nd.HoVaTen);
                cmd.Parameters.AddWithValue("@NgaySinh", nd.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", nd.DiaChi);
                cmd.Parameters.AddWithValue("@GioiTinh", nd.GioiTinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", nd.SoDienThoai);
                cmd.Parameters.AddWithValue("@ChucVu", nd.ChucVu);
                cmd.Parameters.AddWithValue("@Role", nd.Role);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(NhanVienDTO nd)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"UPDATE NguoiDung SET
                    MatKhau = @MatKhau,
                    HoVaTen = @HoVaTen,
                    NgaySinh = @NgaySinh,
                    DiaChi = @DiaChi,
                    GioiTinh = @GioiTinh,
                    SoDienThoai = @SoDienThoai,
                    ChucVu = @ChucVu,
                    Role = @Role
                    WHERE TenTaiKhoan = @TenTaiKhoan";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MatKhau", nd.MatKhau);
                cmd.Parameters.AddWithValue("@HoVaTen", nd.HoVaTen);
                cmd.Parameters.AddWithValue("@NgaySinh", nd.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", nd.DiaChi);
                cmd.Parameters.AddWithValue("@GioiTinh", nd.GioiTinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", nd.SoDienThoai);
                cmd.Parameters.AddWithValue("@ChucVu", nd.ChucVu);
                cmd.Parameters.AddWithValue("@Role", nd.Role);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", nd.TenTaiKhoan);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string tenTaiKhoan)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "DELETE FROM NguoiDung WHERE TenTaiKhoan = @TenTaiKhoan";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public NhanVienDTO GetById(string tenTaiKhoan)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM NguoiDung WHERE TenTaiKhoan = @TenTaiKhoan";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NhanVienDTO
                        {
                            TenTaiKhoan = reader["TenTaiKhoan"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            HoVaTen = reader["HoVaTen"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DiaChi = reader["DiaChi"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            ChucVu = reader["ChucVu"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                    else return null;
                }
            }
        }

        public List<NhanVienDTO> GetNhanVien()
        {
            var list = new List<NhanVienDTO>();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM NguoiDung WHERE Role = @Role";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Role", "NhanVien");
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var nv = new NhanVienDTO
                        {
                            TenTaiKhoan = reader["TenTaiKhoan"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            HoVaTen = reader["HoVaTen"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DiaChi = reader["DiaChi"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            ChucVu = reader["ChucVu"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                        list.Add(nv);
                    }
                }
            }

            return list;
        }

    }
}

