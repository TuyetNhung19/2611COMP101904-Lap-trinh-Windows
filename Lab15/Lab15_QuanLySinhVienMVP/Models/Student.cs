namespace QuanLySinhVienMVP.Models
{
    /// <summary>Model: chỉ chứa dữ liệu của một sinh viên.</summary>
    public class Student
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public double Score { get; set; }

        public Student() { }

        public Student(string id, string fullName, double score)
        {
            Id = id;
            FullName = fullName;
            Score = score;
        }
    }
}
