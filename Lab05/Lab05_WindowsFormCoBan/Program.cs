using CourseRegistrationApp;

namespace Lab05_WindowsFormCoBan;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmDangKyKhoaHoc());
    }
}