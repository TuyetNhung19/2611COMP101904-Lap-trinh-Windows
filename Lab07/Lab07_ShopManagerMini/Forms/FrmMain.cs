using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>Form chính dạng MDI Parent.</summary>
    public partial class FrmMain : Form
    {
        private User _currentUser;

        // Constructor không tham số chỉ để Visual Studio Designer hiển thị được form
        public FrmMain() : this(new User())
        {
        }

        // Nhận thông tin user từ FrmLogin qua constructor
        public FrmMain(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            ShowUserInfo();
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void ShowUserInfo()
        {
            lblUser.Text = $"Người dùng: {_currentUser.FullName}";
            lblRole.Text = $"Vai trò: {_currentUser.Role}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Mở Form con MDI. Nếu Form cùng loại đã mở thì kích hoạt Form cũ, không tạo mới.
        /// </summary>
        private void OpenChildForm<T>() where T : Form, new()
        {
            foreach (Form child in MdiChildren)
            {
                if (child is T)
                {
                    if (child.WindowState == FormWindowState.Minimized)
                        child.WindowState = FormWindowState.Normal;
                    child.Activate();
                    return;
                }
            }

            T newForm = new T();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void mnuProduct_Click(object sender, EventArgs e) => OpenChildForm<FrmProduct>();
        private void mnuCustomer_Click(object sender, EventArgs e) => OpenChildForm<FrmCustomer>();
        private void mnuAbout_Click(object sender, EventArgs e) => OpenChildForm<FrmAbout>();

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();   // đi qua FormClosing để hỏi xác nhận
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Chỉ hỏi khi người dùng chủ động đóng (nút X hoặc menu Thoát)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?",
                    "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn đăng xuất?",
                "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            // Đóng toàn bộ Form con rồi ẩn Form chính
            foreach (Form child in MdiChildren) child.Close();
            Hide();

            using (var login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    _currentUser = login.LoggedInUser!;
                    ShowUserInfo();
                    Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
