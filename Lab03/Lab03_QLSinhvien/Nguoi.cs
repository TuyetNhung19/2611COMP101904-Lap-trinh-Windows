using System;

namespace Lab03_QuanLySinhVienOOP
{
    /// Lớp cha, đại diện cho một con người nói chung.
    /// SinhVien sẽ kế thừa từ lớp này.
    public class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public Nguoi()
        {
        }

        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        public virtual string LayThongTin()
        {
            return $"Họ tên: {HoTen} - Ngày sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }
}