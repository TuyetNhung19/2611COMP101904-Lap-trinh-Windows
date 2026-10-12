namespace ShopManagerMini.Forms
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            mnuSystem = new ToolStripMenuItem();
            mnuLogout = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuCatalog = new ToolStripMenuItem();
            mnuProduct = new ToolStripMenuItem();
            mnuCustomer = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblUser = new ToolStripStatusLabel();
            lblRole = new ToolStripStatusLabel();
            lblTime = new ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuSystem, mnuCatalog, mnuHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 2, 0, 2);
            menuStrip1.Size = new Size(1080, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuSystem
            // 
            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuLogout, mnuExit });
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Size = new Size(85, 24);
            mnuSystem.Text = "Hệ thống";
            // 
            // mnuLogout
            // 
            mnuLogout.Name = "mnuLogout";
            mnuLogout.Size = new Size(160, 26);
            mnuLogout.Text = "Đăng xuất";
            mnuLogout.Click += mnuLogout_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(160, 26);
            mnuExit.Text = "Thoát";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuCatalog
            // 
            mnuCatalog.DropDownItems.AddRange(new ToolStripItem[] { mnuProduct, mnuCustomer });
            mnuCatalog.Name = "mnuCatalog";
            mnuCatalog.Size = new Size(90, 24);
            mnuCatalog.Text = "Danh mục";
            // 
            // mnuProduct
            // 
            mnuProduct.Name = "mnuProduct";
            mnuProduct.Size = new Size(221, 26);
            mnuProduct.Text = "Quản lý sản phẩm";
            mnuProduct.Click += mnuProduct_Click;
            // 
            // mnuCustomer
            // 
            mnuCustomer.Name = "mnuCustomer";
            mnuCustomer.Size = new Size(221, 26);
            mnuCustomer.Text = "Quản lý khách hàng";
            mnuCustomer.Click += mnuCustomer_Click;
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(78, 24);
            mnuHelp.Text = "Trợ giúp";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(156, 26);
            mnuAbout.Text = "Giới thiệu";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblUser, lblRole, lblTime });
            statusStrip1.Location = new Point(0, 413);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1080, 30);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblUser
            // 
            lblUser.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(100, 24);
            lblUser.Text = "Người dùng: ";
            // 
            // lblRole
            // 
            lblRole.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(63, 24);
            lblRole.Text = "Vai trò: ";
            // 
            // lblTime
            // 
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(898, 24);
            lblTime.Spring = true;
            lblTime.Text = "Thời gian";
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 443);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShopManagerMini";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuSystem;
        private ToolStripMenuItem mnuLogout;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuCatalog;
        private ToolStripMenuItem mnuProduct;
        private ToolStripMenuItem mnuCustomer;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuAbout;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblUser;
        private ToolStripStatusLabel lblRole;
        private ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timer1;
    }
}
