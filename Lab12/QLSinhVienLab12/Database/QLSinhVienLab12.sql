USE master;
GO
IF DB_ID(N'QLSinhVienLab12') IS NOT NULL
BEGIN
    ALTER DATABASE QLSinhVienLab12 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSinhVienLab12;
END
GO
CREATE DATABASE QLSinhVienLab12;
GO
USE QLSinhVienLab12;
GO

/* ---------- 1. BANG ---------- */
CREATE TABLE LOP (
    MaLop  NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);

CREATE TABLE SINHVIEN (
    MaSV     NVARCHAR(20)  NOT NULL PRIMARY KEY,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    MaLop    NVARCHAR(20)  NOT NULL,
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);

CREATE TABLE MONHOC (
    MaMon    NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenMon   NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL CHECK (SoTinChi > 0)
);

CREATE TABLE KETQUA (
    MaSV   NVARCHAR(20)  NOT NULL,
    MaMon  NVARCHAR(20)  NOT NULL,
    Diem   FLOAT         NOT NULL,
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMon),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV)  REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC   FOREIGN KEY (MaMon) REFERENCES MONHOC(MaMon),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem >= 0 AND Diem <= 10)
);
GO

/* ---------- 2. DU LIEU MAU ---------- */
INSERT INTO LOP (MaLop, TenLop) VALUES
(N'CTK47A', N'Công nghệ thông tin K47A'),
(N'CTK47B', N'Công nghệ thông tin K47B'),
(N'CTK47C', N'Công nghệ thông tin K47C');

INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, MaLop) VALUES
(N'SV001', N'Nguyễn Văn An',    '2005-01-15', N'CTK47A'),
(N'SV002', N'Trần Thị Bình',    '2005-05-20', N'CTK47A'),
(N'SV003', N'Lê Minh Cường',    '2005-03-11', N'CTK47A'),
(N'SV005', N'Hoàng Gia Huy',    '2005-09-02', N'CTK47A'),
(N'SV006', N'Võ Ngọc Lan',      '2005-12-25', N'CTK47A'),
(N'SV004', N'Phạm Thanh Dung',  '2005-07-09', N'CTK47B'),
(N'SV007', N'Đặng Quốc Khánh',  '2005-02-14', N'CTK47B'),
(N'SV008', N'Bùi Thu Hà',       '2005-06-30', N'CTK47B'),
(N'SV009', N'Ngô Thanh Tùng',   '2005-04-18', N'CTK47C'),
(N'SV010', N'Đỗ Mai Phương',    '2005-11-08', N'CTK47C');

INSERT INTO MONHOC (MaMon, TenMon, SoTinChi) VALUES
(N'COMP1019', N'Lập trình trên Windows', 3),
(N'COMP1017', N'Cơ sở lập trình',        3),
(N'COMP1020', N'Cơ sở dữ liệu',          3);

-- Mot vai diem co san de thay ro nhanh UPDATE (con SV003, SV005, SV006 chua co diem -> nhanh INSERT)
INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) VALUES
(N'SV001', N'COMP1019', 8.5, N'Làm bài tốt'),
(N'SV002', N'COMP1019', 7.0, N''),
(N'SV001', N'COMP1017', 9.0, N'');
GO

/* ---------- 3. STORED PROCEDURE ---------- */
CREATE OR ALTER PROCEDURE sp_Lop_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLop, TenLop
    FROM LOP
    ORDER BY TenLop;
END;
GO

CREATE OR ALTER PROCEDURE sp_MonHoc_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaMon, TenMon, SoTinChi
    FROM MONHOC
    ORDER BY TenMon;
END;
GO

-- LEFT JOIN: SV chua co diem van xuat hien (Diem = NULL)
CREATE OR ALTER PROCEDURE sp_KetQua_GetByLopMon
    @MaLop NVARCHAR(20),
    @MaMon NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV,
           sv.HoTen,
           CAST(kq.Diem AS FLOAT)   AS Diem,     -- NULL neu chua co diem
           ISNULL(kq.GhiChu, N'')   AS GhiChu
    FROM SINHVIEN sv
    LEFT JOIN KETQUA kq
           ON sv.MaSV = kq.MaSV AND kq.MaMon = @MaMon
    WHERE sv.MaLop = @MaLop
    ORDER BY sv.MaSV;
END;
GO

-- UPSERT: co roi thi UPDATE, chua co thi INSERT
CREATE OR ALTER PROCEDURE sp_KetQua_Save
    @MaSV   NVARCHAR(20),
    @MaMon  NVARCHAR(20),
    @Diem   FLOAT,
    @GhiChu NVARCHAR(255) = N''
AS
BEGIN
    SET NOCOUNT ON;

    -- Lop bao ve thu 2 (ngoai validation o C#)
    IF @Diem IS NULL OR @Diem < 0 OR @Diem > 10
        THROW 50001, N'Điểm phải nằm trong khoảng từ 0 đến 10.', 1;

    IF EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = @MaSV AND MaMon = @MaMon)
    BEGIN
        UPDATE KETQUA
        SET Diem = @Diem, GhiChu = @GhiChu
        WHERE MaSV = @MaSV AND MaMon = @MaMon;
    END
    ELSE
    BEGIN
        INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu)
        VALUES (@MaSV, @MaMon, @Diem, @GhiChu);
    END
END;
GO