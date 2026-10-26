using EduManager.Models;

namespace EduManager.BLL
{
    /// <summary>
    /// Ket qua xu ly nghiep vu tra ve cho GUI (thanh cong/that bai + thong bao).
    /// </summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; } = string.Empty;

        public static KetQuaXuLy ThanhCongVoi(string thongBao)
            => new KetQuaXuLy { ThanhCong = true, ThongBao = thongBao };

        public static KetQuaXuLy ThatBaiVoi(string thongBao)
            => new KetQuaXuLy { ThanhCong = false, ThongBao = thongBao };
    }

    /// <summary>
    /// Ket qua xu ly co kem danh sach mon hoc (dung cho tai danh sach, tim kiem).
    /// </summary>
    public class KetQuaDanhSach : KetQuaXuLy
    {
        public List<MonHoc> DuLieu { get; set; } = new List<MonHoc>();
    }
}
