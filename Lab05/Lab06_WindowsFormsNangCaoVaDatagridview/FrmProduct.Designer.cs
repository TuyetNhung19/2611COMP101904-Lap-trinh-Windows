namespace Lab06_WindowsFormsNangCaoVaDatagridview
{
    partial class FrmProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduct));
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuFileLamMoi = new ToolStripMenuItem();
            mnuFileExit = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuThem = new ToolStripMenuItem();
            mnuSua = new ToolStripMenuItem();
            mnuXoa = new ToolStripMenuItem();
            mnuTimKiem = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            tsbThem = new ToolStripButton();
            tsbSua = new ToolStripButton();
            tsbxoa = new ToolStripButton();
            tsbLamMoi = new ToolStripButton();
            tsbTimKiem = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            grbThongTin = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuQuanLy, mnuHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(982, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileLamMoi, mnuFileExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(46, 24);
            mnuFile.Text = "File";
            mnuFile.Click += fileToolStripMenuItem_Click;
            // 
            // mnuFileLamMoi
            // 
            mnuFileLamMoi.Name = "mnuFileLamMoi";
            mnuFileLamMoi.ShortcutKeys = Keys.F5;
            mnuFileLamMoi.Size = new Size(224, 26);
            mnuFileLamMoi.Text = "Làm mới";
            // 
            // mnuFileExit
            // 
            mnuFileExit.Name = "mnuFileExit";
            mnuFileExit.Size = new Size(224, 26);
            mnuFileExit.Text = "Thoát";
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuThem, mnuSua, mnuXoa, mnuTimKiem });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(73, 24);
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuThem
            // 
            mnuThem.Name = "mnuThem";
            mnuThem.ShortcutKeys = Keys.Control | Keys.N;
            mnuThem.Size = new Size(224, 26);
            mnuThem.Text = "Thêm";
            // 
            // mnuSua
            // 
            mnuSua.Name = "mnuSua";
            mnuSua.ShortcutKeys = Keys.Control | Keys.E;
            mnuSua.Size = new Size(224, 26);
            mnuSua.Text = "Sửa";
            // 
            // mnuXoa
            // 
            mnuXoa.Name = "mnuXoa";
            mnuXoa.ShortcutKeys = Keys.Control | Keys.D;
            mnuXoa.Size = new Size(224, 26);
            mnuXoa.Text = "Xóa";
            // 
            // mnuTimKiem
            // 
            mnuTimKiem.Name = "mnuTimKiem";
            mnuTimKiem.ShortcutKeys = Keys.Control | Keys.F;
            mnuTimKiem.Size = new Size(224, 26);
            mnuTimKiem.Text = "Tìm kiếm";
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
            mnuAbout.Size = new Size(224, 26);
            mnuAbout.Text = "Giới thiệu";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbThem, tsbSua, tsbxoa, tsbLamMoi, tsbTimKiem });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(982, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbThem
            // 
            tsbThem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbThem.Image = (Image)resources.GetObject("tsbThem.Image");
            tsbThem.ImageTransparentColor = Color.Magenta;
            tsbThem.Name = "tsbThem";
            tsbThem.Size = new Size(50, 24);
            tsbThem.Text = "Thêm";
            tsbThem.Click += toolStripButton1_Click;
            // 
            // tsbSua
            // 
            tsbSua.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbSua.Image = (Image)resources.GetObject("tsbSua.Image");
            tsbSua.ImageTransparentColor = Color.Magenta;
            tsbSua.Name = "tsbSua";
            tsbSua.Size = new Size(38, 24);
            tsbSua.Text = "Sửa";
            // 
            // tsbxoa
            // 
            tsbxoa.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbxoa.Image = (Image)resources.GetObject("tsbxoa.Image");
            tsbxoa.ImageTransparentColor = Color.Magenta;
            tsbxoa.Name = "tsbxoa";
            tsbxoa.Size = new Size(39, 24);
            tsbxoa.Text = "Xóa";
            // 
            // tsbLamMoi
            // 
            tsbLamMoi.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbLamMoi.Image = (Image)resources.GetObject("tsbLamMoi.Image");
            tsbLamMoi.ImageTransparentColor = Color.Magenta;
            tsbLamMoi.Name = "tsbLamMoi";
            tsbLamMoi.Size = new Size(71, 24);
            tsbLamMoi.Text = "Làm mới";
            // 
            // tsbTimKiem
            // 
            tsbTimKiem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbTimKiem.Image = (Image)resources.GetObject("tsbTimKiem.Image");
            tsbTimKiem.ImageTransparentColor = Color.Magenta;
            tsbTimKiem.Name = "tsbTimKiem";
            tsbTimKiem.Size = new Size(74, 24);
            tsbTimKiem.Text = "Tìm kiếm";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { grbThongTin });
            statusStrip1.Location = new Point(0, 627);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(982, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // grbThongTin
            // 
            grbThongTin.Name = "grbThongTin";
            grbThongTin.Size = new Size(140, 20);
            grbThongTin.Text = "Thông tin sản phẩm";
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 653);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sản phẩm";
            Load += FrmProduct_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuFileLamMoi;
        private ToolStripMenuItem mnuFileExit;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuThem;
        private ToolStripMenuItem mnuSua;
        private ToolStripMenuItem mnuXoa;
        private ToolStripMenuItem mnuTimKiem;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuAbout;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbThem;
        private ToolStripButton tsbSua;
        private ToolStripButton tsbxoa;
        private ToolStripButton tsbLamMoi;
        private ToolStripButton tsbTimKiem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel grbThongTin;
    }
}
