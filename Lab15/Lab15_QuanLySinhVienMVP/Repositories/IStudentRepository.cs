using QuanLySinhVienMVP.Models;

namespace QuanLySinhVienMVP.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        bool Exists(string id);
        void Add(Student student);
        bool Remove(string id);
        List<Student> Search(string keyword);
    }
}
