namespace Lab04_ProductManager;

/// <summary>
/// Ne ra khi them san pham co ma da ton tai trong Repository.
/// </summary>
public class DuplicateProductException : Exception
{
    public string MaSP { get; }

    public DuplicateProductException(string maSP)
        : base($"San pham co ma '{maSP}' da ton tai.")
    {
        MaSP = maSP;
    }
}
