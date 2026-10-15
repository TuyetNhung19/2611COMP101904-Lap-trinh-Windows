USE EduManagerDB;
GO

-- =====================================================================
-- PHẦN A: TRUY VẤN CƠ BẢN (CRUD)
-- =====================================================================

-- 1. Liệt kê toàn bộ sinh viên
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;

-- 2. Liệt kê sinh viên kèm tên lớp và tên khoa (JOIN 3 bảng)
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP  l ON sv.MaLop  = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa  = k.MaKhoa;

-- 3. Tìm sinh viên theo một phần họ tên (LIKE)
--    N'%An%' : họ tên có chứa chữ "An" ở bất kỳ vị trí nào
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%An%'
ORDER BY HoTen ASC;

-- 4. Liệt kê sinh viên theo mã lớp (ví dụ lớp CNTT01)
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';

-- 5. Cập nhật họ tên (hoặc lớp) của một sinh viên
--    LUÔN có WHERE, nếu không sẽ sửa TOÀN BỘ sinh viên!
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An Updated'
WHERE MaSV = 'SV001';

-- Xem lại kết quả sau khi cập nhật
SELECT MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV001';

-- (Có thể chuyển lớp thay vì đổi tên, ví dụ: )
-- UPDATE SINHVIEN SET MaLop = 'CNTT02' WHERE MaSV = 'SV001';

-- 6. Xóa sinh viên CHƯA có dữ liệu điểm
--    Bước 6a: thêm một sinh viên tạm chưa có điểm để thử xóa
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV099', N'Sinh viên tạm xóa', '2005-05-05', N'Nam', 'CNTT01');

--    Bước 6b: xóa, điều kiện NOT EXISTS đảm bảo chỉ xóa khi chưa có điểm
DELETE FROM SINHVIEN
WHERE MaSV = 'SV099'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV099');

--    Bước 6c: thử xóa SV001 (đã có điểm) -> không xóa dòng nào (0 rows affected)
DELETE FROM SINHVIEN
WHERE MaSV = 'SV001'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV001');

--    Bước 6d: kiểm tra lại, vẫn còn 6 sinh viên, SV099 đã biến mất
SELECT MaSV, HoTen FROM SINHVIEN;

-- =====================================================================
-- PHẦN B: JOIN VÀ THỐNG KÊ
-- =====================================================================

-- 7. Liệt kê điểm của từng sinh viên theo từng môn
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC   mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;

-- 8. Tính điểm trung bình của từng sinh viên (AVG + GROUP BY)
SELECT sv.MaSV, sv.HoTen, AVG(kq.Diem) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen;

-- 9. Thống kê số sinh viên theo từng lớp
--    LEFT JOIN để lớp chưa có sinh viên vẫn hiện (số lượng = 0)
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop;

-- 10. Liệt kê các lớp có từ 2 sinh viên trở lên
--     HAVING lọc SAU khi đã GROUP BY (WHERE không dùng được với COUNT)
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2;

-- =====================================================================
-- PHẦN C: KIỂM THỬ RÀNG BUỘC (các lệnh dưới đây PHẢI BÁO LỖI)
-- Dùng TRY...CATCH để in thông báo lỗi ra tab Messages mà không dừng script.
-- Nếu bạn muốn thấy lỗi đỏ gốc của SQL Server, chỉ cần chạy riêng lệnh INSERT.
-- =====================================================================

-- 11. Thêm sinh viên vào lớp không tồn tại (CNTT99) -> lỗi khóa ngoại FK_SINHVIEN_LOP
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
    PRINT N'CẢNH BÁO: lệnh chạy được, ràng buộc khóa ngoại chưa hoạt động!';
END TRY
BEGIN CATCH
    PRINT N'11. ĐÚNG - Bị chặn: ' + ERROR_MESSAGE();
END CATCH;

-- 12. Nhập điểm ngoài khoảng 0..10 (điểm = 12) -> lỗi CHECK CK_KETQUA_Diem
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem)
    VALUES ('SV001', 'COMP1017', 12);
    PRINT N'CẢNH BÁO: lệnh chạy được, ràng buộc CHECK điểm chưa hoạt động!';
END TRY
BEGIN CATCH
    PRINT N'12. ĐÚNG - Bị chặn: ' + ERROR_MESSAGE();
END CATCH;

-- ---------------------------------------------------------------------
-- Test bổ sung (không bắt buộc nhưng nên có để được điểm cao)
-- ---------------------------------------------------------------------

-- 13. Giới tính không hợp lệ ('Khác') -> lỗi CK_SINHVIEN_GioiTinh
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV998', N'Sinh viên giới tính lỗi', '2005-01-01', N'Khác', 'CNTT01');
    PRINT N'CẢNH BÁO: ràng buộc giới tính chưa hoạt động!';
END TRY
BEGIN CATCH
    PRINT N'13. ĐÚNG - Bị chặn: ' + ERROR_MESSAGE();
END CATCH;

-- 14. Trùng khóa chính (SV001 đã tồn tại) -> lỗi PRIMARY KEY
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV001', N'Trùng mã', '2005-01-01', N'Nam', 'CNTT01');
    PRINT N'CẢNH BÁO: khóa chính chưa hoạt động!';
END TRY
BEGIN CATCH
    PRINT N'14. ĐÚNG - Bị chặn: ' + ERROR_MESSAGE();
END CATCH;

-- 15. Số tín chỉ = 0 -> lỗi CK_MONHOC_SoTinChi
BEGIN TRY
    INSERT INTO MONHOC (MaMH, TenMH, SoTinChi)
    VALUES ('COMP9999', N'Môn lỗi', 0);
    PRINT N'CẢNH BÁO: ràng buộc tín chỉ chưa hoạt động!';
END TRY
BEGIN CATCH
    PRINT N'15. ĐÚNG - Bị chặn: ' + ERROR_MESSAGE();
END CATCH;
GO
