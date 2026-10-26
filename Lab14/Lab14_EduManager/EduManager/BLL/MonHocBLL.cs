using EduManager.DAL;
using EduManager.Models;

namespace EduManager.BLL
{
    /// <summary>
    /// Lop nghiep vu (Business Logic Layer): kiem tra du lieu truoc khi goi DAL
    /// va chuyen cac loi ky thuat thanh thong bao de hieu cho nguoi dung.
    /// </summary>
    public class MonHocBLL
    {
        private const int DoDaiToiDaMaMonHoc = 10;
        private const int DoDaiToiDaTenMonHoc = 100;
        private const int SoTinChiToiThieu = 1;
        private const int SoTinChiToiDa = 6;

        private readonly MonHocDAL _monHocDAL = new MonHocDAL();

        /// <summary>Lay toan bo danh sach mon hoc.</summary>
        public KetQuaDanhSach LayDanhSach()
        {
            try
            {
                return new KetQuaDanhSach
                {
                    ThanhCong = true,
                    DuLieu = _monHocDAL.LayTatCa()
                };
            }
            catch (Exception loi)
            {
                return new KetQuaDanhSach { ThanhCong = false, ThongBao = TaoThongBaoLoiHeThong(loi) };
            }
        }

        /// <summary>Tim kiem mon hoc theo ma hoac ten. Tu khoa rong thi tra ve toan bo.</summary>
        public KetQuaDanhSach TimKiem(string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? string.Empty).Trim();
            if (tuKhoa.Length == 0)
            {
                return LayDanhSach();
            }

            try
            {
                var danhSach = _monHocDAL.TimKiem(tuKhoa);
                return new KetQuaDanhSach
                {
                    ThanhCong = true,
                    DuLieu = danhSach,
                    ThongBao = danhSach.Count == 0 ? "Không tìm thấy môn học phù hợp với từ khóa đã nhập." : string.Empty
                };
            }
            catch (Exception loi)
            {
                return new KetQuaDanhSach { ThanhCong = false, ThongBao = TaoThongBaoLoiHeThong(loi) };
            }
        }

        /// <summary>Them mon hoc moi sau khi kiem tra hop le va kiem tra trung ma.</summary>
        public KetQuaXuLy ThemMonHoc(MonHoc monHoc)
        {
            var thongBaoLoi = KiemTraDuLieu(monHoc);
            if (thongBaoLoi != null)
            {
                return KetQuaXuLy.ThatBaiVoi(thongBaoLoi);
            }

            try
            {
                if (_monHocDAL.KiemTraTonTai(monHoc.MaMonHoc))
                {
                    return KetQuaXuLy.ThatBaiVoi($"Mã môn học '{monHoc.MaMonHoc}' đã tồn tại. Vui lòng nhập mã khác.");
                }

                _monHocDAL.Them(monHoc);
                return KetQuaXuLy.ThanhCongVoi("Thêm môn học thành công.");
            }
            catch (Exception loi)
            {
                return KetQuaXuLy.ThatBaiVoi(TaoThongBaoLoiHeThong(loi));
            }
        }

        /// <summary>Cap nhat mon hoc sau khi kiem tra hop le va kiem tra ma co ton tai.</summary>
        public KetQuaXuLy SuaMonHoc(MonHoc monHoc)
        {
            var thongBaoLoi = KiemTraDuLieu(monHoc);
            if (thongBaoLoi != null)
            {
                return KetQuaXuLy.ThatBaiVoi(thongBaoLoi);
            }

            try
            {
                var daSua = _monHocDAL.Sua(monHoc);
                return daSua
                    ? KetQuaXuLy.ThanhCongVoi("Cập nhật môn học thành công.")
                    : KetQuaXuLy.ThatBaiVoi($"Không tìm thấy môn học có mã '{monHoc.MaMonHoc}' để cập nhật.");
            }
            catch (Exception loi)
            {
                return KetQuaXuLy.ThatBaiVoi(TaoThongBaoLoiHeThong(loi));
            }
        }

        /// <summary>Xoa mon hoc theo ma (viec hoi xac nhan do GUI thuc hien truoc khi goi).</summary>
        public KetQuaXuLy XoaMonHoc(string maMonHoc)
        {
            maMonHoc = (maMonHoc ?? string.Empty).Trim();
            if (maMonHoc.Length == 0)
            {
                return KetQuaXuLy.ThatBaiVoi("Vui lòng chọn môn học cần xóa.");
            }

            try
            {
                var daXoa = _monHocDAL.Xoa(maMonHoc);
                return daXoa
                    ? KetQuaXuLy.ThanhCongVoi("Xóa môn học thành công.")
                    : KetQuaXuLy.ThatBaiVoi($"Không tìm thấy môn học có mã '{maMonHoc}' để xóa.");
            }
            catch (Exception loi)
            {
                return KetQuaXuLy.ThatBaiVoi(TaoThongBaoLoiHeThong(loi));
            }
        }

        /// <summary>
        /// Kiem tra tinh hop le cua du lieu mon hoc (validation bat buoc).
        /// Tra ve thong bao loi, hoac null neu du lieu hop le. Ham cung chuan hoa (Trim) du lieu.
        /// </summary>
        private string? KiemTraDuLieu(MonHoc? monHoc)
        {
            if (monHoc == null)
            {
                return "Dữ liệu môn học không hợp lệ.";
            }

            monHoc.MaMonHoc = (monHoc.MaMonHoc ?? string.Empty).Trim();
            monHoc.TenMonHoc = (monHoc.TenMonHoc ?? string.Empty).Trim();

            if (monHoc.MaMonHoc.Length == 0)
            {
                return "Mã môn học không được để trống.";
            }

            if (monHoc.MaMonHoc.Length > DoDaiToiDaMaMonHoc)
            {
                return $"Mã môn học không được vượt quá {DoDaiToiDaMaMonHoc} ký tự.";
            }

            if (monHoc.TenMonHoc.Length == 0)
            {
                return "Tên môn học không được để trống.";
            }

            if (monHoc.TenMonHoc.Length > DoDaiToiDaTenMonHoc)
            {
                return $"Tên môn học không được vượt quá {DoDaiToiDaTenMonHoc} ký tự.";
            }

            if (monHoc.SoTinChi < SoTinChiToiThieu || monHoc.SoTinChi > SoTinChiToiDa)
            {
                return $"Số tín chỉ phải nằm trong khoảng từ {SoTinChiToiThieu} đến {SoTinChiToiDa}.";
            }

            return null;
        }

        /// <summary>Tao thong bao than thien cho cac loi ky thuat (mat ket noi, loi CSDL...).</summary>
        private static string TaoThongBaoLoiHeThong(Exception loi)
        {
            var chiTiet = loi.InnerException?.Message ?? loi.Message;
            return "Không thể thực hiện thao tác với cơ sở dữ liệu. "
                 + "Vui lòng kiểm tra SQL Server đã chạy và chuỗi kết nối đúng.\nChi tiết: " + chiTiet;
        }
    }
}
