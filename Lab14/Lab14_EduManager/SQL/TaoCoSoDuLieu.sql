-- 1. Tao database neu chua co
IF DB_ID(N'EduManagerDB2') IS NULL
BEGIN
    CREATE DATABASE EduManagerDB2;
END
GO

USE EduManagerDB2;
GO

-- 2. Tao bang MONHOC neu chua co
IF OBJECT_ID(N'dbo.MONHOC', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MONHOC
    (
        MaMonHoc  NVARCHAR(10)  NOT NULL
                  CONSTRAINT PK_MONHOC PRIMARY KEY,
        TenMonHoc NVARCHAR(100) NOT NULL,
        SoTinChi  INT           NOT NULL
                  CONSTRAINT CK_MONHOC_SOTINCHI CHECK (SoTinChi BETWEEN 1 AND 6),
        TrangThai BIT           NOT NULL
                  CONSTRAINT DF_MONHOC_TRANGTHAI DEFAULT (1)
    );
END
GO

-- 3. Du lieu mau (chi them khi chua ton tai)
IF NOT EXISTS (SELECT 1 FROM dbo.MONHOC WHERE MaMonHoc = N'COMP1019')
    INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai)
    VALUES (N'COMP1019', N'Lập trình trên Windows', 3, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.MONHOC WHERE MaMonHoc = N'COMP1010')
    INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai)
    VALUES (N'COMP1010', N'Cơ sở dữ liệu', 3, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.MONHOC WHERE MaMonHoc = N'COMP1005')
    INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai)
    VALUES (N'COMP1005', N'Lập trình căn bản', 4, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.MONHOC WHERE MaMonHoc = N'MATH1001')
    INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai)
    VALUES (N'MATH1001', N'Giải tích 1', 3, 0);
GO

-- 4. Kiem tra ket qua
SELECT * FROM dbo.MONHOC ORDER BY MaMonHoc;
GO
