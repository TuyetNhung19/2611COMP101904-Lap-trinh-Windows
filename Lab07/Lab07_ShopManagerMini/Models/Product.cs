namespace ShopManagerMini.Models
{
    /// <summary>Thông tin sản phẩm.</summary>
    public class Product
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
