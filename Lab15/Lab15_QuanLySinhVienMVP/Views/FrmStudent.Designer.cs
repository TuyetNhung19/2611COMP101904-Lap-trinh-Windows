namespace QuanLySinhVienMVP.Views
{
    partial class FrmStudent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            gbInput = new GroupBox();
            lblId = new Label();
            txtId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblScore = new Label();
            txtScore = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            gbSearch = new GroupBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvStudents = new DataGridView();
            lblCount = new Label();
            lblStatus = new Label();
            gbInput.SuspendLayout();
            gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.SteelBlue;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(760, 50);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbInput
            // 
            gbInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbInput.Controls.Add(lblId);
            gbInput.Controls.Add(txtId);
            gbInput.Controls.Add(lblName);
            gbInput.Controls.Add(txtName);
            gbInput.Controls.Add(lblScore);
            gbInput.Controls.Add(txtScore);
            gbInput.Controls.Add(btnAdd);
            gbInput.Controls.Add(btnDelete);
            gbInput.Controls.Add(btnLoad);
            gbInput.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbInput.Location = new Point(15, 60);
            gbInput.Name = "gbInput";
            gbInput.Size = new Size(730, 100);
            gbInput.TabIndex = 2;
            gbInput.TabStop = false;
            gbInput.Text = "Thông tin sinh viên";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(15, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(57, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Mã SV:";
            // 
            // txtId
            // 
            txtId.Location = new Point(15, 52);
            txtId.Name = "txtId";
            txtId.Size = new Size(120, 27);
            txtId.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(150, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(79, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Họ và tên:";
            // 
            // txtName
            // 
            txtName.Location = new Point(150, 52);
            txtName.Name = "txtName";
            txtName.Size = new Size(230, 27);
            txtName.TabIndex = 3;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(395, 30);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(93, 20);
            lblScore.TabIndex = 4;
            lblScore.Text = "Điểm (0–10):";
            // 
            // txtScore
            // 
            txtScore.Location = new Point(395, 52);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(90, 27);
            txtScore.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.ForeColor = SystemColors.ButtonHighlight;
            btnAdd.Location = new Point(505, 48);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 34);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(581, 48);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(60, 34);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.CadetBlue;
            btnLoad.ForeColor = SystemColors.ButtonHighlight;
            btnLoad.Location = new Point(647, 48);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(70, 34);
            btnLoad.TabIndex = 8;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // gbSearch
            // 
            gbSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbSearch.Controls.Add(txtSearch);
            gbSearch.Controls.Add(btnSearch);
            gbSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbSearch.Location = new Point(15, 170);
            gbSearch.Name = "gbSearch";
            gbSearch.Size = new Size(730, 65);
            gbSearch.TabIndex = 1;
            gbSearch.TabStop = false;
            gbSearch.Text = "Tìm kiếm theo mã hoặc tên";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(15, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(580, 27);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = SystemColors.HotTrack;
            btnSearch.ForeColor = SystemColors.ButtonHighlight;
            btnSearch.Location = new Point(605, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 34);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudents.BackgroundColor = SystemColors.Window;
            dgvStudents.ColumnHeadersHeight = 29;
            dgvStudents.Location = new Point(15, 245);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(730, 230);
            dgvStudents.TabIndex = 0;
            dgvStudents.SelectionChanged += dgvStudents_SelectionChanged;
            // 
            // lblCount
            // 
            lblCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCount.AutoSize = true;
            lblCount.Location = new Point(15, 485);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 20);
            lblCount.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(230, 485);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 5;
            // 
            // FrmStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 520);
            Controls.Add(dgvStudents);
            Controls.Add(gbSearch);
            Controls.Add(gbInput);
            Controls.Add(lblTitle);
            Controls.Add(lblCount);
            Controls.Add(lblStatus);
            MinimumSize = new Size(776, 559);
            Name = "FrmStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab 15 - Quản lý sinh viên theo mô hình MVP";
            Load += FrmStudent_Load;
            gbInput.ResumeLayout(false);
            gbInput.PerformLayout();
            gbSearch.ResumeLayout(false);
            gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private GroupBox gbInput;
        private Label lblId;
        private Label lblName;
        private Label lblScore;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtScore;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnLoad;
        private GroupBox gbSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvStudents;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colScore;
        private Label lblCount;
        private Label lblStatus;
    }
}
