using System.Globalization;

namespace Lab04_ProductManager;

internal static class Program
{
    private static readonly ProductService service = new();

    // vi-VN: dau "." la phan cach hang nghin, dau "," la phan cach thap phan.
    // Dung culture nay ca khi nhap (Parse) lan khi hien thi (ToString) de
    // "70.000" nhap vao va "70.000" hien ra la cung mot gia tri.
    private static readonly CultureInfo VietnamCulture = new("vi-VN");

    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        DangKyEvent();

        bool running = true;
        while (running)
        {
            HienThiMenu();
            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        ThemSanPham();
                        break;
                    case "2":
                        XuatDanhSach();
                        break;
                    case "3":
                        TimTheoMa();
                        break;
                    case "4":
                        TimTheoTen();
                        break;
                    case "5":
                        LocTheoKhoangGia();
                        break;
                    case "6":
                        XoaSanPham();
                        break;
                    case "7":
                        TinhTongGiaTriKho();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Ket thuc chuong trinh. Tam biet!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }
            }
            // Bat loi cu the truoc, loi tong quat sau -> khong de chuong trinh
            // dung dot ngot khi nguoi dung nhap sai du lieu.
            catch (DuplicateProductException ex)
            {
                Console.WriteLine($"[Loi] {ex.Message}");
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine($"[Loi] {ex.Message}");
            }
            catch (InvalidProductDataException ex)
            {
                Console.WriteLine($"[Loi du lieu] {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("[Loi] Du lieu nhap khong dung dinh dang so.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Loi khong xac dinh] {ex.Message}");
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }

    private static void DangKyEvent()
    {
        // Program.cs dang ky lang nghe event cua ProductService.
        // ProductService khong can biet Console.WriteLine o day, no chi
        // phat tin hieu "co san pham vua duoc them/xoa".
        service.ProductAdded += message => Console.WriteLine($"  >> [Thong bao] {message}");
        service.ProductRemoved += message => Console.WriteLine($"  >> [Thong bao] {message}");
    }

    private static void HienThiMenu()
    {
        Console.WriteLine("===== QUAN LI SAN PHAM =====");
        Console.WriteLine("1. Them san pham");
        Console.WriteLine("2. Xuat danh sach");
        Console.WriteLine("3. Tim theo ma");
        Console.WriteLine("4. Tim theo ten");
        Console.WriteLine("5. Loc theo khoang gia");
        Console.WriteLine("6. Xoa san pham");
        Console.WriteLine("7. Tinh tong gia tri kho");
        Console.WriteLine("0. Thoat");
        Console.Write("Chon: ");
    }

    private static void ThemSanPham()
    {
        Console.Write("Ma san pham: ");
        string maSP = Console.ReadLine() ?? string.Empty;

        Console.Write("Ten san pham: ");
        string tenSP = Console.ReadLine() ?? string.Empty;

        Console.Write("Don gia: ");
        decimal price = decimal.Parse(Console.ReadLine() ?? "0", NumberStyles.Number, VietnamCulture);

        Console.Write("So luong: ");
        int quantity = int.Parse(Console.ReadLine() ?? "0");

        // Product tu kiem tra du lieu trong constructor (nem
        // InvalidProductDataException neu sai). AddProduct nem
        // DuplicateProductException neu trung ma, va phat event neu thanh cong.
        var product = new Product(maSP, tenSP, price, quantity);
        service.AddProduct(product);

        Console.WriteLine("Them san pham thanh cong.");
    }

    private static void XuatDanhSach()
    {
        var all = service.GetAll();

        if (all.Count == 0)
        {
            Console.WriteLine("Danh sach san pham dang trong.");
            return;
        }

        InBangSanPham(all);
        Console.WriteLine($"Tong so san pham: {all.Count}");
    }

    private static void TimTheoMa()
    {
        Console.Write("Nhap ma san pham can tim: ");
        string maSP = Console.ReadLine() ?? string.Empty;

        // Nem ProductNotFoundException neu khong tim thay, duoc bat o Main.
        var product = service.SearchByCode(maSP);

        Console.WriteLine("Tim thay san pham:");
        InBangSanPham(new List<Product> { product });
    }

    private static void TimTheoTen()
    {
        Console.Write("Nhap tu khoa ten san pham: ");
        string tuKhoa = Console.ReadLine() ?? string.Empty;

        var ketQua = service.SearchByName(tuKhoa);

        if (ketQua.Count == 0)
        {
            Console.WriteLine("Khong co san pham nao co ten chua tu khoa nay.");
            return;
        }

        InBangSanPham(ketQua);
    }

    private static void LocTheoKhoangGia()
    {
        Console.Write("Nhap gia nho nhat: ");
        decimal giaNhoNhat = decimal.Parse(Console.ReadLine() ?? "0", NumberStyles.Number, VietnamCulture);

        Console.Write("Nhap gia lon nhat: ");
        decimal giaLonNhat = decimal.Parse(Console.ReadLine() ?? "0", NumberStyles.Number, VietnamCulture);

        var ketQua = service.FilterByPriceRange(giaNhoNhat, giaLonNhat);

        if (ketQua.Count == 0)
        {
            Console.WriteLine("Khong co san pham nao trong khoang gia nay.");
            return;
        }

        InBangSanPham(ketQua);
    }

    private static void XoaSanPham()
    {
        Console.Write("Nhap ma san pham can xoa: ");
        string maSP = Console.ReadLine() ?? string.Empty;

        // Nem ProductNotFoundException neu khong ton tai, phat event
        // ProductRemoved neu xoa thanh cong.
        service.RemoveProduct(maSP);

        Console.WriteLine("Xoa san pham thanh cong.");
    }

    private static void TinhTongGiaTriKho()
    {
        decimal tong = service.GetTotalInventoryValue();
        Console.WriteLine($"Tong gia tri kho: {tong.ToString("N0", VietnamCulture)}");
    }

    /// <summary>
    /// In danh sach san pham duoi dang bang co tieu de cot ro rang.
    /// Dung chung cho Xuat danh sach, Tim theo ma, Tim theo ten va
    /// Loc theo khoang gia de moi noi hien thi deu nhat quan.
    /// </summary>
    private static void InBangSanPham(List<Product> products)
    {
        Console.WriteLine($"{"Ma",-8} | {"Ten",-20} | {"Don gia",12} | {"So luong",8}");
        Console.WriteLine(new string('-', 58));

        foreach (var p in products)
        {
            string donGiaText = p.Price.ToString("N0", VietnamCulture);
            Console.WriteLine($"{p.MaSP,-8} | {p.TenSP,-20} | {donGiaText,12} | {p.Quantity,8}");
        }
    }
}
