using System.Reflection;
using System.Runtime.InteropServices;

namespace ShopManagerMini.Forms
{

    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            // Lấy phiên bản từ chính ứng dụng (Assembly) thay vì gõ cứng
            Version? version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = $"Phiên bản: {version?.ToString(3) ?? "1.0.0"}";

            // Hiển thị nền tảng đang chạy, ví dụ ".NET 8.0.x"
            lblFramework.Text = $"Nền tảng: C# WinForms, {RuntimeInformation.FrameworkDescription}";
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }
    }
}