namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
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
            pnlLoc = new Panel();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblKetQua = new Label();
            cboKetQua = new ComboBox();
            lblTuKhoa = new Label();
            txtTuKhoa = new TextBox();
            btnXemBaoCao = new Button();
            btnThongKe = new Button();
            btnXuatFile = new Button();
            lblSapXep = new Label();
            cboSapXep = new ComboBox();
            lblTieuDe = new Label();
            ssThongKe = new StatusStrip();
            tslTongSo = new ToolStripStatusLabel();
            tslSoDat = new ToolStripStatusLabel();
            tslSoKhongDat = new ToolStripStatusLabel();
            tslDiemTB = new ToolStripStatusLabel();
            dgvBaoCao = new DataGridView();
            pnlLoc.SuspendLayout();
            ssThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // pnlLoc
            // 
            pnlLoc.Controls.Add(lblLop);
            pnlLoc.Controls.Add(cboLop);
            pnlLoc.Controls.Add(lblKetQua);
            pnlLoc.Controls.Add(cboKetQua);
            pnlLoc.Controls.Add(lblTuKhoa);
            pnlLoc.Controls.Add(txtTuKhoa);
            pnlLoc.Controls.Add(btnXemBaoCao);
            pnlLoc.Controls.Add(btnThongKe);
            pnlLoc.Controls.Add(btnXuatFile);
            pnlLoc.Controls.Add(lblSapXep);
            pnlLoc.Controls.Add(cboSapXep);
            pnlLoc.Dock = DockStyle.Top;
            pnlLoc.Location = new Point(0, 0);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1266, 114);
            pnlLoc.TabIndex = 0;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLop.Location = new Point(19, 23);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(44, 19);
            lblLop.TabIndex = 0;
            lblLop.Text = "Lớp:";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(76, 19);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(244, 27);
            cboLop.TabIndex = 0;
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKetQua.Location = new Point(367, 23);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(71, 19);
            lblKetQua.TabIndex = 1;
            lblKetQua.Text = "Kết quả:";
            // 
            // cboKetQua
            // 
            cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQua.FormattingEnabled = true;
            cboKetQua.Location = new Point(443, 19);
            cboKetQua.Name = "cboKetQua";
            cboKetQua.Size = new Size(166, 27);
            cboKetQua.TabIndex = 1;
            // 
            // lblTuKhoa
            // 
            lblTuKhoa.AutoSize = true;
            lblTuKhoa.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTuKhoa.Location = new Point(800, 23);
            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Size = new Size(74, 19);
            lblTuKhoa.TabIndex = 2;
            lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(901, 19);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Mã SV hoặc họ tên...";
            txtTuKhoa.Size = new Size(282, 27);
            txtTuKhoa.TabIndex = 2;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.BackColor = SystemColors.MenuHighlight;
            btnXemBaoCao.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXemBaoCao.ForeColor = SystemColors.ButtonFace;
            btnXemBaoCao.Location = new Point(19, 60);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(168, 38);
            btnXemBaoCao.TabIndex = 3;
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = false;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.Green;
            btnThongKe.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThongKe.ForeColor = SystemColors.ButtonFace;
            btnThongKe.Location = new Point(199, 60);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(192, 38);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "Thống kê theo lớp";
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnXuatFile
            // 
            btnXuatFile.BackColor = Color.Firebrick;
            btnXuatFile.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatFile.ForeColor = SystemColors.ButtonFace;
            btnXuatFile.Location = new Point(405, 60);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(142, 38);
            btnXuatFile.TabIndex = 5;
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.UseVisualStyleBackColor = false;
            btnXuatFile.Click += btnXuatFile_Click;
            // 
            // lblSapXep
            // 
            lblSapXep.AutoSize = true;
            lblSapXep.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSapXep.Location = new Point(804, 72);
            lblSapXep.Name = "lblSapXep";
            lblSapXep.Size = new Size(70, 19);
            lblSapXep.TabIndex = 6;
            lblSapXep.Text = "Sắp xếp:";
            // 
            // cboSapXep
            // 
            cboSapXep.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSapXep.FormattingEnabled = true;
            cboSapXep.Location = new Point(903, 66);
            cboSapXep.Name = "cboSapXep";
            cboSapXep.Size = new Size(218, 27);
            cboSapXep.TabIndex = 6;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.MidnightBlue;
            lblTieuDe.Location = new Point(0, 114);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(1266, 41);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "BÁO CÁO SINH VIÊN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ssThongKe
            // 
            ssThongKe.ImageScalingSize = new Size(20, 20);
            ssThongKe.Items.AddRange(new ToolStripItem[] { tslTongSo, tslSoDat, tslSoKhongDat, tslDiemTB });
            ssThongKe.Location = new Point(0, 681);
            ssThongKe.Name = "ssThongKe";
            ssThongKe.Padding = new Padding(1, 0, 18, 0);
            ssThongKe.Size = new Size(1266, 30);
            ssThongKe.TabIndex = 2;
            // 
            // tslTongSo
            // 
            tslTongSo.BorderSides = ToolStripStatusLabelBorderSides.Right;
            tslTongSo.Name = "tslTongSo";
            tslTongSo.Size = new Size(102, 24);
            tslTongSo.Text = "Tổng số SV: 0";
            // 
            // tslSoDat
            // 
            tslSoDat.BorderSides = ToolStripStatusLabelBorderSides.Right;
            tslSoDat.Name = "tslSoDat";
            tslSoDat.Size = new Size(52, 24);
            tslSoDat.Text = "Đạt: 0";
            // 
            // tslSoKhongDat
            // 
            tslSoKhongDat.BorderSides = ToolStripStatusLabelBorderSides.Right;
            tslSoKhongDat.Name = "tslSoKhongDat";
            tslSoKhongDat.Size = new Size(97, 24);
            tslSoKhongDat.Text = "Không đạt: 0";
            // 
            // tslDiemTB
            // 
            tslDiemTB.Name = "tslDiemTB";
            tslDiemTB.Size = new Size(100, 24);
            tslDiemTB.Text = "Điểm TB: 0,00";
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.BackgroundColor = SystemColors.Window;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Dock = DockStyle.Fill;
            dgvBaoCao.Location = new Point(0, 155);
            dgvBaoCao.MultiSelect = false;
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.Size = new Size(1266, 526);
            dgvBaoCao.TabIndex = 3;
            // 
            // FrmBaoCaoSinhVien
            // 
            AcceptButton = btnXemBaoCao;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 711);
            Controls.Add(dgvBaoCao);
            Controls.Add(lblTieuDe);
            Controls.Add(ssThongKe);
            Controls.Add(pnlLoc);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(1088, 557);
            Name = "FrmBaoCaoSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo sinh viên theo lớp";
            Load += FrmBaoCaoSinhVien_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ssThongKe.ResumeLayout(false);
            ssThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlLoc;
        private Label lblLop;
        private ComboBox cboLop;
        private Label lblKetQua;
        private ComboBox cboKetQua;
        private Label lblTuKhoa;
        private TextBox txtTuKhoa;
        private Button btnXemBaoCao;
        private Button btnThongKe;
        private Button btnXuatFile;
        private Label lblSapXep;
        private ComboBox cboSapXep;
        private Label lblTieuDe;
        private StatusStrip ssThongKe;
        private ToolStripStatusLabel tslTongSo;
        private ToolStripStatusLabel tslSoDat;
        private ToolStripStatusLabel tslSoKhongDat;
        private ToolStripStatusLabel tslDiemTB;
        private DataGridView dgvBaoCao;
    }
}
