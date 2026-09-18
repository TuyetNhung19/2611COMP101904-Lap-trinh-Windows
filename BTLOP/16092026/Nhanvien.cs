using System;

namespace QuanLyNhanVien
{
    // LỚP CHA: NhanVien
    public class NhanVien
    {
        private string maNV;
        private string hoTen;
        private double luongCoBan;

        public string MaNV
        {
            get { return maNV; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã nhân viên không được để trống.");
                maNV = value.Trim();
            }
        }

        public string HoTen
        {
            get { return hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được để trống.");
                hoTen = value.Trim();
            }
        }

        // Lương cơ bản: cho phép >= 0 (thay vì > 0) để lớp NhanVienThoiVu
        // không cần truyền giá trị "giả" khi không dùng lương cơ bản để tính lương.
        public double LuongCoBan
        {
            get { return luongCoBan; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Lương cơ bản không được âm.");
                luongCoBan = value;
            }
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        // Đa hình: các lớp con override để tính lương & hiển thị riêng 
        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        // Loại nhân viên (dùng để hiển thị) - lớp con override lại tên loại
        public virtual string LoaiNhanVien => "Nhân viên";

        // Thông tin bổ sung riêng của từng loại (VD: số ngày LV, doanh số, số giờ...)
        // Lớp con override để trả về chuỗi mô tả phù hợp.
        public virtual string ThongTinBoSung => "-";

        public virtual void HienThiThongTin()
        {
            Console.WriteLine("{0,-8} | {1,-20} | {2,-20} | {3,-28} | {4,15:N0} VNĐ",
                MaNV, HoTen, LoaiNhanVien, ThongTinBoSung, TinhLuong());
        }
    }
}