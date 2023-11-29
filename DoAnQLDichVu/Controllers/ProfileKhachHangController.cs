using DoAnQLDichVu.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnQLDichVu.Controllers
{
    public class ProfileKhachHangController : BaseController
    {
        //QldichVuDangKiContext db = new QldichVuDangKiContext();
        private readonly QldichVuDangKiContext _db;
        public ProfileKhachHangController(QldichVuDangKiContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //ViewData["UserName"] = HttpContext.Session.GetString("TenTk");
            //ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");

            List<ProfileKhachHang> kh = _db.ProfileKhachHangs
            .Where(kh => kh.TrangThaiXetDuyet == 3)
            .ToList();
            return View(kh);
        }

        public IActionResult XetDuyetProfile()
        {
            
            //List<ProfileKhachHang> khachHangList = _db.ProfileKhachHangs
            //.Where(kh => kh.TrangThaiXetDuyet == 0 || kh.TrangThaiXetDuyet == 1)
            //.ToList();

            ViewBag.DanhSachTrangThai02 = _db.ProfileKhachHangs
            .Where(kh => kh.TrangThaiXetDuyet == 0 || kh.TrangThaiXetDuyet == 2)
            .ToList();

            ViewBag.DanhSachTrangThai1 = _db.ProfileKhachHangs
            .Where(kh => kh.TrangThaiXetDuyet == 1)
            .ToList();

            return View();
        }

        public IActionResult ProfileAccept(int id)
        {
            var kh = _db.ProfileKhachHangs.FirstOrDefault(x => x.IdKhachHang == id);
            kh.TrangThaiXetDuyet = 3;
            _db.SaveChanges();
            return RedirectToAction("XetDuyetProfile");
        }

        public IActionResult ProfileReject(int id)
        {
            var kh = _db.ProfileKhachHangs.FirstOrDefault(x => x.IdKhachHang == id);
            kh.TrangThaiXetDuyet = 4;
            _db.SaveChanges();
            return RedirectToAction("XetDuyetProfile");
        }

        public IActionResult ProfileDetail(int id)
        {
            
            var kh = _db.ProfileKhachHangs.FirstOrDefault(x => x.IdKhachHang == id);

            if (kh == null)
            {
                return RedirectToAction("XetDuyetProfile");
            }
            return View(kh);
        }

        //public IActionResult DanhSachTaiKhoan()
        //{
        //    var kh = _db.TaiKhoanKhachHangs.ToList();

        //    if (kh == null)
        //    {
        //        return RedirectToAction("XetDuyetProfile");
        //    }
        //    return View(kh);
        //}

    }
}
