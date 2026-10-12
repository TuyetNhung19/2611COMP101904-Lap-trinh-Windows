using System.ComponentModel;

namespace Lab06_ProductManager
{
    public partial class FrmProduct : Form
    {
        private readonly BindingList<Product> products = new BindingList<Product>();
        private readonly BindingSource productSource = new BindingSource();
        private string selectedImagePath = string.Empty;

        public FrmProduct()
        {
            InitializeComponent();
        }

        // ================= LOAD FORM =================
        private void FrmProduct_Load(object? sender, EventArgs e)
        {
            cboLoaiSP.Items.AddRange(new object[]
            {
                "Điện tử", "Văn phòng", "Gia dụng", "Thời trang"
            });
            cboLoaiSP.SelectedIndex = 0;

            products.Add(new Product
            {
                MaSP = "SP01", TenSP = "Chuột không dây", LoaiSP = "Điện tử",
                DonGia = 150000, SoLuong = 20, NgayNhap = DateTime.Today,
                ConKinhDoanh = true
            });
            products.Add(new Product
            {
                MaSP = "SP02", TenSP = "Bút bi", LoaiSP = "Văn phòng",
                DonGia = 5000, SoLuong = 100, NgayNhap = DateTime.Today,
                ConKinhDoanh = true
            });
            products.Add(new Product
            {
                MaSP = "SP03", TenSP = "Nồi cơm điện", LoaiSP = "Gia dụng",
                DonGia = 850000, SoLuong = 8, NgayNhap = DateTime.Today.AddDays(-5),
                ConKinhDoanh = true
            });

            dgvProducts.AutoGenerateColumns = true;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.DataSource = productSource;
            dgvProducts.DataBindingComplete += (s, ev) => ConfigureGrid();

            SetSource(products);
            UpdateStatus("Sẵn sàng");
        }

        // Gán nguồn dữ liệu cho lưới (toàn bộ hoặc kết quả tìm kiếm)
        private void SetSource(IList<Product> source)
        {
            productSource.DataSource = source;
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            if (dgvProducts.Columns.Count == 0) return;

            void Set(string name, string header, string? format = null, bool visible = true)
            {
                var col = dgvProducts.Columns[name];
                if (col == null) return;
                col.HeaderText = header;
                col.Visible = visible;
                if (format != null) col.DefaultCellStyle.Format = format;
            }

            Set("MaSP", "Mã SP");
            Set("TenSP", "Tên sản phẩm");
            Set("LoaiSP", "Loại");
            Set("DonGia", "Đơn giá", "N0");
            Set("SoLuong", "Số lượng");
            Set("NgayNhap", "Ngày nhập", "dd/MM/yyyy");
            Set("ConKinhDoanh", "Còn KD");
            Set("DuongDanAnh", "Đường dẫn ảnh", null, false);
            Set("ThanhTien", "Thành tiền", "N0");
        }

        // ================= VALIDATION =================
        // editing = null  -> đang thêm mới
        // editing != null -> đang sửa sản phẩm đó (bỏ qua chính nó khi kiểm tra trùng mã)
        private bool ValidateInput(Product? editing = null)
        {
            errorProvider1.Clear();
            bool isValid = true;

            string ma = txtMaSP.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm không được rỗng");
                isValid = false;
            }
            else if (products.Any(p => p != editing &&
                     p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được rỗng");
                isValid = false;
            }

            if (cboLoaiSP.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm");
                isValid = false;
            }

            if (numDonGia.Value <= 0)
            {
                errorProvider1.SetError(numDonGia, "Đơn giá phải lớn hơn 0");
                isValid = false;
            }

            if (numSoLuong.Value < 0)
            {
                errorProvider1.SetError(numSoLuong, "Số lượng phải lớn hơn hoặc bằng 0");
                isValid = false;
            }

            if (dtpNgayNhap.Value.Date > DateTime.Today)
            {
                errorProvider1.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn hôm nay");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Dữ liệu nhập chưa hợp lệ, vui lòng kiểm tra các ô báo lỗi.",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isValid;
        }

        // ================= HÀM PHỤ TRỢ =================
        private Product? GetSelectedProduct()
        {
            if (productSource.Current is not Product p)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return p;
        }

        private void ClearInput()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 1;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Today;
            chkConKinhDoanh.Checked = true;
            txtTimKiem.Clear();
            SetPicture(string.Empty);
            errorProvider1.Clear();
            txtMaSP.Focus();
        }

        private void LoadProductToForm(Product p)
        {
            txtMaSP.Text = p.MaSP;
            txtTenSP.Text = p.TenSP;
            cboLoaiSP.Text = p.LoaiSP;
            numDonGia.Value = Math.Min(p.DonGia, numDonGia.Maximum);
            numSoLuong.Value = Math.Min(p.SoLuong, numSoLuong.Maximum);
            dtpNgayNhap.Value = p.NgayNhap > dtpNgayNhap.MaxDate ? dtpNgayNhap.MaxDate : p.NgayNhap;
            chkConKinhDoanh.Checked = p.ConKinhDoanh;
            SetPicture(p.DuongDanAnh);
            errorProvider1.Clear();
        }

        // Đọc ảnh qua bản sao để không bị khóa file
        private void SetPicture(string? path)
        {
            selectedImagePath = path ?? string.Empty;
            picSanPham.Image?.Dispose();
            picSanPham.Image = null;

            if (!string.IsNullOrWhiteSpace(selectedImagePath) && File.Exists(selectedImagePath))
            {
                try
                {
                    using var temp = Image.FromFile(selectedImagePath);
                    picSanPham.Image = new Bitmap(temp);
                }
                catch (Exception)
                {
                    selectedImagePath = string.Empty;
                    MessageBox.Show("Không thể đọc file ảnh này.", "Lỗi ảnh",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = $"{message} | Số sản phẩm: {products.Count}";
        }

        // ================= THÊM =================
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            products.Add(new Product
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                LoaiSP = cboLoaiSP.Text,
                DonGia = numDonGia.Value,
                SoLuong = (int)numSoLuong.Value,
                NgayNhap = dtpNgayNhap.Value.Date,
                ConKinhDoanh = chkConKinhDoanh.Checked,
                DuongDanAnh = selectedImagePath
            });

            SetSource(products);   // quay lại xem toàn bộ danh sách
            ClearInput();
            UpdateStatus("Đã thêm sản phẩm mới");
        }

        // ================= SỬA =================
        private void btnSua_Click(object? sender, EventArgs e)
        {
            Product? p = GetSelectedProduct();
            if (p == null) return;
            if (!ValidateInput(p)) return;

            p.MaSP = txtMaSP.Text.Trim();
            p.TenSP = txtTenSP.Text.Trim();
            p.LoaiSP = cboLoaiSP.Text;
            p.DonGia = numDonGia.Value;
            p.SoLuong = (int)numSoLuong.Value;
            p.NgayNhap = dtpNgayNhap.Value.Date;
            p.ConKinhDoanh = chkConKinhDoanh.Checked;
            p.DuongDanAnh = selectedImagePath;

            productSource.ResetBindings(false);
            UpdateStatus("Đã cập nhật sản phẩm");
        }

        // ================= XÓA =================
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            Product? p = GetSelectedProduct();
            if (p == null) return;

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm {p.TenSP}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                products.Remove(p);
                SetSource(products);
                ClearInput();
                UpdateStatus("Đã xóa sản phẩm");
            }
        }

        // ================= TÌM KIẾM / LÀM MỚI =================
        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            var result = products.Where(p =>
                p.MaSP.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            SetSource(new BindingList<Product>(result));
            lblStatus.Text = $"Tìm thấy {result.Count} sản phẩm | Tổng số sản phẩm: {products.Count}";
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            SetSource(products);
            ClearInput();
            UpdateStatus("Đã làm mới dữ liệu");
        }

        // ================= CHỌN ẢNH =================
        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Chọn ảnh sản phẩm";
            dialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SetPicture(dialog.FileName);
                UpdateStatus("Đã chọn ảnh sản phẩm");
            }
        }

        // ================= DATAGRIDVIEW =================
        private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (productSource.Current is Product p)
                LoadProductToForm(p);
        }

        // Nhấn chuột phải cũng chọn dòng đó trước khi hiện context menu
        private void dgvProducts_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvProducts.ClearSelection();
                dgvProducts.Rows[e.RowIndex].Selected = true;
                dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[0];
                if (productSource.Current is Product p)
                    LoadProductToForm(p);
            }
        }

        // ================= MENU / CONTEXT MENU =================
        private void mnuFileExit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void mnuAbout_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Quản lý sản phẩm - Lab 05\nCOMP1019 - Lập trình trên Windows",
                "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmsChiTiet_Click(object? sender, EventArgs e)
        {
            Product? p = GetSelectedProduct();
            if (p == null) return;

            MessageBox.Show(
                $"Mã: {p.MaSP}\nTên: {p.TenSP}\nLoại: {p.LoaiSP}\n" +
                $"Đơn giá: {p.DonGia:N0}\nSố lượng: {p.SoLuong}\n" +
                $"Ngày nhập: {p.NgayNhap:dd/MM/yyyy}\n" +
                $"Trạng thái: {(p.ConKinhDoanh ? "Còn kinh doanh" : "Ngừng kinh doanh")}\n" +
                $"Thành tiền: {p.ThanhTien:N0}",
                "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
