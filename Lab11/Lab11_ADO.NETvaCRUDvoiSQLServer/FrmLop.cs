using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Lab11_ADO.NETvaCRUDvoiSQLServer
{
    /// <summary>
    /// Form quản lý lớp học (bảng LOP trong SQL Server).
    /// Buổi 11: viết trực tiếp trong Form để thấy rõ luồng:
    /// Button Click -> câu SQL (có SqlParameter) -> DataGridView.
    /// </summary>
    public partial class FrmLop : Form
    {
        private readonly string connectionString = @"Data Source=TYTNHNG\SQLEXPRESS;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";
        private const string TieuDeThongBao = "Quản lý lớp học";

        // Mã lỗi SQL Server thường gặp
        private const int LoiTrungKhoaChinh1 = 2627;   // Violation of PRIMARY KEY constraint
        private const int LoiTrungKhoaChinh2 = 2601;   // Cannot insert duplicate key row
        private const int LoiKhoaNgoai = 547;          // FOREIGN KEY / REFERENCE constraint

        public FrmLop()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------------
        // F1: Mở Form -> tự động load danh sách lớp
        // ------------------------------------------------------------------
        private void FrmLop_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string sql = @"SELECT l.MaLop, l.TenLop,
                                      COUNT(sv.MaSV) AS SoSinhVien
                               FROM LOP l
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
                               GROUP BY l.MaLop, l.TenLop
                               ORDER BY l.MaLop";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);   // SqlDataAdapter tự mở/đóng kết nối
                    HienThiLenLuoi(dt);
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi load dữ liệu: " + ex.Message
                    + "\n\nKiểm tra lại connection string, tên database và SQL Server service.",
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>Gán DataTable cho DataGridView và đặt tiêu đề cột tiếng Việt.</summary>
        private void HienThiLenLuoi(DataTable dt)
        {
            dgvLop.DataSource = dt;

            // Tên cột (Name) vẫn là MaLop, TenLop, SoSinhVien để code đọc ô theo tên;
            // chỉ đổi HeaderText để hiển thị tiếng Việt có dấu.
            dgvLop.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvLop.Columns["TenLop"].HeaderText = "Tên lớp";
            dgvLop.Columns["SoSinhVien"].HeaderText = "Số sinh viên";
            dgvLop.Columns["SoSinhVien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLop.ClearSelection();   // không tô sẵn dòng đầu tiên
        }

        // ------------------------------------------------------------------
        // F2: Chọn một dòng -> đưa dữ liệu lên TextBox
        // ------------------------------------------------------------------
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // bấm vào dòng tiêu đề

            DataGridViewRow row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = Convert.ToString(row.Cells["MaLop"].Value);
            txtTenLop.Text = Convert.ToString(row.Cells["TenLop"].Value);

            // Khóa mã lớp: MaLop là khóa chính, không cho sửa; đồng thời đánh dấu "đã chọn lớp".
            txtMaLop.ReadOnly = true;
        }

        // ------------------------------------------------------------------
        // Các hàm kiểm tra / hỗ trợ (tách riêng để dễ đọc, dễ kiểm thử)
        // ------------------------------------------------------------------
        private bool DaChonLop()
        {
            return txtMaLop.ReadOnly;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                ThongBao("Vui lòng nhập mã lớp.", MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                ThongBao("Vui lòng nhập tên lớp.", MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return false;
            }

            return true;
        }

        private bool IsMaLopExists(string maLop)
        {
            string sql = "SELECT COUNT(*) FROM LOP WHERE MaLop = @ma";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = maLop;

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private int CountSinhVienByLop(string maLop)
        {
            string sql = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = maLop;

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTimKiem.Clear();
            txtMaLop.ReadOnly = false;   // mở khóa mã lớp để nhập lớp mới
            txtMaLop.Focus();
        }

        private void ThongBao(string noiDung, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(noiDung, TieuDeThongBao, MessageBoxButtons.OK, icon);
        }

        // ------------------------------------------------------------------
        // F3: Thêm lớp (không cho rỗng, không cho trùng mã)
        // ------------------------------------------------------------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (DaChonLop())
            {
                ThongBao("Bạn đang chọn một lớp có sẵn.\nHãy bấm \"Làm mới\" rồi nhập thông tin lớp mới.",
                    MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();

            try
            {
                if (IsMaLopExists(ma))
                {
                    ThongBao("Mã lớp \"" + ma + "\" đã tồn tại. Vui lòng nhập mã khác.", MessageBoxIcon.Warning);
                    txtMaLop.Focus();
                    return;
                }

                string sql = "INSERT INTO LOP(MaLop, TenLop, MaKhoa) VALUES(@ma, @ten, 'FIT')";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = ma;
                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ten;   // NVARCHAR -> tiếng Việt có dấu

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        ThongBao("Thêm lớp thành công.");
                        LoadData();
                        ClearInput();
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == LoiTrungKhoaChinh1 || ex.Number == LoiTrungKhoaChinh2)
            {
                ThongBao("Mã lớp đã tồn tại (vừa có người khác thêm).", MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi thêm lớp: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------------
        // F4: Sửa tên lớp theo mã lớp đang chọn
        // ------------------------------------------------------------------
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!DaChonLop())
            {
                ThongBao("Vui lòng chọn lớp cần sửa trong danh sách.", MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();

            try
            {
                string sql = "UPDATE LOP SET TenLop = @ten WHERE MaLop = @ma";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = ma;
                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ten;

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        ThongBao("Cập nhật lớp thành công.");
                        LoadData();
                        ClearInput();
                    }
                    else
                    {
                        ThongBao("Không tìm thấy lớp cần sửa (có thể đã bị xóa).", MessageBoxIcon.Warning);
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi cập nhật lớp: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------------
        // F5: Xóa lớp (hỏi xác nhận, không cho xóa lớp đang có sinh viên)
        // ------------------------------------------------------------------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!DaChonLop())
            {
                ThongBao("Vui lòng chọn lớp cần xóa trong danh sách.", MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaLop.Text.Trim();

            try
            {
                int soSinhVien = CountSinhVienByLop(ma);
                if (soSinhVien > 0)
                {
                    ThongBao("Không thể xóa lớp \"" + ma + "\" vì lớp đang có " + soSinhVien + " sinh viên.",
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa lớp \"" + ma + "\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                string sql = "DELETE FROM LOP WHERE MaLop = @ma";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = ma;

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        ThongBao("Xóa lớp thành công.");
                    }
                    else
                    {
                        ThongBao("Không tìm thấy lớp cần xóa (có thể đã bị xóa).", MessageBoxIcon.Warning);
                    }

                    LoadData();
                    ClearInput();
                }
            }
            catch (SqlException ex) when (ex.Number == LoiKhoaNgoai)
            {
                // Phòng trường hợp vừa có sinh viên được thêm vào lớp sau lúc kiểm tra -> khóa ngoại chặn lệnh DELETE
                ThongBao("Không thể xóa lớp vì dữ liệu đang được tham chiếu ở bảng khác.", MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi xóa lớp: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------------
        // F6: Tìm theo mã lớp hoặc tên lớp (LIKE + parameter)
        // ------------------------------------------------------------------
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Escape ký tự đặc biệt của LIKE để tìm đúng nghĩa đen: [ % _
                string keyword = txtTimKiem.Text.Trim()
                    .Replace("[", "[[]")
                    .Replace("%", "[%]")
                    .Replace("_", "[_]");

                string sql = @"SELECT l.MaLop, l.TenLop,
                                      COUNT(sv.MaSV) AS SoSinhVien
                               FROM LOP l
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
                               WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw
                               GROUP BY l.MaLop, l.TenLop
                               ORDER BY l.MaLop";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 200).Value = "%" + keyword + "%";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        HienThiLenLuoi(dt);

                        if (dt.Rows.Count == 0)
                        {
                            ThongBao("Không tìm thấy lớp nào phù hợp.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi tìm kiếm: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        // Nhấn Enter trong ô tìm kiếm = bấm nút Tìm kiếm
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTimKiem_Click(sender, EventArgs.Empty);
            }
        }

        // ------------------------------------------------------------------
        // F7: Làm mới -> xóa TextBox, mở khóa txtMaLop, load lại dữ liệu
        // ------------------------------------------------------------------
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }
    }
}
