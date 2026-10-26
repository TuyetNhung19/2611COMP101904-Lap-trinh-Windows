using EduManager.Data;
using EduManager.GUI;

namespace EduManager
{
    internal static class Program
    {
        /// <summary>Diem vao chinh cua ung dung.</summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (!KhoiTaoCoSoDuLieu())
            {
                return;
            }

            Application.Run(new FrmMonHoc());
        }

        /// <summary>
        /// Dam bao co so du lieu ton tai (neu chua chay script SQL thi EF tu tao).
        /// Tra ve false neu khong ket noi duoc SQL Server.
        /// </summary>
        private static bool KhoiTaoCoSoDuLieu()
        {
            try
            {
                using var nguCanh = new EduManagerContext();
                nguCanh.Database.EnsureCreated();
                return true;
            }
            catch (Exception loi)
            {
                MessageBox.Show(
                    "Không thể kết nối tới SQL Server.\n" +
                    "Hãy kiểm tra SQL Server đang chạy và chuỗi kết nối trong Data/EduManagerContext.cs.\n\n" +
                    "Chi tiết: " + loi.Message,
                    "Lỗi kết nối cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
