using System.Data;
using System.Globalization;
using System.Text;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        // Tên cột của grid (đặt tên rõ ràng, tránh "magic string" rải rác)
        private const string ColMaSV = "colMaSV";
        private const string ColHoTen = "colHoTen";
        private const string ColDiem = "colDiem";
        private const string ColGhiChu = "colGhiChu";

        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
        private readonly BindingSource ketQuaSource = new BindingSource();

        // Lớp/môn tại thời điểm TẢI danh sách. Lưu theo 2 biến này, không lấy từ ComboBox lúc bấm Lưu.
        private string currentMaLop = "";
        private string currentMaMon = "";

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
            ConfigureGrid();
        }

        // =====================================================================
        //  FORM LOAD / CLOSING
        // =====================================================================
        private void FrmNhapDiemTheoLop_Load(object? sender, EventArgs e)
        {
            btnLuuTatCa.Enabled = false;
            try
            {
                LoadComboBox();
                SetStatus("Sẵn sàng. Hãy chọn lớp, môn học rồi bấm \"Tải danh sách\".");
            }
            catch (Exception ex)
            {
                btnTaiDanhSach.Enabled = false;
                SetStatus("Không kết nối được database.", true);
                MessageBox.Show(
                    "Không thể tải danh sách lớp/môn học.\nKiểm tra SQL Server và ServerName trong Database.cs.\n\n" + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateThongKe();
        }

        private void FrmNhapDiemTheoLop_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && HasUnsavedChanges())
            {
                DialogResult result = MessageBox.Show(
                    "Bạn còn thay đổi chưa lưu. Thoát sẽ mất các thay đổi này. Vẫn thoát?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) e.Cancel = true;
            }
        }

        // =====================================================================
        //  BINDING COMBOBOX
        // =====================================================================
        private void LoadComboBox()
        {
            // Lớp
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.DisplayMember = "TenLop";      // người dùng thấy
            cboLop.ValueMember = "MaLop";       // giá trị thật dùng để truy vấn/lưu
            cboLop.DataSource = ketQuaDAL.GetLop();

            // Môn học: thêm cột tính toán "MaMon - TenMon" cho dễ nhìn
            DataTable monHoc = ketQuaDAL.GetMonHoc();
            monHoc.Columns.Add("HienThi", typeof(string), "MaMon + ' - ' + TenMon");

            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.DisplayMember = "HienThi";
            cboMonHoc.ValueMember = "MaMon";
            cboMonHoc.DataSource = monHoc;
            // Đặt DisplayMember/ValueMember TRƯỚC DataSource để tránh hiện "System.Data.DataRowView"
        }

        // =====================================================================
        //  CẤU HÌNH GRID (binding qua BindingSource, cột đặt tên rõ ràng)
        // =====================================================================
        private void ConfigureGrid()
        {
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.AllowUserToAddRows = false;          // ẩn dòng trống cuối
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.AllowUserToResizeRows = false;
            dgvKetQua.RowHeadersVisible = true;            // để hiện biểu tượng lỗi của dòng
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvKetQua.Columns.Clear();
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColMaSV,
                DataPropertyName = "MaSV",
                HeaderText = "MSSV",
                ReadOnly = true,
                FillWeight = 15
            });
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColHoTen,
                DataPropertyName = "HoTen",
                HeaderText = "Họ và tên",
                ReadOnly = true,
                FillWeight = 35
            });
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColDiem,
                DataPropertyName = "Diem",
                HeaderText = "Điểm (0 - 10)",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "0.0#",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColGhiChu,
                DataPropertyName = "GhiChu",
                HeaderText = "Ghi chú",
                FillWeight = 35,
                MaxInputLength = 255          // khớp NVARCHAR(255)
            });

            dgvKetQua.DataSource = ketQuaSource;               // grid <- BindingSource <- DataTable

            dgvKetQua.CellValidating += dgvKetQua_CellValidating;
            dgvKetQua.CellParsing += dgvKetQua_CellParsing;
            dgvKetQua.CellFormatting += dgvKetQua_CellFormatting;
            dgvKetQua.DataError += dgvKetQua_DataError;
            dgvKetQua.CellEndEdit += dgvKetQua_CellEndEdit;
            ketQuaSource.ListChanged += (s, e) => UpdateThongKe();
        }

        // =====================================================================
        //  TẢI DANH SÁCH
        // =====================================================================
        private void btnTaiDanhSach_Click(object? sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";

            if (maLop.Length == 0 || maMon.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (HasUnsavedChanges())
            {
                DialogResult result = MessageBox.Show(
                    "Bạn còn thay đổi chưa lưu. Tải lại sẽ mất các thay đổi này. Tiếp tục?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);

                txtTimKiem.Clear();                    // bỏ bộ lọc cũ
                ketQuaSource.DataSource = table;       // grid tự cập nhật

                currentMaLop = maLop;
                currentMaMon = maMon;
                btnLuuTatCa.Enabled = table.Rows.Count > 0;

                SetStatus($"Đã tải {table.Rows.Count} sinh viên - Lớp: {cboLop.Text} - Môn: {cboMonHoc.Text}");
            }
            catch (Exception ex)
            {
                SetStatus("Tải danh sách thất bại.", true);
                MessageBox.Show("Không thể tải danh sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // =====================================================================
        //  LƯU TẤT CẢ (validate -> transaction)
        // =====================================================================
        private void btnLuuTatCa_Click(object? sender, EventArgs e)
        {
            if (ketQuaSource.DataSource is not DataTable table || table.Rows.Count == 0 || currentMaMon.Length == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để lưu. Hãy tải danh sách trước.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Đẩy giá trị ô đang sửa về DataTable
            if (!dgvKetQua.EndEdit())
            {
                MessageBox.Show("Ô đang nhập chưa hợp lệ. Hãy sửa lại hoặc nhấn Esc để hủy.", "Dữ liệu chưa hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ketQuaSource.EndEdit();

            // 1) VALIDATE TRƯỚC khi mở transaction
            Dictionary<string, string> errors = ValidateData(table);
            MarkRowErrors(errors);
            if (errors.Count > 0)
            {
                ShowValidationErrors(errors);
                return;
            }

            // 2) LƯU bằng transaction
            try
            {
                Cursor = Cursors.WaitCursor;
                int count = ketQuaDAL.SaveAll(currentMaMon, table);   // lưu theo môn lúc tải
                table.AcceptChanges();                                // xóa trạng thái "đã sửa"

                SetStatus($"Đã lưu thành công {count} dòng.");
                MessageBox.Show($"Đã lưu thành công {count} dòng.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SetStatus("Lưu thất bại - toàn bộ thao tác đã được rollback.", true);
                MessageBox.Show(
                    "Không thể lưu dữ liệu. Toàn bộ thao tác đã được hủy (rollback), không có dòng nào được lưu.\n\n"
                    + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // =====================================================================
        //  VALIDATION
        // =====================================================================
        /// <summary>Trả về lỗi (null nếu hợp lệ). Dùng chung cho lúc nhập ô và lúc bấm Lưu.</summary>
        private static string? GetDiemError(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "Điểm không được để trống.";
            if (!TryParseDiem(text, out double diem))
                return "Điểm phải là một số (ví dụ 8 hoặc 8.5).";
            if (diem < 0 || diem > 10)
                return "Điểm phải nằm trong khoảng từ 0 đến 10.";
            return null;
        }

        /// <summary>Chấp nhận cả "8.5" và "8,5" (không phụ thuộc cài đặt vùng của Windows).</summary>
        private static bool TryParseDiem(string? text, out double diem)
        {
            diem = 0;
            if (string.IsNullOrWhiteSpace(text)) return false;

            string normalized = text.Trim().Replace(',', '.');
            return double.TryParse(normalized,
                       NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                       CultureInfo.InvariantCulture, out diem)
                   && double.IsFinite(diem);
        }

        /// <summary>Kiểm tra toàn bộ DataTable. Trả về dictionary MaSV -> thông báo lỗi.</summary>
        private static Dictionary<string, string> ValidateData(DataTable table)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            foreach (DataRow row in table.Rows)
            {
                string maSV = row["MaSV"].ToString() ?? "";
                string diemText = row["Diem"] is DBNull
                    ? ""
                    : Convert.ToString(row["Diem"], CultureInfo.InvariantCulture) ?? "";

                string? error = GetDiemError(diemText);
                if (error != null) errors[maSV] = error;
            }
            return errors;
        }

        /// <summary>Hiện biểu tượng lỗi ở dòng sai; truyền dictionary rỗng để xóa hết.</summary>
        private void MarkRowErrors(Dictionary<string, string> errors)
        {
            if (errors.Count > 0) txtTimKiem.Clear();    // bỏ lọc để thấy hết dòng lỗi

            foreach (DataGridViewRow gridRow in dgvKetQua.Rows)
            {
                string maSV = gridRow.Cells[ColMaSV].Value?.ToString() ?? "";
                SetRowError(gridRow, errors.TryGetValue(maSV, out string? msg) ? msg : null);
            }
        }

        private void ShowValidationErrors(Dictionary<string, string> errors)
        {
            // Nhảy tới ô điểm của dòng lỗi đầu tiên
            foreach (DataGridViewRow gridRow in dgvKetQua.Rows)
            {
                if (gridRow.ErrorText.Length > 0)
                {
                    dgvKetQua.CurrentCell = gridRow.Cells[ColDiem];
                    break;
                }
            }

            string detail = string.Join(Environment.NewLine,
                errors.Take(5).Select(kv => $"- {kv.Key}: {kv.Value}"));
            if (errors.Count > 5) detail += $"{Environment.NewLine}... và {errors.Count - 5} lỗi khác.";

            SetStatus($"Có {errors.Count} dòng không hợp lệ. Chưa lưu gì xuống database.", true);
            MessageBox.Show("Không thể lưu vì dữ liệu chưa hợp lệ:\n\n" + detail,
                "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // =====================================================================
        //  SỰ KIỆN CỦA GRID (được gắn bằng code trong ConfigureGrid)
        // =====================================================================
        // Kiểm tra ngay khi người dùng rời ô Điểm
        private void dgvKetQua_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvKetQua.Columns[e.ColumnIndex].Name != ColDiem) return;
            if (!dgvKetQua.IsCurrentCellDirty) return;   // chỉ kiểm tra khi người dùng thực sự sửa

            DataGridViewRow row = dgvKetQua.Rows[e.RowIndex];
            string? error = GetDiemError(e.FormattedValue?.ToString());
            if (error != null)
            {
                SetRowError(row, error);
                e.Cancel = true;                          // giữ con trỏ ở ô này; Esc để hủy sửa
                SetStatus(error + " (Nhấn Esc để hoàn tác ô này)", true);
            }
            else
            {
                SetRowError(row, null);
            }
        }

        // Khi kết thúc sửa ô Điểm (nhập xong hoặc nhấn Esc) thì xóa dấu lỗi cũ.
        // Nếu ô vẫn còn trống, lần bấm Lưu tiếp theo sẽ đánh dấu lại.
        private void dgvKetQua_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvKetQua.Columns[e.ColumnIndex].Name != ColDiem) return;
            SetRowError(dgvKetQua.Rows[e.RowIndex], null);
        }

        // Đánh dấu / xóa lỗi của một dòng bằng 3 dấu hiệu:
        // nền hồng cả dòng, biểu tượng lỗi ở đầu dòng, biểu tượng lỗi trong ô Điểm.
        private static readonly Color ErrorRowColor = Color.FromArgb(255, 228, 228);

        private void SetRowError(DataGridViewRow row, string? message)
        {
            bool hasError = !string.IsNullOrEmpty(message);
            row.ErrorText = hasError ? message! : string.Empty;
            row.Cells[ColDiem].ErrorText = hasError ? message! : string.Empty;
            row.DefaultCellStyle.BackColor = hasError ? ErrorRowColor : Color.Empty;
        }

        // Chuyển chuỗi nhập ("8,5" hoặc "8.5") thành double theo đúng quy ước
        private void dgvKetQua_CellParsing(object? sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvKetQua.Columns[e.ColumnIndex].Name != ColDiem) return;

            if (TryParseDiem(e.Value?.ToString(), out double diem))
            {
                e.Value = diem;
                e.ParsingApplied = true;
            }
        }

        // Tô đỏ điểm dưới 5
        private void dgvKetQua_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvKetQua.Columns[e.ColumnIndex].Name != ColDiem) return;
            if (e.Value is double diem && diem < 5)
                e.CellStyle!.ForeColor = Color.Red;
        }

        // Không để WinForms bật hộp thoại lỗi mặc định
        private void dgvKetQua_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            SetStatus("Giá trị ô không hợp lệ. Nhấn Esc để hoàn tác.", true);
        }

        // =====================================================================
        //  TÌM KIẾM / LỌC (lọc trên RAM bằng BindingSource.Filter, không gửi SQL)
        // =====================================================================
        private void txtTimKiem_TextChanged(object? sender, EventArgs e)
        {
            if (ketQuaSource.DataSource is not DataTable) return;   // chưa tải danh sách

            string keyword = txtTimKiem.Text.Trim();
            if (keyword.Length == 0)
            {
                ketQuaSource.RemoveFilter();
                return;
            }

            string safe = EscapeLikeValue(keyword);
            ketQuaSource.Filter = $"HoTen LIKE '%{safe}%' OR MaSV LIKE '%{safe}%'";
        }

        private static string EscapeLikeValue(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                switch (c)
                {
                    case '[':
                    case ']':
                    case '%':
                    case '*':
                        sb.Append('[').Append(c).Append(']'); break;
                    case '\'':
                        sb.Append("''"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }

        // =====================================================================
        //  TIỆN ÍCH
        // =====================================================================
        private void UpdateThongKe()
        {
            if (ketQuaSource.DataSource is not DataTable table || table.Rows.Count == 0)
            {
                tslThongKe.Text = "Chưa có dữ liệu";
                return;
            }

            int tong = table.Rows.Count;
            int daNhap = table.Select("Diem IS NOT NULL").Length;
            int dat = table.Select("Diem >= 5").Length;
            object avg = table.Compute("AVG(Diem)", "Diem IS NOT NULL");
            string avgText = avg is DBNull ? "-" : Convert.ToDouble(avg).ToString("0.00");

            tslThongKe.Text = $"Tổng: {tong} | Đã nhập: {daNhap} | Đạt (≥ 5): {dat} | Điểm TB: {avgText}";
        }

        private bool HasUnsavedChanges()
        {
            if (ketQuaSource.DataSource is not DataTable table) return false;
            dgvKetQua.EndEdit();
            ketQuaSource.EndEdit();
            return table.GetChanges() != null;    // DataTable tự theo dõi dòng đã sửa
        }

        private void SetStatus(string message, bool isError = false)
        {
            tslTrangThai.Text = message;
            tslTrangThai.ForeColor = isError ? Color.Firebrick : Color.DarkGreen;
        }
    }
}