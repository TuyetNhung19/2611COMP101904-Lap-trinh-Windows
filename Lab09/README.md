# Lab 09 – Thiết kế và in thẻ sinh viên bằng WinForms

## Thông tin sinh viên

- Họ tên: Võ Ngọc Tuyết Nhung
- MSSV: 49.01.103.058
- Lớp: 49.01.SPTIN.A

## Mô tả

Ứng dụng Windows Forms cho phép nhập thông tin sinh viên, chọn ảnh đại diện, **xem trước thẻ sinh viên theo thời gian thực** và **in thẻ** (hoặc xuất ra PDF/PNG). Thẻ được vẽ bằng **GDI+** trên `Panel`, sau đó dùng lại cho `PrintDocument` để bản in giống bản xem trước.

Ứng dụng **không dùng cơ sở dữ liệu**: dữ liệu nhập trực tiếp trên Form, danh sách sinh viên lưu tạm trong bộ nhớ bằng `List<T>`. Vì vậy repository không có script database và không có tài khoản demo.

## Công nghệ sử dụng

- C# – Windows Forms (.NET)
- Visual Studio 2022
- GDI+ (`Graphics`, sự kiện `Paint` của `Panel`)
- `PictureBox`, `OpenFileDialog`, `SaveFileDialog`
- `PrintDocument`, `PrintPreviewDialog`, `PrintDialog`
- `ListView`/`DataGridView` + `List<T>` cho danh sách sinh viên

## Chức năng

### Yêu cầu của đề bài

| Mã | Chức năng | Mô tả |
| --- | --- | --- |
| F1 | Chọn ảnh | `OpenFileDialog` lọc JPG, JPEG, PNG, BMP; ảnh hiển thị trong `PictureBox` chế độ **Zoom** (không méo); không khóa file ảnh cũ khi đổi ảnh. |
| F2 | Preview thẻ | Panel vẽ lại thẻ bằng GDI+ mỗi khi dữ liệu thay đổi. |
| F3 | Validation | Không cho xem trước/in nếu thiếu **mã sinh viên**, **họ tên** hoặc **ảnh**. |
| F4 | Print Preview | Nút **Xem trước in** mở `PrintPreviewDialog`. |
| F5 | Print | Nút **In thẻ** mở `PrintDialog` và in qua `PrintDocument`. |
| F6 | Làm mới | Xóa dữ liệu nhập, xóa ảnh, đưa Form về trạng thái ban đầu. |

### Chức năng mở rộng đã làm

- Mã **QR** giả lập trên thẻ.
- Chọn **logo** trường (nút *Chọn logo…*) hoặc quay về logo *Mặc định*.
- **Lưu thẻ ra PNG**.
- **Xem trước in / In nhiều thẻ trên một trang A4**.
- **Danh sách sinh viên** bằng `List<T>`: thêm, cập nhật, xóa (có xác nhận).

### Thông tin hiển thị trên thẻ

Mã sinh viên, họ tên, ngày sinh, giới tính, lớp, khoa, khóa học, ảnh đại diện, logo trường, tiêu đề **THẺ SINH VIÊN** và mã QR.

## Cách chạy

1. Mở file `.sln` ở thư mục gốc bằng Visual Studio.
2. Build Solution.
3. Nhấn **F5** (hoặc `Ctrl+F5`) để chạy project.


## Hình ảnh minh họa

### Form chính (trạng thái ban đầu)
![Giao diện chính](screenshots/1_giao_dien_chinh.png)
**Chưa nhập mã sinh viên**

![Cảnh báo chưa nhập MSSV](screenshots/9_canh_bao_chua_nhap_mssv.png)

**Chưa nhập họ tên**

![Cảnh báo chưa nhập họ tên](docs/screenshots/10_canh_bao_chua_nhap_mssv.png)

**Chưa chọn ảnh sinh viên**

![Cảnh báo thiếu ảnh](docs/screenshots/11_canh_bao_thieu_anh_sv.png)

### Xem trước khi in
![Xem trước khi in](screenshots/2_xem_truoc_khi_in.png)


## Test case

| STT | Chức năng | Các bước thực hiện | Kết quả mong đợi | Kết quả | Minh chứng |
| --- | --- | --- | --- | --- | --- |
| TC01 | Khởi động | Chạy chương trình | Hiển thị đủ nhóm nhập liệu, preview thẻ (ô ảnh “Chưa có ảnh”, QR trống), các nút và danh sách rỗng | Pass | ![Giao diện chính](screenshots/1_giao_dien_chinh.png) |
| TC02 | Chọn ảnh + preview thời gian thực | Nhập thông tin, bấm *Chọn ảnh…* và chọn ảnh | Ảnh hiển thị đúng tỉ lệ ở PictureBox; thẻ cập nhật ảnh và thông tin ngay | Pass | ![Thêm sinh viên vào danh sách](screenshots/6_them_SV_vao_ds_SV.png) |
| TC03 | Thiếu mã sinh viên | Để trống MSSV, bấm *In thẻ* | Báo “Vui lòng nhập mã sinh viên.”, không in | Pass | ![Cảnh báo chưa nhập MSSV](screenshots/9_canh_bao_chua_nhap_mssv.png) |
| TC04 | Thiếu họ tên | Nhập MSSV, để trống họ tên, bấm *In thẻ* | Báo “Vui lòng nhập họ tên.”, không in | Pass | ![Cảnh báo chưa nhập họ tên](screenshots/10_canh_bao_chua_nhap_mssv.png) |
| TC05 | Thiếu ảnh | Nhập đủ MSSV, họ tên, chưa chọn ảnh, bấm *In thẻ* | Báo “Vui lòng chọn ảnh sinh viên.”, không in | Pass | ![Cảnh báo thiếu ảnh](screenshots/11_canh_bao_thieu_anh_sv.png) |
| TC06 | Hộp thoại in | Nhập đủ dữ liệu, bấm *In thẻ* | Mở hộp thoại in, chọn được máy in (ví dụ Microsoft Print to PDF) | Pass | ![Hộp thoại in](screenshots/2_xem_truoc_khi_in.png) |
| TC07 | Thẻ sau khi in | In thẻ ra PDF/ảnh | Thẻ có khung, tiêu đề, ảnh, thông tin; ảnh không méo | Pass | ![Thẻ sinh viên đã in](screenshots/3_the_SV_da_in.png) |
| TC08 | Lưu PNG | Bấm *Lưu thẻ ra PNG* | Hiện thông báo thành công kèm đường dẫn file PNG | Pass | ![Lưu thẻ PNG](screenshots/4_luu_the_SV_dang_PNG.png) |
| TC09 | In nhiều thẻ A4 | Bấm *Xem trước in nhiều thẻ A4* | Nhiều thẻ được xếp trên một trang A4 | Pass | ![Xem trước in nhiều thẻ A4](screenshots/5_xem_truoc_in_nhieu_the.png) |
| TC10 | Thêm vào danh sách | Bấm *Thêm vào danh sách* | Sinh viên xuất hiện trong danh sách, tiêu đề hiển thị “1 sinh viên” | Pass | ![Thêm sinh viên vào danh sách](screenshots/6_them_SV_vao_ds_SV.png) |
| TC11 | Cập nhật sinh viên | Chọn dòng, sửa thông tin (ví dụ đổi Khoa), bấm *Cập nhật* | Dòng được chọn cập nhật theo dữ liệu mới | Pass | ![Cập nhật sinh viên](screenshots/7_cap_nhat_thong_tin_sv.png) |
| TC12 | Xóa sinh viên | Chọn dòng, bấm *Xóa khỏi danh sách*, chọn *Có* | Hỏi xác nhận; sau khi đồng ý, sinh viên bị xóa khỏi danh sách | Pass | ![Xóa sinh viên](screenshots/8_xoa_SV_ra_khoi_ds.png) |