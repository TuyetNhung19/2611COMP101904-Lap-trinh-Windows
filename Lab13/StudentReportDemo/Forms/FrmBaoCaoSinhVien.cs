using System.Globalization;
using System.Text;
using StudentReportDemo.Models;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        private const string TatCa = "Tất cả";
        private const string TatCaLop = "Tất cả lớp";
        private const string SapDiemGiam = "Điểm giảm dần";   // mặc định theo yêu cầu đề
        private const string SapMaTang = "Mã SV tăng dần";
        private const string SapTenTang = "Họ tên A → Z";

        private List<SinhVien> danhSachSinhVien = new List<SinhVien>(); // nguồn dữ liệu gốc
        private string tieuDeBaoCao = "";   // dùng khi xuất file TXT
        private string dongTongHop = "";    // dùng khi xuất file TXT

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        // =============== SỰ KIỆN ===============
        private void FrmBaoCaoSinhVien_Load(object? sender, EventArgs e)
        {
            TaoDuLieuMau();
            LoadComboBox();
            XemBaoCao(false);   // hiển thị sẵn, không bật thông báo khi vừa mở form
        }

        private void btnXemBaoCao_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDauVao()) return;
            XemBaoCao(true);
        }

        private void btnThongKe_Click(object? sender, EventArgs e)
        {
            ThongKeTheoLop();
        }

        private void btnXuatFile_Click(object? sender, EventArgs e)
        {
            XuatFile();
        }

        // =============== DỮ LIỆU MẪU ===============
        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2 },
                new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5 },
                new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8 },
                new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung",   MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1 },
                new SinhVien { MaSV = "SV005", HoTen = "Phan Văn Em",       MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 5.0 }, // đúng ngưỡng đạt

                new SinhVien { MaSV = "SV006", HoTen = "Hoàng Quốc Huy",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },
                new SinhVien { MaSV = "SV007", HoTen = "Võ Gia Khang",      MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9 },
                new SinhVien { MaSV = "SV008", HoTen = "Đặng Minh Khôi",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5 },
                new SinhVien { MaSV = "SV009", HoTen = "Bùi Thảo Linh",     MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0 },
                new SinhVien { MaSV = "SV010", HoTen = "Lương Thanh Giang", MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 }, // trùng điểm để thấy ThenBy

                new SinhVien { MaSV = "SV011", HoTen = "Ngô Tuấn Minh",     MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
                new SinhVien { MaSV = "SV012", HoTen = "Đỗ Bảo Ngọc",       MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3 },
                new SinhVien { MaSV = "SV013", HoTen = "Huỳnh Gia Phúc",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2 },
                new SinhVien { MaSV = "SV014", HoTen = "Mai Anh Thư",       MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8 },
                new SinhVien { MaSV = "SV015", HoTen = "Trịnh Hoài Nam",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 2.5 }
            };
        }

        // =============== LOAD COMBOBOX ===============
        private void LoadComboBox()
        {
            // LINQ: GroupBy để mỗi lớp chỉ xuất hiện 1 lần, sắp xếp theo mã lớp
            List<LopItem> dsLop = danhSachSinhVien
                .GroupBy(sv => sv.MaLop)
                .Select(g => new LopItem { MaLop = g.Key, TenLop = g.First().TenLop })
                .OrderBy(lop => lop.MaLop)
                .ToList();

            dsLop.Insert(0, new LopItem { MaLop = "", TenLop = TatCaLop });

            cboLop.DataSource = dsLop;
            cboLop.DisplayMember = nameof(LopItem.TenLop);
            cboLop.ValueMember = nameof(LopItem.MaLop);

            cboKetQua.Items.Clear();
            cboKetQua.Items.AddRange(new object[] { TatCa, SinhVien.Dat, SinhVien.KhongDat });
            cboKetQua.SelectedIndex = 0;

            cboSapXep.Items.Clear();
            cboSapXep.Items.AddRange(new object[] { SapDiemGiam, SapMaTang, SapTenTang });
            cboSapXep.SelectedIndex = 0;
        }

        // =============== XEM BÁO CÁO ===============
        private bool KiemTraDauVao()
        {
            if (cboLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLop.Focus();
                return false;
            }
            if (txtTuKhoa.Text.Trim().Length > 50)
            {
                MessageBox.Show("Từ khóa tìm kiếm không được quá 50 ký tự.", "Từ khóa không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTuKhoa.Focus();
                return false;
            }
            return true;
        }

        private List<SinhVien> LocDanhSach(string maLop, string ketQua, string tuKhoa, string kieuSapXep)
        {
            IEnumerable<SinhVien> query = danhSachSinhVien;

            if (!string.IsNullOrEmpty(maLop))
                query = query.Where(sv => sv.MaLop == maLop);

            if (ketQua != TatCa)
                query = query.Where(sv => sv.KetQua == ketQua);

            if (!string.IsNullOrEmpty(tuKhoa))
                query = query.Where(sv =>
                    sv.MaSV.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) ||
                    sv.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase));

            IOrderedEnumerable<SinhVien> daSapXep = kieuSapXep switch
            {
                SapMaTang => query.OrderBy(sv => sv.MaSV),
                SapTenTang => query.OrderBy(sv => sv.HoTen),
                _ => query.OrderByDescending(sv => sv.Diem)   // mặc định: giảm dần theo điểm
                          .ThenBy(sv => sv.HoTen)             // cùng điểm thì theo họ tên
            };

            return daSapXep.ToList();
        }

        private void XemBaoCao(bool thongBaoNeuRong)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string ketQua = cboKetQua.SelectedItem?.ToString() ?? TatCa;
            string tuKhoa = txtTuKhoa.Text.Trim();
            string kieuSapXep = cboSapXep.SelectedItem?.ToString() ?? SapDiemGiam;

            List<SinhVien> dsLoc = LocDanhSach(maLop, ketQua, tuKhoa, kieuSapXep);

            // LINQ Select: chọn cột cần hiển thị + đánh số thứ tự
            var duLieuHienThi = dsLoc
                .Select((sv, i) => new { STT = i + 1, sv.MaSV, sv.HoTen, sv.TenLop, sv.Diem, sv.KetQua })
                .ToList();

            HienThiLenLuoi(duLieuHienThi, new Dictionary<string, string>
            {
                ["STT"] = "STT",
                ["MaSV"] = "Mã SV",
                ["HoTen"] = "Họ tên",
                ["TenLop"] = "Lớp",
                ["Diem"] = "Điểm",
                ["KetQua"] = "Kết quả"
            });
            TomauKhongDat();

            tieuDeBaoCao = $"BÁO CÁO SINH VIÊN - {cboLop.Text} - Kết quả: {ketQua}";
            if (tuKhoa != "") tieuDeBaoCao += $" - Từ khóa: \"{tuKhoa}\"";
            lblTieuDe.Text = tieuDeBaoCao;

            CapNhatThongKe(dsLoc);

            if (dsLoc.Count == 0 && thongBaoNeuRong)
            {
                MessageBox.Show("Không có sinh viên nào phù hợp với điều kiện lọc.\nHãy thử đổi lớp, kết quả hoặc từ khóa.",
                                "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =============== THỐNG KÊ ===============
        private void CapNhatThongKe(List<SinhVien> ds)
        {
            int tong = ds.Count;
            int soDat = ds.Count(sv => sv.KetQua == SinhVien.Dat);
            int soKhongDat = ds.Count(sv => sv.KetQua == SinhVien.KhongDat);
            double diemTB = tong > 0 ? ds.Average(sv => sv.Diem) : 0;   // tránh lỗi Average trên danh sách rỗng

            tslTongSo.Text = $"Tổng số SV: {tong}";
            tslSoDat.Text = $"Đạt: {soDat}";
            tslSoKhongDat.Text = $"Không đạt: {soKhongDat}";
            tslDiemTB.Text = $"Điểm TB: {diemTB:0.00}";

            dongTongHop = $"{tslTongSo.Text} | {tslSoDat.Text} | {tslSoKhongDat.Text} | {tslDiemTB.Text}";
        }

        private void ThongKeTheoLop()
        {
            if (danhSachSinhVien.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để thống kê.", "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new
                {
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat = g.Count(sv => sv.KetQua == SinhVien.Dat),
                    SoKhongDat = g.Count(sv => sv.KetQua == SinhVien.KhongDat),
                    DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2),
                    DiemCaoNhat = g.Max(sv => sv.Diem)
                })
                .OrderBy(x => x.MaLop)
                .ToList();

            HienThiLenLuoi(thongKe, new Dictionary<string, string>
            {
                ["MaLop"] = "Mã lớp",
                ["TenLop"] = "Tên lớp",
                ["SoLuong"] = "Số lượng SV",
                ["SoDat"] = "Số đạt",
                ["SoKhongDat"] = "Số không đạt",
                ["DiemTrungBinh"] = "Điểm TB",
                ["DiemCaoNhat"] = "Điểm cao nhất"
            });

            tieuDeBaoCao = "THỐNG KÊ SINH VIÊN THEO LỚP";
            lblTieuDe.Text = tieuDeBaoCao;
            CapNhatThongKe(danhSachSinhVien);   // thanh trạng thái hiển thị tổng của tất cả các lớp
        }

        // =============== HIỂN THỊ LÊN DATAGRIDVIEW ===============
        private void HienThiLenLuoi(object nguonDuLieu, Dictionary<string, string> tieuDeCot)
        {
            dgvBaoCao.DataSource = null;
            dgvBaoCao.Columns.Clear();
            dgvBaoCao.AutoGenerateColumns = true;
            dgvBaoCao.DataSource = nguonDuLieu;

            foreach (DataGridViewColumn cot in dgvBaoCao.Columns)
            {
                if (tieuDeCot.TryGetValue(cot.Name, out string? tieuDe))
                    cot.HeaderText = tieuDe;

                if (cot.ValueType == typeof(double))
                    cot.DefaultCellStyle.Format = cot.Name == "DiemTrungBinh" ? "0.00" : "0.0";

                if (cot.ValueType == typeof(double) || cot.ValueType == typeof(int) || cot.Name == "KetQua")
                    cot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (cot.Name == "STT") cot.FillWeight = 30;
            }
        }

        private void TomauKhongDat()
        {
            if (!dgvBaoCao.Columns.Contains("KetQua")) return;

            foreach (DataGridViewRow dong in dgvBaoCao.Rows)
            {
                if (dong.Cells["KetQua"].Value?.ToString() == SinhVien.KhongDat)
                    dong.DefaultCellStyle.ForeColor = Color.Firebrick;
            }
        }

        // =============== XUẤT FILE ===============
        private void XuatFile()
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất. Hãy bấm \"Xem báo cáo\" hoặc \"Thống kê theo lớp\" trước.",
                                "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Title = "Lưu báo cáo",
                Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt",
                FileName = "BaoCaoSinhVien",
                AddExtension = true,
                OverwritePrompt = true
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                bool laTxt = Path.GetExtension(sfd.FileName).Equals(".txt", StringComparison.OrdinalIgnoreCase);
                string noiDung = TaoNoiDungXuat(laTxt);

                // UTF-8 có BOM để Excel/Notepad đọc đúng tiếng Việt
                File.WriteAllText(sfd.FileName, noiDung, new UTF8Encoding(true));

                MessageBox.Show("Xuất file thành công:\n" + sfd.FileName, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Không có quyền ghi vào vị trí đã chọn. Hãy chọn thư mục khác.",
                                "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Không ghi được file (có thể file đang được mở bởi chương trình khác).\n" + ex.Message,
                                "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định khi xuất file: " + ex.Message,
                                "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TaoNoiDungXuat(bool laTxt)
        {
            char phanCach = laTxt ? '\t' : ',';
            var sb = new StringBuilder();

            if (laTxt)
            {
                sb.AppendLine(tieuDeBaoCao);
                sb.AppendLine($"Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}");
                sb.AppendLine();
            }

            List<DataGridViewColumn> cot = dgvBaoCao.Columns.Cast<DataGridViewColumn>()
                                                    .Where(c => c.Visible).ToList();

            sb.AppendLine(string.Join(phanCach, cot.Select(c => ChuanHoaGiaTri(c.HeaderText, phanCach))));

            foreach (DataGridViewRow dong in dgvBaoCao.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow))
            {
                sb.AppendLine(string.Join(phanCach, cot.Select(c => ChuanHoaGiaTri(dong.Cells[c.Index].Value, phanCach))));
            }

            if (laTxt)
            {
                sb.AppendLine();
                sb.AppendLine(dongTongHop);
            }
            return sb.ToString();
        }

        // Chuẩn CSV: nếu có dấu phân cách, dấu nháy kép hoặc xuống dòng thì bọc trong "..."
        private static string ChuanHoaGiaTri(object? giaTri, char phanCach)
        {
            string s = Convert.ToString(giaTri, CultureInfo.InvariantCulture) ?? "";
            bool canBocNhay = s.Contains(phanCach) || s.Contains('"') || s.Contains('\n') || s.Contains('\r');
            return canBocNhay ? "\"" + s.Replace("\"", "\"\"") + "\"" : s;
        }
    }
}
