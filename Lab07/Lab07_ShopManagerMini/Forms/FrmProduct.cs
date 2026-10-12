using ShopManagerMini.Data;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>Quản lý sản phẩm: thêm, sửa, xóa, làm mới, tìm kiếm (dữ liệu trong bộ nhớ).</summary>
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cboCategory.Items.AddRange(new object[] { "Đồ uống", "Thực phẩm", "Gia dụng", "Khác" });
            ShowProducts(DataStore.Products);
        }

        /// <summary>Đổ danh sách lên DataGridView.</summary>
        private void ShowProducts(IEnumerable<Product> list)
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = list.ToList();

            if (dgvProducts.Columns.Count > 0)
            {
                dgvProducts.Columns["Id"]!.HeaderText = "Mã SP";
                dgvProducts.Columns["Name"]!.HeaderText = "Tên sản phẩm";
                dgvProducts.Columns["Category"]!.HeaderText = "Loại";
                dgvProducts.Columns["Price"]!.HeaderText = "Đơn giá";
                dgvProducts.Columns["Price"]!.DefaultCellStyle.Format = "N0";
                dgvProducts.Columns["Quantity"]!.HeaderText = "Số lượng";
            }
        }

        private void ClearInput()
        {
            txtId.Clear();
            txtName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            txtQuantity.Clear();
            txtId.Focus();
        }

        /// <summary>Đọc và kiểm tra dữ liệu nhập. Trả về false nếu không hợp lệ.</summary>
        private bool TryReadInput(out Product product)
        {
            product = new Product();
            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();

            if (id == "" || name == "")
            {
                Warn("Vui lòng nhập mã và tên sản phẩm.");
                return false;
            }
            if (cboCategory.SelectedIndex < 0)
            {
                Warn("Vui lòng chọn loại sản phẩm.");
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                Warn("Đơn giá phải là số và không được âm.");
                return false;
            }
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                Warn("Số lượng phải là số nguyên và không được âm.");
                return false;
            }

            product = new Product
            {
                Id = id,
                Name = name,
                Category = cboCategory.SelectedItem!.ToString()!,
                Price = price,
                Quantity = quantity
            };
            return true;
        }

        private void Warn(string message) =>
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private Product? FindById(string id) =>
            DataStore.Products.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        // ---------- THÊM ----------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryReadInput(out Product p)) return;

            if (FindById(p.Id) != null)
            {
                Warn("Mã sản phẩm đã tồn tại, không thể thêm trùng.");
                return;
            }

            DataStore.Products.Add(p);
            ShowProducts(DataStore.Products);
            ClearInput();
        }

        // ---------- SỬA ----------
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!TryReadInput(out Product p)) return;

            Product? existing = FindById(p.Id);
            if (existing == null)
            {
                Warn("Không tìm thấy sản phẩm có mã này. Hãy chọn một dòng trong danh sách để sửa.");
                return;
            }

            existing.Name = p.Name;
            existing.Category = p.Category;
            existing.Price = p.Price;
            existing.Quantity = p.Quantity;

            ShowProducts(DataStore.Products);
            MessageBox.Show("Cập nhật thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------- XÓA ----------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product? existing = FindById(txtId.Text.Trim());
            if (existing == null)
            {
                Warn("Vui lòng chọn sản phẩm cần xóa trong danh sách.");
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm '{existing.Name}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            DataStore.Products.Remove(existing);
            ShowProducts(DataStore.Products);
            ClearInput();
        }

        // ---------- LÀM MỚI ----------
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            ClearInput();
            ShowProducts(DataStore.Products);
        }

        // ---------- TÌM KIẾM (theo mã hoặc tên) ----------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var result = DataStore.Products.Where(p =>
                p.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            ShowProducts(result);
        }

        // ---------- CLICK DÒNG -> ĐỔ LÊN Ô NHẬP ----------
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProducts.Rows[e.RowIndex].DataBoundItem is Product p)
            {
                txtId.Text = p.Id;
                txtName.Text = p.Name;
                cboCategory.SelectedItem = p.Category;
                txtPrice.Text = p.Price.ToString("0");
                txtQuantity.Text = p.Quantity.ToString();
            }
        }
    }
}
