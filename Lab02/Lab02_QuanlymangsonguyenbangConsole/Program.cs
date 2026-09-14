using System;

namespace Lab02_QuanLyMang
{
    class Program
    {
        // Mảng dùng chung và cờ đánh dấu đã nhập mảng hay chưa
        static int[] mang = null;
        static bool daNhapMang = false;

        static void Main(string[] args)
        {
            int luaChon;
            do
            {
                HienThiMenu();
                luaChon = NhapSoNguyen("Chon chuc nang: ");

                switch (luaChon)
                {
                    case 1:
                        mang = NhapMang();
                        daNhapMang = true;
                        break;

                    case 2:
                        if (KiemTraDaNhapMang())
                            XuatMang(mang);
                        break;

                    case 3:
                        if (KiemTraDaNhapMang())
                            Console.WriteLine("Tong cac phan tu la: " + TinhTong(mang));
                        break;

                    case 4:
                        if (KiemTraDaNhapMang())
                        {
                            Console.WriteLine("Gia tri lon nhat: " + TimMax(mang));
                            Console.WriteLine("Gia tri nho nhat: " + TimMin(mang));
                        }
                        break;

                    case 5:
                        if (KiemTraDaNhapMang())
                        {
                            Console.WriteLine("So luong phan tu chan: " + DemChan(mang));
                            Console.WriteLine("So luong phan tu le: " + DemLe(mang));
                        }
                        break;

                    case 6:
                        if (KiemTraDaNhapMang())
                        {
                            SapXepTangDan(mang);
                            Console.WriteLine("Mang sau khi sap xep tang dan:");
                            XuatMang(mang);
                        }
                        break;

                    case 7:
                        if (KiemTraDaNhapMang())
                        {
                            int x = NhapSoNguyen("Nhap gia tri can tim x: ");
                            int viTri = TimKiem(mang, x);
                            if (viTri != -1)
                                Console.WriteLine($"Tim thay {x} tai vi tri {viTri} (tinh tu 0)");
                            else
                                Console.WriteLine($"Khong tim thay {x} trong mang");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Cam on da su dung chuong trinh. Tam biet!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }

                Console.WriteLine(); // dòng trống cho dễ nhìn
            } while (luaChon != 0);
        }

        // ================== CÁC PHƯƠNG THỨC HỖ TRỢ ==================

        static void HienThiMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
        }

        // Kiểm tra xem người dùng đã nhập mảng chưa, nếu chưa thì báo lỗi
        static bool KiemTraDaNhapMang()
        {
            if (!daNhapMang)
            {
                Console.WriteLine("Ban chua nhap mang. Vui long chon chuc nang 1 truoc.");
                return false;
            }
            return true;
        }

        // Nhập một số nguyên bất kỳ, có kiểm tra hợp lệ
        static int NhapSoNguyen(string message)
        {
            int so;
            bool hopLe;
            do
            {
                Console.Write(message);
                hopLe = int.TryParse(Console.ReadLine(), out so);
                if (!hopLe)
                    Console.WriteLine("Du lieu khong hop le. Vui long nhap lai mot so nguyen.");
            } while (!hopLe);

            return so;
        }

        // Nhập một số nguyên dương (dùng cho số lượng phần tử n)
        static int NhapSoNguyenDuong(string message)
        {
            int so;
            do
            {
                so = NhapSoNguyen(message);
                if (so <= 0)
                    Console.WriteLine("So luong phan tu phai la so nguyen duong (n > 0). Vui long nhap lai.");
            } while (so <= 0);

            return so;
        }

        // Nhập mảng: nhập n rồi nhập từng phần tử
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhap phan tu thu {i + 1}: ");
            }

            Console.WriteLine("Nhap mang thanh cong!");
            return a;
        }

        // Xuất toàn bộ phần tử của mảng
        static void XuatMang(int[] a)
        {
            Console.Write("Mang hien tai: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        // Tính tổng các phần tử trong mảng
        static int TinhTong(int[] a)
        {
            int tong = 0;
            for (int i = 0; i < a.Length; i++)
            {
                tong += a[i];
            }
            return tong;
        }

        // Tìm giá trị lớn nhất trong mảng
        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            return max;
        }

        // Tìm giá trị nhỏ nhất trong mảng
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            return min;
        }

        // Đếm số lượng phần tử chẵn
        static int DemChan(int[] a)
        {
            int soLuong = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                    soLuong++;
            }
            return soLuong;
        }

        // Đếm số lượng phần tử lẻ
        static int DemLe(int[] a)
        {
            int soLuong = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 != 0)
                    soLuong++;
            }
            return soLuong;
        }

        // Sắp xếp mảng tăng dần (thuật toán Selection Sort đơn giản)
        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int chiSoNhoNhat = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[chiSoNhoNhat])
                        chiSoNhoNhat = j;
                }

                if (chiSoNhoNhat != i)
                {
                    int tam = a[i];
                    a[i] = a[chiSoNhoNhat];
                    a[chiSoNhoNhat] = tam;
                }
            }
        }

        // Tìm kiếm giá trị x trong mảng, trả về vị trí đầu tiên tìm thấy hoặc -1
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                    return i;
            }
            return -1;
        }
    }
}