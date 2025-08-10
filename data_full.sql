-- Bảng DocGia
INSERT INTO DocGia (HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai) VALUES
('Nguyễn Văn A', '1995-05-12', 'Hà Nội', 'Nam', '0905123456'),
('Trần Thị B', '2000-08-22', 'TP. Hồ Chí Minh', 'Nam', '0912345678'),
('Lê Văn C', '1998-11-15', 'Đà Nẵng', 'Nam', '0987654321');

-- Bảng Thể Loại
INSERT INTO TheLoai (TenTheLoai) VALUES
('Khoa học'),
('Văn học'),
('Công nghệ thông tin'),
('Kinh tế');

-- Bảng Sách
INSERT INTO Sach (NhaXuatBan, MaTheLoai, TacGia, TenSach, NamXuatBan, SoLuong) VALUES
('NXB Giáo Dục', 1, 'Nguyễn Văn D', 'Vũ trụ và những điều kỳ thú', 2020, 5),
('NXB Trẻ', 2, 'Nguyễn Nhật Ánh', 'Mắt biếc', 2018, 10),
('NXB Lao Động', 3, 'Robert C. Martin', 'Clean Code', 2015, 7),
('NXB Thống Kê', 4, 'Adam Smith', 'Wealth of Nations', 2010, 3);

-- Bảng Nhân Viên
INSERT INTO NhanVien (TenTaiKhoan, MatKhau, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, ChucVu) VALUES
('1', '1', 'Quản trị viên', '1990-01-01', 'Hà Nội', 'Nam', '0900000000', 'Quản trị'),
('nhanvien1', '123456', 'Nguyễn Văn Nhân', '1995-04-10', 'Hà Nội', 'Nam', '0911111111', 'Nhân viên'),
('nhanvien2', '123456', 'Trần Thị Viên', '1997-06-20', 'TP. Hồ Chí Minh', 'Nam', '0922222222', 'Nhân viên');

-- Bảng Phiếu Mượn
INSERT INTO PhieuMuon (MaNhanVien, MaDocGia, NgayMuon, HanTra, NgayTra, TrangThai) VALUES
(2, 1, '2025-08-01', '2025-08-15', NULL, 0),
(3, 2, '2025-08-05', '2025-08-19', '2025-08-18', 1);

-- Bảng Chi Tiết Mượn Sách
INSERT INTO ChiTietMuonSach (MaSach, MaPhieuMuon, SoLuong) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 2, 1);

-- Bảng Quy Định
INSERT INTO QuyDinh (SoNgayMuonToiDa,SoSachMuonToiDa) VALUES
(14, 10);
