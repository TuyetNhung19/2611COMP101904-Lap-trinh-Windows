using System.Globalization;
using QuanLySinhVienMVP.Models;
using QuanLySinhVienMVP.Repositories;
using QuanLySinhVienMVP.Views;

namespace QuanLySinhVienMVP.Presenters
{
    /// <summary>
    /// Xử lý nghiệp vụ: kiểm tra dữ liệu, gọi Repository, yêu cầu View hiển thị.
    /// Không dùng TextBox/DataGridView/MessageBox trực tiếp.
    /// </summary>
    public class StudentPresenter
    {
        private readonly IStudentView _view;
        private readonly IStudentRepository _repo;

        public StudentPresenter(IStudentView view, IStudentRepository repo)
        {
            _view = view;
            _repo = repo;
        }

        /// <summary>Tải toàn bộ danh sách.</summary>
        public void LoadStudents()
        {
            _view.ShowStudents(_repo.GetAll());
        }

        /// <summary>Thêm sinh viên mới sau khi kiểm tra rỗng, sai kiểu, trùng mã.</summary>
        public void AddStudent()
        {
            string id = (_view.StudentId ?? "").Trim();
            string name = (_view.FullName ?? "").Trim();
            string scoreText = (_view.ScoreText ?? "").Trim();

            if (id == "" || name == "" || scoreText == "")
            {
                _view.ShowError("Vui lòng nhập đầy đủ Mã, Họ tên và Điểm.");
                return;
            }

            if (!TryParseScore(scoreText, out double score))
            {
                _view.ShowError("Điểm phải là số hợp lệ (ví dụ: 8.5).");
                return;
            }

            if (score < 0 || score > 10)
            {
                _view.ShowError("Điểm phải nằm trong khoảng từ 0 đến 10.");
                return;
            }

            if (_repo.Exists(id))
            {
                _view.ShowError($"Mã '{id}' đã tồn tại. Vui lòng nhập mã khác.");
                return;
            }

            _repo.Add(new Student(id, name, score));
            RefreshList();
            _view.ClearInput();
            _view.ShowMessage($"Đã thêm sinh viên '{name}' thành công.");
        }

        /// <summary>Xóa sinh viên theo mã đang nhập/chọn trên View.</summary>
        public void DeleteStudent()
        {
            string id = (_view.StudentId ?? "").Trim();

            if (id == "")
            {
                _view.ShowError("Vui lòng nhập hoặc chọn mã sinh viên cần xóa.");
                return;
            }

            if (!_repo.Exists(id))
            {
                _view.ShowError($"Không tìm thấy sinh viên có mã '{id}'.");
                return;
            }

            if (!_view.Confirm($"Bạn có chắc muốn xóa sinh viên có mã '{id}'?"))
                return;

            _repo.Remove(id);
            RefreshList();
            _view.ClearInput();
            _view.ShowMessage($"Đã xóa sinh viên có mã '{id}'.");
        }

        /// <summary>Tìm theo mã hoặc tên (không phân biệt hoa thường, dấu).</summary>
        public void SearchStudents()
        {
            var result = _repo.Search(_view.SearchKeyword);
            _view.ShowStudents(result);

            if (string.IsNullOrWhiteSpace(_view.SearchKeyword))
                return;

            if (result.Count == 0)
                _view.ShowMessage("Không tìm thấy sinh viên phù hợp.");
            else
                _view.ShowMessage($"Tìm thấy {result.Count} sinh viên phù hợp.");
        }

        // Hiển thị lại danh sách, giữ nguyên bộ lọc tìm kiếm hiện tại.
        private void RefreshList()
        {
            _view.ShowStudents(_repo.Search(_view.SearchKeyword));
        }

        // Chấp nhận cả "8.5" và "8,5".
        private static bool TryParseScore(string text, out double score)
        {
            return double.TryParse(text.Replace(',', '.'),
                                   NumberStyles.Float,
                                   CultureInfo.InvariantCulture,
                                   out score);
        }
    }
}
