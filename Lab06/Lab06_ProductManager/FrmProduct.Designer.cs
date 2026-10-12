namespace Lab06_ProductManager
{
    partial class FrmProduct
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
            tsbXoa = new ToolStripButton();
            tsbLamMoi = new ToolStripButton();
            tsbTimKiem = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            grbThongTin = new GroupBox();
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblLoaiSP = new Label();
            cboLoaiSP = new ComboBox();
            lblDonGia = new Label();
            numDonGia = new NumericUpDown();
            lblSoLuong = new Label();
            numSoLuong = new NumericUpDown();
            lblNgayNhap = new Label();
            dtpNgayNhap = new DateTimePicker();
            chkConKinhDoanh = new CheckBox();
            picSanPham = new PictureBox();
            btnChonAnh = new Button();
            pnlButtons = new Panel();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvProducts = new DataGridView();
            cmsProduct = new ContextMenuStrip(components);
            cmsSua = new ToolStripMenuItem();
            cmsXoa = new ToolStripMenuItem();
            cmsChiTiet = new ToolStripMenuItem();
            errorProvider1 = new ErrorProvider(components);
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSanPham).BeginInit();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            cmsProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.SteelBlue;
            menuStrip1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuQuanLy, mnuHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1125, 27);
            menuStrip1.TabIndex = 0;
            // 
            // mnuFile
            // 
            mnuFile.BackColor = Color.SteelBlue;
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileLamMoi, mnuFileExit });
            mnuFile.ForeColor = Color.MidnightBlue;
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(47, 21);
            mnuFile.Text = "File";
            // 
            // mnuFileLamMoi
            // 
            mnuFileLamMoi.Name = "mnuFileLamMoi";
            mnuFileLamMoi.ShortcutKeys = Keys.F5;
            mnuFileLamMoi.Size = new Size(224, 26);
            mnuFileLamMoi.Text = "Làm mới";
            mnuFileLamMoi.Click += btnLamMoi_Click;
            // 
            // mnuFileExit
            // 
            mnuFileExit.Name = "mnuFileExit";
            mnuFileExit.Size = new Size(224, 26);
            mnuFileExit.Text = "Thoát";
            mnuFileExit.Click += mnuFileExit_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.BackColor = Color.SteelBlue;
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuThem, mnuSua, mnuXoa, mnuTimKiem });
            mnuQuanLy.ForeColor = Color.MidnightBlue;
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(72, 21);
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuThem
            // 
            mnuThem.Name = "mnuThem";
            mnuThem.ShortcutKeys = Keys.Control | Keys.N;
            mnuThem.Size = new Size(224, 26);
            mnuThem.Text = "Thêm";
            mnuThem.Click += btnThem_Click;
            // 
            // mnuSua
            // 
            mnuSua.Name = "mnuSua";
            mnuSua.ShortcutKeys = Keys.Control | Keys.E;
            mnuSua.Size = new Size(224, 26);
            mnuSua.Text = "Sửa";
            mnuSua.Click += btnSua_Click;
            // 
            // mnuXoa
            // 
            mnuXoa.Name = "mnuXoa";
            mnuXoa.ShortcutKeys = Keys.Control | Keys.D;
            mnuXoa.Size = new Size(224, 26);
            mnuXoa.Text = "Xóa";
            mnuXoa.Click += btnXoa_Click;
            // 
            // mnuTimKiem
            // 
            mnuTimKiem.Name = "mnuTimKiem";
            mnuTimKiem.ShortcutKeys = Keys.Control | Keys.F;
            mnuTimKiem.Size = new Size(224, 26);
            mnuTimKiem.Text = "Tìm kiếm";
            mnuTimKiem.Click += btnTimKiem_Click;
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            mnuHelp.ForeColor = Color.MidnightBlue;
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(77, 21);
            mnuHelp.Text = "Trợ giúp";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(224, 26);
            mnuAbout.Text = "Giới thiệu";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbThem, tsbSua, tsbXoa, tsbLamMoi, tsbTimKiem });
            toolStrip1.Location = new Point(0, 27);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1125, 26);
            toolStrip1.TabIndex = 1;
            // 
            // tsbThem
            // 
            tsbThem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbThem.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbThem.ForeColor = Color.SteelBlue;
            tsbThem.Name = "tsbThem";
            tsbThem.Size = new Size(47, 23);
            tsbThem.Text = "Thêm";
            tsbThem.Click += btnThem_Click;
            // 
            // tsbSua
            // 
            tsbSua.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbSua.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbSua.ForeColor = Color.SteelBlue;
            tsbSua.Name = "tsbSua";
            tsbSua.Size = new Size(35, 23);
            tsbSua.Text = "Sửa";
            tsbSua.Click += btnSua_Click;
            // 
            // tsbXoa
            // 
            tsbXoa.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbXoa.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbXoa.ForeColor = Color.SteelBlue;
            tsbXoa.Name = "tsbXoa";
            tsbXoa.Size = new Size(38, 23);
            tsbXoa.Text = "Xóa";
            tsbXoa.Click += btnXoa_Click;
            // 
            // tsbLamMoi
            // 
            tsbLamMoi.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbLamMoi.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbLamMoi.ForeColor = Color.SteelBlue;
            tsbLamMoi.Name = "tsbLamMoi";
            tsbLamMoi.Size = new Size(66, 23);
            tsbLamMoi.Text = "Làm mới";
            tsbLamMoi.Click += btnLamMoi_Click;
            // 
            // tsbTimKiem
            // 
            tsbTimKiem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbTimKiem.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbTimKiem.ForeColor = Color.SteelBlue;
            tsbTimKiem.Name = "tsbTimKiem";
            tsbTimKiem.Size = new Size(70, 23);
            tsbTimKiem.Text = "Tìm kiếm";
            tsbTimKiem.Click += btnTimKiem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 855);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1125, 26);
            statusStrip1.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(68, 20);
            lblStatus.Text = "Sẵn sàng";
            // 
            // grbThongTin
            // 
            grbThongTin.BackColor = Color.Lavender;
            grbThongTin.Controls.Add(lblMaSP);
            grbThongTin.Controls.Add(txtMaSP);
            grbThongTin.Controls.Add(lblTenSP);
            grbThongTin.Controls.Add(txtTenSP);
            grbThongTin.Controls.Add(lblLoaiSP);
            grbThongTin.Controls.Add(cboLoaiSP);
            grbThongTin.Controls.Add(lblDonGia);
            grbThongTin.Controls.Add(numDonGia);
            grbThongTin.Controls.Add(lblSoLuong);
            grbThongTin.Controls.Add(numSoLuong);
            grbThongTin.Controls.Add(lblNgayNhap);
            grbThongTin.Controls.Add(dtpNgayNhap);
            grbThongTin.Controls.Add(chkConKinhDoanh);
            grbThongTin.Controls.Add(picSanPham);
            grbThongTin.Controls.Add(btnChonAnh);
            grbThongTin.Dock = DockStyle.Top;
            grbThongTin.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grbThongTin.Location = new Point(0, 53);
            grbThongTin.Margin = new Padding(3, 4, 3, 4);
            grbThongTin.Name = "grbThongTin";
            grbThongTin.Padding = new Padding(3, 4, 3, 4);
            grbThongTin.Size = new Size(1125, 333);
            grbThongTin.TabIndex = 3;
            grbThongTin.TabStop = false;
            grbThongTin.Text = "Thông tin sản phẩm";
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(23, 51);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(57, 19);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã SP";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(149, 47);
            txtMaSP.Margin = new Padding(3, 4, 3, 4);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(228, 27);
            txtMaSP.TabIndex = 0;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Location = new Point(23, 104);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(60, 19);
            lblTenSP.TabIndex = 1;
            lblTenSP.Text = "Tên SP";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(149, 100);
            txtTenSP.Margin = new Padding(3, 4, 3, 4);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(228, 27);
            txtTenSP.TabIndex = 1;
            // 
            // lblLoaiSP
            // 
            lblLoaiSP.AutoSize = true;
            lblLoaiSP.Location = new Point(23, 157);
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Size = new Size(67, 19);
            lblLoaiSP.TabIndex = 2;
            lblLoaiSP.Text = "Loại SP";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.Location = new Point(149, 153);
            cboLoaiSP.Margin = new Padding(3, 4, 3, 4);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(228, 27);
            cboLoaiSP.TabIndex = 2;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(23, 211);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(66, 19);
            lblDonGia.TabIndex = 3;
            lblDonGia.Text = "Đơn giá";
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(149, 203);
            numDonGia.Margin = new Padding(3, 7, 3, 7);
            numDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(228, 27);
            numDonGia.TabIndex = 3;
            numDonGia.ThousandsSeparator = true;
            numDonGia.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(23, 264);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(74, 19);
            lblSoLuong.TabIndex = 4;
            lblSoLuong.Text = "Số lượng";
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(149, 256);
            numSoLuong.Margin = new Padding(3, 7, 3, 7);
            numSoLuong.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(228, 27);
            numSoLuong.TabIndex = 4;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Location = new Point(423, 51);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(85, 19);
            lblNgayNhap.TabIndex = 5;
            lblNgayNhap.Text = "Ngày nhập";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Format = DateTimePickerFormat.Short;
            dtpNgayNhap.Location = new Point(537, 47);
            dtpNgayNhap.Margin = new Padding(3, 4, 3, 4);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(228, 27);
            dtpNgayNhap.TabIndex = 5;
            // 
            // chkConKinhDoanh
            // 
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Checked = true;
            chkConKinhDoanh.CheckState = CheckState.Checked;
            chkConKinhDoanh.Location = new Point(537, 104);
            chkConKinhDoanh.Margin = new Padding(3, 4, 3, 4);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.Size = new Size(146, 23);
            chkConKinhDoanh.TabIndex = 6;
            chkConKinhDoanh.Text = "Còn kinh doanh";
            // 
            // picSanPham
            // 
            picSanPham.BorderStyle = BorderStyle.FixedSingle;
            picSanPham.Location = new Point(834, 46);
            picSanPham.Margin = new Padding(3, 4, 3, 4);
            picSanPham.Name = "picSanPham";
            picSanPham.Size = new Size(194, 213);
            picSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            picSanPham.TabIndex = 7;
            picSanPham.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.ForeColor = Color.Brown;
            btnChonAnh.Location = new Point(834, 267);
            btnChonAnh.Margin = new Padding(3, 4, 3, 4);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(194, 43);
            btnChonAnh.TabIndex = 7;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(txtTimKiem);
            pnlButtons.Controls.Add(btnTimKiem);
            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnSua);
            pnlButtons.Controls.Add(btnXoa);
            pnlButtons.Controls.Add(btnLamMoi);
            pnlButtons.Dock = DockStyle.Top;
            pnlButtons.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlButtons.Location = new Point(0, 386);
            pnlButtons.Margin = new Padding(3, 4, 3, 4);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(1125, 67);
            pnlButtons.TabIndex = 4;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(23, 16);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên sản phẩm...";
            txtTimKiem.Size = new Size(251, 25);
            txtTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.SteelBlue;
            btnTimKiem.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.ButtonFace;
            btnTimKiem.Location = new Point(291, 12);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(103, 43);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.SteelBlue;
            btnThem.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.ButtonFace;
            btnThem.Location = new Point(457, 12);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(103, 43);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.SteelBlue;
            btnSua.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = SystemColors.ButtonFace;
            btnSua.Location = new Point(571, 12);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(103, 43);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.SteelBlue;
            btnXoa.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = SystemColors.ButtonFace;
            btnXoa.Location = new Point(686, 12);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(103, 43);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.SteelBlue;
            btnLamMoi.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = SystemColors.ButtonFace;
            btnLamMoi.Location = new Point(800, 12);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(103, 43);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = SystemColors.ControlLight;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.ContextMenuStrip = cmsProduct;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(0, 453);
            dgvProducts.Margin = new Padding(3, 4, 3, 4);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1125, 402);
            dgvProducts.TabIndex = 5;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellMouseDown += dgvProducts_CellMouseDown;
            // 
            // cmsProduct
            // 
            cmsProduct.ImageScalingSize = new Size(20, 20);
            cmsProduct.Items.AddRange(new ToolStripItem[] { cmsSua, cmsXoa, cmsChiTiet });
            cmsProduct.Name = "cmsProduct";
            cmsProduct.Size = new Size(158, 76);
            // 
            // cmsSua
            // 
            cmsSua.Name = "cmsSua";
            cmsSua.Size = new Size(157, 24);
            cmsSua.Text = "Sửa";
            cmsSua.Click += btnSua_Click;
            // 
            // cmsXoa
            // 
            cmsXoa.Name = "cmsXoa";
            cmsXoa.Size = new Size(157, 24);
            cmsXoa.Text = "Xóa";
            cmsXoa.Click += btnXoa_Click;
            // 
            // cmsChiTiet
            // 
            cmsChiTiet.Name = "cmsChiTiet";
            cmsChiTiet.Size = new Size(157, 24);
            cmsChiTiet.Text = "Xem chi tiết";
            cmsChiTiet.Click += cmsChiTiet_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1125, 881);
            Controls.Add(dgvProducts);
            Controls.Add(pnlButtons);
            Controls.Add(grbThongTin);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            ForeColor = SystemColors.ActiveCaptionText;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
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
            grbThongTin.ResumeLayout(false);
            grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSanPham).EndInit();
            pnlButtons.ResumeLayout(false);
            pnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            cmsProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
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
        private ToolStripButton tsbXoa;
        private ToolStripButton tsbLamMoi;
        private ToolStripButton tsbTimKiem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private GroupBox grbThongTin;
        private Label lblMaSP;
        private TextBox txtMaSP;
        private Label lblTenSP;
        private TextBox txtTenSP;
        private Label lblLoaiSP;
        private ComboBox cboLoaiSP;
        private Label lblDonGia;
        private NumericUpDown numDonGia;
        private Label lblSoLuong;
        private NumericUpDown numSoLuong;
        private Label lblNgayNhap;
        private DateTimePicker dtpNgayNhap;
        private CheckBox chkConKinhDoanh;
        private PictureBox picSanPham;
        private Button btnChonAnh;
        private Panel pnlButtons;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvProducts;
        private ContextMenuStrip cmsProduct;
        private ToolStripMenuItem cmsSua;
        private ToolStripMenuItem cmsXoa;
        private ToolStripMenuItem cmsChiTiet;
        private ErrorProvider errorProvider1;
    }
}
