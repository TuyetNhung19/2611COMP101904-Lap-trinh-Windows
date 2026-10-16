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
﻿USE EduManagerDB;
GO

-- 2 khoa
INSERT INTO KHOA (MaKhoa, TenKhoa, DienThoai) VALUES
('FIT',  N'Khoa Công nghệ Thông tin', '0281234567'),
('MATH', N'Khoa Toán - Tin học',      '0287654321');

-- 3 lớp (CNTT01, CNTT02 thuộc FIT; SPTIN01 thuộc MATH)
INSERT INTO LOP (MaLop, TenLop, MaKhoa) VALUES
('CNTT01',  N'Công nghệ thông tin 01', 'FIT'),
('CNTT02',  N'Công nghệ thông tin 02', 'FIT'),
('SPTIN01', N'Sư phạm Tin học 01',     'MATH');

-- 6 sinh viên (mỗi lớp 2 sinh viên)
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) VALUES
('SV001', N'Nguyễn Văn An',    '2005-02-10', N'Nam', 'CNTT01'),
('SV002', N'Trần Thị Bình',    '2005-08-21', N'Nữ',  'CNTT01'),
('SV003', N'Lê Minh Chi',      '2004-12-02', N'Nữ',  'CNTT02'),
('SV004', N'Phạm Quốc Dũng',   '2005-04-16', N'Nam', 'CNTT02'),
('SV005', N'Hoàng Gia Hân',    '2005-10-30', N'Nữ',  'SPTIN01'),
('SV006', N'Võ Thành Khang',   '2004-09-09', N'Nam', 'SPTIN01');

-- 4 môn học
INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES
('COMP1019', N'Lập trình trên Windows',        3),
('COMP1017', N'Lập trình cơ bản',              3),
('COMP1020', N'Cơ sở dữ liệu',                 3),
('COMP1044', N'Nhập môn Công nghệ phần mềm',   3);

-- 8 kết quả học tập
INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES
('SV001', 'COMP1019', 8.5),
('SV001', 'COMP1020', 7.5),
('SV002', 'COMP1019', 9.0),
('SV002', 'COMP1020', 8.0),
('SV003', 'COMP1019', 6.5),
('SV004', 'COMP1019', 7.0),
('SV005', 'COMP1017', 8.0),
('SV006', 'COMP1044', 7.8);

-- 2 tài khoản demo (VaiTro, TrangThai dùng giá trị mặc định nếu không ghi)
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, HoTen, VaiTro) VALUES
('admin', '123456', N'Quản trị viên',   'Admin'),
('gv01',  '123456', N'Giảng viên demo', 'User');
GO

-- Kiểm tra số dòng của từng bảng (KHOA=2, LOP=3, SINHVIEN=6, MONHOC=4, KETQUA=8, TAIKHOAN=2)
SELECT 'KHOA' AS Bang, COUNT(*) AS SoDong FROM KHOA
UNION ALL SELECT 'LOP',       COUNT(*) FROM LOP
UNION ALL SELECT 'SINHVIEN',  COUNT(*) FROM SINHVIEN
UNION ALL SELECT 'MONHOC',    COUNT(*) FROM MONHOC
UNION ALL SELECT 'KETQUA',    COUNT(*) FROM KETQUA
UNION ALL SELECT 'TAIKHOAN',  COUNT(*) FROM TAIKHOAN;
GO
