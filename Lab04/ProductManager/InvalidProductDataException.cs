namespace Lab04_ProductManager;

/// <summary>
/// Nem ra khi du lieu san pham khong hop le: ma/ten rong, don gia
/// hoac so luong am. Giup Program.cs bao loi nhap lieu ro rang,
/// khong de chuong trinh dung dot ngot.
/// </summary>
public class InvalidProductDataException : Exception
{
    public InvalidProductDataException(string message) : base(message)
    {
    }
}
