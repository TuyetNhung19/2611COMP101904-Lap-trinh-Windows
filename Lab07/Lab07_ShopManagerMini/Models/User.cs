namespace ShopManagerMini.Models
{
    /// <summary>Thông tin người dùng đăng nhập.</summary>
    public class User
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Role { get; set; } = "";
    }
}
