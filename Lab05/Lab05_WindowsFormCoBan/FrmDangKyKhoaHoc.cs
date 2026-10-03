using System.Globalization;

namespace CourseRegistrationApp
{
    public partial class FrmDangKyKhoaHoc : Form
    {
        // Bảng học phí / tháng của từng khóa học (giữ nguyên thứ tự thêm vào ComboBox)
        private readonly Dictionary<string, decimal> _hocPhiKhoaHoc = new()
        {
            { "C# WinForms cơ bản",      800000 },
            { "SQL Server cơ bản",       700000 },
            { "Web Frontend cơ bản",     750000 },
            { "Lập trình Python cơ bản", 650000 }
        };

        private static readonly CultureInfo ViVN = new("vi-VN");

        public FrmDangKyKhoaHoc()
        {
            InitializeComponent();
        }

        // ===================== 5.1. FORM LOAD =====================
        private void FrmDangKyKhoaHoc_Load(object sender, EventArgs e)
        {
            // Nạp danh sách khóa học
            cboKhoaHoc.Items.Clear();
            foreach (string tenKhoa in _hocPhiKhoaHoc.Keys)
            {
                cboKhoaHoc.Items.Add(tenKhoa);
            }

            // Giá trị mặc định: chưa chọn khóa học, hình thức Online
            cboKhoaHoc.SelectedIndex = -1;
            radOnline.Checked = true;

            numSoThang.Maximum = 12;

            // Ngày sinh không được lớn hơn ngày hiện tại
            dtpNgaySinh.MaxDate = DateTime.Today;
            dtpNgaySinh.Value = DateTime.Today;

            CapNhatTheoKhoaHoc();   // số tháng = 0, tiền = 0
            txtHoTen.Focus();
        }

        // ===================== TÍNH HỌC PHÍ =====================
        private bool DaChonKhoaHoc()
        {
            return _hocPhiKhoaHoc.ContainsKey(cboKhoaHoc.Text);
        }

        private decimal LayHocPhiMotThang()
        {
            return _hocPhiKhoaHoc.TryGetValue(cboKhoaHoc.Text, out decimal hocPhi) ? hocPhi : 0;
        }

        private decimal TinhHocPhi()
        {
            decimal hocPhi = LayHocPhiMotThang();
            int soThang = (int)numSoThang.Value;
            decimal tongTien = hocPhi * soThang;

            lblTongTien.Text = DinhDangTien(tongTien);
            return tongTien;
        }

        private static string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("N0", ViVN) + " VNĐ";
        }

        // Đồng bộ số tháng và học phí theo việc đã chọn khóa học hay chưa
        private void CapNhatTheoKhoaHoc()
        {
            if (DaChonKhoaHoc())
            {
                numSoThang.Minimum = 1;     // nếu đang là 0 sẽ tự nhảy lên 1
                numSoThang.Enabled = true;
            }
            else
            {
                numSoThang.Minimum = 0;
                numSoThang.Value = 0;       // chưa chọn khóa học thì số tháng = 0
                numSoThang.Enabled = false;
            }

            TinhHocPhi();
        }

        // Đổi khóa học (chọn hoặc xóa trống) -> cập nhật số tháng và học phí
        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTheoKhoaHoc();
        }

        // Đổi số tháng -> tính lại học phí
        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            TinhHocPhi();
        }

        // ===================== VALIDATION =====================
        private bool KiemTraDuLieu()
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            string sdt = txtSoDienThoai.Text.Trim();
            if (sdt == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }

            // Số điện thoại phải gồm đúng 10 chữ số
            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }

            // Chưa chọn khóa học (hoặc nhập tên không có trong danh sách)
            if (!DaChonKhoaHoc())
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return false;
            }

            return true;
        }

        // ===================== 5.2. NÚT ĐĂNG KÝ =====================
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
            string nhanEmail = chkNhanEmail.Checked ? "Có" : "Không";
            int soThang = (int)numSoThang.Value;
            decimal tongTien = TinhHocPhi();

            string phieu =
                $"Họ tên: {txtHoTen.Text.Trim()}\n" +
                $"Số điện thoại: {txtSoDienThoai.Text.Trim()}\n" +
                $"Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}\n" +
                $"Khóa học: {cboKhoaHoc.Text}\n" +
                $"Hình thức học: {hinhThuc}\n" +
                $"Số tháng: {soThang}\n" +
                $"Tổng tiền: {DinhDangTien(tongTien)}\n" +
                $"Nhận email: {nhanEmail}";

            MessageBox.Show(phieu, "Phiếu đăng ký",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===================== 5.3. NÚT LÀM MỚI =====================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            chkNhanEmail.Checked = false;
            cboKhoaHoc.SelectedIndex = -1;
            radOnline.Checked = true;

            CapNhatTheoKhoaHoc();   // số tháng về 0, tiền về 0
            txtHoTen.Focus();
        }

        // ===================== 5.4. NÚT THOÁT =====================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}