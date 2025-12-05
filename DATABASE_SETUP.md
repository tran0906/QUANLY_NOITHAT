# HƯỚNG DẪN CÀI ĐẶT DATABASE

## 📋 Thông tin kết nối

**Server:** `LAPTOP-R442T6OB\MSSQLSERVER2025`  
**Database:** `QUANLY_NOITHAT_DB`  
**Authentication:** Windows Authentication (Trusted_Connection)

## 🔧 Cấu hình

### Connection String (đã cấu hình trong appsettings.json):
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=LAPTOP-R442T6OB\\MSSQLSERVER2025;Database=QUANLY_NOITHAT_DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

## 🚀 Cách chạy

### Tự động tạo database:
Khi chạy ứng dụng lần đầu, database sẽ được tự động tạo với:
- ✅ Tất cả các bảng theo schema đã định nghĩa
- ✅ Dữ liệu mẫu (seed data)
- ✅ Foreign keys và indexes

```bash
dotnet run --project QUANLY_NOITHAT/QUANLY_NOITHAT.csproj
```

## 📊 Cấu trúc Database

### Các bảng đã tạo:

1. **User** - Người dùng hệ thống
2. **KHACH_HANG** - Thông tin khách hàng
3. **MUC_DICH_SU_DUNG** - Mục đích sử dụng sản phẩm
4. **NHA_CUNG_CAP** - Nhà cung cấp
5. **NHOM_SAN_PHAM** - Nhóm sản phẩm
6. **VAT_LIEU** - Vật liệu
7. **SAN_PHAM** - Sản phẩm
8. **CUNGCAP** - Quan hệ nhà cung cấp - sản phẩm
9. **QUAN_BA_SP** - Đợt giảm giá
10. **QUANGBA** - Quan hệ sản phẩm - đợt giảm giá
11. **DON_HANG** - Đơn hàng
12. **CT_DONHANG** - Chi tiết đơn hàng
13. **SUDUNG** - Quan hệ sản phẩm - mục đích sử dụng
14. **THANH_TOAN** - Thanh toán
15. **PHIEU_XUAT_KHO** - Phiếu xuất kho
16. **VAN_CHUYEN** - Vận chuyển

## 🎯 Dữ liệu mẫu (Seed Data)

### Users:
| UserId | Password | VaiTro | HoTen |
|--------|----------|--------|-------|
| admin | Admin123 | Admin | Quản trị viên |
| user | User123 | KhachHang | Khách hàng |

### Nhóm sản phẩm:
- NSP001: Phòng khách
- NSP002: Phòng ngủ
- NSP003: Phòng bếp
- NSP004: Phòng làm việc

### Vật liệu:
- VL001: Gỗ sồi
- VL002: Gỗ óc chó
- VL003: Vải nỉ
- VL004: Da thật

### Sản phẩm:
- SP001: Sofa Góc Hiện Đại - 15,000,000đ
- SP002: Giường Ngủ Gỗ Sồi - 12,500,000đ
- SP003: Bộ Bàn Ăn 6 Ghế - 8,900,000đ
- SP004: Tủ Quần Áo Cánh Lùa - 9,500,000đ

### Khách hàng:
- KH001: Nguyễn Văn A
- KH002: Trần Thị B

## 🔍 Kiểm tra Database

### Sử dụng SQL Server Management Studio (SSMS):

1. Kết nối đến server: `LAPTOP-R442T6OB\MSSQLSERVER2025`
2. Tìm database: `QUANLY_NOITHAT_DB`
3. Xem các bảng trong **Tables**

### Query kiểm tra dữ liệu:

```sql
-- Kiểm tra users
SELECT * FROM [User];

-- Kiểm tra sản phẩm
SELECT * FROM SAN_PHAM;

-- Kiểm tra nhóm sản phẩm
SELECT * FROM NHOM_SAN_PHAM;

-- Kiểm tra khách hàng
SELECT * FROM KHACH_HANG;
```

## 🛠️ Các lớp Database đã tạo

### 1. ApplicationDbContext.cs
- DbContext chính của ứng dụng
- Cấu hình tất cả các bảng và quan hệ
- Sử dụng Fluent API để định nghĩa schema

### 2. DbInitializer.cs
- Khởi tạo database
- Seed dữ liệu mẫu
- Tự động chạy khi start ứng dụng

### 3. Models (trong Models/SanPham.cs và Models/Account.cs)
- User
- KhachHang
- SanPham
- NhomSanPham
- VatLieu
- NhaCungCap
- MucDichSuDung
- DonHang
- CTDonHang
- ThanhToan
- PhieuXuatKho
- VanChuyen
- Và các bảng quan hệ khác

## ⚙️ Entity Framework Core

### Packages đã cài đặt:
- ✅ Microsoft.EntityFrameworkCore.SqlServer (8.0.0)
- ✅ Microsoft.EntityFrameworkCore.Tools (8.0.0)

### Các tính năng:
- ✅ Code-First approach
- ✅ Automatic migrations
- ✅ Fluent API configuration
- ✅ Foreign key relationships
- ✅ Cascade delete rules
- ✅ Indexes

## 🔐 Bảo mật

- Mật khẩu được hash bằng SHA256
- Connection string sử dụng Windows Authentication
- TrustServerCertificate=True cho môi trường development

## 📝 Lưu ý

1. **SQL Server phải đang chạy** trước khi start ứng dụng
2. **Windows Authentication** phải được enable
3. User Windows hiện tại phải có quyền tạo database
4. Nếu database đã tồn tại, nó sẽ không bị ghi đè
5. Dữ liệu mẫu chỉ được thêm nếu database trống

## 🐛 Troubleshooting

### Lỗi: Cannot connect to SQL Server
**Giải pháp:**
- Kiểm tra SQL Server đang chạy
- Kiểm tra tên server đúng: `LAPTOP-R442T6OB\MSSQLSERVER2025`
- Kiểm tra Windows Authentication được enable

### Lỗi: Login failed for user
**Giải pháp:**
- Thêm user Windows vào SQL Server
- Grant quyền tạo database

### Lỗi: Database already exists
**Giải pháp:**
- Xóa database cũ trong SSMS
- Hoặc đổi tên database trong connection string

## 📞 Hỗ trợ

Nếu gặp vấn đề, kiểm tra:
1. SQL Server Service đang chạy
2. Connection string đúng
3. Quyền truy cập database
4. Logs trong console khi chạy ứng dụng
