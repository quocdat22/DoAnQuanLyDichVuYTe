using DoAnQLDichVu.Models;

using Microsoft.AspNetCore.Mvc;

namespace DoAnQLDichVu.Controllers
{
    public class TaiKhoanKhachHang : BaseController
    {
        private readonly QldichVuDangKiContext _db;
        public TaiKhoanKhachHang(QldichVuDangKiContext db)
        {
            _db = db;
        }
        public IActionResult XetDuyetTaiKhoan()
        {

            var kh = _db.TaiKhoanKhachHangs.ToList();
            var query = from TaiKhoanKhachHang in _db.TaiKhoanKhachHangs
                        join ProfileKhachHang in _db.ProfileKhachHangs on TaiKhoanKhachHang.IdKhachHang equals ProfileKhachHang.IdKhachHang
                        where TaiKhoanKhachHang.TrangThai == 0
                        select new TK_PF_KH { TaiKhoan = TaiKhoanKhachHang, Profile = ProfileKhachHang };

            //ViewBag.DanhSachTaiKhoanKhachHang = query.ToList();
            var model = query.ToList();
            return View(model);
        }

        public IActionResult DanhSachTaiKhoan()
        {
            var query = from TaiKhoanKhachHang in _db.TaiKhoanKhachHangs
                        join ProfileKhachHang in _db.ProfileKhachHangs on TaiKhoanKhachHang.IdKhachHang equals ProfileKhachHang.IdKhachHang
                        select new TK_PF_KH { TaiKhoan = TaiKhoanKhachHang, Profile = ProfileKhachHang };
            var model = query.ToList();
            return View(model);
        }

        public IActionResult TaiKhoanAccept(int id)
        {
            var kh = _db.TaiKhoanKhachHangs.FirstOrDefault(x => x.IdKhachHang == id);
            kh.TrangThai = 1;
            _db.SaveChanges();
            return RedirectToAction("XetDuyetTaiKhoan");
        }

        public IActionResult TaiKhoanReject(int id)
        {
            var kh = _db.TaiKhoanKhachHangs.FirstOrDefault(x => x.IdKhachHang == id);
            kh.TrangThai = 2;
            _db.SaveChanges();
            return RedirectToAction("XetDuyetTaiKhoan");
        }


    }
}
