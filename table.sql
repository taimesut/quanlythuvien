CREATE TABLE DocGia (
    MaDocGia INT PRIMARY KEY AUTO_INCREMENT,
    HoVaTen VARCHAR(100) CHARACTER SET utf8mb4,
    NgaySinh DATE,
    DiaChi VARCHAR(200) CHARACTER SET utf8mb4,
    GioiTinh VARCHAR(10) CHARACTER SET utf8mb4,
    SoDienThoai VARCHAR(20)
);

CREATE TABLE TacGia (
    MaTacGia INT PRIMARY KEY AUTO_INCREMENT,
    HoVaTen VARCHAR(100) CHARACTER SET utf8mb4,
    NgaySinh DATE,
    DiaChi VARCHAR(200) CHARACTER SET utf8mb4,
    GioiTinh VARCHAR(10) CHARACTER SET utf8mb4,
    SoDienThoai VARCHAR(20)
);

CREATE TABLE TheLoai (
    MaTheLoai INT PRIMARY KEY AUTO_INCREMENT,
    TenTheLoai VARCHAR(100) CHARACTER SET utf8mb4
);

CREATE TABLE NhaXuatBan (
    MaNhaXuatBan INT PRIMARY KEY AUTO_INCREMENT,
    TenNhaCungCap VARCHAR(200) CHARACTER SET utf8mb4,
    SoDienThoai VARCHAR(20),
    Gmail VARCHAR(100),
    DiaChi VARCHAR(200) CHARACTER SET utf8mb4
);

CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY AUTO_INCREMENT,
    TenNhaCungCap VARCHAR(200) CHARACTER SET utf8mb4,
    SoDienThoai VARCHAR(20),
    Gmail VARCHAR(100),
    DiaChi VARCHAR(200) CHARACTER SET utf8mb4
);

CREATE TABLE Sach (
    MaSach INT PRIMARY KEY AUTO_INCREMENT,
    MaNhaXuatBan INT,
    MaTheLoai INT,
    MaTacGia INT,
    MaNhaCungCap INT,
    TenSach VARCHAR(200) CHARACTER SET utf8mb4,
    NamXuatBan INT,
    SoLuong INT DEFAULT 0,
    FOREIGN KEY (MaNhaXuatBan) REFERENCES NhaXuatBan(MaNhaXuatBan),
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai),
    FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);

CREATE TABLE NguoiDung (
    MaNguoiDung INT PRIMARY KEY AUTO_INCREMENT,
    TenTaiKhoan VARCHAR(50) UNIQUE NOT NULL,
    MatKhau VARCHAR(100) NOT NULL,
    HoVaTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    DiaChi VARCHAR(200) CHARACTER SET utf8mb4,
    GioiTinh VARCHAR(10) CHARACTER SET utf8mb4,
    SoDienThoai VARCHAR(20),
    ChucVu VARCHAR(50) CHARACTER SET utf8mb4,
    Role VARCHAR(20) NOT NULL DEFAULT 'NhanVien'
);

CREATE TABLE PhieuMuon (
    MaPhieuMuon INT PRIMARY KEY AUTO_INCREMENT,
    MaNguoiDung INT,
    MaDocGia INT,
    NgayMuon DATE,
    HanTra DATE,
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
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

CREATE TABLE PhieuNhap (
    MaPhieuNhap INT PRIMARY KEY AUTO_INCREMENT,
    MaNguoiDung INT,
    MaNhaCungCap INT,
    NgayLapPhieu DATE,
    NgayNhanSach DATE,
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);

CREATE TABLE ChiTietNhapSach (
    MaPhieuNhap INT,
    MaSach INT,
    SoLuong INT,
    PRIMARY KEY (MaPhieuNhap, MaSach),
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

CREATE TABLE QuyDinh (
    MaQuyDinh INT PRIMARY KEY AUTO_INCREMENT,
    SoNgayMuonToiDa INT
);

-- Trigger: Cập nhật tồn kho khi nhập sách
DELIMITER $$
CREATE TRIGGER trg_NhapSach_UpdateTonKho
AFTER INSERT ON ChiTietNhapSach
FOR EACH ROW
BEGIN
    UPDATE Sach
    SET SoLuong = IFNULL(SoLuong,0) + IFNULL(NEW.SoLuong,0)
    WHERE MaSach = NEW.MaSach;
END$$
DELIMITER ;

-- Trigger: Kiểm tra tồn kho trước khi mượn
DELIMITER $$
CREATE TRIGGER trg_KiemTraTonKhoTruocMuon
BEFORE INSERT ON ChiTietMuonSach
FOR EACH ROW
BEGIN
    DECLARE sl INT;
    SELECT SoLuong INTO sl FROM Sach WHERE MaSach = NEW.MaSach;
    IF sl IS NULL OR NEW.SoLuong > sl THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Số lượng sách không đủ để mượn!';
    END IF;
    UPDATE Sach
    SET SoLuong = SoLuong - NEW.SoLuong
    WHERE MaSach = NEW.MaSach;
END$$
DELIMITER ;

-- Trigger: Trả sách -> cộng lại tồn kho
DELIMITER $$
CREATE TRIGGER trg_TraSach_RestoreTonKho
AFTER DELETE ON ChiTietMuonSach
FOR EACH ROW
BEGIN
    UPDATE Sach
    SET SoLuong = IFNULL(SoLuong,0) + IFNULL(OLD.SoLuong,0)
    WHERE MaSach = OLD.MaSach;
END$$
DELIMITER ;

-- Trigger: Cập nhật nhập sách
DELIMITER $$
CREATE TRIGGER trg_UpdateNhapSach_AdjustTonKho
AFTER UPDATE ON ChiTietNhapSach
FOR EACH ROW
BEGIN
    UPDATE Sach
    SET SoLuong = IFNULL(SoLuong,0) + IFNULL(NEW.SoLuong,0) - IFNULL(OLD.SoLuong,0)
    WHERE MaSach = NEW.MaSach;
END$$
DELIMITER ;

-- Trigger: Cập nhật mượn sách
DELIMITER $$
CREATE TRIGGER trg_UpdateMuonSach_AdjustTonKho
AFTER UPDATE ON ChiTietMuonSach
FOR EACH ROW
BEGIN
    UPDATE Sach
    SET SoLuong = IFNULL(SoLuong,0) - (IFNULL(NEW.SoLuong,0) - IFNULL(OLD.SoLuong,0))
    WHERE MaSach = NEW.MaSach;
END$$
DELIMITER ;
