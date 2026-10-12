using ShopManagerMini.Forms;

namespace ShopManagerMini
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Hiện form đăng nhập trước (modal). Chỉ khi đăng nhập OK mới mở form chính.
            using (var login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Truyền thông tin user sang FrmMain qua constructor
                    Application.Run(new FrmMain(login.LoggedInUser!));
                }
            }
        }
    }
}
