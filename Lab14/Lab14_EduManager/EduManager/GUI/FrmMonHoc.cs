using EduManager.BLL;
using EduManager.Models;

namespace EduManager.GUI
{
    /// <summary>
    /// Form quan ly mon hoc. GUI chi nhan du lieu, goi BLL va hien thi ket qua.
    /// Khong viet SQL, khong chua logic kiem tra nghiep vu.
    /// </summary>
    public partial class FrmMonHoc : Form
    {
        private readonly MonHocBLL _monHocBLL = new MonHocBLL();

        public FrmMonHoc()
        {
            InitializeComponent();
        }

        // ================= SU KIEN FORM =================

        /// <summary>Yeu cau 1: load danh sach mon hoc khi mo Form.</summary>
        private void FrmMonHoc_Load(object? sender, EventArgs e)
        {
            CauHinhLuoi();
            TaiDanhSach();
        }

        /// <summary>Yeu cau 2: them mon hoc moi.</summary>
        private void btnThem_Click(object? sender, EventArgs e)
        {
            var ketQua = _monHocBLL.ThemMonHoc(LayMonHocTuForm());
            if (ketQua.ThanhCong)
            {
                HienThiThongBao(ketQua.ThongBao);
                LamMoiForm();
            }
            else
            {
                HienThiCanhBao(ketQua.ThongBao);
            }
        }

        /// <summary>Yeu cau 3: sua thong tin mon hoc.</summary>
        private void btnSua_Click(object? sender, EventArgs e)
        {
            var ketQua = _monHocBLL.SuaMonHoc(LayMonHocTuForm());
            if (ketQua.ThanhCong)
            {
                HienThiThongBao(ketQua.ThongBao);
                LamMoiForm();
            }
            else
            {
                HienThiCanhBao(ketQua.ThongBao);
            }
        }

        /// <summary>Yeu cau 4: xoa mon hoc sau khi xac nhan bang MessageBox.</summary>
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            var maMonHoc = txtMaMonHoc.Text.Trim();
            if (maMonHoc.Length == 0)
            {
                HienThiCanhBao("Vui lòng chọn môn học cần xóa trên danh sách.");
                return;
            }

            var luaChon = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa môn học '{maMonHoc}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (luaChon != DialogResult.Yes)
            {
                return;
            }

            var ketQua = _monHocBLL.XoaMonHoc(maMonHoc);
            if (ketQua.ThanhCong)
            {
                HienThiThongBao(ketQua.ThongBao);
                LamMoiForm();
            }
            else
            {
                HienThiCanhBao(ketQua.ThongBao);
            }
        }

        /// <summary>Yeu cau 5: tim kiem mon hoc theo ma hoac ten.</summary>
        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            var ketQua = _monHocBLL.TimKiem(txtTimKiem.Text);
            if (!ketQua.ThanhCong)
            {
                HienThiLoi(ketQua.ThongBao);
                return;
            }

            dgvMonHoc.DataSource = ketQua.DuLieu;
            dgvMonHoc.ClearSelection();

            if (ketQua.ThongBao.Length > 0)
            {
                HienThiThongBao(ketQua.ThongBao);
            }
        }

        /// <summary>Cho phep nhan Enter trong o tim kiem de tim.</summary>
        private void txtTimKiem_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTimKiem.PerformClick();
            }
        }

        /// <summary>Yeu cau 6: chon dong tren luoi thi hien thi len cac control nhap lieu.</summary>
        private void dgvMonHoc_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvMonHoc.Rows[e.RowIndex].DataBoundItem is MonHoc monHoc)
            {
                txtMaMonHoc.Text = monHoc.MaMonHoc;
                txtTenMonHoc.Text = monHoc.TenMonHoc;
                nudSoTinChi.Value = monHoc.SoTinChi;
                chkTrangThai.Checked = monHoc.TrangThai;

                // Ma mon hoc la khoa chinh nen khong cho sua khi dang chon mot dong
                txtMaMonHoc.ReadOnly = true;
            }
        }

        /// <summary>Yeu cau 7: lam moi Form va load lai danh sach.</summary>
        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LamMoiForm();
        }

        // ================= HAM HO TRO =================

        /// <summary>Tao cac cot cho DataGridView.</summary>
        private void CauHinhLuoi()
        {
            dgvMonHoc.AutoGenerateColumns = false;
            dgvMonHoc.Columns.Clear();

            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cotMaMonHoc",
                HeaderText = "Mã môn học",
                DataPropertyName = nameof(MonHoc.MaMonHoc),
                Width = 130
            });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cotTenMonHoc",
                HeaderText = "Tên môn học",
                DataPropertyName = nameof(MonHoc.TenMonHoc),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cotSoTinChi",
                HeaderText = "Số tín chỉ",
                DataPropertyName = nameof(MonHoc.SoTinChi),
                Width = 100
            });
            dgvMonHoc.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "cotTrangThai",
                HeaderText = "Còn sử dụng",
                DataPropertyName = nameof(MonHoc.TrangThai),
                Width = 110
            });

            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToDeleteRows = false;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.RowHeadersVisible = false;
        }

        /// <summary>Tai lai toan bo danh sach mon hoc len luoi.</summary>
        private void TaiDanhSach()
        {
            var ketQua = _monHocBLL.LayDanhSach();
            if (!ketQua.ThanhCong)
            {
                HienThiLoi(ketQua.ThongBao);
                return;
            }

            dgvMonHoc.DataSource = ketQua.DuLieu;
            dgvMonHoc.ClearSelection();
        }

        /// <summary>Dua cac control nhap lieu ve trang thai ban dau va load lai danh sach.</summary>
        private void LamMoiForm()
        {
            txtMaMonHoc.Clear();
            txtMaMonHoc.ReadOnly = false;
            txtTenMonHoc.Clear();
            nudSoTinChi.Value = 3;
            chkTrangThai.Checked = true;
            TaiDanhSach();
            txtMaMonHoc.Focus();
        }

        /// <summary>Doc du lieu nguoi dung nhap tren Form thanh doi tuong MonHoc.</summary>
        private MonHoc LayMonHocTuForm()
        {
            return new MonHoc
            {
                MaMonHoc = txtMaMonHoc.Text,
                TenMonHoc = txtTenMonHoc.Text,
                SoTinChi = (int)nudSoTinChi.Value,
                TrangThai = chkTrangThai.Checked
            };
        }

        private static void HienThiThongBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void HienThiCanhBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static void HienThiLoi(string noiDung)
        {
            MessageBox.Show(noiDung, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
