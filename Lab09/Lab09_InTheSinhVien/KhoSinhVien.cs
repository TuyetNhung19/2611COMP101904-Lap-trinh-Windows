namespace InTheSinhVien
{
    /// <summary>
    /// Giao dien kho luu tru sinh vien. Hien tai cai dat bang List&lt;T&gt; (trong bo nho).
    /// Buoi sau chi can viet them lop KhoSinhVienSql : IKhoSinhVien (SQL Server)
    /// va thay dong khoi tao trong form, khong phai sua giao dien.
    /// </summary>
    public interface IKhoSinhVien
    {
        int SoLuong { get; }
        IReadOnlyList<ThongTinTheSinhVien> TatCa();
        ThongTinTheSinhVien? Tim(string maSV);
        bool Them(ThongTinTheSinhVien sv);
        bool Sua(string maCu, ThongTinTheSinhVien sv);
        bool Xoa(string maSV);
    }

    /// <summary>
    /// Luu danh sach sinh vien bang List&lt;ThongTinTheSinhVien&gt;.
    /// Moi phan tu giu mot ban sao rieng cua anh de khong phu thuoc PictureBox.
    /// </summary>
    public class KhoSinhVienList : IKhoSinhVien, IDisposable
    {
        private readonly List<ThongTinTheSinhVien> _danhSach = new List<ThongTinTheSinhVien>();

        public int SoLuong => _danhSach.Count;

        public IReadOnlyList<ThongTinTheSinhVien> TatCa() => _danhSach;

        public ThongTinTheSinhVien? Tim(string maSV)
        {
            return _danhSach.Find(x => string.Equals(x.MaSV, maSV, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Tra ve false neu ma sinh vien da ton tai.</summary>
        public bool Them(ThongTinTheSinhVien sv)
        {
            if (Tim(sv.MaSV) != null) return false;
            _danhSach.Add(SaoChep(sv));
            return true;
        }

        /// <summary>Cap nhat sinh vien co ma cu = maCu. False neu khong tim thay hoac ma moi bi trung.</summary>
        public bool Sua(string maCu, ThongTinTheSinhVien sv)
        {
            int viTri = _danhSach.FindIndex(x => string.Equals(x.MaSV, maCu, StringComparison.OrdinalIgnoreCase));
            if (viTri < 0) return false;

            ThongTinTheSinhVien? trung = Tim(sv.MaSV);
            if (trung != null && !ReferenceEquals(trung, _danhSach[viTri])) return false;

            _danhSach[viTri].Anh?.Dispose();
            _danhSach[viTri] = SaoChep(sv);
            return true;
        }

        public bool Xoa(string maSV)
        {
            ThongTinTheSinhVien? sv = Tim(maSV);
            if (sv == null) return false;
            sv.Anh?.Dispose();
            return _danhSach.Remove(sv);
        }

        private static ThongTinTheSinhVien SaoChep(ThongTinTheSinhVien sv)
        {
            return new ThongTinTheSinhVien
            {
                MaSV = sv.MaSV,
                HoTen = sv.HoTen,
                Lop = sv.Lop,
                Khoa = sv.Khoa,
                KhoaHoc = sv.KhoaHoc,
                NgaySinh = sv.NgaySinh,
                GioiTinh = sv.GioiTinh,
                Anh = sv.Anh == null ? null : new Bitmap(sv.Anh)
            };
        }

        public void Dispose()
        {
            foreach (ThongTinTheSinhVien sv in _danhSach) sv.Anh?.Dispose();
            _danhSach.Clear();
        }
    }
}
