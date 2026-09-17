using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    /// Lớp quản lý toàn bộ nghiệp vụ trên danh sách sinh viên.
    public class QuanLySinhVien
    {
        private readonly List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        /// Thêm sinh viên. Trả về false nếu mã đã tồn tại.
        public bool Them(SinhVien sv)
        {
            if (TimTheoMa(sv.MaSinhVien) != null)
                return false;

            danhSachSinhVien.Add(sv);
            return true;
        }

        /// Sửa điểm trung bình theo mã sinh viên.
        public bool Sua(string maSinhVien, double diemMoi)
        {
            SinhVien sv = TimTheoMa(maSinhVien);
            if (sv == null)
                return false;

            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        ///Xóa sinh viên theo mã.
        public bool Xoa(string maSinhVien)
        {
            SinhVien sv = TimTheoMa(maSinhVien);
            if (sv == null)
                return false;

            danhSachSinhVien.Remove(sv);
            return true;
        }

        ///Tìm sinh viên theo mã (LINQ).
        public SinhVien TimTheoMa(string maSinhVien)
        {
            if (string.IsNullOrWhiteSpace(maSinhVien))
                return null;

            return danhSachSinhVien
                .FirstOrDefault(sv => sv.MaSinhVien.Equals(
                    maSinhVien, StringComparison.OrdinalIgnoreCase));
        }

        ///Tìm sinh viên có họ tên chứa từ khóa (LINQ).
        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return new List<SinhVien>();

            return danhSachSinhVien
                .Where(sv => sv.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        ///Sắp xếp danh sách theo điểm giảm dần (LINQ).
        public List<SinhVien> SapXepTheoDiem()
        {
            return danhSachSinhVien
                .OrderByDescending(sv => sv.DiemTrungBinh)
                .ToList();
        }

        /// Lọc sinh viên đạt (điểm >= 5) (LINQ).
        public List<SinhVien> LocSinhVienDat()
        {
            return danhSachSinhVien
                .Where(sv => sv.DiemTrungBinh >= 5)
                .ToList();
        }

        /// Lấy toàn bộ danh sách hiện có.
        public List<SinhVien> LayDanhSach()
        {
            return danhSachSinhVien;
        }
    }
}