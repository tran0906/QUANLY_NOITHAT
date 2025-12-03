using Microsoft.AspNetCore.Mvc;
using QUANLY_NOITHAT.Models;

namespace QUANLY_NOITHAT.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public IActionResult Index()
        {
            return View();
        }

        // POST: GioHang/ThemVaoGio
        [HttpPost]
        public IActionResult ThemVaoGio(string maSP, int soLuong = 1)
        {
            // Logic thêm vào giỏ hàng sẽ được implement sau
            return RedirectToAction("Index");
        }

        // POST: GioHang/CapNhat
        [HttpPost]
        public IActionResult CapNhat(string maSP, int soLuong)
        {
            return RedirectToAction("Index");
        }

        // POST: GioHang/Xoa
        [HttpPost]
        public IActionResult Xoa(string maSP)
        {
            return RedirectToAction("Index");
        }

        // GET: GioHang/ThanhToan
        public IActionResult ThanhToan()
        {
            return View();
        }
    }
}
