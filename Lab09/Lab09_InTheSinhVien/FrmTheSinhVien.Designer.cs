namespace InTheSinhVien
{
    partial class FrmTheSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                picAnhDaiDien?.Image?.Dispose();
                _logoTruong?.Dispose();
                _kho?.Dispose();
                QrHelper.GiaiPhong();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpThongTin = new GroupBox();
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblKhoa = new Label();
            cboKhoa = new ComboBox();
            lblKhoaHoc = new Label();
            txtKhoaHoc = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            cboGioiTinh = new ComboBox();
            grpAnh = new GroupBox();
            picAnhDaiDien = new PictureBox();
            btnChonAnh = new Button();
            lblGoiYAnh = new Label();
            grpXemTruoc = new GroupBox();
            pnlXemTruocThe = new PanelChongNhap();
            btnLamMoi = new Button();
            btnXemTruocIn = new Button();
            btnIn = new Button();
            btnThoat = new Button();
            btnLuuPng = new Button();
            btnXemTruocA4 = new Button();
            btnInA4 = new Button();
            btnChonLogo = new Button();
            btnLogoMacDinh = new Button();
            lblTenLogo = new Label();
            grpDanhSach = new GroupBox();
            dgvDanhSach = new DataGridView();
            btnThem = new Button();
            btnCapNhat = new Button();
            btnXoa = new Button();
            pdTheSinhVien = new System.Drawing.Printing.PrintDocument();
            ppdXemTruoc = new PrintPreviewDialog();
            pdlChonMayIn = new PrintDialog();
            grpThongTin.SuspendLayout();
            grpAnh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnhDaiDien).BeginInit();
            grpXemTruoc.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.AddRange(new Control[] {
                lblMaSV,
                txtMaSV,
                lblHoTen,
                txtHoTen,
                lblLop,
                cboLop,
                lblKhoa,
                cboKhoa,
                lblKhoaHoc,
                txtKhoaHoc,
                lblNgaySinh,
                dtpNgaySinh,
                lblGioiTinh,
                cboGioiTinh
            });
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(425, 300);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sinh viên";
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.Location = new Point(15, 35);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Text = "Mã sinh viên (*):";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(125, 32);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(285, 23);
            txtMaSV.TabIndex = 0;
            txtMaSV.MaxLength = 20;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(15, 73);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Text = "Họ tên (*):";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(125, 70);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(285, 23);
            txtHoTen.TabIndex = 1;
            txtHoTen.MaxLength = 60;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(15, 111);
            lblLop.Name = "lblLop";
            lblLop.Text = "Lớp:";
            // 
            // cboLop
            // 
            cboLop.Location = new Point(125, 108);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(285, 23);
            cboLop.TabIndex = 2;
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Location = new Point(15, 149);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Text = "Khoa:";
            // 
            // cboKhoa
            // 
            cboKhoa.Location = new Point(125, 146);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(285, 23);
            cboKhoa.TabIndex = 3;
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(15, 187);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Text = "Khóa học:";
            // 
            // txtKhoaHoc
            // 
            txtKhoaHoc.Location = new Point(125, 184);
            txtKhoaHoc.Name = "txtKhoaHoc";
            txtKhoaHoc.Size = new Size(285, 23);
            txtKhoaHoc.TabIndex = 4;
            txtKhoaHoc.MaxLength = 10;
            txtKhoaHoc.PlaceholderText = "Ví dụ: K49";
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(15, 225);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(125, 222);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(285, 23);
            dtpNgaySinh.TabIndex = 5;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(15, 263);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Text = "Giới tính:";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.Location = new Point(125, 260);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(285, 23);
            cboGioiTinh.TabIndex = 6;
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // grpAnh
            // 
            grpAnh.Controls.Add(picAnhDaiDien);
            grpAnh.Controls.Add(btnChonAnh);
            grpAnh.Controls.Add(lblGoiYAnh);
            grpAnh.Controls.Add(btnChonLogo);
            grpAnh.Controls.Add(btnLogoMacDinh);
            grpAnh.Controls.Add(lblTenLogo);
            grpAnh.Location = new Point(12, 318);
            grpAnh.Name = "grpAnh";
            grpAnh.Size = new Size(425, 245);
            grpAnh.TabIndex = 1;
            grpAnh.TabStop = false;
            grpAnh.Text = "Ảnh đại diện và logo";
            // 
            // picAnhDaiDien
            // 
            picAnhDaiDien.BackColor = Color.White;
            picAnhDaiDien.BorderStyle = BorderStyle.FixedSingle;
            picAnhDaiDien.Location = new Point(15, 25);
            picAnhDaiDien.Name = "picAnhDaiDien";
            picAnhDaiDien.Size = new Size(165, 210);
            picAnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
            picAnhDaiDien.TabIndex = 0;
            picAnhDaiDien.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(200, 25);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(210, 38);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "Chọn ảnh...";
            btnChonAnh.UseVisualStyleBackColor = true;
            // 
            // lblGoiYAnh
            // 
            lblGoiYAnh.Location = new Point(200, 75);
            lblGoiYAnh.Name = "lblGoiYAnh";
            lblGoiYAnh.Size = new Size(210, 80);
            lblGoiYAnh.Text = "Hỗ trợ file JPG, JPEG, PNG, BMP.\r\nẢnh được hiển thị giữ đúng tỉ lệ (Zoom). Nên dùng ảnh thẻ 3x4.";
            // 
            // grpXemTruoc
            // 
            grpXemTruoc.Controls.Add(pnlXemTruocThe);
            grpXemTruoc.Location = new Point(452, 12);
            grpXemTruoc.Name = "grpXemTruoc";
            grpXemTruoc.Size = new Size(566, 400);
            grpXemTruoc.TabIndex = 2;
            grpXemTruoc.TabStop = false;
            grpXemTruoc.Text = "Xem trước thẻ sinh viên";
            // 
            // pnlXemTruocThe
            // 
            pnlXemTruocThe.BackColor = Color.WhiteSmoke;
            pnlXemTruocThe.BorderStyle = BorderStyle.FixedSingle;
            pnlXemTruocThe.Location = new Point(10, 25);
            pnlXemTruocThe.Name = "pnlXemTruocThe";
            pnlXemTruocThe.Size = new Size(546, 365);
            pnlXemTruocThe.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(452, 430);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(130, 42);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnXemTruocIn
            // 
            btnXemTruocIn.Location = new Point(592, 430);
            btnXemTruocIn.Name = "btnXemTruocIn";
            btnXemTruocIn.Size = new Size(130, 42);
            btnXemTruocIn.TabIndex = 4;
            btnXemTruocIn.Text = "Xem trước in";
            btnXemTruocIn.UseVisualStyleBackColor = true;
            // 
            // btnIn
            // 
            btnIn.Location = new Point(732, 430);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(130, 42);
            btnIn.TabIndex = 5;
            btnIn.Text = "In thẻ";
            btnIn.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(872, 430);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(130, 42);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnChonLogo
            // 
            btnChonLogo.Location = new Point(200, 165);
            btnChonLogo.Name = "btnChonLogo";
            btnChonLogo.Size = new Size(120, 34);
            btnChonLogo.TabIndex = 2;
            btnChonLogo.Text = "Chọn logo...";
            btnChonLogo.UseVisualStyleBackColor = true;
            // 
            // btnLogoMacDinh
            // 
            btnLogoMacDinh.Location = new Point(328, 165);
            btnLogoMacDinh.Name = "btnLogoMacDinh";
            btnLogoMacDinh.Size = new Size(82, 34);
            btnLogoMacDinh.TabIndex = 3;
            btnLogoMacDinh.Text = "Mặc định";
            btnLogoMacDinh.UseVisualStyleBackColor = true;
            // 
            // lblTenLogo
            // 
            lblTenLogo.Location = new Point(200, 205);
            lblTenLogo.Name = "lblTenLogo";
            lblTenLogo.Size = new Size(210, 32);
            lblTenLogo.Text = "Logo: mặc định";
            // 
            // btnLuuPng
            // 
            btnLuuPng.Location = new Point(452, 480);
            btnLuuPng.Name = "btnLuuPng";
            btnLuuPng.Size = new Size(178, 42);
            btnLuuPng.TabIndex = 7;
            btnLuuPng.Text = "Lưu thẻ ra PNG";
            btnLuuPng.UseVisualStyleBackColor = true;
            // 
            // btnXemTruocA4
            // 
            btnXemTruocA4.Location = new Point(646, 480);
            btnXemTruocA4.Name = "btnXemTruocA4";
            btnXemTruocA4.Size = new Size(178, 42);
            btnXemTruocA4.TabIndex = 8;
            btnXemTruocA4.Text = "Xem trước in nhiều thẻ A4";
            btnXemTruocA4.UseVisualStyleBackColor = true;
            // 
            // btnInA4
            // 
            btnInA4.Location = new Point(840, 480);
            btnInA4.Name = "btnInA4";
            btnInA4.Size = new Size(162, 42);
            btnInA4.TabIndex = 9;
            btnInA4.Text = "In nhiều thẻ A4";
            btnInA4.UseVisualStyleBackColor = true;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(dgvDanhSach);
            grpDanhSach.Controls.Add(btnThem);
            grpDanhSach.Controls.Add(btnCapNhat);
            grpDanhSach.Controls.Add(btnXoa);
            grpDanhSach.Location = new Point(12, 575);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(1006, 160);
            grpDanhSach.TabIndex = 10;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách sinh viên (List<T>)";
            // 
            // dgvDanhSach
            // 
            dgvDanhSach.Location = new Point(10, 22);
            dgvDanhSach.Name = "dgvDanhSach";
            dgvDanhSach.Size = new Size(770, 128);
            dgvDanhSach.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(795, 22);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(200, 36);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm vào danh sách";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnCapNhat
            // 
            btnCapNhat.Location = new Point(795, 66);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(200, 36);
            btnCapNhat.TabIndex = 2;
            btnCapNhat.Text = "Cập nhật sinh viên đang chọn";
            btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(795, 110);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(200, 36);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa khỏi danh sách";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // pdTheSinhVien
            // 
            pdTheSinhVien.DocumentName = "The sinh vien";
            // 
            // ppdXemTruoc
            // 
            ppdXemTruoc.AutoScrollMargin = new Size(0, 0);
            ppdXemTruoc.AutoScrollMinSize = new Size(0, 0);
            ppdXemTruoc.ClientSize = new Size(400, 300);
            ppdXemTruoc.Document = pdTheSinhVien;
            ppdXemTruoc.Enabled = true;
            ppdXemTruoc.Name = "ppdXemTruoc";
            ppdXemTruoc.Visible = false;
            // 
            // pdlChonMayIn
            // 
            pdlChonMayIn.Document = pdTheSinhVien;
            pdlChonMayIn.UseEXDialog = true;
            // 
            // FrmTheSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 745);
            Controls.Add(grpThongTin);
            Controls.Add(grpAnh);
            Controls.Add(grpXemTruoc);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXemTruocIn);
            Controls.Add(btnIn);
            Controls.Add(btnThoat);
            Controls.Add(btnLuuPng);
            Controls.Add(btnXemTruocA4);
            Controls.Add(btnInA4);
            Controls.Add(grpDanhSach);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmTheSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thiết kế và in thẻ sinh viên - Lab 09";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpAnh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAnhDaiDien).EndInit();
            grpXemTruoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
            grpDanhSach.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaSV;
        private TextBox txtMaSV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblLop;
        private ComboBox cboLop;
        private Label lblKhoa;
        private ComboBox cboKhoa;
        private Label lblKhoaHoc;
        private TextBox txtKhoaHoc;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private ComboBox cboGioiTinh;
        private GroupBox grpAnh;
        private PictureBox picAnhDaiDien;
        private Button btnChonAnh;
        private Label lblGoiYAnh;
        private GroupBox grpXemTruoc;
        private PanelChongNhap pnlXemTruocThe;
        private Button btnLamMoi;
        private Button btnXemTruocIn;
        private Button btnIn;
        private Button btnThoat;
        private Button btnLuuPng;
        private Button btnXemTruocA4;
        private Button btnInA4;
        private Button btnChonLogo;
        private Button btnLogoMacDinh;
        private Label lblTenLogo;
        private GroupBox grpDanhSach;
        private DataGridView dgvDanhSach;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;
        private System.Drawing.Printing.PrintDocument pdTheSinhVien;
        private PrintPreviewDialog ppdXemTruoc;
        private PrintDialog pdlChonMayIn;
    }
}
