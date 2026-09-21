namespace Lab04_ProductManager;

/// <summary>
/// Nem ra khi tim, xoa hoac sua san pham khong ton tai trong Repository.
/// </summary>
public class ProductNotFoundException : Exception
{
    public string MaSP { get; }

    public ProductNotFoundException(string maSP)
        : base($"Khong tim thay san pham co ma '{maSP}'.")
    {
        MaSP = maSP;
    }
}
