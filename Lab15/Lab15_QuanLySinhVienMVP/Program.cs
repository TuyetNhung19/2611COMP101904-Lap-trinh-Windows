using QuanLySinhVienMVP.Presenters;
using QuanLySinhVienMVP.Repositories;
using QuanLySinhVienMVP.Views;

namespace QuanLySinhVienMVP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Nơi duy nhất "ráp" 3 thành phần MVP lại với nhau.
            var view = new FrmStudent();
            var repository = new StudentRepository();
            view.Presenter = new StudentPresenter(view, repository);

            Application.Run(view);
        }
    }
}
