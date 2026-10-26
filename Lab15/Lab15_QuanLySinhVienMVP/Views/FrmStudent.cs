using QuanLySinhVienMVP.Models;
using QuanLySinhVienMVP.Presenters;

namespace QuanLySinhVienMVP.Views
{
    /// <summary>View: chỉ nhận thao tác và gọi Presenter, không chứa nghiệp vụ.</summary>
    public partial class FrmStudent : Form, IStudentView
    {
        public StudentPresenter Presenter { private get; set; }

        public FrmStudent()
        {
            InitializeComponent();
        }

        // ===== Triển khai IStudentView =====
        public string StudentId => txtId.Text;
        public string FullName => txtName.Text;
        public string ScoreText => txtScore.Text;
        public string SearchKeyword => txtSearch.Text;

        public void ShowStudents(List<Student> students)
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = students;
            lblCount.Text = $"Tổng số: {students.Count} sinh viên";
        }

        public void ShowMessage(string message)
        {
            lblStatus.ForeColor = Color.DarkGreen;
            lblStatus.Text = message;
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            lblStatus.ForeColor = Color.Firebrick;
            lblStatus.Text = message;
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public bool Confirm(string message)
        {
            return MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void ClearInput()
        {
            txtId.Clear();
            txtName.Clear();
            txtScore.Clear();
            txtId.Focus();
        }

        // ===== Sự kiện: chỉ gọi Presenter =====
        private void FrmStudent_Load(object sender, EventArgs e)
        {
            Presenter.LoadStudents();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            Presenter.LoadStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Presenter.AddStudent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Presenter.DeleteStudent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Presenter.SearchStudents();
        }

        // Chỉ đổ dòng đang chọn lên ô nhập (thao tác giao diện thuần túy).
        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow?.DataBoundItem is Student s)
            {
                txtId.Text = s.Id;
                txtName.Text = s.FullName;
                txtScore.Text = s.Score.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
        }
    }
}
