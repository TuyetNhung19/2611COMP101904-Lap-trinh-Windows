using System.Globalization;
using System.Text;
using QuanLySinhVienMVP.Models;

namespace QuanLySinhVienMVP.Repositories
{
    /// <summary>Lưu dữ liệu trong bộ nhớ bằng List&lt;Student&gt;, có sẵn dữ liệu mẫu.</summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>
        {
            new Student("SV001", "Nguyễn Văn An",   8.5),
            new Student("SV002", "Trần Thị Bình",   9.0),
            new Student("SV003", "Lê Hoàng Cường",  7.25),
            new Student("SV004", "Phạm Minh Đức",   6.5),
            new Student("SV005", "Võ Thị Lan Anh",  9.5),
            new Student("SV006", "Đặng Quốc Huy",   5.75)
        };

        public List<Student> GetAll()
        {
            return _students.ToList();
        }

        public bool Exists(string id)
        {
            return _students.Any(s => string.Equals(s.Id, id, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public bool Remove(string id)
        {
            var found = _students.FirstOrDefault(s =>
                string.Equals(s.Id, id, StringComparison.OrdinalIgnoreCase));
            return found != null && _students.Remove(found);
        }

        public List<Student> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            string key = Normalize(keyword);
            return _students
                .Where(s => Normalize(s.Id).Contains(key) || Normalize(s.FullName).Contains(key))
                .ToList();
        }

        // Bỏ dấu + chữ thường để tìm "duc" vẫn ra "Đức".
        private static string Normalize(string text)
        {
            string decomposed = (text ?? "").Trim().ToLowerInvariant()
                                            .Replace('đ', 'd')
                                            .Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in decomposed)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
