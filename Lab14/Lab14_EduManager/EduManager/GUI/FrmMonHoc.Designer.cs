namespace EduManager.GUI
{
    partial class FrmMonHoc
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
            grpThongTin = new GroupBox();
            lblMaMonHoc = new Label();
            txtMaMonHoc = new TextBox();
            lblTenMonHoc = new Label();
            txtTenMonHoc = new TextBox();
            lblSoTinChi = new Label();
            nudSoTinChi = new NumericUpDown();
            chkTrangThai = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvMonHoc = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.FromArgb(0, 70, 140);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(805, 50);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ MÔN HỌC";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblMaMonHoc);
            grpThongTin.Controls.Add(txtMaMonHoc);
            grpThongTin.Controls.Add(lblTenMonHoc);
            grpThongTin.Controls.Add(txtTenMonHoc);
            grpThongTin.Controls.Add(lblSoTinChi);
            grpThongTin.Controls.Add(nudSoTinChi);
            grpThongTin.Controls.Add(chkTrangThai);
            grpThongTin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpThongTin.Location = new Point(15, 55);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(775, 140);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin môn học";
            // 
            // lblMaMonHoc
            // 
            lblMaMonHoc.AutoSize = true;
            lblMaMonHoc.Location = new Point(20, 38);
            lblMaMonHoc.Name = "lblMaMonHoc";
            lblMaMonHoc.Size = new Size(100, 20);
            lblMaMonHoc.TabIndex = 0;
            lblMaMonHoc.Text = "Mã môn học:";
            // 
            // txtMaMonHoc
            // 
            txtMaMonHoc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaMonHoc.Location = new Point(122, 35);
            txtMaMonHoc.MaxLength = 10;
            txtMaMonHoc.Name = "txtMaMonHoc";
            txtMaMonHoc.Size = new Size(220, 27);
            txtMaMonHoc.TabIndex = 0;
            // 
            // lblTenMonHoc
            // 
            lblTenMonHoc.AutoSize = true;
            lblTenMonHoc.Location = new Point(380, 38);
            lblTenMonHoc.Name = "lblTenMonHoc";
            lblTenMonHoc.Size = new Size(103, 20);
            lblTenMonHoc.TabIndex = 1;
            lblTenMonHoc.Text = "Tên môn học:";
            // 
            // txtTenMonHoc
            // 
            txtTenMonHoc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenMonHoc.Location = new Point(483, 35);
            txtTenMonHoc.MaxLength = 100;
            txtTenMonHoc.Name = "txtTenMonHoc";
            txtTenMonHoc.Size = new Size(275, 27);
            txtTenMonHoc.TabIndex = 1;
            // 
            // lblSoTinChi
            // 
            lblSoTinChi.AutoSize = true;
            lblSoTinChi.Location = new Point(20, 90);
            lblSoTinChi.Name = "lblSoTinChi";
            lblSoTinChi.Size = new Size(77, 20);
            lblSoTinChi.TabIndex = 2;
            lblSoTinChi.Text = "Số tín chỉ:";
            // 
            // nudSoTinChi
            // 
            nudSoTinChi.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudSoTinChi.Location = new Point(122, 87);
            nudSoTinChi.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            nudSoTinChi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoTinChi.Name = "nudSoTinChi";
            nudSoTinChi.Size = new Size(100, 27);
            nudSoTinChi.TabIndex = 2;
            nudSoTinChi.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = CheckState.Checked;
            chkTrangThai.Location = new Point(380, 89);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(119, 24);
            chkTrangThai.TabIndex = 3;
            chkTrangThai.Text = "Còn sử dụng";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.SeaGreen;
            btnThem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.ButtonHighlight;
            btnThem.Location = new Point(15, 207);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 36);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.SteelBlue;
            btnSua.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = SystemColors.ButtonHighlight;
            btnSua.Location = new Point(125, 207);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 36);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.IndianRed;
            btnXoa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = SystemColors.ButtonHighlight;
            btnXoa.Location = new Point(235, 207);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 36);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Moccasin;
            btnLamMoi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.Location = new Point(345, 207);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 36);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimKiem.Location = new Point(460, 215);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(75, 20);
            lblTimKiem.TabIndex = 8;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(538, 212);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên...";
            txtTimKiem.Size = new Size(145, 27);
            txtTimKiem.TabIndex = 5;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.DarkGreen;
            btnTimKiem.Location = new Point(690, 207);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 36);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvMonHoc
            // 
            dgvMonHoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMonHoc.BackgroundColor = SystemColors.AppWorkspace;
            dgvMonHoc.ColumnHeadersHeight = 29;
            dgvMonHoc.Location = new Point(15, 255);
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.RowHeadersWidth = 51;
            dgvMonHoc.Size = new Size(775, 300);
            dgvMonHoc.TabIndex = 7;
            dgvMonHoc.CellClick += dgvMonHoc_CellClick;
            // 
            // FrmMonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 570);
            Controls.Add(dgvMonHoc);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(lblTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(grpThongTin);
            Controls.Add(lblTieuDe);
            MinimumSize = new Size(823, 617);
            Name = "FrmMonHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EduManager - Quản lý môn học";
            Load += FrmMonHoc_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private GroupBox grpThongTin;
        private Label lblMaMonHoc;
        private Label lblTenMonHoc;
        private Label lblSoTinChi;
        private TextBox txtMaMonHoc;
        private TextBox txtTenMonHoc;
        private NumericUpDown nudSoTinChi;
        private CheckBox chkTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvMonHoc;
    }
}
