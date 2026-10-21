#nullable disable
using System.Drawing;
using System.Windows.Forms;

namespace QLSinhVienLab12.Forms
{
    partial class FrmNhapDiemTheoLop
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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
            pnlTop = new Panel();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblMonHoc = new Label();
            cboMonHoc = new ComboBox();
            btnTaiDanhSach = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnLuuTatCa = new Button();
            dgvKetQua = new DataGridView();
            ssTrangThai = new StatusStrip();
            tslTrangThai = new ToolStripStatusLabel();
            tslThongKe = new ToolStripStatusLabel();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            ssTrangThai.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(240, 244, 248);
            pnlTop.Controls.Add(lblLop);
            pnlTop.Controls.Add(cboLop);
            pnlTop.Controls.Add(lblMonHoc);
            pnlTop.Controls.Add(cboMonHoc);
            pnlTop.Controls.Add(btnTaiDanhSach);
            pnlTop.Controls.Add(lblTimKiem);
            pnlTop.Controls.Add(txtTimKiem);
            pnlTop.Controls.Add(btnLuuTatCa);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(900, 100);
            pnlTop.TabIndex = 0;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLop.Location = new Point(15, 20);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(44, 19);
            lblLop.TabIndex = 0;
            lblLop.Text = "Lớp:";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(65, 16);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(230, 27);
            cboLop.TabIndex = 1;
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonHoc.Location = new Point(310, 20);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(79, 19);
            lblMonHoc.TabIndex = 2;
            lblMonHoc.Text = "Môn học:";
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(394, 16);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(270, 27);
            cboMonHoc.TabIndex = 3;
            // 
            // btnTaiDanhSach
            // 
            btnTaiDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTaiDanhSach.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaiDanhSach.Location = new Point(745, 12);
            btnTaiDanhSach.Name = "btnTaiDanhSach";
            btnTaiDanhSach.Size = new Size(140, 34);
            btnTaiDanhSach.TabIndex = 4;
            btnTaiDanhSach.Text = "Tải danh sách";
            btnTaiDanhSach.UseVisualStyleBackColor = true;
            btnTaiDanhSach.Click += btnTaiDanhSach_Click;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimKiem.Location = new Point(15, 62);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(86, 19);
            lblTimKiem.TabIndex = 5;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(102, 58);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập MSSV hoặc họ tên...";
            txtTimKiem.Size = new Size(300, 27);
            txtTimKiem.TabIndex = 6;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // btnLuuTatCa
            // 
            btnLuuTatCa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuuTatCa.BackColor = Color.SeaGreen;
            btnLuuTatCa.Enabled = false;
            btnLuuTatCa.FlatStyle = FlatStyle.Flat;
            btnLuuTatCa.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuuTatCa.ForeColor = Color.White;
            btnLuuTatCa.Location = new Point(745, 52);
            btnLuuTatCa.Name = "btnLuuTatCa";
            btnLuuTatCa.Size = new Size(140, 38);
            btnLuuTatCa.TabIndex = 7;
            btnLuuTatCa.Text = "Lưu tất cả";
            btnLuuTatCa.UseVisualStyleBackColor = false;
            btnLuuTatCa.Click += btnLuuTatCa_Click;
            // 
            // dgvKetQua
            // 
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.BackgroundColor = Color.White;
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKetQua.Dock = DockStyle.Fill;
            dgvKetQua.Location = new Point(0, 100);
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.RowHeadersWidth = 40;
            dgvKetQua.Size = new Size(900, 435);
            dgvKetQua.TabIndex = 1;
            // 
            // ssTrangThai
            // 
            ssTrangThai.ImageScalingSize = new Size(20, 20);
            ssTrangThai.Items.AddRange(new ToolStripItem[] { tslTrangThai, tslThongKe });
            ssTrangThai.Location = new Point(0, 535);
            ssTrangThai.Name = "ssTrangThai";
            ssTrangThai.Size = new Size(900, 25);
            ssTrangThai.TabIndex = 2;
            // 
            // tslTrangThai
            // 
            tslTrangThai.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tslTrangThai.Name = "tslTrangThai";
            tslTrangThai.Size = new Size(885, 19);
            tslTrangThai.Spring = true;
            tslTrangThai.Text = "Sẵn sàng";
            tslTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tslThongKe
            // 
            tslThongKe.Name = "tslThongKe";
            tslThongKe.Size = new Size(0, 19);
            // 
            // FrmNhapDiemTheoLop
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(900, 560);
            Controls.Add(dgvKetQua);
            Controls.Add(pnlTop);
            Controls.Add(ssTrangThai);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(860, 480);
            Name = "FrmNhapDiemTheoLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập điểm theo lớp";
            FormClosing += FrmNhapDiemTheoLop_FormClosing;
            Load += FrmNhapDiemTheoLop_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            ssTrangThai.ResumeLayout(false);
            ssTrangThai.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTop;
        private Label lblLop;
        private ComboBox cboLop;
        private Label lblMonHoc;
        private ComboBox cboMonHoc;
        private Button btnTaiDanhSach;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnLuuTatCa;
        private DataGridView dgvKetQua;
        private StatusStrip ssTrangThai;
        private ToolStripStatusLabel tslTrangThai;
        private ToolStripStatusLabel tslThongKe;
    }
}
