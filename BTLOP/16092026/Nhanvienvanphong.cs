using System;

namespace QuanLyNhanVien
{
    // LỚP CON: NhanVienVanPhong
    public class NhanVienVanPhong : NhanVien
    {
        private int soNgayLamViec;

        public int SoNgayLamViec
        {
            get { return soNgayLamViec; }
            set
            {
                if (value < 0 || value > 31)
                    throw new ArgumentException("Số ngày làm việc phải trong khoảng 0 - 31.");
                soNgayLamViec = value;
            }
        }

        public const double DON_GIA_NGAY = 200000;

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + SoNgayLamViec * DON_GIA_NGAY;
        }

        public override string LoaiNhanVien => "Nhân viên văn phòng";

        public override string ThongTinBoSung => $"Số ngày LV: {SoNgayLamViec}";
    }
}