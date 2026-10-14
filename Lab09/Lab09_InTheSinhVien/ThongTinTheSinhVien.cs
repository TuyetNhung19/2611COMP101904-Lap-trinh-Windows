using System.Globalization;

namespace InTheSinhVien
{
    /// <summary>
    /// Gom toan bo du lieu can ve len the sinh vien.
    /// Tach du lieu ra khoi control de cung 1 ham ve dung cho ca preview, in, luu PNG va in nhieu the.
    /// Cung la lop "entity" se duoc anh xa sang bang SQL Server o buoi sau.
    /// </summary>
    public class ThongTinTheSinhVien
    {
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string Lop { get; set; } = string.Empty;
        public string Khoa { get; set; } = string.Empty;
        public string KhoaHoc { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; } = DateTime.Today;
        public string GioiTinh { get; set; } = string.Empty;
        public Image? Anh { get; set; }

        /// <summary>Noi dung ma hoa vao QR code tren the.</summary>
        public string TaoNoiDungQr()
        {
            return $"MSSV: {MaSV}\n" +
                   $"Họ tên: {HoTen}\n" +
                   $"Ngày sinh: {NgaySinh.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}\n" +
                   $"Lớp: {Lop}";
        }
    }
}
