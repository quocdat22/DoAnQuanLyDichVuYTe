using DoAnQLDichVu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoAnQLDichVu.Controllers
{
    public class BaseController : Controller
    {
        //private readonly QldichVuDangKiContext _db;
        //public BaseController(QldichVuDangKiContext db)
        //{
        //    _db = db;
        //}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string tenDangNhap = HttpContext.Session.GetString("TenTk");
            string avatar = HttpContext.Session.GetString("Avatar");

            ViewData["UserName"] = tenDangNhap;
            ViewData["Avatar"] = avatar;
            base.OnActionExecuting(filterContext);
        }
    }
}
