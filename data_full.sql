USE QuanLyThuVien;
GO

-- Bảng NguoiDung (5 dòng)
INSERT INTO NguoiDung (TenTaiKhoan, MatKhau, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai, ChucVu, Role) VALUES
('admin01', 'hashed_pass_admin01', N'Nguyễn Thị A', '1980-01-01', N'Hà Nội', N'Nữ', '0123456789', N'Quản trị viên', 'Admin'),
('nv01', 'hashed_pass_nv01', N'Nguyễn Văn B', '1990-05-10', N'Hà Nội', N'Nam', '0987654321', N'Nhân viên thư viện', 'NhanVien'),
('nv02', 'hashed_pass_nv02', N'Trần Thị C', '1988-07-20', N'Hải Phòng', N'Nữ', '0912345678', N'Nhân viên', 'NhanVien'),
('nv03', 'hashed_pass_nv03', N'Lê Văn D', '1992-10-15', N'Đà Nẵng', N'Nam', '0909988776', N'Nhân viên', 'NhanVien'),
('nv04', 'hashed_pass_nv04', N'Phạm Thị E', '1991-03-05', N'HCM', N'Nữ', '0933221100', N'Nhân viên', 'NhanVien');

-- Bảng DocGia (20 dòng)
INSERT INTO DocGia (MaDocGia, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai) VALUES
(1, N'Phạm Văn A', '1995-03-15', N'Hà Nội', N'Nam', '0909123456'),
(2, N'Vũ Thị B', '1992-08-21', N'Đà Nẵng', N'Nữ', '0909876543'),
(3, N'Ngô Văn C', '1993-04-10', N'HCM', N'Nam', '0912345670'),
(4, N'Hoàng Thị D', '1990-12-25', N'Hải Phòng', N'Nữ', '0908765432'),
(5, N'Bùi Văn E', '1988-07-30', N'Hà Nội', N'Nam', '0911222333'),
(6, N'Trần Thị F', '1991-01-01', N'Đà Nẵng', N'Nữ', '0922333444'),
(7, N'Phan Văn G', '1994-09-15', N'HCM', N'Nam', '0933444555'),
(8, N'Đặng Thị H', '1987-05-20', N'Hà Nội', N'Nữ', '0944555666'),
(9, N'Nguyễn Văn I', '1990-11-11', N'Hải Phòng', N'Nam', '0955666777'),
(10, N'Võ Thị J', '1993-06-06', N'Đà Nẵng', N'Nữ', '0966777888'),
(11, N'Lê Văn K', '1992-02-14', N'HCM', N'Nam', '0977888999'),
(12, N'Phạm Thị L', '1991-08-08', N'Hà Nội', N'Nữ', '0988999000'),
(13, N'Ngô Văn M', '1989-10-10', N'Hải Phòng', N'Nam', '0999000111'),
(14, N'Hoàng Thị N', '1995-07-07', N'Đà Nẵng', N'Nữ', '0911000222'),
(15, N'Bùi Văn O', '1993-12-12', N'HCM', N'Nam', '0922000333'),
(16, N'Trần Thị P', '1990-03-03', N'Hà Nội', N'Nữ', '0933000444'),
(17, N'Phan Văn Q', '1991-05-05', N'Hải Phòng', N'Nam', '0944000555'),
(18, N'Đặng Thị R', '1988-09-09', N'Đà Nẵng', N'Nữ', '0955000666'),
(19, N'Nguyễn Văn S', '1992-01-01', N'HCM', N'Nam', '0966000777'),
(20, N'Võ Thị T', '1993-04-04', N'Hà Nội', N'Nữ', '0977000888');

-- Bảng TacGia (20 dòng)
INSERT INTO TacGia (MaTacGia, HoVaTen, NgaySinh, DiaChi, GioiTinh, SoDienThoai) VALUES
(1, N'Nguyễn Nhật Ánh', '1955-05-07', N'Hà Nội', N'Nam', '0911222333'),
(2, N'Hồ Anh Thái', '1970-10-10', N'HCM', N'Nam', '0988777666'),
(3, N'Phạm Thị Mai', '1980-04-04', N'Hà Nội', N'Nữ', '0911333444'),
(4, N'Trần Văn An', '1975-12-12', N'Đà Nẵng', N'Nam', '0922444555'),
(5, N'Lê Thị Bình', '1982-06-06', N'HCM', N'Nữ', '0933555666'),
(6, N'Vũ Văn Cường', '1978-07-07', N'Hà Nội', N'Nam', '0944666777'),
(7, N'Phan Thị Dung', '1985-03-03', N'Hải Phòng', N'Nữ', '0955777888'),
(8, N'Bùi Văn Đông', '1970-08-08', N'Đà Nẵng', N'Nam', '0966888999'),
(9, N'Ngô Thị Hà', '1983-11-11', N'HCM', N'Nữ', '0977999000'),
(10, N'Hoàng Văn Khoa', '1979-09-09', N'Hà Nội', N'Nam', '0988000111'),
(11, N'Phạm Thị Lan', '1984-05-05', N'Hải Phòng', N'Nữ', '0911000222'),
(12, N'Trần Văn Minh', '1976-10-10', N'Đà Nẵng', N'Nam', '0922000333'),
(13, N'Lê Thị Nga', '1981-02-02', N'HCM', N'Nữ', '0933000444'),
(14, N'Vũ Văn Oanh', '1973-07-07', N'Hà Nội', N'Nam', '0944000555'),
(15, N'Phan Thị Phương', '1986-12-12', N'Hải Phòng', N'Nữ', '0955000666'),
(16, N'Bùi Văn Quang', '1974-03-03', N'Đà Nẵng', N'Nam', '0966000777'),
(17, N'Ngô Thị Quyên', '1987-08-08', N'HCM', N'Nữ', '0977000888'),
(18, N'Hoàng Văn Sơn', '1972-01-01', N'Hà Nội', N'Nam', '0988000999'),
(19, N'Phạm Thị Thu', '1980-04-04', N'Hải Phòng', N'Nữ', '0911000999'),
(20, N'Trần Văn Vinh', '1975-07-07', N'Đà Nẵng', N'Nam', '0922000888');

-- Bảng TheLoai (20 dòng)
INSERT INTO TheLoai (MaTheLoai, TenTheLoai) VALUES
(1, N'Văn học thiếu nhi'),
(2, N'Tiểu thuyết hiện đại'),
(3, N'Khoa học viễn tưởng'),
(4, N'Giáo trình'),
(5, N'Lịch sử'),
(6, N'Kinh tế'),
(7, N'Tâm lý học'),
(8, N'Chính trị'),
(9, N'Kỹ năng sống'),
(10, N'Văn học cổ điển'),
(11, N'Thơ ca'),
(12, N'Văn học nước ngoài'),
(13, N'Sách tham khảo'),
(14, N'Sách học ngoại ngữ'),
(15, N'Chính luận'),
(16, N'Tuổi trẻ'),
(17, N'Sách khoa học'),
(18, N'Thể thao'),
(19, N'Văn hóa xã hội'),
(20, N'Truyện ngắn');

-- Bảng NhaXuatBan (20 dòng)
INSERT INTO NhaXuatBan (MaNhaXuatBan, TenNhaCungCap, SoDienThoai, Gmail, DiaChi) VALUES
(1, N'NXB Trẻ', '0241234567', 'contact@nxbtree.vn', N'123 Đường A, Hà Nội'),
(2, N'NXB Kim Đồng', '0247654321', 'info@nxbkimdong.vn', N'456 Đường B, Hà Nội'),
(3, N'NXB Văn Học', '0241111222', 'vanhoc@nxb.com', N'789 Đường C, Hà Nội'),
(4, N'NXB Giáo Dục', '0281234567', 'giaoduc@nxb.com', N'101 Đường D, HCM'),
(5, N'NXB Tổng Hợp', '0243333444', 'tonghop@nxb.com', N'202 Đường E, Hà Nội'),
(6, N'NXB Hồng Đức', '0284444555', 'hongduc@nxb.com', N'303 Đường F, HCM'),
(7, N'NXB Lao Động', '0245555666', 'laodong@nxb.com', N'404 Đường G, Hà Nội'),
(8, N'NXB Trí Thức', '0286666777', 'trithuc@nxb.com', N'505 Đường H, HCM'),
(9, N'NXB Văn Hóa', '0247777888', 'vanhoa@nxb.com', N'606 Đường I, Hà Nội'),
(10, N'NXB Sự Thật', '0288888999', 'suthat@nxb.com', N'707 Đường J, HCM'),
(11, N'NXB Đại Học', '0249999000', 'daihoc@nxb.com', N'808 Đường K, Hà Nội'),
(12, N'NXB Phụ Nữ', '0280000111', 'phunu@nxb.com', N'909 Đường L, HCM'),
(13, N'NXB Khoa Học', '0241111000', 'khoahoc@nxb.com', N'111 Đường M, Hà Nội'),
(14, N'NXB Tài Chính', '0282222000', 'taichinh@nxb.com', N'222 Đường N, HCM'),
(15, N'NXB Văn Thể', '0243333000', 'vanthe@nxb.com', N'333 Đường O, Hà Nội'),
(16, N'NXB Thanh Niên', '0284444000', 'thanhnien@nxb.com', N'444 Đường P, HCM'),
(17, N'NXB Đại Nam', '0245555000', 'dainam@nxb.com', N'555 Đường Q, Hà Nội'),
(18, N'NXB Trẻ Thơ', '0286666000', 'tretho@nxb.com', N'666 Đường R, HCM'),
(19, N'NXB Tác Giả', '0247777000', 'tacgia@nxb.com', N'777 Đường S, Hà Nội'),
(20, N'NXB Thời Đại', '0288888000', 'thoidai@nxb.com', N'888 Đường T, HCM');

-- Bảng NhaCungCap (20 dòng)
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, SoDienThoai, Gmail, DiaChi) VALUES
(1, N'Công ty Sách ABC', '0281234567', 'abc@booksupply.vn', N'789 Đường C, HCM'),
(2, N'Công ty Sách XYZ', '0249876543', 'xyz@booksupply.vn', N'101 Đường D, Hà Nội'),
(3, N'Công ty Sách LMN', '0285555666', 'lmn@booksupply.vn', N'102 Đường E, HCM'),
(4, N'Công ty Sách QRS', '0244444555', 'qrs@booksupply.vn', N'103 Đường F, Hà Nội'),
(5, N'Công ty Sách UVW', '0283333444', 'uvw@booksupply.vn', N'104 Đường G, HCM'),
(6, N'Công ty Sách EFG', '0242222333', 'efg@booksupply.vn', N'105 Đường H, Hà Nội'),
(7, N'Công ty Sách HIJ', '0281111222', 'hij@booksupply.vn', N'106 Đường I, HCM'),
(8, N'Công ty Sách KLM', '0249999000', 'klm@booksupply.vn', N'107 Đường J, Hà Nội'),
(9, N'Công ty Sách NOP', '0288888999', 'nop@booksupply.vn', N'108 Đường K, HCM'),
(10, N'Công ty Sách QWE', '0247777888', 'qwe@booksupply.vn', N'109 Đường L, Hà Nội'),
(11, N'Công ty Sách RTY', '0286666777', 'rty@booksupply.vn', N'110 Đường M, HCM'),
(12, N'Công ty Sách UIO', '0245555666', 'uio@booksupply.vn', N'111 Đường N, Hà Nội'),
(13, N'Công ty Sách PAS', '0284444555', 'pas@booksupply.vn', N'112 Đường O, HCM'),
(14, N'Công ty Sách DFG', '0243333444', 'dfg@booksupply.vn', N'113 Đường P, Hà Nội'),
(15, N'Công ty Sách HJK', '0282222333', 'hjk@booksupply.vn', N'114 Đường Q, HCM'),
(16, N'Công ty Sách LMN2', '0241111222', 'lmn2@booksupply.vn', N'115 Đường R, Hà Nội'),
(17, N'Công ty Sách OPQ', '0280000111', 'opq@booksupply.vn', N'116 Đường S, HCM'),
(18, N'Công ty Sách RST', '0249999000', 'rst@booksupply.vn', N'117 Đường T, Hà Nội'),
(19, N'Công ty Sách UVW2', '0288888999', 'uvw2@booksupply.vn', N'118 Đường U, HCM'),
(20, N'Công ty Sách XYZ2', '0247777888', 'xyz2@booksupply.vn', N'119 Đường V, Hà Nội');

-- Bảng Sach (20 dòng)
INSERT INTO Sach (MaSach, MaNhaXuatBan, MaTheLoai, MaTacGia, MaNhaCungCap, TenSach, NamXuatBan, SoLuong) VALUES
(1, 1, 1, 1, 1, N'Chú bé rắc rối', 2010, 10),
(2, 2, 2, 2, 2, N'Tiểu thuyết cuộc sống', 2015, 5),
(3, 3, 3, 3, 3, N'Khoa học viễn tưởng 1', 2018, 8),
(4, 4, 4, 4, 4, N'Giáo trình toán', 2019, 12),
(5, 5, 5, 5, 5, N'Lịch sử Việt Nam', 2012, 7),
(6, 6, 6, 6, 6, N'Kinh tế học căn bản', 2016, 9),
(7, 7, 7, 7, 7, N'Tâm lý học phổ thông', 2014, 6),
(8, 8, 8, 8, 8, N'Chính trị hiện đại', 2017, 10),
(9, 9, 9, 9, 9, N'Kỹ năng sống hiệu quả', 2020, 11),
(10, 10, 10, 10, 10, N'Văn học cổ điển', 2013, 4),
(11, 11, 11, 11, 11, N'Thơ ca Việt Nam', 2011, 3),
(12, 12, 12, 12, 12, N'Văn học nước ngoài', 2015, 8),
(13, 13, 13, 13, 13, N'Sách tham khảo phổ thông', 2019, 7),
(14, 14, 14, 14, 14, N'Sách học ngoại ngữ cơ bản', 2021, 15),
(15, 15, 15, 15, 15, N'Chính luận xã hội', 2010, 5),
(16, 16, 16, 16, 16, N'Tuổi trẻ và tương lai', 2018, 9),
(17, 17, 17, 17, 17, N'Sách khoa học mới', 2017, 6),
(18, 18, 18, 18, 18, N'Thể thao thế giới', 2014, 10),
(19, 19, 19, 19, 19, N'Văn hóa xã hội Việt Nam', 2013, 8),
(20, 20, 20, 20, 20, N'Truyện ngắn Việt Nam', 2016, 7);

-- Bảng PhieuMuon (20 dòng)
INSERT INTO PhieuMuon (MaPhieuMuon, MaNguoiDung, MaDocGia, NgayMuon, HanTra) VALUES
(1, 2, 1, '2025-08-01', '2025-08-15'),
(2, 3, 2, '2025-08-02', '2025-08-16'),
(3, 4, 3, '2025-08-03', '2025-08-17'),
(4, 5, 4, '2025-08-04', '2025-08-18'),
(5, 2, 5, '2025-08-05', '2025-08-19'),
(6, 3, 6, '2025-08-06', '2025-08-20'),
(7, 4, 7, '2025-08-07', '2025-08-21'),
(8, 5, 8, '2025-08-08', '2025-08-22'),
(9, 2, 9, '2025-08-09', '2025-08-23'),
(10, 3, 10, '2025-08-10', '2025-08-24'),
(11, 4, 11, '2025-08-11', '2025-08-25'),
(12, 5, 12, '2025-08-12', '2025-08-26'),
(13, 2, 13, '2025-08-13', '2025-08-27'),
(14, 3, 14, '2025-08-14', '2025-08-28'),
(15, 4, 15, '2025-08-15', '2025-08-29'),
(16, 5, 16, '2025-08-16', '2025-08-30'),
(17, 2, 17, '2025-08-17', '2025-08-31'),
(18, 3, 18, '2025-08-18', '2025-09-01'),
(19, 4, 19, '2025-08-19', '2025-09-02'),
(20, 5, 20, '2025-08-20', '2025-09-03');

-- Bảng ChiTietMuonSach (20 dòng)
INSERT INTO ChiTietMuonSach (MaSach, MaPhieuMuon, SoLuong) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 1),
(4, 4, 3),
(5, 5, 1),
(6, 6, 2),
(7, 7, 1),
(8, 8, 2),
(9, 9, 1),
(10, 10, 1),
(11, 11, 2),
(12, 12, 1),
(13, 13, 3),
(14, 14, 2),
(15, 15, 1),
(16, 16, 1),
(17, 17, 2),
(18, 18, 1),
(19, 19, 1),
(20, 20, 2);

-- Bảng PhieuNhap (20 dòng)
INSERT INTO PhieuNhap (MaPhieuNhap, MaNguoiDung, MaNhaCungCap, NgayLapPhieu, NgayNhanSach) VALUES
(1, 2, 1, '2025-07-25', '2025-07-30'),
(2, 3, 2, '2025-07-28', '2025-08-01'),
(3, 4, 3, '2025-07-29', '2025-08-02'),
(4, 5, 4, '2025-07-30', '2025-08-03'),
(5, 2, 5, '2025-07-31', '2025-08-04'),
(6, 3, 6, '2025-08-01', '2025-08-05'),
(7, 4, 7, '2025-08-02', '2025-08-06'),
(8, 5, 8, '2025-08-03', '2025-08-07'),
(9, 2, 9, '2025-08-04', '2025-08-08'),
(10, 3, 10, '2025-08-05', '2025-08-09'),
(11, 4, 11, '2025-08-06', '2025-08-10'),
(12, 5, 12, '2025-08-07', '2025-08-11'),
(13, 2, 13, '2025-08-08', '2025-08-12'),
(14, 3, 14, '2025-08-09', '2025-08-13'),
(15, 4, 15, '2025-08-10', '2025-08-14'),
(16, 5, 16, '2025-08-11', '2025-08-15'),
(17, 2, 17, '2025-08-12', '2025-08-16'),
(18, 3, 18, '2025-08-13', '2025-08-17'),
(19, 4, 19, '2025-08-14', '2025-08-18'),
(20, 5, 20, '2025-08-15', '2025-08-19');

-- Bảng ChiTietNhapSach (20 dòng)
INSERT INTO ChiTietNhapSach (MaPhieuNhap, MaSach, SoLuong) VALUES
(1, 1, 10),
(2, 2, 5),
(3, 3, 7),
(4, 4, 12),
(5, 5, 9),
(6, 6, 8),
(7, 7, 6),
(8, 8, 10),
(9, 9, 11),
(10, 10, 4),
(11, 11, 3),
(12, 12, 8),
(13, 13, 7),
(14, 14, 15),
(15, 15, 5),
(16, 16, 9),
(17, 17, 6),
(18, 18, 10),
(19, 19, 8),
(20, 20, 7);

-- Bảng QuyDinh (1 dòng, bạn có thể thêm nếu muốn)
INSERT INTO QuyDinh (MaQuyDinh, SoNgayMuonToiDa) VALUES (1, 15);
