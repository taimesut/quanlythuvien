using MySql.Data.MySqlClient;
using QuanLyThuVien.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                string sql = "SELECT MaSach, MaTheLoai, NhaXuatBan, TacGia, TenSach, NamXuatBan, SoLuong, Anh FROM Sach";
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
                            reader.GetInt32("SoLuong"),
                            reader.GetString("Anh")
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
                string sql = "SELECT MaSach, MaTheLoai, NhaXuatBan, TacGia, TenSach, NamXuatBan, SoLuong, Anh FROM Sach WHERE MaSach = @id";
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
                                reader.GetInt32("SoLuong"),
                                reader.GetString("Anh")
                            );
                        }
                    }
                }
            }

            return sach;
        }

        public bool IsSachTonTai(string tenSach, string tacGia)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Sach WHERE TenSach = @tenSach AND TacGia = @tacGia";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tenSach", tenSach);
                    cmd.Parameters.AddWithValue("@tacGia", tacGia);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }


        public bool Add(SachDTO sach)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                if (IsSachTonTai(sach.TenSach, sach.TacGia))
                {
                    MessageBox.Show("Sách đã tồn tại rồi");
                    return false;
                }

                string sql = @"
                    INSERT INTO Sach (MaTheLoai, NhaXuatBan, TacGia, TenSach, NamXuatBan, SoLuong, Anh)
                    VALUES (@maTheLoai, @nxb, @tacGia, @tenSach, @namXB, @soLuong, @Anh)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maTheLoai", sach.MaTheLoai);
                    cmd.Parameters.AddWithValue("@nxb", sach.NhaXuatBan);
                    cmd.Parameters.AddWithValue("@tacGia", sach.TacGia);
                    cmd.Parameters.AddWithValue("@tenSach", sach.TenSach);
                    cmd.Parameters.AddWithValue("@namXB", sach.NamXuatBan);
                    cmd.Parameters.AddWithValue("@soLuong", sach.SoLuong);
                    cmd.Parameters.AddWithValue("@anh", sach.Anh);
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
                        SoLuong = @soLuong,
                        Anh = @anh
                    WHERE MaSach = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maTheLoai", sach.MaTheLoai);
                    cmd.Parameters.AddWithValue("@nxb", sach.NhaXuatBan);
                    cmd.Parameters.AddWithValue("@tacGia", sach.TacGia);
                    cmd.Parameters.AddWithValue("@tenSach", sach.TenSach);
                    cmd.Parameters.AddWithValue("@namXB", sach.NamXuatBan);
                    cmd.Parameters.AddWithValue("@soLuong", sach.SoLuong);
                    cmd.Parameters.AddWithValue("@anh", sach.Anh);
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
