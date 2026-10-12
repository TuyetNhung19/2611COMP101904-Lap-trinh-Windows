namespace ShopManagerMini.Models
{
    /// <summary>Thông tin khách hàng.</summary>
    public class Customer
    {
        public string Id { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string CustomerType { get; set; } = "";
    }
}
