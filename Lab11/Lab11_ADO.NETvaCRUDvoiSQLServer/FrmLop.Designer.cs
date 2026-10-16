namespace Lab11_ADO.NETvaCRUDvoiSQLServer
{
    partial class FrmLop
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
            lblTieuDe = new System.Windows.Forms.Label();
            grpThongTin = new System.Windows.Forms.GroupBox();
            lblMaLop = new System.Windows.Forms.Label();
            txtMaLop = new System.Windows.Forms.TextBox();
            lblTenLop = new System.Windows.Forms.Label();
            txtTenLop = new System.Windows.Forms.TextBox();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            grpTimKiem = new System.Windows.Forms.GroupBox();
            txtTimKiem = new System.Windows.Forms.TextBox();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvLop = new System.Windows.Forms.DataGridView();
            grpThongTin.SuspendLayout();
            grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(0, 84, 147);
            lblTieuDe.Location = new System.Drawing.Point(20, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new System.Drawing.Size(277, 32);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ LỚP HỌC";
            // 
            // grpThongTin
            // 
            grpThongTin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpThongTin.Controls.Add(lblMaLop);
            grpThongTin.Controls.Add(txtMaLop);
            grpThongTin.Controls.Add(lblTenLop);
            grpThongTin.Controls.Add(txtTenLop);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Location = new System.Drawing.Point(20, 55);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new System.Drawing.Size(740, 140);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin lớp học";
            // 
            // lblMaLop
            // 
            lblMaLop.AutoSize = true;
            lblMaLop.Location = new System.Drawing.Point(20, 38);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Size = new System.Drawing.Size(67, 19);
            lblMaLop.TabIndex = 0;
            lblMaLop.Text = "Mã lớp:";
            // 
            // txtMaLop
            // 
            txtMaLop.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtMaLop.Location = new System.Drawing.Point(93, 38);
            txtMaLop.MaxLength = 20;
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new System.Drawing.Size(210, 27);
            txtMaLop.TabIndex = 0;
            // 
            // lblTenLop
            // 
            lblTenLop.AutoSize = true;
            lblTenLop.Location = new System.Drawing.Point(340, 38);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Size = new System.Drawing.Size(70, 19);
            lblTenLop.TabIndex = 1;
            lblTenLop.Text = "Tên lớp:";
            // 
            // txtTenLop
            // 
            txtTenLop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTenLop.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtTenLop.Location = new System.Drawing.Point(415, 35);
            txtTenLop.MaxLength = 100;
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new System.Drawing.Size(305, 27);
            txtTenLop.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.BackColor = System.Drawing.Color.SteelBlue;
            btnThem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnThem.Location = new System.Drawing.Point(20, 85);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(110, 34);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = System.Drawing.Color.DarkOliveGreen;
            btnSua.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnSua.Location = new System.Drawing.Point(145, 85);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(110, 34);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = System.Drawing.Color.Brown;
            btnXoa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnXoa.Location = new System.Drawing.Point(270, 85);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(110, 34);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.ForeColor = System.Drawing.Color.DarkGreen;
            btnLamMoi.Location = new System.Drawing.Point(395, 85);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(110, 34);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // grpTimKiem
            // 
            grpTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpTimKiem.Controls.Add(txtTimKiem);
            grpTimKiem.Controls.Add(btnTimKiem);
            grpTimKiem.Location = new System.Drawing.Point(20, 205);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new System.Drawing.Size(740, 70);
            grpTimKiem.TabIndex = 2;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTimKiem.Location = new System.Drawing.Point(20, 28);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã lớp hoặc tên lớp cần tìm...";
            txtTimKiem.Size = new System.Drawing.Size(560, 27);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnTimKiem.Location = new System.Drawing.Point(600, 25);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(120, 32);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvLop
            // 
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.AllowUserToResizeRows = false;
            dgvLop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.BackgroundColor = System.Drawing.Color.White;
            dgvLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLop.Location = new System.Drawing.Point(20, 290);
            dgvLop.MultiSelect = false;
            dgvLop.Name = "dgvLop";
            dgvLop.ReadOnly = true;
            dgvLop.RowHeadersVisible = false;
            dgvLop.RowHeadersWidth = 51;
            dgvLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvLop.Size = new System.Drawing.Size(740, 250);
            dgvLop.TabIndex = 3;
            dgvLop.CellClick += dgvLop_CellClick;
            // 
            // FrmLop
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(780, 560);
            Controls.Add(dgvLop);
            Controls.Add(grpTimKiem);
            Controls.Add(grpThongTin);
            Controls.Add(lblTieuDe);
            Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            MinimumSize = new System.Drawing.Size(640, 480);
            Name = "FrmLop";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản lý lớp học";
            Load += FrmLop_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvLop;
    }
}
