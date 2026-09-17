using System;

namespace Lab03_QuanLySinhVienOOP
{
    /// Lớp SinhVien kế thừa từ Nguoi.
    /// Có property DiemTrungBinh tự kiểm tra giá trị hợp lệ (0 - 10).
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        private double diemTrungBinh;

        public double DiemTrungBinh
        {
            get => diemTrungBinh;
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Điểm trung bình chỉ được nhận giá trị từ 0 đến 10.");
                }
                diemTrungBinh = value;
            }
        }

        public SinhVien() : base()
        {
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh,
                         string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh; // đi qua property để được kiểm tra
        }

        /// Xếp loại học lực dựa trên điểm trung bình.
        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.5) return "Xuất sắc";
            if (DiemTrungBinh >= 7.0) return "Giỏi";
            if (DiemTrungBinh >= 5.5) return "Khá";
            if (DiemTrungBinh >= 4.0) return "Trung bình";
            return "Yếu";
        }

        public override string LayThongTin()
        {
            return string.Format(
                "{0,-8} {1,-25} {2,-10} {3,-6:0.00} {4,-10}",
                MaSinhVien, HoTen, MaLop, DiemTrungBinh, XepLoai());
        }
    }
}