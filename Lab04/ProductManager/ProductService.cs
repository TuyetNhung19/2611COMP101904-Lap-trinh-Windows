namespace Lab04_ProductManager;

/// <summary>
/// Tang nghiep vu: dung Repository&lt;Product&gt; ben trong, kiem tra quy tac
/// nghiep vu (trung ma, khong ton tai), nem custom exception khi can,
/// va phat event de thong bao khi them/xoa san pham thanh cong.
/// </summary>
public class ProductService
{
    private readonly Repository<Product> repository = new();

    // Event dung Action<string>: chi can thong bao mot chuoi mo ta.
    // Dau ?.Invoke dam bao chi goi khi co noi dang ky lang nghe.
    public event Action<string>? ProductAdded;
    public event Action<string>? ProductRemoved;

    /// <summary>
    /// Them san pham moi. Nem DuplicateProductException neu ma da ton tai.
    /// Product tu kiem tra du lieu ngay trong constructor.
    /// </summary>
    public void AddProduct(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        if (repository.FindById(product.MaSP) is not null)
            throw new DuplicateProductException(product.MaSP);

        repository.Add(product);
        ProductAdded?.Invoke($"Da them san pham '{product.TenSP}' (ma {product.MaSP}).");
    }

    /// <summary>
    /// Xoa san pham theo ma. Nem ProductNotFoundException neu khong ton tai,
    /// phat event ProductRemoved neu xoa thanh cong.
    /// </summary>
    public void RemoveProduct(string maSP)
    {
        var product = repository.FindById(maSP);
        if (product is null)
            throw new ProductNotFoundException(maSP);

        repository.Remove(maSP);
        ProductRemoved?.Invoke($"Da xoa san pham '{product.TenSP}' (ma {product.MaSP}).");
    }

    /// <summary>
    /// Tim theo ma. Nem ProductNotFoundException neu khong tim thay.
    /// </summary>
    public Product SearchByCode(string maSP)
    {
        var product = repository.FindById(maSP);
        if (product is null)
            throw new ProductNotFoundException(maSP);

        return product;
    }

    /// <summary>
    /// Tim theo ten: tra ve cac san pham co ten chua tu khoa (khong phan
    /// biet hoa/thuong). Dung Func&lt;Product,bool&gt; ben duoi thong qua Repository.Find.
    /// </summary>
    public List<Product> SearchByName(string keyword)
    {
        string tuKhoa = (keyword ?? string.Empty).Trim();
        Func<Product, bool> dieuKien = p => p.TenSP.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase);
        return repository.Find(dieuKien);
    }

    /// <summary>
    /// Loc theo khoang gia [minPrice, maxPrice], dung Func&lt;Product,bool&gt;
    /// theo dung yeu cau cua Lab 04.
    /// </summary>
    public List<Product> FilterByPriceRange(decimal minPrice, decimal maxPrice)
    {
        Func<Product, bool> dieuKien = p => p.Price >= minPrice && p.Price <= maxPrice;
        return repository.Find(dieuKien);
    }

    public List<Product> GetAll()
    {
        return repository.GetAll();
    }

    /// <summary>Tong gia tri kho = tong (don gia * so luong) cua tat ca san pham.</summary>
    public decimal GetTotalInventoryValue()
    {
        return repository.GetAll().Sum(p => p.Total);
    }

    public int Count => repository.Count;
}
