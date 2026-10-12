using ShopManagerMini.Data;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>Quản lý khách hàng: thêm, sửa, xóa, làm mới, tìm kiếm (dữ liệu trong bộ nhớ).</summary>
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            cboCustomerType.Items.AddRange(new object[] { "Thường", "VIP" });
            ShowCustomers(DataStore.Customers);
        }

        private void ShowCustomers(IEnumerable<Customer> list)
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = list.ToList();

            if (dgvCustomers.Columns.Count > 0)
            {
                dgvCustomers.Columns["Id"]!.HeaderText = "Mã KH";
                dgvCustomers.Columns["FullName"]!.HeaderText = "Họ tên";
                dgvCustomers.Columns["Phone"]!.HeaderText = "Số điện thoại";
                dgvCustomers.Columns["CustomerType"]!.HeaderText = "Loại KH";
            }
        }

        private void ClearInput()
        {
            txtCustomerId.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            cboCustomerType.SelectedIndex = -1;
            txtCustomerId.Focus();
        }

        private void Warn(string message) =>
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private Customer? FindById(string id) =>
            DataStore.Customers.FirstOrDefault(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        /// <summary>Đọc và kiểm tra dữ liệu nhập.</summary>
        private bool TryReadInput(out Customer customer)
        {
            customer = new Customer();
            string id = txtCustomerId.Text.Trim();
            string name = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (id == "" || name == "" || phone == "" || cboCustomerType.SelectedIndex < 0)
            {
                Warn("Vui lòng nhập đầy đủ thông tin khách hàng.");
                return false;
            }
            if (!phone.All(char.IsDigit))
            {
                Warn("Số điện thoại chỉ được chứa chữ số.");
                return false;
            }

            customer = new Customer
            {
                Id = id,
                FullName = name,
                Phone = phone,
                CustomerType = cboCustomerType.SelectedItem!.ToString()!
            };
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryReadInput(out Customer c)) return;

            if (FindById(c.Id) != null)
            {
                Warn("Mã khách hàng đã tồn tại.");
                return;
            }

            DataStore.Customers.Add(c);
            ShowCustomers(DataStore.Customers);
            ClearInput();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!TryReadInput(out Customer c)) return;

            Customer? existing = FindById(c.Id);
            if (existing == null)
            {
                Warn("Không tìm thấy khách hàng có mã này. Hãy chọn một dòng trong danh sách để sửa.");
                return;
            }

            existing.FullName = c.FullName;
            existing.Phone = c.Phone;
            existing.CustomerType = c.CustomerType;

            ShowCustomers(DataStore.Customers);
            MessageBox.Show("Cập nhật thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Customer? existing = FindById(txtCustomerId.Text.Trim());
            if (existing == null)
            {
                Warn("Vui lòng chọn khách hàng cần xóa trong danh sách.");
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng '{existing.FullName}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            DataStore.Customers.Remove(existing);
            ShowCustomers(DataStore.Customers);
            ClearInput();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            ClearInput();
            ShowCustomers(DataStore.Customers);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var result = DataStore.Customers.Where(c =>
                c.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.Phone.Contains(keyword));
            ShowCustomers(result);
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCustomers.Rows[e.RowIndex].DataBoundItem is Customer c)
            {
                txtCustomerId.Text = c.Id;
                txtFullName.Text = c.FullName;
                txtPhone.Text = c.Phone;
                cboCustomerType.SelectedItem = c.CustomerType;
            }
        }
    }
}
