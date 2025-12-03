using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using QUANLY_NOITHAT.Models;
using System.Security.Cryptography;
using System.Text;

namespace QUANLY_NOITHAT.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // TODO: Kiểm tra user trong database
                // Đây là logic mẫu - cần thay bằng database thực tế
                
                // Kiểm tra tài khoản demo
                if (model.UserId == "admin" && model.MatKhau == "Admin123")
                {
                    // Tạo claims cho user
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.UserId),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim("FullName", "Quản trị viên")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddDays(7) : DateTimeOffset.UtcNow.AddHours(1)
                    };

                    await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

                    // Lưu thông tin vào session
                    HttpContext.Session.SetString("UserId", model.UserId);
                    HttpContext.Session.SetString("UserRole", "Admin");
                    HttpContext.Session.SetString("FullName", "Quản trị viên");

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Dashboard", "Admin");
                }
                else if (model.UserId == "user" && model.MatKhau == "User123")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.UserId),
                        new Claim(ClaimTypes.Role, "Customer"),
                        new Claim("FullName", "Khách hàng")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddDays(7) : DateTimeOffset.UtcNow.AddHours(1)
                    };

                    await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

                    HttpContext.Session.SetString("UserId", model.UserId);
                    HttpContext.Session.SetString("UserRole", "Customer");
                    HttpContext.Session.SetString("FullName", "Khách hàng");

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi: " + ex.Message);
                return View(model);
            }
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // TODO: Kiểm tra user đã tồn tại trong database
                // Đây là logic mẫu - cần thay bằng database thực tế

                // Kiểm tra username đã tồn tại (demo)
                if (model.UserId.ToLower() == "admin" || model.UserId.ToLower() == "user")
                {
                    ModelState.AddModelError("UserId", "Tên đăng nhập đã tồn tại");
                    return View(model);
                }

                // Kiểm tra email đã tồn tại (demo)
                if (model.Email.ToLower() == "admin@noithat.vn")
                {
                    ModelState.AddModelError("Email", "Email đã được sử dụng");
                    return View(model);
                }

                // TODO: Mã hóa mật khẩu và lưu vào database
                // string hashedPassword = HashPassword(model.MatKhau);

                // TODO: Tạo mã khách hàng tự động
                // string maKH = GenerateCustomerId();

                // TODO: Lưu user vào database
                /*
                var user = new User
                {
                    UserId = model.UserId,
                    TenUser = model.UserId,
                    MatKhau = hashedPassword,
                    VaiTro = "KhachHang",
                    HoTen = model.HoTen,
                    NgayTao = DateTime.UtcNow
                };
                // Save to database
                
                var khachHang = new KhachHang
                {
                    MAKH = maKH,
                    HOTENKH = model.HoTen,
                    EMAILKH = model.Email,
                    SDTKH = model.SoDienThoai
                };
                // Save to database
                */

                TempData["SuccessMessage"] = "Đăng ký thành công! Vui lòng đăng nhập.";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi: " + ex.Message);
                return View(model);
            }
        }

        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: Account/AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: Account/ForgotPassword
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: Account/ForgotPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // TODO: Gửi email reset password
            TempData["SuccessMessage"] = "Đã gửi email hướng dẫn đặt lại mật khẩu. Vui lòng kiểm tra hộp thư.";
            return RedirectToAction("Login");
        }

        // Helper method để hash password
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Helper method để verify password
        private bool VerifyPassword(string password, string hashedPassword)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hashedPassword;
        }

        // Helper method để tạo mã khách hàng
        private string GenerateCustomerId()
        {
            // TODO: Lấy số thứ tự từ database
            var random = new Random();
            return "KH" + random.Next(1000, 9999).ToString();
        }
    }
}
