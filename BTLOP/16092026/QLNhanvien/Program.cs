using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    // CHƯƠNG TRÌNH CHÍNH
    class Program
    {
        static List<NhanVien> danhSach = new List<NhanVien>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            NhapDanhSachNhanVien();

            int luaChon;
            do
            {
                HienThiMenu();
                luaChon = DocSoNguyen("Chọn chức năng: ");
                try
                {
                    switch (luaChon)
                    {
                        case 1:
                            XuatDanhSach();
                            break;
                        case 2:
                            TimNhanVienTheoMa();
                            break;
                        case 3:
                            TimNhanVienLuongCaoNhat();
                            break;
                        case 4:
                            TinhTongLuongCongTy();
                            break;
                        case 0:
                            Console.WriteLine("Đã thoát chương trình. Tạm biệt!");
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi phát sinh ngoài dự kiến để chương trình không bị crash
                    Console.WriteLine("Đã có lỗi xảy ra: " + ex.Message);
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\nNhấn Enter để tiếp tục...");
                    Console.ReadLine();
                }
            } while (luaChon != 0);
        }

        // ----- Nhập danh sách nhân viên (>= 5 nhân viên, chọn loại) -----
        static void NhapDanhSachNhanVien()
        {
            Console.WriteLine("===== NHẬP DANH SÁCH NHÂN VIÊN =====");
            int soLuong = DocSoNguyen("Nhập số lượng nhân viên cần thêm: ", 5);

            for (int i = 1; i <= soLuong; i++)
            {
                Console.WriteLine("\n--- Nhân viên thứ {0} ---", i);
                Console.WriteLine("Chọn loại nhân viên:");
                Console.WriteLine("  1. Nhân viên văn phòng");
                Console.WriteLine("  2. Nhân viên kinh doanh");
                Console.WriteLine("  3. Nhân viên thời vụ");
                int loai = DocSoNguyen("Loại (1/2/3): ", 1, 3);

                NhanVien nv = null;
                try
                {
                    string maNV = DocChuoiKhongRong("Mã nhân viên: ");

                    // Kiểm tra trùng mã nhân viên
                    if (danhSach.Any(x => x.MaNV.Equals(maNV, StringComparison.OrdinalIgnoreCase)))
                        throw new ArgumentException($"Mã nhân viên '{maNV}' đã tồn tại.");

                    string hoTen = DocChuoiKhongRong("Họ tên: ");

                    switch (loai)
                    {
                        case 1:
                            {
                                double luongCoBan = DocSoThucKhongAm("Lương cơ bản (>= 0): ");
                                int soNgay = DocSoNguyen("Số ngày làm việc (0-31): ", 0, 31);
                                nv = new NhanVienVanPhong(maNV, hoTen, luongCoBan, soNgay);
                                break;
                            }
                        case 2:
                            {
                                double luongCoBan = DocSoThucKhongAm("Lương cơ bản (>= 0): ");
                                double doanhSo = DocSoThucKhongAm("Doanh số (>= 0): ");
                                nv = new NhanVienKinhDoanh(maNV, hoTen, luongCoBan, doanhSo);
                                break;
                            }
                        case 3:
                            {
                                double soGio = DocSoThucKhongAm("Số giờ làm (>= 0): ");
                                double luongGio = DocSoThucKhongAm("Lương theo giờ (>= 0): ");
                                nv = new NhanVienThoiVu(maNV, hoTen, soGio, luongGio);
                                break;
                            }
                    }

                    danhSach.Add(nv);
                    Console.WriteLine("=> Thêm nhân viên thành công!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message + " -> Vui lòng nhập lại nhân viên này.");
                    i--; // yêu cầu nhập lại cho đủ số lượng
                }
            }
        }

        static void HienThiMenu()
        {
            Console.WriteLine();
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("1. Xuất danh sách nhân viên");
            Console.WriteLine("2. Tìm nhân viên theo mã");
            Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
            Console.WriteLine("4. Tính tổng lương công ty phải trả");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("===========================");
        }

        // ----- 1. Xuất danh sách: dùng đa hình HienThiThongTin() -----
        static void XuatDanhSach()
        {
            Console.WriteLine("\n===== DANH SÁCH NHÂN VIÊN =====");
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            // In tiêu đề bảng 1 lần duy nhất - vì mọi loại nhân viên giờ dùng
            // chung 1 định dạng cột (xem NhanVien.HienThiThongTin), bảng sẽ luôn thẳng hàng
            // dù danh sách có trộn lẫn nhiều loại nhân viên khác nhau.
            Console.WriteLine("{0,-8} | {1,-20} | {2,-20} | {3,-28} | {4,15}",
                "Mã NV", "Họ tên", "Loại", "Thông tin thêm", "Lương");
            Console.WriteLine(new string('-', 100));

            foreach (NhanVien nv in danhSach)
            {
                nv.HienThiThongTin(); // Đa hình: gọi đúng phiên bản override theo loại thực tế
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Tổng số nhân viên: {0}", danhSach.Count);
        }

        // ----- 2. Tìm theo mã -----
        static void TimNhanVienTheoMa()
        {
            string ma = DocChuoiKhongRong("\nNhập mã nhân viên cần tìm: ");

            NhanVien ketQua = danhSach.FirstOrDefault(
                nv => nv.MaNV.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (ketQua != null)
            {
                Console.WriteLine("Đã tìm thấy:");
                ketQua.HienThiThongTin(); // Đa hình
            }
            else
            {
                Console.WriteLine("Không tìm thấy nhân viên có mã: " + ma);
            }
        }

        // ----- 3. Tìm nhân viên lương cao nhất -----
        // Không dùng if/switch để phân loại; chỉ dùng TinhLuong() (đa hình) để so sánh.
        // Thuật toán này KHÔNG cần sửa dù có thêm loại nhân viên mới (VD: NhanVienThoiVu).
        static void TimNhanVienLuongCaoNhat()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("\nDanh sách trống.");
                return;
            }

            NhanVien nvCaoNhat = danhSach[0];
            foreach (NhanVien nv in danhSach)
            {
                if (nv.TinhLuong() > nvCaoNhat.TinhLuong()) // đa hình: mỗi loại tự tính lương riêng
                {
                    nvCaoNhat = nv;
                }
            }

            Console.WriteLine("\nNhân viên có lương cao nhất là:");
            nvCaoNhat.HienThiThongTin(); // đa hình
        }

        // ----- 4. Tính tổng lương công ty -----
        // Chỉ dựa vào TinhLuong() (đa hình), không cần biết là loại nhân viên nào.
        // Thuật toán này KHÔNG cần sửa dù có thêm loại nhân viên mới.
        static void TinhTongLuongCongTy()
        {
            double tongLuong = 0;
            foreach (NhanVien nv in danhSach)
            {
                tongLuong += nv.TinhLuong(); // đa hình
            }
            Console.WriteLine("\nTổng lương công ty phải trả: {0:N0} VNĐ", tongLuong);
        }

        // ==========================================================
        // Các hàm hỗ trợ nhập dữ liệu an toàn
        // ==========================================================
        static int DocSoNguyen(string thongBao, int min = int.MinValue, int max = int.MaxValue)
        {
            int giaTri;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (int.TryParse(input, out giaTri) && giaTri >= min && giaTri <= max)
                {
                    return giaTri;
                }
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập số nguyên từ {0} đến {1}.", min, max);
            }
        }

        static double DocSoThuc(string thongBao)
        {
            double giaTri;
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (double.TryParse(input, out giaTri))
                {
                    return giaTri;
                }
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại số.");
            }
        }

        // Đọc số thực và bắt buộc không âm - dùng chung cho lương, doanh số, số giờ...
        static double DocSoThucKhongAm(string thongBao)
        {
            while (true)
            {
                double giaTri = DocSoThuc(thongBao);
                if (giaTri >= 0) return giaTri;
                Console.WriteLine("Giá trị không được âm. Vui lòng nhập lại.");
            }
        }

        // Đọc chuỗi và bắt buộc không được để trống
        static string DocChuoiKhongRong(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();
                Console.WriteLine("Giá trị không được để trống. Vui lòng nhập lại.");
            }
        }
    }
}