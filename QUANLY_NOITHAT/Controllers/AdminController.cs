using Microsoft.AspNetCore.Mvc;

namespace QUANLY_NOITHAT.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: Admin/SanPham
        public IActionResult SanPham()
        {
            return View();
        }

        // GET: Admin/DonHang
        public IActionResult DonHang()
        {
            return View();
        }

        // GET: Admin/KhachHang
        public IActionResult KhachHang()
        {
            return View();
        }
    }
}
