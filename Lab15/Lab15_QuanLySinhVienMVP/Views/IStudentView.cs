using QuanLySinhVienMVP.Models;

namespace QuanLySinhVienMVP.Views
{
    /// <summary>
    /// Hợp đồng giữa Presenter và giao diện.
    /// Presenter chỉ biết interface này, không biết TextBox hay DataGridView.
    /// </summary>
    public interface IStudentView
    {
        // Dữ liệu người dùng nhập (Score để dạng chuỗi để Presenter bắt lỗi sai kiểu)
        string StudentId { get; }
        string FullName { get; }
        string ScoreText { get; }
        string SearchKeyword { get; }

        // Các thao tác Presenter yêu cầu View thực hiện
        void ShowStudents(List<Student> students);
        void ShowMessage(string message);
        void ShowError(string message);
        bool Confirm(string message);
        void ClearInput();
    }
}
