using Microsoft.AspNetCore.Mvc;
using DoAnQLDichVu.Models;


namespace DoAnQLDichVu.Controllers
{
    public class AccessController : Controller
    {
        QldichVuDangKiContext db = new QldichVuDangKiContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("TenTk") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Quantrivien user)
        {
            if (HttpContext.Session.GetString("TenTk") == null)
            {
                var account = db.Quantriviens.Where(a => a.TenTk == user.TenTk && a.MatKhau == user.MatKhau).FirstOrDefault();
                if (account != null)
                {
                    HttpContext.Session.SetString("TenTk", account.TenTk.ToString());
                    HttpContext.Session.SetString("IdQuanTriVien", account.IdQuanTriVien.ToString());
                    HttpContext.Session.SetString("Avatar", account.Avatar.ToString());

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("TenTk");
            return RedirectToAction("Login", "Access");
        }
    }
}
