namespace Lab01_Ungdungthongtincanhan
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblHoTen = new Label();
            lblNamSinh = new Label();
            txtHoTen = new TextBox();
            txtNamSinh = new TextBox();
            grpGioitinh = new GroupBox();
            radNu = new RadioButton();
            radNam = new RadioButton();
            lblEmail = new Label();
            cboKhoa = new ComboBox();
            btnHienThi = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            txtEmail = new TextBox();
            lblKhoa = new Label();
            grpGioitinh.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = SystemColors.Control;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.SteelBlue;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN CÁ NHÂN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoTen.ForeColor = Color.SteelBlue;
            lblHoTen.Location = new Point(30, 80);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(59, 20);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên:";
            // 
            // lblNamSinh
            // 
            lblNamSinh.AutoSize = true;
            lblNamSinh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNamSinh.ForeColor = Color.SteelBlue;
            lblNamSinh.Location = new Point(30, 120);
            lblNamSinh.Name = "lblNamSinh";
            lblNamSinh.Size = new Size(78, 20);
            lblNamSinh.TabIndex = 2;
            lblNamSinh.Text = "Năm sinh:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(160, 77);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 27);
            txtHoTen.TabIndex = 3;
            // 
            // txtNamSinh
            // 
            txtNamSinh.Location = new Point(160, 117);
            txtNamSinh.Name = "txtNamSinh";
            txtNamSinh.Size = new Size(150, 27);
            txtNamSinh.TabIndex = 4;
            // 
            // grpGioitinh
            // 
            grpGioitinh.Controls.Add(radNu);
            grpGioitinh.Controls.Add(radNam);
            grpGioitinh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpGioitinh.ForeColor = Color.SteelBlue;
            grpGioitinh.Location = new Point(30, 195);
            grpGioitinh.Name = "grpGioitinh";
            grpGioitinh.Size = new Size(430, 50);
            grpGioitinh.TabIndex = 5;
            grpGioitinh.TabStop = false;
            grpGioitinh.Text = "Giới tính";
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(120, 20);
            radNu.Name = "radNu";
            radNu.Size = new Size(51, 24);
            radNu.TabIndex = 1;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(20, 20);
            radNam.Name = "radNam";
            radNam.Size = new Size(63, 24);
            radNam.TabIndex = 0;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.SteelBlue;
            lblEmail.Location = new Point(30, 154);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(50, 20);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Items.AddRange(new object[] { "các ngành tôi chọn:", "Sư phạm Tin học", "Công nghệ Thông tin", "Chính trị học", "Công tác xã hội", "Địa lý học", "Du lịch", "Giáo dục Chính trị", "Giáo dục Mầm non" });
            cboKhoa.Location = new Point(160, 255);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(300, 28);
            cboKhoa.TabIndex = 7;
            // 
            // btnHienThi
            // 
            btnHienThi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHienThi.ForeColor = Color.MidnightBlue;
            btnHienThi.Location = new Point(30, 300);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(120, 40);
            btnHienThi.TabIndex = 8;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = Color.MidnightBlue;
            btnXoa.Location = new Point(170, 300);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 40);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.ForeColor = Color.MidnightBlue;
            btnThoat.Location = new Point(310, 300);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(150, 40);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(160, 157);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 27);
            txtEmail.TabIndex = 11;
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKhoa.ForeColor = Color.SteelBlue;
            lblKhoa.Location = new Point(30, 258);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(79, 20);
            lblKhoa.TabIndex = 12;
            lblKhoa.Text = "Khoa/Lớp:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(532, 353);
            Controls.Add(lblKhoa);
            Controls.Add(txtEmail);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnHienThi);
            Controls.Add(cboKhoa);
            Controls.Add(lblEmail);
            Controls.Add(grpGioitinh);
            Controls.Add(txtNamSinh);
            Controls.Add(txtHoTen);
            Controls.Add(lblNamSinh);
            Controls.Add(lblHoTen);
            Controls.Add(lblTitle);
            ForeColor = SystemColors.Menu;
            Name = "Form1";
            Text = "Lab 01 - Ứng dụng thông tin cá nhân";
            Load += Form1_Load;
            grpGioitinh.ResumeLayout(false);
            grpGioitinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHoTen;
        private Label lblNamSinh;
        private TextBox txtHoTen;
        private TextBox txtNamSinh;
        private GroupBox grpGioitinh;
        private RadioButton radNu;
        private RadioButton radNam;
        private Label lblEmail;
        private ComboBox cboKhoa;
        private Button btnHienThi;
        private Button btnXoa;
        private Button btnThoat;
        private TextBox txtEmail;
        private Label lblKhoa;
    }
}
