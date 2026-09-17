using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab03_QuanLySinhVienOOP
{
    class Program
    {
        private static readonly QuanLySinhVien quanLy = new QuanLySinhVien();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool thoat = false;
            while (!thoat)
            {
                HienThiMenu();
                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1": ThemSinhVien(); break;
                    case "2": XuatDanhSach(); break;
                    case "3": TimTheoMa(); break;
                    case "4": TimTheoTen(); break;
                    case "5": SuaDiem(); break;
                    case "6": XoaSinhVien(); break;
                    case "7": SapXepTheoDiem(); break;
                    case "8": LocSinhVienDat(); break;
                    case "0":
                        thoat = true;
                        Console.WriteLine("\nCam on ban da su dung chuong trinh. Tam biet!");
                        break;
                    default:
                        Console.WriteLine("\nLựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

                if (!thoat)
                {
                    Console.WriteLine("\nNhấn Enter để tiếp tục...");
                    Console.ReadLine();
                }
            }
        }

        private static void HienThiMenu()
        {
            Console.Clear();
            Console.WriteLine("===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim sinh vien theo ten");
            Console.WriteLine("5. Sua diem trung binh");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo diem giam dan");
            Console.WriteLine("8. Loc sinh vien dat");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon chuc nang: ");
        }

        // ----- 1. Thêm sinh viên -----
        private static void ThemSinhVien()
        {
            Console.WriteLine("\n--- THEM SINH VIEN ---");

            string maSV = NhapChuoiKhongRong("Nhập mã sinh viên: ");

            if (quanLy.TimTheoMa(maSV) != null)
            {
                Console.WriteLine($"Mã sinh viên '{maSV}' đã tồn tại!");
                return;
            }

            string hoTen = NhapChuoiKhongRong("Nhập họ tên: ");
            DateTime ngaySinh = NhapNgaySinh("Nhập ngày sinh (dd/MM/yyyy): ");
            string maLop = NhapChuoiKhongRong("Nhập mã lớp: ");
            double diem = NhapDiem("Nhập điểm trung bình (0-10): ");

            SinhVien sv;
            try
            {
                sv = new SinhVien(maSV, hoTen, ngaySinh, maLop, diem);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Phòng trường hợp DiemTrungBinh set trực tiếp gây lỗi
                Console.WriteLine($"Dữ liệu không hợp lệ: {ex.Message}");
                return;
            }

            if (quanLy.Them(sv))
                Console.WriteLine("Thêm sinh viên thành công!");
            else
                Console.WriteLine("Thêm sinh viên thất bại (mã đã tồn tại).");
        }

        // ----- 2. Xuất danh sách -----
        private static void XuatDanhSach()
        {
            Console.WriteLine("\n--- DANH SACH SINH VIEN ---");
            InBangSinhVien(quanLy.LayDanhSach());
        }

        // ----- 3. Tìm theo mã -----
        private static void TimTheoMa()
        {
            string maSV = NhapChuoiKhongRong("\nNhập mã sinh viên cần tìm: ");
            SinhVien sv = quanLy.TimTheoMa(maSV);

            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên có mã này.");
            }
            else
            {
                Console.WriteLine("Tìm thấy sinh viên:");
                InBangSinhVien(new List<SinhVien> { sv });
            }
        }

        // ----- 4. Tìm theo tên -----
        private static void TimTheoTen()
        {
            string tuKhoa = NhapChuoiKhongRong("\nNhập từ khóa họ tên: ");
            List<SinhVien> ketQua = quanLy.TimTheoTen(tuKhoa);

            Console.WriteLine($"Tìm thấy {ketQua.Count} sinh viên:");
            InBangSinhVien(ketQua);
        }

        // ----- 5. Sửa điểm -----
        private static void SuaDiem()
        {
            string maSV = NhapChuoiKhongRong("\nNhập mã sinh viên cần sửa điểm: ");
            SinhVien sv = quanLy.TimTheoMa(maSV);

            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên có mã này.");
                return;
            }

            double diemMoi = NhapDiem("Nhập điểm trung bình mới (0-10): ");
            quanLy.Sua(maSV, diemMoi);
            Console.WriteLine("Cập nhật điểm thành công!");
        }

        // ----- 6. Xóa sinh viên -----
        private static void XoaSinhVien()
        {
            string maSV = NhapChuoiKhongRong("\nNhập mã sinh viên cần xóa: ");

            if (quanLy.Xoa(maSV))
                Console.WriteLine("Xóa sinh viên thành công!");
            else
                Console.WriteLine("Không tìm thấy sinh viên có mã này.");
        }

        // ----- 7. Sắp xếp theo điểm giảm dần -----
        private static void SapXepTheoDiem()
        {
            Console.WriteLine("\n--- DANH SACH SAP XEP THEO DIEM GIAM DAN ---");
            InBangSinhVien(quanLy.SapXepTheoDiem());
        }

        // ----- 8. Lọc sinh viên đạt -----
        private static void LocSinhVienDat()
        {
            Console.WriteLine("\n--- DANH SACH SINH VIEN DAT (DIEM >= 5) ---");
            InBangSinhVien(quanLy.LocSinhVienDat());
        }


        private static void InBangSinhVien(List<SinhVien> ds)
        {
            if (ds == null || ds.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            Console.WriteLine(string.Format(
                "{0,-8} {1,-25} {2,-10} {3,-6} {4,-10}",
                "Mã SV", "Họ tên", "Lớp", "Điểm", "Xếp loại"));
            Console.WriteLine(new string('-', 65));

            foreach (SinhVien sv in ds)
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }

        /// Nhập chuỗi, bắt buộc không được rỗng.
        private static string NhapChuoiKhongRong(string thongBao)
        {
            string ketQua;
            do
            {
                Console.Write(thongBao);
                ketQua = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(ketQua))
                    Console.WriteLine("Giá trị không được để trống. Vui lòng nhập lại.");

            } while (string.IsNullOrEmpty(ketQua));

            return ketQua;
        }

        /// Nhập ngày sinh, không bị crash khi nhập sai định dạng.
        private static DateTime NhapNgaySinh(string thongBao)
        {
            DateTime ngaySinh;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out ngaySinh))
                {
                    return ngaySinh;
                }

                Console.WriteLine("Định dạng ngày không hợp lệ (ví dụ đúng: 01/01/2003). Vui lòng nhập lại.");
            }
        }

        /// Nhập điểm trung bình, không bị crash khi nhập sai kiểu, kiểm tra khoảng 0-10.
        private static double NhapDiem(string thongBao)
        {
            double diem;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out diem))
                {
                    if (diem >= 0 && diem <= 10)
                        return diem;

                    Console.WriteLine("Điểm không hợp lệ! Điểm phải nằm trong khoảng 0 đến 10.");
                }
                else
                {
                    Console.WriteLine("Vui lòng nhập một số hợp lệ (ví dụ: 8.2).");
                }
            }
        }
    }
}