using System.Security.Principal;

namespace Lab04_ProductManager;

/// <summary>
/// Entity san pham. Constructor tu kiem tra du lieu (fail fast):
/// MaSP khong duoc rong, Price va Quantity khong duoc am.
/// </summary>
public class Product : IEntity
{
    public string MaSP { get; }
    public string TenSP { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // IEntity.Id anh xa ve MaSP -> Repository<T> where T : IEntity co the
    // FindById theo dung ma san pham.
    public string Id => MaSP;

    public Product(string maSP, string tenSP, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(maSP))
            throw new InvalidProductDataException("Ma san pham khong duoc de trong.");

        if (string.IsNullOrWhiteSpace(tenSP))
            throw new InvalidProductDataException("Ten san pham khong duoc de trong.");

        if (price < 0)
            throw new InvalidProductDataException("Don gia khong duoc am.");

        if (quantity < 0)
            throw new InvalidProductDataException("So luong khong duoc am.");

        MaSP = maSP.Trim();
        TenSP = tenSP.Trim();
        Price = price;
        Quantity = quantity;
    }

    /// <summary>Thanh tien = don gia * so luong, dung cho chuc nang "Tinh tong gia tri kho".</summary>
    public decimal Total => Price * Quantity;

    public override string ToString()
    {
        return $"{MaSP} - {TenSP} - {Price:N0} - {Quantity}";
    }
}
