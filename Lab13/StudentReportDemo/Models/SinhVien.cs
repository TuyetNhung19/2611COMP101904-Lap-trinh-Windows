namespace StudentReportDemo.Models
{
    public class SinhVien
    {
        public const double DiemDat = 5.0;
        public const string Dat = "Đạt";
        public const string KhongDat = "Không đạt";

        public string MaSV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string MaLop { get; set; } = "";
        public string TenLop { get; set; } = "";
        public double Diem { get; set; }

        // Thuộc tính chỉ đọc, tính từ Diem nên không bao giờ bị lệch dữ liệu
        public string KetQua => Diem >= DiemDat ? Dat : KhongDat;
    }
}
