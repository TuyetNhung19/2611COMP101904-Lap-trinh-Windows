-- ---------------------------------------------------------------------
-- BƯỚC 1: Tạo database
-- ---------------------------------------------------------------------
USE master;
GO

-- Nếu database đã tồn tại thì đóng mọi kết nối rồi xóa để chạy lại từ đầu
IF DB_ID('EduManagerDB') IS NOT NULL
BEGIN
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE EduManagerDB;
END
GO

CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

-- ---------------------------------------------------------------------
-- BƯỚC 2: Tạo bảng theo thứ tự "bảng cha trước, bảng con sau"
-- ---------------------------------------------------------------------

-- Bảng KHOA: thông tin khoa (bảng cha của LOP)
CREATE TABLE KHOA (
    MaKhoa    VARCHAR(20)   PRIMARY KEY,          -- Khóa chính
    TenKhoa   NVARCHAR(100) NOT NULL,             -- NVARCHAR để lưu tiếng Việt có dấu
    DienThoai VARCHAR(15)   NULL
);
GO

-- Bảng LOP: mỗi lớp thuộc một khoa
CREATE TABLE LOP (
    MaLop   VARCHAR(20)   PRIMARY KEY,
    TenLop  NVARCHAR(100) NOT NULL,
    MaKhoa  VARCHAR(20)   NOT NULL,
    CONSTRAINT FK_LOP_KHOA
        FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)   -- Khóa ngoại -> KHOA
);
GO

-- Bảng SINHVIEN: mỗi sinh viên thuộc một lớp
CREATE TABLE SINHVIEN (
    MaSV     VARCHAR(20)   PRIMARY KEY,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    GioiTinh NVARCHAR(10)  NOT NULL,
    MaLop    VARCHAR(20)   NOT NULL,
    -- Giới tính chỉ nhận 'Nam' hoặc 'Nữ'
    CONSTRAINT CK_SINHVIEN_GioiTinh
        CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    -- Khóa ngoại -> LOP
    CONSTRAINT FK_SINHVIEN_LOP
        FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

-- Bảng MONHOC: thông tin môn học
CREATE TABLE MONHOC (
    MaMH     VARCHAR(20)   PRIMARY KEY,
    TenMH    NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL,
    -- Số tín chỉ phải lớn hơn 0
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

-- Bảng KETQUA: điểm của sinh viên theo môn
-- Khóa chính ghép (MaSV, MaMH): một sinh viên chỉ có 1 điểm cho 1 môn
CREATE TABLE KETQUA (
    MaSV VARCHAR(20)   NOT NULL,
    MaMH VARCHAR(20)   NOT NULL,
    Diem DECIMAL(4,2)  NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    -- Điểm phải nằm trong khoảng 0 đến 10
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),
    -- Hai khóa ngoại
    CONSTRAINT FK_KETQUA_SINHVIEN
        FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC
        FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);
GO

-- Bảng TAIKHOAN: tài khoản đăng nhập demo (không có khóa ngoại)
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50)   PRIMARY KEY,
    MatKhau     VARCHAR(100)  NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL DEFAULT 'User',  -- giá trị mặc định
    TrangThai   BIT           NOT NULL DEFAULT 1        -- 1 = đang hoạt động
);
GO

-- Kiểm tra nhanh: liệt kê các bảng vừa tạo (phải có 6 dòng)
SELECT name AS TenBang FROM sys.tables ORDER BY name;
GO
