namespace Lab04_ProductManager;

/// <summary>
/// Kho luu tru generic, dung lai duoc cho bat ky kieu T nao mien la
/// T trien khai IEntity. Repository chi phu trach luu tru thuan tuy,
/// khong biet gi ve nghiep vu (khong nem DuplicateProductException...).
/// Viec do thuoc ve ProductService o tang tren.
/// </summary>
public class Repository<T> where T : IEntity
{
    private readonly List<T> items = new();

    public void Add(T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        items.Add(item);
    }

    public bool Remove(string id)
    {
        var item = FindById(id);
        if (item is null)
            return false;

        return items.Remove(item);
    }

    public T? FindById(string id)
    {
        return items.FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Tim kiem/loc theo dieu kien bat ky, truyen vao duoi dang Func&lt;T, bool&gt;.
    /// Day la cach Repository ho tro ca "Tim theo ten" lan "Loc theo khoang gia"
    /// ma khong can biet truoc tieu chi loc la gi.
    /// </summary>
    public List<T> Find(Func<T, bool> condition)
    {
        if (condition is null)
            throw new ArgumentNullException(nameof(condition));

        return items.Where(condition).ToList();
    }

    public List<T> GetAll()
    {
        return items.ToList();
    }

    public int Count => items.Count;
}
