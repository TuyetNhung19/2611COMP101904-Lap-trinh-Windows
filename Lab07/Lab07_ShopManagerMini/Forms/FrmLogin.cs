using ShopManagerMini.Data;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>Form đăng nhập. Hiển thị bằng ShowDialog() và trả về DialogResult.OK khi thành công.</summary>
    public partial class FrmLogin : Form
    {
        /// <summary>User đăng nhập thành công. Program.cs đọc property này để truyền sang FrmMain.</summary>
        public User? LoggedInUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra bỏ trống
            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm tài khoản khớp trong DataStore
            User? user = DataStore.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            LoggedInUser = user;
            DialogResult = DialogResult.OK;   // tự đóng form khi dùng ShowDialog()
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
