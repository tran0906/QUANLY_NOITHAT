using Microsoft.AspNetCore.Mvc;
using QUANLY_NOITHAT.Models;

namespace QUANLY_NOITHAT.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public IActionResult Index(string? category)
        {
            ViewBag.Category = category;
            return View();
        }

        // GET: SanPham/Details/5
        public IActionResult Details(string id)
        {
            ViewBag.MaSP = id;
            return View();
        }

        // GET: SanPham/Search
        public IActionResult Search(string keyword)
        {
            ViewBag.Keyword = keyword;
            return View();
        }
    }
}
