namespace CourseRegistrationApp
{
    partial class FrmDangKyKhoaHoc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            grpHocVien = new GroupBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            chkNhanEmail = new CheckBox();
            grpKhoaHoc = new GroupBox();
            lblKhoaHoc = new Label();
            cboKhoaHoc = new ComboBox();
            lblHinhThuc = new Label();
            radOnline = new RadioButton();
            radOffline = new RadioButton();
            lblSoThang = new Label();
            numSoThang = new NumericUpDown();
            lblTongTienTieuDe = new Label();
            lblTongTien = new Label();
            btnDangKy = new Button();
            btnLamMoi = new Button();
            btnThoat = new Button();
            grpHocVien.SuspendLayout();
            grpKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(24, 62, 99);
            lblTieuDe.Location = new Point(0, 10);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(560, 45);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐĂNG KÝ KHÓA HỌC";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // grpHocVien
            //
            grpHocVien.Controls.Add(lblHoTen);
            grpHocVien.Controls.Add(txtHoTen);
            grpHocVien.Controls.Add(lblSoDienThoai);
            grpHocVien.Controls.Add(txtSoDienThoai);
            grpHocVien.Controls.Add(lblNgaySinh);
            grpHocVien.Controls.Add(dtpNgaySinh);
            grpHocVien.Controls.Add(chkNhanEmail);
            grpHocVien.Location = new Point(20, 65);
            grpHocVien.Name = "grpHocVien";
            grpHocVien.Size = new Size(520, 200);
            grpHocVien.TabIndex = 1;
            grpHocVien.TabStop = false;
            grpHocVien.Text = "Thông tin học viên";
            //
            // lblHoTen
            //
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 38);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên:";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(140, 35);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(350, 27);
            txtHoTen.TabIndex = 1;
            //
            // lblSoDienThoai
            //
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(20, 78);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.TabIndex = 2;
            lblSoDienThoai.Text = "Số điện thoại:";
            //
            // txtSoDienThoai
            //
            txtSoDienThoai.Location = new Point(140, 75);
            txtSoDienThoai.MaxLength = 10;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(350, 27);
            txtSoDienThoai.TabIndex = 3;
            //
            // lblNgaySinh
            //
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(20, 118);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.TabIndex = 4;
            lblNgaySinh.Text = "Ngày sinh:";
            //
            // dtpNgaySinh
            //
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(140, 115);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(150, 27);
            dtpNgaySinh.TabIndex = 5;
            //
            // chkNhanEmail
            //
            chkNhanEmail.AutoSize = true;
            chkNhanEmail.Location = new Point(140, 158);
            chkNhanEmail.Name = "chkNhanEmail";
            chkNhanEmail.TabIndex = 6;
            chkNhanEmail.Text = "Nhận email thông báo";
            chkNhanEmail.UseVisualStyleBackColor = true;
            //
            // grpKhoaHoc
            //
            grpKhoaHoc.Controls.Add(lblKhoaHoc);
            grpKhoaHoc.Controls.Add(cboKhoaHoc);
            grpKhoaHoc.Controls.Add(lblHinhThuc);
            grpKhoaHoc.Controls.Add(radOnline);
            grpKhoaHoc.Controls.Add(radOffline);
            grpKhoaHoc.Controls.Add(lblSoThang);
            grpKhoaHoc.Controls.Add(numSoThang);
            grpKhoaHoc.Controls.Add(lblTongTienTieuDe);
            grpKhoaHoc.Controls.Add(lblTongTien);
            grpKhoaHoc.Location = new Point(20, 280);
            grpKhoaHoc.Name = "grpKhoaHoc";
            grpKhoaHoc.Size = new Size(520, 220);
            grpKhoaHoc.TabIndex = 2;
            grpKhoaHoc.TabStop = false;
            grpKhoaHoc.Text = "Thông tin khóa học";
            //
            // lblKhoaHoc
            //
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(20, 38);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.TabIndex = 0;
            lblKhoaHoc.Text = "Khóa học:";
            //
            // cboKhoaHoc
            //
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(140, 35);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(350, 28);
            cboKhoaHoc.TabIndex = 1;
            cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;
            cboKhoaHoc.TextChanged += cboKhoaHoc_SelectedIndexChanged;
            //
            // lblHinhThuc
            //
            lblHinhThuc.AutoSize = true;
            lblHinhThuc.Location = new Point(20, 80);
            lblHinhThuc.Name = "lblHinhThuc";
            lblHinhThuc.TabIndex = 2;
            lblHinhThuc.Text = "Hình thức học:";
            //
            // radOnline
            //
            radOnline.AutoSize = true;
            radOnline.Checked = true;
            radOnline.Location = new Point(140, 78);
            radOnline.Name = "radOnline";
            radOnline.TabIndex = 3;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            //
            // radOffline
            //
            radOffline.AutoSize = true;
            radOffline.Location = new Point(250, 78);
            radOffline.Name = "radOffline";
            radOffline.TabIndex = 4;
            radOffline.Text = "Trực tiếp";
            radOffline.UseVisualStyleBackColor = true;
            //
            // lblSoThang
            //
            lblSoThang.AutoSize = true;
            lblSoThang.Location = new Point(20, 123);
            lblSoThang.Name = "lblSoThang";
            lblSoThang.TabIndex = 5;
            lblSoThang.Text = "Số tháng:";
            //
            // numSoThang
            //
            numSoThang.Location = new Point(140, 120);
            numSoThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(80, 27);
            numSoThang.TabIndex = 6;
            numSoThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.ValueChanged += numSoThang_ValueChanged;
            //
            // lblTongTienTieuDe
            //
            lblTongTienTieuDe.AutoSize = true;
            lblTongTienTieuDe.Location = new Point(20, 170);
            lblTongTienTieuDe.Name = "lblTongTienTieuDe";
            lblTongTienTieuDe.TabIndex = 7;
            lblTongTienTieuDe.Text = "Tổng học phí:";
            //
            // lblTongTien
            //
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.Firebrick;
            lblTongTien.Location = new Point(140, 167);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.TabIndex = 8;
            lblTongTien.Text = "0 VNĐ";
            //
            // btnDangKy
            //
            btnDangKy.Location = new Point(110, 520);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(110, 38);
            btnDangKy.TabIndex = 3;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(225, 520);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(110, 38);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // btnThoat
            //
            btnThoat.Location = new Point(340, 520);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(110, 38);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            //
            // FrmDangKyKhoaHoc
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 580);
            Controls.Add(lblTieuDe);
            Controls.Add(grpHocVien);
            Controls.Add(grpKhoaHoc);
            Controls.Add(btnDangKy);
            Controls.Add(btnLamMoi);
            Controls.Add(btnThoat);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmDangKyKhoaHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ĐĂNG KÝ KHÓA HỌC";
            Load += FrmDangKyKhoaHoc_Load;
            grpHocVien.ResumeLayout(false);
            grpHocVien.PerformLayout();
            grpKhoaHoc.ResumeLayout(false);
            grpKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private GroupBox grpHocVien;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private CheckBox chkNhanEmail;
        private GroupBox grpKhoaHoc;
        private Label lblKhoaHoc;
        private ComboBox cboKhoaHoc;
        private Label lblHinhThuc;
        private RadioButton radOnline;
        private RadioButton radOffline;
        private Label lblSoThang;
        private NumericUpDown numSoThang;
        private Label lblTongTienTieuDe;
        private Label lblTongTien;
        private Button btnDangKy;
        private Button btnLamMoi;
        private Button btnThoat;
    }
}
