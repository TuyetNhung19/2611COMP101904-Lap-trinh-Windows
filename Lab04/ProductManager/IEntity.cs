namespace Lab04_ProductManager;

/// <summary>
/// Rang buoc generic cho Repository&lt;T&gt;: bat ky kieu T nao muon luu trong
/// Repository deu phai co "Id" de tim kiem theo khoa chinh.
/// </summary>
public interface IEntity
{
    string Id { get; }
}
