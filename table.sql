CREATE TABLE DocGia (
    MaDocGia INT PRIMARY KEY AUTO_INCREMENT,
    HoVaTen VARCHAR(100) CHARACTER SET utf8mb4,
    NgaySinh DATE,
    DiaChi VARCHAR(200) CHARACTER SET utf8mb4,
	GioiTinh VARCHAR(10),
    SoDienThoai VARCHAR(20)
);

CREATE TABLE TheLoai (
    MaTheLoai INT PRIMARY KEY AUTO_INCREMENT,
    TenTheLoai VARCHAR(100) CHARACTER SET utf8mb4
);

CREATE TABLE Sach (
    MaSach INT PRIMARY KEY AUTO_INCREMENT,
    NhaXuatBan VARCHAR(100) CHARACTER SET utf8mb4,
    MaTheLoai INT,
    TacGia VARCHAR(100) CHARACTER SET utf8mb4,
    TenSach VARCHAR(200) CHARACTER SET utf8mb4,
    NamXuatBan INT,
    SoLuong INT DEFAULT 0,
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai)
);

CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY AUTO_INCREMENT,
    TenTaiKhoan VARCHAR(50) UNIQUE NOT NULL,
    MatKhau VARCHAR(100) NOT NULL,
    HoVaTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    DiaChi VARCHAR(200) CHARACTER SET utf8mb4,
    GioiTinh VARCHAR(10),
    SoDienThoai VARCHAR(20),
    ChucVu VARCHAR(50) CHARACTER SET utf8mb4
);

CREATE TABLE PhieuMuon (
    MaPhieuMuon INT PRIMARY KEY AUTO_INCREMENT,
    MaNhanVien INT,
    MaDocGia INT,
    NgayMuon DATE,
    NgayTra DATE,
    HanTra DATE,
    TrangThai int default 0,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia)
);

CREATE TABLE ChiTietMuonSach (
    MaSach INT,
    MaPhieuMuon INT,
    SoLuong INT,
    PRIMARY KEY (MaSach, MaPhieuMuon),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach),
    FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon)
);

CREATE TABLE QuyDinh (
    MaQuyDinh INT PRIMARY KEY AUTO_INCREMENT,
    SoNgayMuonToiDa INT,
    SoSachMuonToiDa INT
);
