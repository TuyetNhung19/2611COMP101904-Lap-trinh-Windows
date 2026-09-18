using System;

namespace QuanLyNhanVien
{
    // LỚP CON: NhanVienKinhDoanh
    public class NhanVienKinhDoanh : NhanVien
    {
        private double doanhSo;

        public double DoanhSo
        {
            get { return doanhSo; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Doanh số phải >= 0.");
                doanhSo = value;
            }
        }

        public const double TY_LE_HOA_HONG = 0.05;

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + TY_LE_HOA_HONG * DoanhSo;
        }

        public override string LoaiNhanVien => "Nhân viên kinh doanh";

        public override string ThongTinBoSung => $"Doanh số: {DoanhSo:N0}";
    }
}