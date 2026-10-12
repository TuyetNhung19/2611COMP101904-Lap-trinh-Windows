namespace ShopManagerMini.Forms
{
    partial class FrmAbout
    {
        private System.ComponentModel.IContainer? components = null;

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
            lblAppName = new Label();
            lblDescription = new Label();
            grpApp = new GroupBox();
            lblVersion = new Label();
            lblFramework = new Label();
            lblSubject = new Label();
            grpStudent = new GroupBox();
            lblStudent = new Label();
            lblStudentId = new Label();
            lblClass = new Label();
            btnClose = new Button();
            grpApp.SuspendLayout();
            grpStudent.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.Firebrick;
            lblAppName.Location = new Point(165, 9);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(255, 32);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Shop Manager Mini";
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(20, 56);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(547, 62);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Ứng dụng quản lý cửa hàng mini nhiều Form (MDI): đăng nhập, quản lý sản phẩm và quản lý khách hàng.";
            // 
            // grpApp
            // 
            grpApp.Controls.Add(lblVersion);
            grpApp.Controls.Add(lblFramework);
            grpApp.Controls.Add(lblSubject);
            grpApp.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpApp.Location = new Point(20, 130);
            grpApp.Name = "grpApp";
            grpApp.Size = new Size(547, 120);
            grpApp.TabIndex = 2;
            grpApp.TabStop = false;
            grpApp.Text = "Thông tin ứng dụng";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(15, 28);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(127, 20);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "Phiên bản: 1.0.0";
            // 
            // lblFramework
            // 
            lblFramework.AutoSize = true;
            lblFramework.Location = new Point(15, 56);
            lblFramework.Name = "lblFramework";
            lblFramework.Size = new Size(249, 20);
            lblFramework.TabIndex = 1;
            lblFramework.Text = "Nền tảng: C# WinForms, .NET 8";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(15, 84);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(328, 20);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "Môn: COMP1019 - Lập trình trên Windows";
            // 
            // grpStudent
            // 
            grpStudent.Controls.Add(lblStudent);
            grpStudent.Controls.Add(lblStudentId);
            grpStudent.Controls.Add(lblClass);
            grpStudent.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpStudent.Location = new Point(20, 260);
            grpStudent.Name = "grpStudent";
            grpStudent.Size = new Size(547, 120);
            grpStudent.TabIndex = 3;
            grpStudent.TabStop = false;
            grpStudent.Text = "Thông tin sinh viên";
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(15, 28);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(249, 20);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Sinh viên: Võ Ngọc Tuyết Nhung";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(15, 56);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(170, 20);
            lblStudentId.TabIndex = 1;
            lblStudentId.Text = "MSSV: 49.01.103.058";
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(15, 84);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(163, 20);
            lblClass.TabIndex = 2;
            lblClass.Text = "Lớp: 49.01.SPTIN.A";
            // 
            // btnClose
            // 
            btnClose.ForeColor = Color.DarkRed;
            btnClose.Location = new Point(459, 402);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 32);
            btnClose.TabIndex = 4;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FrmAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 446);
            Controls.Add(lblAppName);
            Controls.Add(lblDescription);
            Controls.Add(grpApp);
            Controls.Add(grpStudent);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAbout";
            Text = "Giới thiệu";
            Load += FrmAbout_Load;
            grpApp.ResumeLayout(false);
            grpApp.PerformLayout();
            grpStudent.ResumeLayout(false);
            grpStudent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private Label lblDescription;
        private GroupBox grpApp;
        private Label lblVersion;
        private Label lblFramework;
        private Label lblSubject;
        private GroupBox grpStudent;
        private Label lblStudent;
        private Label lblStudentId;
        private Label lblClass;
        private Button btnClose;
    }
}