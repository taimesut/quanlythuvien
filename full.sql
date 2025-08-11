-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: thu_vien
-- ------------------------------------------------------
-- Server version	8.4.5

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `chitietmuonsach`
--

DROP TABLE IF EXISTS `chitietmuonsach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitietmuonsach` (
  `MaSach` int NOT NULL,
  `MaPhieuMuon` int NOT NULL,
  `SoLuong` int DEFAULT NULL,
  PRIMARY KEY (`MaSach`,`MaPhieuMuon`),
  KEY `MaPhieuMuon` (`MaPhieuMuon`),
  CONSTRAINT `chitietmuonsach_ibfk_1` FOREIGN KEY (`MaSach`) REFERENCES `sach` (`MaSach`),
  CONSTRAINT `chitietmuonsach_ibfk_2` FOREIGN KEY (`MaPhieuMuon`) REFERENCES `phieumuon` (`MaPhieuMuon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitietmuonsach`
--

LOCK TABLES `chitietmuonsach` WRITE;
/*!40000 ALTER TABLE `chitietmuonsach` DISABLE KEYS */;
INSERT INTO `chitietmuonsach` VALUES (1,1,2),(1,4,10),(2,1,1),(2,5,4),(3,2,1),(4,3,1),(6,4,100),(6,6,1);
/*!40000 ALTER TABLE `chitietmuonsach` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_update_soluong_sach_after_insert` AFTER INSERT ON `chitietmuonsach` FOR EACH ROW BEGIN
    UPDATE sach
    SET SoLuong = SoLuong - NEW.SoLuong
    WHERE MaSach = NEW.MaSach;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `docgia`
--

DROP TABLE IF EXISTS `docgia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `docgia` (
  `MaDocGia` int NOT NULL AUTO_INCREMENT,
  `HoVaTen` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NgaySinh` date DEFAULT NULL,
  `DiaChi` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `GioiTinh` varchar(10) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `SoDienThoai` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`MaDocGia`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `docgia`
--

LOCK TABLES `docgia` WRITE;
/*!40000 ALTER TABLE `docgia` DISABLE KEYS */;
INSERT INTO `docgia` VALUES (1,'Nguyễn Văn A','1990-05-15','Hà Nội','Nam','0901234567'),(2,'Trần Thị B','1995-09-20','TP HCM','Nữ','0902345678'),(3,'Lê Văn C','1988-12-01','Đà Nẵng','Nam','0903456789');
/*!40000 ALTER TABLE `docgia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhanvien`
--

DROP TABLE IF EXISTS `nhanvien`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhanvien` (
  `MaNhanVien` int NOT NULL AUTO_INCREMENT,
  `TenTaiKhoan` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MatKhau` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `HoVaTen` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `NgaySinh` date DEFAULT NULL,
  `DiaChi` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `GioiTinh` varchar(10) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `SoDienThoai` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ChucVu` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`MaNhanVien`),
  UNIQUE KEY `TenTaiKhoan` (`TenTaiKhoan`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhanvien`
--

LOCK TABLES `nhanvien` WRITE;
/*!40000 ALTER TABLE `nhanvien` DISABLE KEYS */;
INSERT INTO `nhanvien` VALUES (1,'1','1','Nguyễn Quản Lý','1985-07-10','Hà Nội','Nam','0911111111','Nhân viên'),(2,'thuthu1','123456','Trần Thủ Thư','1992-03-25','TP HCM','Nữ','0922222222','Nhân viên'),(4,'a','1','1','2025-08-11','1','Nữ','1','Admin'),(5,'2','2','1','2025-08-11','1','Nam','2','Nhân viên');
/*!40000 ALTER TABLE `nhanvien` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phieumuon`
--

DROP TABLE IF EXISTS `phieumuon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phieumuon` (
  `MaPhieuMuon` int NOT NULL AUTO_INCREMENT,
  `MaNhanVien` int DEFAULT NULL,
  `MaDocGia` int DEFAULT NULL,
  `NgayMuon` date DEFAULT NULL,
  `NgayTra` date DEFAULT NULL,
  `HanTra` date DEFAULT NULL,
  `TrangThai` int DEFAULT '0',
  PRIMARY KEY (`MaPhieuMuon`),
  KEY `MaNhanVien` (`MaNhanVien`),
  KEY `MaDocGia` (`MaDocGia`),
  CONSTRAINT `phieumuon_ibfk_1` FOREIGN KEY (`MaNhanVien`) REFERENCES `nhanvien` (`MaNhanVien`),
  CONSTRAINT `phieumuon_ibfk_2` FOREIGN KEY (`MaDocGia`) REFERENCES `docgia` (`MaDocGia`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phieumuon`
--

LOCK TABLES `phieumuon` WRITE;
/*!40000 ALTER TABLE `phieumuon` DISABLE KEYS */;
INSERT INTO `phieumuon` VALUES (1,1,1,'2025-08-01',NULL,'2025-08-08',0),(2,2,2,'2025-08-02',NULL,'2025-08-09',0),(3,1,3,'2025-08-05',NULL,'2025-08-12',0),(4,1,1,'2025-08-11',NULL,'2025-08-12',0),(5,1,1,'2025-08-11',NULL,'2025-08-12',0),(6,1,1,'2025-08-12',NULL,'2025-08-19',0);
/*!40000 ALTER TABLE `phieumuon` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_update_trangthai_after_update` AFTER UPDATE ON `phieumuon` FOR EACH ROW BEGIN
    -- Kiểm tra trạng thái cũ khác 0 và trạng thái mới là 0
    IF OLD.TrangThai <> 0 AND NEW.TrangThai = 0 THEN
        -- Cộng lại số lượng sách từ chi tiết phiếu mượn vào bảng sach
        UPDATE sach s
        JOIN chitietmuonsach ct ON s.MaSach = ct.MaSach
        JOIN phieumuon pm ON pm.MaPhieuMuon = ct.MaPhieuMuon
        SET s.SoLuong = s.SoLuong + ct.SoLuong
        WHERE pm.MaPhieuMuon = NEW.MaPhieuMuon;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `quydinh`
--

DROP TABLE IF EXISTS `quydinh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quydinh` (
  `MaQuyDinh` int NOT NULL AUTO_INCREMENT,
  `SoNgayMuonToiDa` int DEFAULT NULL,
  `SoSachMuonToiDa` int DEFAULT NULL,
  PRIMARY KEY (`MaQuyDinh`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quydinh`
--

LOCK TABLES `quydinh` WRITE;
/*!40000 ALTER TABLE `quydinh` DISABLE KEYS */;
INSERT INTO `quydinh` VALUES (1,7,5);
/*!40000 ALTER TABLE `quydinh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sach`
--

DROP TABLE IF EXISTS `sach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sach` (
  `MaSach` int NOT NULL AUTO_INCREMENT,
  `NhaXuatBan` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `MaTheLoai` int DEFAULT NULL,
  `TacGia` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `TenSach` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NamXuatBan` int DEFAULT NULL,
  `SoLuong` int DEFAULT '0',
  `Anh` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`MaSach`),
  KEY `MaTheLoai` (`MaTheLoai`),
  CONSTRAINT `sach_ibfk_1` FOREIGN KEY (`MaTheLoai`) REFERENCES `theloai` (`MaTheLoai`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sach`
--

LOCK TABLES `sach` WRITE;
/*!40000 ALTER TABLE `sach` DISABLE KEYS */;
INSERT INTO `sach` VALUES (1,'NXB Trẻ',1,'Stephen Hawking','Lược Sử Thời Gian',2015,0,'https://res.cloudinary.com/demfjaknk/image/upload/v1754900926/hifbbvjyanpx0p8opuze.png'),(2,'NXB Văn Học',2,'Nguyễn Nhật Ánh','Mắt Biếc',2018,5,'https://res.cloudinary.com/demfjaknk/image/upload/v1754900926/hifbbvjyanpx0p8opuze.png'),(3,'NXB Lao Động',6,'Napoleon Hill','Think and Grow Rich',2020,7,'https://res.cloudinary.com/demfjaknk/image/upload/v1754930753/fwvrmbnyhueuceh6svqm.png'),(4,'NXB CNTT',4,'Robert C. Martin','Clean Code',2019,3,'https://res.cloudinary.com/demfjaknk/image/upload/v1754900926/hifbbvjyanpx0p8opuze.png'),(5,'NXB Tâm Lý',5,'Dale Carnegie','Đắc Nhân Tâm',2017,8,'https://res.cloudinary.com/demfjaknk/image/upload/v1754900926/hifbbvjyanpx0p8opuze.png'),(6,'NXB Kim Đồng',6,'Tô Hoài','Dế Mèn Phiêu Lưu Ký',2010,20,'https://res.cloudinary.com/demfjaknk/image/upload/v1754900926/hifbbvjyanpx0p8opuze.png'),(7,'NXB Kim Đồng',5,'Tô Hoài','Dế Mèn Phiêu Lưu Ký dsadas',2010,202,'https://res.cloudinary.com/demfjaknk/image/upload/v1754930774/i4x2kq2mchqp7vd0kbhi.png');
/*!40000 ALTER TABLE `sach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `theloai`
--

DROP TABLE IF EXISTS `theloai`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `theloai` (
  `MaTheLoai` int NOT NULL AUTO_INCREMENT,
  `TenTheLoai` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`MaTheLoai`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `theloai`
--

LOCK TABLES `theloai` WRITE;
/*!40000 ALTER TABLE `theloai` DISABLE KEYS */;
INSERT INTO `theloai` VALUES (1,'Khoa học'),(2,'Văn học'),(3,'Kinh tế'),(4,'CNTT'),(5,'Tâm lý'),(6,'Thiếu nhi');
/*!40000 ALTER TABLE `theloai` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'thu_vien'
--

--
-- Dumping routines for database 'thu_vien'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-12  0:09:22
