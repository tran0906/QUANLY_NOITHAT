# RÀNG BUỘC VÀ VALIDATION CHO ĐĂNG NHẬP & ĐĂNG KÝ

## 📋 MỤC LỤC
1. [Ràng buộc đăng ký](#ràng-buộc-đăng-ký)
2. [Ràng buộc đăng nhập](#ràng-buộc-đăng-nhập)
3. [Các trường hợp xảy ra](#các-trường-hợp-xảy-ra)
4. [Bảo mật](#bảo-mật)

---

## 🔐 RÀNG BUỘC ĐĂNG KÝ

### 1. Tên đăng nhập (UserId)
**Bảng:** `User.UserId` (nvarchar(10))

**Ràng buộc:**
- ✅ **Bắt buộc nhập** (Required)
- ✅ **Độ dài:** 3-10 ký tự
- ✅ **Định dạng:** Chỉ chứa chữ cái (a-z, A-Z), số (0-9) và dấu gạch dưới (_)
- ✅ **Duy nhất:** Không được trùng với tài khoản đã tồn tại
- ✅ **Không thể thay đổi** sau khi đăng ký

**Thông báo lỗi:**
```
- "Vui lòng nhập tên đăng nhập"
- "Tên đăng nhập phải từ 3-10 ký tự"
- "Tên đăng nhập chỉ chứa chữ, số và dấu gạch dưới"
- "Tên đăng nhập đã tồn tại"
```

**Ví dụ hợp lệ:**
- `user123`
- `nguyen_van_a`
- `admin_01`

**Ví dụ không hợp lệ:**
- `ab` (quá ngắn)
- `user@123` (chứa ký tự đặc biệt)
- `nguyen van a` (chứa khoảng trắng)

---

### 2. Họ và tên (HoTen)
**Bảng:** `User.HoTen` (nvarchar(150))

**Ràng buộc:**
- ✅ **Bắt buộc nhập**
- ✅ **Độ dài:** 2-150 ký tự
- ✅ **Cho phép:** Chữ cái, khoảng trắng, dấu tiếng Việt

**Thông báo lỗi:**
```
- "Vui lòng nhập họ tên"
- "Họ tên phải từ 2-150 ký tự"
```

**Ví dụ hợp lệ:**
- `Nguyễn Văn A`
- `Trần Thị Bích Ngọc`

---

### 3. Email
**Bảng:** `KHACH_HANG.EMAILKH` (nvarchar(150))

**Ràng buộc:**
- ✅ **Bắt buộc nhập**
- ✅ **Định dạng email hợp lệ** (có @ và domain)
- ✅ **Độ dài:** Tối đa 150 ký tự
- ✅ **Duy nhất:** Không được trùng với email đã đăng ký

**Thông báo lỗi:**
```
- "Vui lòng nhập email"
- "Email không hợp lệ"
- "Email không được quá 150 ký tự"
- "Email đã được sử dụng"
```

**Ví dụ hợp lệ:**
- `user@example.com`
- `nguyen.van.a@company.vn`

**Ví dụ không hợp lệ:**
- `user@` (thiếu domain)
- `user.com` (thiếu @)
- `@example.com` (thiếu local part)

---

### 4. Số điện thoại
**Bảng:** `KHACH_HANG.SDTKH` (nvarchar(20))

**Ràng buộc:**
- ✅ **Bắt buộc nhập**
- ✅ **Định dạng:** Số điện thoại Việt Nam (10 số)
- ✅ **Bắt đầu bằng:** 03, 05, 07, 08, 09
- ✅ **Regex:** `^(0[3|5|7|8|9])+([0-9]{8})$`

**Thông báo lỗi:**
```
- "Vui lòng nhập số điện thoại"
- "Số điện thoại không hợp lệ"
- "Số điện thoại phải là số Việt Nam hợp lệ (10 số)"
```

**Ví dụ hợp lệ:**
- `0912345678`
- `0387654321`
- `0567891234`

**Ví dụ không hợp lệ:**
- `012345678` (thiếu 1 số)
- `01234567890` (thừa 1 số)
- `0212345678` (đầu số không hợp lệ)

---

### 5. Mật khẩu (MatKhau)
**Bảng:** `User.MatKhau` (nvarchar(256) - đã mã hóa)

**Ràng buộc:**
- ✅ **Bắt buộc nhập**
- ✅ **Độ dài:** 6-256 ký tự
- ✅ **Phải chứa:**
  - Ít nhất 1 chữ hoa (A-Z)
  - Ít nhất 1 chữ thường (a-z)
  - Ít nhất 1 số (0-9)
- ✅ **Regex:** `^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$`

**Thông báo lỗi:**
```
- "Vui lòng nhập mật khẩu"
- "Mật khẩu phải từ 6-256 ký tự"
- "Mật khẩu phải chứa ít nhất 1 chữ hoa, 1 chữ thường và 1 số"
```

**Độ mạnh mật khẩu:**
- 🔴 **Yếu:** Chỉ đáp ứng yêu cầu tối thiểu
- 🟡 **Trung bình:** Có thêm ký tự đặc biệt hoặc độ dài > 8
- 🟢 **Mạnh:** Có đầy đủ chữ hoa, thường, số, ký tự đặc biệt và độ dài > 10

**Ví dụ hợp lệ:**
- `Pass123` (yếu)
- `Password123` (trung bình)
- `P@ssw0rd!123` (mạnh)

**Ví dụ không hợp lệ:**
- `pass` (quá ngắn, thiếu chữ hoa và số)
- `PASSWORD` (thiếu chữ thường và số)
- `password123` (thiếu chữ hoa)

---

### 6. Xác nhận mật khẩu
**Ràng buộc:**
- ✅ **Bắt buộc nhập**
- ✅ **Phải khớp** với mật khẩu đã nhập

**Thông báo lỗi:**
```
- "Vui lòng xác nhận mật khẩu"
- "Mật khẩu xác nhận không khớp"
```

---

### 7. Đồng ý điều khoản
**Ràng buộc:**
- ✅ **Bắt buộc** phải check
- ✅ **Giá trị:** true

**Thông báo lỗi:**
```
- "Bạn phải đồng ý với điều khoản sử dụng"
```

---

## 🔑 RÀNG BUỘC ĐĂNG NHẬP

### 1. Tên đăng nhập
**Ràng buộc:**
- ✅ **Bắt buộc nhập**
- ✅ **Độ dài:** Tối đa 10 ký tự
- ✅ **Phải tồn tại** trong database

**Thông báo lỗi:**
```
- "Vui lòng nhập tên đăng nhập"
- "Tên đăng nhập không được quá 10 ký tự"
- "Tên đăng nhập hoặc mật khẩu không đúng"
```

---

### 2. Mật khẩu
**Ràng buộc:**
- ✅ **Bắt buộc nhập**
- ✅ **Phải khớp** với mật khẩu đã mã hóa trong database

**Thông báo lỗi:**
```
- "Vui lòng nhập mật khẩu"
- "Tên đăng nhập hoặc mật khẩu không đúng"
```

---

### 3. Ghi nhớ đăng nhập (Remember Me)
**Ràng buộc:**
- ✅ **Tùy chọn** (không bắt buộc)
- ✅ **Nếu checked:** Cookie tồn tại 7 ngày
- ✅ **Nếu không:** Cookie tồn tại 1 giờ

---

## ⚠️ CÁC TRƯỜNG HỢP XẢY RA

### A. ĐĂNG KÝ

#### ✅ Trường hợp thành công:
1. Tất cả các trường hợp lệ
2. Username chưa tồn tại
3. Email chưa được sử dụng
4. Đã đồng ý điều khoản

**Kết quả:**
- Tạo record trong bảng `User` với VaiTro = "KhachHang"
- Tạo record trong bảng `KHACH_HANG`
- Mật khẩu được mã hóa SHA256
- Chuyển đến trang đăng nhập với thông báo thành công

---

#### ❌ Trường hợp thất bại:

**1. Validation lỗi:**
- Thiếu thông tin bắt buộc
- Định dạng không hợp lệ
- Độ dài không đúng
- Mật khẩu không đủ mạnh
- Mật khẩu xác nhận không khớp

**Kết quả:** Hiển thị lỗi tại từng trường, không submit form

---

**2. Username đã tồn tại:**
```csharp
if (UserExists(model.UserId))
{
    ModelState.AddModelError("UserId", "Tên đăng nhập đã tồn tại");
    return View(model);
}
```

**Kết quả:** Hiển thị lỗi "Tên đăng nhập đã tồn tại"

---

**3. Email đã được sử dụng:**
```csharp
if (EmailExists(model.Email))
{
    ModelState.AddModelError("Email", "Email đã được sử dụng");
    return View(model);
}
```

**Kết quả:** Hiển thị lỗi "Email đã được sử dụng"

---

**4. Không đồng ý điều khoản:**
```csharp
if (!model.DongYDieuKhoan)
{
    ModelState.AddModelError("DongYDieuKhoan", "Bạn phải đồng ý với điều khoản");
    return View(model);
}
```

**Kết quả:** Không cho submit form

---

**5. Lỗi hệ thống:**
- Database không kết nối được
- Lỗi khi lưu dữ liệu

**Kết quả:** Hiển thị thông báo "Đã xảy ra lỗi: [chi tiết lỗi]"

---

### B. ĐĂNG NHẬP

#### ✅ Trường hợp thành công:

**1. Đăng nhập với vai trò Admin:**
```
Username: admin
Password: Admin123
```

**Kết quả:**
- Tạo Cookie authentication với Role = "Admin"
- Lưu thông tin vào Session
- Chuyển đến `/Admin/Dashboard`

---

**2. Đăng nhập với vai trò Customer:**
```
Username: user
Password: User123
```

**Kết quả:**
- Tạo Cookie authentication với Role = "Customer"
- Lưu thông tin vào Session
- Chuyển đến trang chủ `/Home/Index`

---

**3. Đăng nhập với Remember Me:**
- Cookie tồn tại 7 ngày
- Không cần đăng nhập lại trong 7 ngày

---

**4. Đăng nhập không Remember Me:**
- Cookie tồn tại 1 giờ
- Hết 1 giờ phải đăng nhập lại

---

#### ❌ Trường hợp thất bại:

**1. Validation lỗi:**
- Thiếu username hoặc password
- Độ dài không hợp lệ

**Kết quả:** Hiển thị lỗi validation

---

**2. Sai username hoặc password:**
```csharp
if (!ValidateCredentials(username, password))
{
    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng");
    return View(model);
}
```

**Kết quả:** Hiển thị lỗi "Tên đăng nhập hoặc mật khẩu không đúng"

**Lưu ý bảo mật:** Không nên nói cụ thể là sai username hay password

---

**3. Tài khoản bị khóa:**
```csharp
if (user.IsLocked)
{
    ModelState.AddModelError(string.Empty, "Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên");
    return View(model);
}
```

---

**4. Đăng nhập quá nhiều lần sai:**
- Sau 5 lần đăng nhập sai liên tiếp
- Khóa tài khoản trong 15 phút

**Kết quả:** "Tài khoản tạm thời bị khóa do đăng nhập sai quá nhiều lần"

---

**5. Lỗi hệ thống:**
**Kết quả:** "Đã xảy ra lỗi: [chi tiết lỗi]"

---

## 🔒 BẢO MẬT

### 1. Mã hóa mật khẩu
```csharp
// Sử dụng SHA256
private string HashPassword(string password)
{
    using (var sha256 = SHA256.Create())
    {
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}
```

**Lưu ý:** Trong production nên dùng BCrypt hoặc PBKDF2

---

### 2. Cookie Authentication
- **HttpOnly:** true (không thể truy cập bằng JavaScript)
- **Secure:** true (chỉ gửi qua HTTPS)
- **SameSite:** Strict (chống CSRF)
- **Sliding Expiration:** true (tự động gia hạn)

---

### 3. Session Management
```csharp
HttpContext.Session.SetString("UserId", userId);
HttpContext.Session.SetString("UserRole", role);
HttpContext.Session.SetString("FullName", fullName);
```

**Timeout:** 30 phút không hoạt động

---

### 4. CSRF Protection
- Sử dụng `[ValidateAntiForgeryToken]` cho tất cả POST requests
- Token được tự động tạo và validate

---

### 5. SQL Injection Prevention
- Sử dụng Entity Framework với parameterized queries
- Không bao giờ concatenate SQL strings

---

### 6. XSS Prevention
- Razor tự động encode output
- Sử dụng `@Html.Raw()` cẩn thận

---

## 📊 LUỒNG XỬ LÝ

### Đăng ký:
```
1. User nhập thông tin
2. Client-side validation (JavaScript)
3. Submit form
4. Server-side validation (Model validation)
5. Kiểm tra username đã tồn tại
6. Kiểm tra email đã tồn tại
7. Mã hóa mật khẩu
8. Tạo mã khách hàng (MAKH)
9. Lưu vào bảng User
10. Lưu vào bảng KHACH_HANG
11. Chuyển đến trang đăng nhập
```

### Đăng nhập:
```
1. User nhập username/password
2. Client-side validation
3. Submit form
4. Server-side validation
5. Tìm user trong database
6. Verify password (so sánh hash)
7. Kiểm tra tài khoản có bị khóa không
8. Tạo Claims (UserId, Role, FullName)
9. Tạo Cookie authentication
10. Lưu thông tin vào Session
11. Redirect theo Role:
    - Admin → /Admin/Dashboard
    - Customer → /Home/Index
```

---

## 🎯 TÀI KHOẢN DEMO

### Admin:
```
Username: admin
Password: Admin123
Role: Admin
```

### Customer:
```
Username: user
Password: User123
Role: Customer
```

---

## 📝 CHECKLIST IMPLEMENTATION

- [x] Model validation với Data Annotations
- [x] Client-side validation (jQuery Validation)
- [x] Server-side validation
- [x] Kiểm tra username trùng
- [x] Kiểm tra email trùng
- [x] Mã hóa mật khẩu (SHA256)
- [x] Cookie authentication
- [x] Session management
- [x] CSRF protection
- [x] Password strength indicator
- [x] Show/hide password
- [x] Remember me functionality
- [x] Forgot password page
- [x] Access denied page
- [ ] Email verification (TODO)
- [ ] Two-factor authentication (TODO)
- [ ] Password reset via email (TODO)
- [ ] Account lockout after failed attempts (TODO)
- [ ] Captcha for registration (TODO)
