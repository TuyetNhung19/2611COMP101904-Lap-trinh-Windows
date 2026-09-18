using System;

namespace QuanLyNhanVien
{
    // LỚP CON: NhanVienThoiVu
    // Lương = Số giờ làm x Lương theo giờ (KHÔNG dùng LuongCoBan để tính)
    public class NhanVienThoiVu : NhanVien
    {
        private double soGioLam;
        private double luongTheoGio;

        public double SoGioLam
        {
            get { return soGioLam; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số giờ làm phải >= 0.");
                soGioLam = value;
            }
        }

        public double LuongTheoGio
        {
            get { return luongTheoGio; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Lương theo giờ phải >= 0.");
                luongTheoGio = value;
            }
        }

        // LuongCoBan = 0 vì lớp này không dùng lương cơ bản để tính lương thực tế.
        public NhanVienThoiVu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, 0)
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override string LoaiNhanVien => "Nhân viên thời vụ";

        public override string ThongTinBoSung => $"Giờ: {SoGioLam:N1}, Lương/giờ: {LuongTheoGio:N0}";
    }
}