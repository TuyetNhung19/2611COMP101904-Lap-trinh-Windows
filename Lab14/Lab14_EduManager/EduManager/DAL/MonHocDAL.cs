using EduManager.Data;
using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.DAL
{
    /// <summary>
    /// Lop truy cap du lieu (Data Access Layer) cho bang MONHOC.
    /// Chi lam viec voi EF Core, KHONG kiem tra nghiep vu.
    /// Moi phuong thuc dung mot DbContext rieng (using) de tranh giu ket noi lau.
    /// </summary>
    public class MonHocDAL
    {
        /// <summary>Lay toan bo danh sach mon hoc, sap xep theo ma.</summary>
        public List<MonHoc> LayTatCa()
        {
            using var nguCanh = new EduManagerContext();
            return nguCanh.DanhSachMonHoc
                          .AsNoTracking()
                          .OrderBy(m => m.MaMonHoc)
                          .ToList();
        }

        /// <summary>Lay mot mon hoc theo ma; tra ve null neu khong ton tai.</summary>
        public MonHoc? LayTheoMa(string maMonHoc)
        {
            using var nguCanh = new EduManagerContext();
            return nguCanh.DanhSachMonHoc
                          .AsNoTracking()
                          .FirstOrDefault(m => m.MaMonHoc == maMonHoc);
        }

        /// <summary>Kiem tra ma mon hoc da ton tai trong CSDL hay chua.</summary>
        public bool KiemTraTonTai(string maMonHoc)
        {
            using var nguCanh = new EduManagerContext();
            return nguCanh.DanhSachMonHoc.Any(m => m.MaMonHoc == maMonHoc);
        }

        /// <summary>Tim kiem theo ma hoac ten mon hoc (chua tu khoa).</summary>
        public List<MonHoc> TimKiem(string tuKhoa)
        {
            using var nguCanh = new EduManagerContext();
            return nguCanh.DanhSachMonHoc
                          .AsNoTracking()
                          .Where(m => m.MaMonHoc.Contains(tuKhoa) || m.TenMonHoc.Contains(tuKhoa))
                          .OrderBy(m => m.MaMonHoc)
                          .ToList();
        }

        /// <summary>Them mot mon hoc moi vao CSDL.</summary>
        public void Them(MonHoc monHoc)
        {
            using var nguCanh = new EduManagerContext();
            nguCanh.DanhSachMonHoc.Add(monHoc);
            nguCanh.SaveChanges();
        }

        /// <summary>Cap nhat thong tin mon hoc. Tra ve false neu khong tim thay ma.</summary>
        public bool Sua(MonHoc monHoc)
        {
            using var nguCanh = new EduManagerContext();
            var monHocHienTai = nguCanh.DanhSachMonHoc.Find(monHoc.MaMonHoc);
            if (monHocHienTai == null)
            {
                return false;
            }

            monHocHienTai.TenMonHoc = monHoc.TenMonHoc;
            monHocHienTai.SoTinChi = monHoc.SoTinChi;
            monHocHienTai.TrangThai = monHoc.TrangThai;
            nguCanh.SaveChanges();
            return true;
        }

        /// <summary>Xoa mon hoc theo ma. Tra ve false neu khong tim thay ma.</summary>
        public bool Xoa(string maMonHoc)
        {
            using var nguCanh = new EduManagerContext();
            var monHocCanXoa = nguCanh.DanhSachMonHoc.Find(maMonHoc);
            if (monHocCanXoa == null)
            {
                return false;
            }

            nguCanh.DanhSachMonHoc.Remove(monHocCanXoa);
            nguCanh.SaveChanges();
            return true;
        }
    }
}
