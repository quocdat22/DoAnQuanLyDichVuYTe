using DoAn.Models;
using DoAnQLDichVu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoAnQLDichVu.Controllers
{
    public class HomeController : BaseController
    {
        QldichVuDangKiContext db = new QldichVuDangKiContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authentication]
        public IActionResult Index()
        {
            //var userName = HttpContext.Session.GetString("TenTk");
            //var user = db.Quantriviens.Where(x => x.TenTk == userName).FirstOrDefault();

            //ViewData["UserName"] = HttpContext.Session.GetString("TenTk");
            //ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");

            return View();
        }
        [Authentication]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
