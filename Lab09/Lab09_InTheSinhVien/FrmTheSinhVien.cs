using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace InTheSinhVien
{
    public partial class FrmTheSinhVien : Form
    {
        // Kich thuoc the trong he toa do thiet ke (the ngang, ti le ~ 540:340).
        // Ca preview, in, luu PNG deu ve theo he toa do nay roi scale cho vua khung.
        private const float RONG_THE = 540f;
        private const float CAO_THE = 340f;

        private static readonly Color MauNen = Color.FromArgb(238, 247, 247);  // nen the (xanh nhat)
        private static readonly Color MauChu = Color.FromArgb(0, 51, 102);     // dai tieu de + khung ngoai + duong ke (xanh navy)

        private enum CheDoIn { MotThe, NhieuTheA4 }

        // ----- Du lieu dung chung -----
        private readonly KhoSinhVienList _kho = new KhoSinhVienList();   // List<T>: buoi sau doi sang SQL Server
        private Image? _logoTruong;        // null => dung logo mac dinh ve bang code
        private string? _maDangChon;       // ma SV dang chon trong danh sach (de Cap nhat / Xoa)

        // ----- Trang thai in -----
        private CheDoIn _cheDoIn = CheDoIn.MotThe;
        private List<ThongTinTheSinhVien> _dsDangIn = new List<ThongTinTheSinhVien>();
        private int _viTriIn;

        public FrmTheSinhVien()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
            DangKySuKien();
        }

        // ============ KHOI TAO ============

        private void KhoiTaoDuLieu()
        {
            cboLop.Items.AddRange(new object[] { "K49.CNTT.A", "K49.CNTT.B", "K49.SPTIN.A" , "K49.SPTIN.B" , "K50.CNTT.A", "K50.CNTT.B", "K51.CNTT.A" });
            cboKhoa.Items.AddRange(new object[] { "Công nghệ thông tin", "Toán - Tin học", "Vật lý", "Hóa học" });
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboLop.SelectedIndex = 2;
            cboKhoa.SelectedIndex = 0;
            cboGioiTinh.SelectedIndex = 1;

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.MaxDate = DateTime.Today;
            dtpNgaySinh.Value = new DateTime(2004, 1, 1);

            picAnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;   // F1: giu dung ti le

            KhoiTaoLuoiDanhSach();
            CapNhatLuoi();
        }

        private void KhoiTaoLuoiDanhSach()
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.AllowUserToDeleteRows = false;
            dgvDanhSach.MultiSelect = false;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.RowHeadersVisible = false;
            dgvDanhSach.BackgroundColor = Color.White;

            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "MSSV", DataPropertyName = nameof(ThongTinTheSinhVien.MaSV), Width = 90
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Họ tên", DataPropertyName = nameof(ThongTinTheSinhVien.HoTen),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày sinh", DataPropertyName = nameof(ThongTinTheSinhVien.NgaySinh), Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Lớp", DataPropertyName = nameof(ThongTinTheSinhVien.Lop), Width = 100
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Khoa", DataPropertyName = nameof(ThongTinTheSinhVien.Khoa), Width = 150
            });
        }

        // Gan su kien MOT LAN duy nhat o day.
        // Dac biet PrintPage khong duoc gan trong nut xem truoc/in vi se bi ve lap.
        private void DangKySuKien()
        {
            btnChonAnh.Click += btnChonAnh_Click;
            btnXemTruocIn.Click += btnXemTruocIn_Click;
            btnIn.Click += btnIn_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnThoat.Click += btnThoat_Click;

            btnLuuPng.Click += btnLuuPng_Click;
            btnChonLogo.Click += btnChonLogo_Click;
            btnLogoMacDinh.Click += btnLogoMacDinh_Click;
            btnXemTruocA4.Click += btnXemTruocA4_Click;
            btnInA4.Click += btnInA4_Click;

            btnThem.Click += btnThem_Click;
            btnCapNhat.Click += btnCapNhat_Click;
            btnXoa.Click += btnXoa_Click;
            dgvDanhSach.CellClick += dgvDanhSach_CellClick;

            pnlXemTruocThe.Paint += pnlXemTruocThe_Paint;
            pdTheSinhVien.BeginPrint += pdTheSinhVien_BeginPrint;
            pdTheSinhVien.PrintPage += pdTheSinhVien_PrintPage;

            txtMaSV.TextChanged += DuLieuThayDoi;
            txtHoTen.TextChanged += DuLieuThayDoi;
            txtKhoaHoc.TextChanged += DuLieuThayDoi;
            cboLop.SelectedIndexChanged += DuLieuThayDoi;
            cboKhoa.SelectedIndexChanged += DuLieuThayDoi;
            cboGioiTinh.SelectedIndexChanged += DuLieuThayDoi;
            dtpNgaySinh.ValueChanged += DuLieuThayDoi;
        }

        // ============ F1: CHON ANH ============

        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Chọn ảnh sinh viên";
            dlg.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                // Load roi tao ban sao Bitmap de KHONG khoa file anh goc.
                using Image tam = Image.FromFile(dlg.FileName);
                Image banSao = new Bitmap(tam);

                picAnhDaiDien.Image?.Dispose();   // giai phong anh cu
                picAnhDaiDien.Image = banSao;
                pnlXemTruocThe.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("File được chọn không phải ảnh hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============ LOGO TRUONG / KHOA ============

        private void btnChonLogo_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Chọn logo trường / khoa";
            dlg.Filter = "Ảnh (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                using Image tam = Image.FromFile(dlg.FileName);
                Image banSao = new Bitmap(tam);

                _logoTruong?.Dispose();
                _logoTruong = banSao;
                lblTenLogo.Text = "Logo: " + Path.GetFileName(dlg.FileName);
                pnlXemTruocThe.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("File được chọn không phải ảnh hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogoMacDinh_Click(object? sender, EventArgs e)
        {
            _logoTruong?.Dispose();
            _logoTruong = null;
            lblTenLogo.Text = "Logo: mặc định";
            pnlXemTruocThe.Invalidate();
        }

        // ============ LAY DU LIEU + F3: VALIDATION ============

        private ThongTinTheSinhVien LayThongTin()
        {
            return new ThongTinTheSinhVien
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                Lop = cboLop.Text,
                Khoa = cboKhoa.Text,
                KhoaHoc = txtKhoaHoc.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = cboGioiTinh.Text,
                Anh = picAnhDaiDien.Image
            };
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            if (picAnhDaiDien.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh sinh viên.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnChonAnh.Focus();
                return false;
            }
            return true;
        }

        // ============ F2: PREVIEW THE TREN PANEL ============

        private void DuLieuThayDoi(object? sender, EventArgs e)
        {
            pnlXemTruocThe.Invalidate();   // yeu cau Panel ve lai (khong dung CreateGraphics)
        }

        private void pnlXemTruocThe_Paint(object? sender, PaintEventArgs e)
        {
            const int le = 10;
            RectangleF vung = new RectangleF(le, le,
                pnlXemTruocThe.Width - 2 * le,
                pnlXemTruocThe.Height - 2 * le);

            VeTheVaoVung(e.Graphics, LayThongTin(), vung);
        }

        // ============ HAM VE THE DUNG CHUNG ============

        /// <summary>
        /// Ve the vao mot vung bat ky: tinh ti le, can giua, roi goi VeThe.
        /// </summary>
        private void VeTheVaoVung(Graphics g, ThongTinTheSinhVien tt, RectangleF vung)
        {
            float tyLe = Math.Min(vung.Width / RONG_THE, vung.Height / CAO_THE);
            float rong = RONG_THE * tyLe;
            float cao = CAO_THE * tyLe;
            float x = vung.Left + (vung.Width - rong) / 2f;
            float y = vung.Top + (vung.Height - cao) / 2f;

            GraphicsState trangThai = g.Save();
            g.TranslateTransform(x, y);
            g.ScaleTransform(tyLe, tyLe);
            VeThe(g, tt);
            g.Restore(trangThai);
        }

        /// <summary>
        /// Ve noi dung the trong he toa do thiet ke 540 x 340.
        /// Font dung GraphicsUnit.World de kich thuoc chu scale theo the,
        /// nhu vay preview tren man hinh, ban in va file PNG luon giong nhau.
        /// </summary>
        private void VeThe(Graphics g, ThongTinTheSinhVien tt)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            using Font fontTruong = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.World);
            using Font fontTieuDe = new Font("Arial", 22f, FontStyle.Bold, GraphicsUnit.World);
            using Font fontNhan = new Font("Arial", 13f, FontStyle.Bold, GraphicsUnit.World);
            using Font fontGiaTri = new Font("Arial", 13f, FontStyle.Regular, GraphicsUnit.World);
            using Font fontNho = new Font("Arial", 10f, FontStyle.Italic, GraphicsUnit.World);

            using SolidBrush nenThe = new SolidBrush(MauNen);
            using SolidBrush nenDau = new SolidBrush(MauChu);
            using SolidBrush chuDen = new SolidBrush(Color.Black);
            using SolidBrush chuXam = new SolidBrush(Color.Gray);
            using Pen vienNgoai = new Pen(MauChu, 4f);
            using Pen vienAnh = new Pen(Color.Gray, 1f);

            // Nen the + khung ngoai
            RectangleF khungThe = new RectangleF(0, 0, RONG_THE, CAO_THE);
            g.FillRectangle(nenThe, khungThe);

            // Dai tieu de: logo + ten truong + THE SINH VIEN
            g.FillRectangle(nenDau, 0, 0, RONG_THE, 75);
            VeLogo(g, new RectangleF(14, 10, 56, 56));

            using (StringFormat giua = new StringFormat { Alignment = StringAlignment.Center })
            {
                g.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH", fontTruong, Brushes.White,
                    new RectangleF(75, 10, RONG_THE - 90, 22), giua);
                g.DrawString("THẺ SINH VIÊN", fontTieuDe, Brushes.White,
                    new RectangleF(75, 34, RONG_THE - 90, 34), giua);
            }

            g.DrawRectangle(vienNgoai, 2, 2, RONG_THE - 4, CAO_THE - 4);

            // Anh sinh vien (ben trai, ti le 3x4)
            RectangleF khungAnh = new RectangleF(25, 95, 120, 160);
            g.FillRectangle(Brushes.White, khungAnh);
            if (tt.Anh != null)
            {
                VeAnhGiuTiLe(g, tt.Anh, khungAnh);
            }
            else
            {
                using StringFormat giua = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString("Chưa có ảnh", fontNho, chuXam, khungAnh, giua);
            }
            g.DrawRectangle(vienAnh, khungAnh.X, khungAnh.Y, khungAnh.Width, khungAnh.Height);

            // Thong tin sinh vien (ben phai)
            float xNhan = 170f;
            float xGiaTri = 265f;
            float y = 88f;
            float buoc = 27f;
            float gioiHanCoQr = 425f - xGiaTri;   // cac dong ben canh QR phai hep lai

            VeDongThongTin(g, "MSSV:", tt.MaSV, fontNhan, fontGiaTri, chuDen, xNhan, xGiaTri, y);
            VeDongThongTin(g, "Họ tên:", tt.HoTen, fontNhan, fontGiaTri, chuDen, xNhan, xGiaTri, y + buoc);
            VeDongThongTin(g, "Ngày sinh:", tt.NgaySinh.ToString("dd/MM/yyyy"), fontNhan, fontGiaTri, chuDen, xNhan, xGiaTri, y + 2 * buoc);
            VeDongThongTin(g, "Giới tính:", tt.GioiTinh, fontNhan, fontGiaTri, chuDen, xNhan, xGiaTri, y + 3 * buoc);
            VeDongThongTin(g, "Lớp:", tt.Lop, fontNhan, fontGiaTri, chuDen, xNhan, xGiaTri, y + 4 * buoc, gioiHanCoQr);
            VeDongThongTin(g, "Khoa:", tt.Khoa, fontNhan, fontGiaTri, chuDen, xNhan, xGiaTri, y + 5 * buoc, gioiHanCoQr);
            VeDongThongTin(g, "Khóa:", tt.KhoaHoc, fontNhan, fontGiaTri, chuDen, xNhan, xGiaTri, y + 6 * buoc, gioiHanCoQr);

            // Ma QR (goc duoi ben phai)
            VeQr(g, tt, new RectangleF(430, 205, 90, 90), fontNho);

            // Chan the
            using (Pen duongKe = new Pen(MauChu, 1f))
            {
                g.DrawLine(duongKe, 25, 300, RONG_THE - 25, 300);
            }
            using (StringFormat giua = new StringFormat { Alignment = StringAlignment.Center })
            {
                g.DrawString("Quét mã QR để xem thông tin sinh viên", fontNho, chuXam,
                    new RectangleF(0, 310, RONG_THE, 18), giua);
            }
        }

        private void VeDongThongTin(Graphics g, string nhan, string giaTri,
            Font fontNhan, Font fontGiaTri, Brush chu,
            float xNhan, float xGiaTri, float y, float rongToiDa = 0f)
        {
            using StringFormat dinhDang = new StringFormat
            {
                FormatFlags = StringFormatFlags.NoWrap,
                Trimming = StringTrimming.EllipsisCharacter
            };

            g.DrawString(nhan, fontNhan, chu, xNhan, y);

            // Gioi han chieu rong de ten dai khong tran ra ngoai the.
            float rong = rongToiDa > 0f ? rongToiDa : RONG_THE - xGiaTri - 20;
            RectangleF vungGiaTri = new RectangleF(xGiaTri, y, rong, 24);
            g.DrawString(giaTri, fontGiaTri, chu, vungGiaTri, dinhDang);
        }

        /// <summary>
        /// Ve anh vao khung theo che do Zoom: giu ti le, can giua, khong meo.
        /// </summary>
        private void VeAnhGiuTiLe(Graphics g, Image anh, RectangleF khung)
        {
            float tyLe = Math.Min(khung.Width / anh.Width, khung.Height / anh.Height);
            float rong = anh.Width * tyLe;
            float cao = anh.Height * tyLe;
            float x = khung.Left + (khung.Width - rong) / 2f;
            float y = khung.Top + (khung.Height - cao) / 2f;

            g.DrawImage(anh, new RectangleF(x, y, rong, cao));
        }

        /// <summary>
        /// Ve logo: neu nguoi dung da chon file thi ve file do, nguoc lai ve logo mac dinh bang code.
        /// </summary>
        private void VeLogo(Graphics g, RectangleF khung)
        {
            using Pen vienVang = new Pen(Color.Goldenrod, 2f);

            if (_logoTruong != null)
            {
                // Logo cua nguoi dung: ve KHIT theo hinh anh (khong ep vao vong tron).
                // Khung rong hon mot chut de logo hinh chu nhat khong bi nho.
                RectangleF vung = new RectangleF(khung.X - 4f, khung.Y - 2f, khung.Width + 8f, khung.Height + 4f);

                float tyLe = Math.Min(vung.Width / _logoTruong.Width, vung.Height / _logoTruong.Height);
                float rong = _logoTruong.Width * tyLe;
                float cao = _logoTruong.Height * tyLe;
                RectangleF vungAnh = new RectangleF(
                    vung.X + (vung.Width - rong) / 2f,
                    vung.Y + (vung.Height - cao) / 2f,
                    rong, cao);

                g.FillRectangle(Brushes.White, vungAnh);     // nen trang om sat logo
                g.DrawImage(_logoTruong, vungAnh);
                g.DrawRectangle(vienVang, vungAnh.X, vungAnh.Y, vungAnh.Width, vungAnh.Height);
                return;
            }

            // Logo mac dinh (chu "SP" trong vong tron)
            using SolidBrush nenTrang = new SolidBrush(Color.White);
            g.FillEllipse(nenTrang, khung);

            using Pen vongTrong = new Pen(MauChu, 1.5f);
            g.DrawEllipse(vongTrong, RectangleF.Inflate(khung, -5f, -5f));

            using Font fontLogo = new Font("Arial", 20f, FontStyle.Bold, GraphicsUnit.World);
            using SolidBrush chuLogo = new SolidBrush(MauChu);
            using StringFormat giua = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString("SP", fontLogo, chuLogo, khung, giua);

            g.DrawEllipse(vienVang, khung);
        }

        /// <summary>
        /// Ve ma QR (tao bang thu vien QRCoder). Chua co MSSV thi ve khung cho.
        /// </summary>
        private void VeQr(Graphics g, ThongTinTheSinhVien tt, RectangleF khung, Font fontNho)
        {
            g.FillRectangle(Brushes.White, khung);

            if (string.IsNullOrWhiteSpace(tt.MaSV))
            {
                using Pen net = new Pen(Color.Silver, 1f) { DashStyle = DashStyle.Dash };
                using StringFormat giua = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawRectangle(net, khung.X, khung.Y, khung.Width, khung.Height);
                g.DrawString("QR", fontNho, Brushes.Silver, khung, giua);
                return;
            }

            Bitmap qr = QrHelper.LayQr(tt.TaoNoiDungQr());

            GraphicsState trangThai = g.Save();
            g.InterpolationMode = InterpolationMode.NearestNeighbor;   // giu net o vuong sac
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.DrawImage(qr, khung);
            g.Restore(trangThai);
        }

        // ============ LUU THE THANH FILE PNG (BITMAP) ============

        /// <summary>
        /// Ve the len mot Bitmap rieng, he so phong to heSo (3 => 1620 x 1020 px, ~300 dpi).
        /// </summary>
        private Bitmap TaoBitmapThe(ThongTinTheSinhVien tt, int heSo)
        {
            int rong = (int)(RONG_THE * heSo);
            int cao = (int)(CAO_THE * heSo);

            Bitmap bmp = new Bitmap(rong, cao, PixelFormat.Format32bppArgb);
            bmp.SetResolution(300f, 300f);

            using Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            VeTheVaoVung(g, tt, new RectangleF(0, 0, rong, cao));
            return bmp;
        }

        private void btnLuuPng_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string tenGoiY = txtMaSV.Text.Trim();
            foreach (char c in Path.GetInvalidFileNameChars())
                tenGoiY = tenGoiY.Replace(c, '_');

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Lưu thẻ sinh viên";
            dlg.Filter = "Ảnh PNG (*.png)|*.png";
            dlg.DefaultExt = "png";
            dlg.FileName = "TheSV_" + tenGoiY + ".png";

            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                using Bitmap bmp = TaoBitmapThe(LayThongTin(), 3);
                bmp.Save(dlg.FileName, ImageFormat.Png);
                MessageBox.Show("Đã lưu thẻ sinh viên:\n" + dlg.FileName, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lưu được file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============ DANH SACH SINH VIEN (List<T>) ============

        private void CapNhatLuoi()
        {
            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = _kho.TatCa().ToList();   // ban sao danh sach de gan cho luoi
            grpDanhSach.Text = $"Danh sách sinh viên (List<T>) - {_kho.SoLuong} sinh viên";

            dgvDanhSach.ClearSelection();
            if (_maDangChon == null) return;

            foreach (DataGridViewRow dong in dgvDanhSach.Rows)
            {
                if (dong.DataBoundItem is ThongTinTheSinhVien sv &&
                    string.Equals(sv.MaSV, _maDangChon, StringComparison.OrdinalIgnoreCase))
                {
                    dong.Selected = true;
                    break;
                }
            }
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            ThongTinTheSinhVien tt = LayThongTin();
            if (!_kho.Them(tt))
            {
                MessageBox.Show("Mã sinh viên này đã có trong danh sách.\nHãy chọn dòng đó rồi bấm \"Cập nhật\".",
                    "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            _maDangChon = tt.MaSV;
            CapNhatLuoi();
        }

        private void btnCapNhat_Click(object? sender, EventArgs e)
        {
            if (_maDangChon == null)
            {
                MessageBox.Show("Hãy chọn một sinh viên trong danh sách trước.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!KiemTraDuLieu()) return;

            ThongTinTheSinhVien tt = LayThongTin();
            if (!_kho.Sua(_maDangChon, tt))
            {
                MessageBox.Show("Không cập nhật được: mã mới trùng với sinh viên khác hoặc sinh viên đã bị xóa.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _maDangChon = tt.MaSV;
            CapNhatLuoi();
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (_maDangChon == null)
            {
                MessageBox.Show("Hãy chọn một sinh viên trong danh sách trước.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Xóa sinh viên {_maDangChon} khỏi danh sách?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            _kho.Xoa(_maDangChon);
            _maDangChon = null;
            CapNhatLuoi();
            btnLamMoi_Click(null, EventArgs.Empty);
        }

        private void dgvDanhSach_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDanhSach.Rows[e.RowIndex].DataBoundItem is not ThongTinTheSinhVien sv) return;

            _maDangChon = sv.MaSV;
            NapVaoForm(sv);
        }

        private void NapVaoForm(ThongTinTheSinhVien sv)
        {
            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;
            txtKhoaHoc.Text = sv.KhoaHoc;
            cboLop.SelectedItem = sv.Lop;
            cboKhoa.SelectedItem = sv.Khoa;
            cboGioiTinh.SelectedItem = sv.GioiTinh;
            dtpNgaySinh.Value = sv.NgaySinh > dtpNgaySinh.MaxDate ? dtpNgaySinh.MaxDate : sv.NgaySinh;

            picAnhDaiDien.Image?.Dispose();
            picAnhDaiDien.Image = sv.Anh == null ? null : new Bitmap(sv.Anh);   // ban sao, khong dung chung voi List

            pnlXemTruocThe.Invalidate();
        }

        // ============ F4, F5: XEM TRUOC IN VA IN (1 THE) ============

        private void btnXemTruocIn_Click(object? sender, EventArgs e)
        {
            MoXemTruoc(CheDoIn.MotThe);
        }

        private void btnIn_Click(object? sender, EventArgs e)
        {
            InThe(CheDoIn.MotThe);
        }

        // ============ IN NHIEU THE TREN MOT TRANG A4 ============

        private void btnXemTruocA4_Click(object? sender, EventArgs e)
        {
            MoXemTruoc(CheDoIn.NhieuTheA4);
        }

        private void btnInA4_Click(object? sender, EventArgs e)
        {
            InThe(CheDoIn.NhieuTheA4);
        }

        /// <summary>
        /// Chuan bi du lieu va giay in cho che do duoc chon.
        /// A4: in toan bo danh sach; danh sach rong thi in the dang nhap lap day 1 trang.
        /// </summary>
        private bool ChuanBiIn(CheDoIn che)
        {
            if (che == CheDoIn.NhieuTheA4)
            {
                if (_kho.SoLuong > 0)
                {
                    _dsDangIn = _kho.TatCa().ToList();
                }
                else
                {
                    if (!KiemTraDuLieu()) return false;
                    ThongTinTheSinhVien hienTai = LayThongTin();
                    _dsDangIn = Enumerable.Repeat(hienTai, 8).ToList();
                }
            }
            else
            {
                if (!KiemTraDuLieu()) return false;
            }

            _cheDoIn = che;
            CauHinhGiay(che);
            return true;
        }

        private void CauHinhGiay(CheDoIn che)
        {
            PageSettings cauHinh = new PageSettings(pdTheSinhVien.PrinterSettings);

            if (che == CheDoIn.NhieuTheA4)
            {
                PaperSize? a4 = pdTheSinhVien.PrinterSettings.PaperSizes
                    .Cast<PaperSize>()
                    .FirstOrDefault(p => p.Kind == PaperKind.A4);

                cauHinh.PaperSize = a4 ?? new PaperSize("A4", 827, 1169);   // don vi 1/100 inch
                cauHinh.Margins = new Margins(40, 40, 40, 40);
            }

            pdTheSinhVien.DefaultPageSettings = cauHinh;
        }

        private void MoXemTruoc(CheDoIn che)
        {
            try
            {
                if (!ChuanBiIn(che)) return;

                ppdXemTruoc.Document = pdTheSinhVien;
                ppdXemTruoc.Width = 900;
                ppdXemTruoc.Height = 700;
                ppdXemTruoc.StartPosition = FormStartPosition.CenterParent;
                ppdXemTruoc.ShowDialog(this);
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("Không tìm thấy máy in. Hãy cài đặt một máy in (ví dụ Microsoft Print to PDF).",
                    "Lỗi máy in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InThe(CheDoIn che)
        {
            try
            {
                if (!ChuanBiIn(che)) return;

                pdlChonMayIn.Document = pdTheSinhVien;
                if (pdlChonMayIn.ShowDialog(this) == DialogResult.OK)
                {
                    pdTheSinhVien.Print();
                }
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("Không tìm thấy máy in. Hãy cài đặt một máy in (ví dụ Microsoft Print to PDF).",
                    "Lỗi máy in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pdTheSinhVien_BeginPrint(object? sender, PrintEventArgs e)
        {
            _viTriIn = 0;   // moi lan in / xem truoc phai bat dau lai tu the dau tien
        }

        private void pdTheSinhVien_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null) return;

            if (_cheDoIn == CheDoIn.NhieuTheA4)
            {
                InNhieuTheTrenTrang(e.Graphics, e);
                return;
            }

            // The in o kich thuoc 540 x 340 (don vi 1/100 inch), thu nho neu giay hep.
            Rectangle le = e.MarginBounds;
            float rong = Math.Min(RONG_THE, le.Width);
            float cao = rong * CAO_THE / RONG_THE;
            RectangleF vung = new RectangleF(le.Left, le.Top, rong, cao);

            VeTheVaoVung(e.Graphics, LayThongTin(), vung);
            e.HasMorePages = false;
        }

        /// <summary>
        /// Xep luoi 2 cot x 4 hang the kich thuoc CR80 (85.6 x 54 mm ~ 337 x 212 don vi 1/100 inch).
        /// Danh sach dai hon 8 the thi tu dong sang trang moi.
        /// </summary>
        private void InNhieuTheTrenTrang(Graphics g, PrintPageEventArgs e)
        {
            const int soCot = 2;
            const int soHang = 4;

            float rongThe = 337f;
            float caoThe = rongThe * CAO_THE / RONG_THE;
            float khoang = 20f;

            Rectangle le = e.MarginBounds;
            float tongRong = soCot * rongThe + (soCot - 1) * khoang;
            float tongCao = soHang * caoThe + (soHang - 1) * khoang;

            // Giay nho hon A4 thi thu nho toan bo luoi cho vua.
            float heSo = Math.Min(1f, Math.Min(le.Width / tongRong, le.Height / tongCao));
            rongThe *= heSo;
            caoThe *= heSo;
            khoang *= heSo;
            tongRong = soCot * rongThe + (soCot - 1) * khoang;

            float x0 = le.Left + (le.Width - tongRong) / 2f;
            float y0 = le.Top;

            using Pen duongCat = new Pen(Color.Silver, 0.5f) { DashStyle = DashStyle.Dash };

            int daInTrongTrang = 0;
            while (_viTriIn < _dsDangIn.Count && daInTrongTrang < soCot * soHang)
            {
                int cot = daInTrongTrang % soCot;
                int hang = daInTrongTrang / soCot;

                RectangleF o = new RectangleF(
                    x0 + cot * (rongThe + khoang),
                    y0 + hang * (caoThe + khoang),
                    rongThe, caoThe);

                VeTheVaoVung(g, _dsDangIn[_viTriIn], o);
                g.DrawRectangle(duongCat, o.X - 2, o.Y - 2, o.Width + 4, o.Height + 4);   // vien de cat the

                _viTriIn++;
                daInTrongTrang++;
            }

            e.HasMorePages = _viTriIn < _dsDangIn.Count;
        }

        // ============ F6: LAM MOI ============

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtKhoaHoc.Clear();
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 2;
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 1;
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = new DateTime(2005, 1, 1);

            picAnhDaiDien.Image?.Dispose();
            picAnhDaiDien.Image = null;

            _maDangChon = null;
            dgvDanhSach.ClearSelection();

            pnlXemTruocThe.Invalidate();
            txtMaSV.Focus();
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
