using ShopManagerMini.Models;

namespace ShopManagerMini.Data
{
    /// <summary>
    /// Kho dữ liệu tạm lưu trong bộ nhớ (thay cho SQL Server ở buổi này).
    /// Dùng static để đóng/mở Form con vẫn giữ được dữ liệu.
    /// </summary>
    public static class DataStore
    {
        public static List<User> Users { get; } = new()
        {
            new User { Username = "admin", Password = "123", FullName = "Quản trị viên",       Role = "Admin" },
            new User { Username = "user",  Password = "123", FullName = "Nhân viên bán hàng",  Role = "User"  }
        };

        public static List<Product> Products { get; } = new()
        {
            new Product { Id = "SP01", Name = "Nước suối", Category = "Đồ uống",   Price = 5000, Quantity = 100 },
            new Product { Id = "SP02", Name = "Mì gói",    Category = "Thực phẩm", Price = 4000, Quantity = 200 }
        };

        public static List<Customer> Customers { get; } = new()
        {
            new Customer { Id = "KH01", FullName = "Nguyễn Văn A", Phone = "0901234567", CustomerType = "Thường" }
        };
    }
}
