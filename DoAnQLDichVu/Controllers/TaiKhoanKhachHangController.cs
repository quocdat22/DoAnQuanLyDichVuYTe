using DoAn.Models;
using DoAnQLDichVu.Models;

using Microsoft.AspNetCore.Mvc;

namespace DoAnQLDichVu.Controllers
{
    public class TaiKhoanKhachHangController : BaseController
    {
        private readonly QldichVuDangKiContext _db;
        public TaiKhoanKhachHangController(QldichVuDangKiContext db)
        {
            _db = db;
        }
        [Authentication]
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
        [Authentication]
        public IActionResult DanhSachTaiKhoan()
        {
            var query = from TaiKhoanKhachHang in _db.TaiKhoanKhachHangs
                        join ProfileKhachHang in _db.ProfileKhachHangs on TaiKhoanKhachHang.IdKhachHang equals ProfileKhachHang.IdKhachHang
                        select new TK_PF_KH { TaiKhoan = TaiKhoanKhachHang, Profile = ProfileKhachHang };
            var model = query.ToList();
            return View(model);
        }
        [Authentication]
        public IActionResult TaiKhoanAccept(int id)
        {
            var kh = _db.TaiKhoanKhachHangs.FirstOrDefault(x => x.IdKhachHang == id);
            var profile = _db.ProfileKhachHangs.FirstOrDefault(x => x.IdKhachHang == id);
            if(kh!= null)
            {
                profile.TrangThaiTaiKhoan = 1;
                kh.TrangThai = 1;
                _db.SaveChanges();
            }   
            
            _db.SaveChanges();
            return RedirectToAction("XetDuyetTaiKhoan");
        }
        [Authentication]
        public IActionResult TaiKhoanReject(int id)
        {
            var kh = _db.TaiKhoanKhachHangs.FirstOrDefault(x => x.IdKhachHang == id);
            var profile = _db.ProfileKhachHangs.FirstOrDefault(x => x.IdKhachHang == id);
            if(kh != null)
            {
                profile.TrangThaiTaiKhoan = 2;
                kh.TrangThai = 2;
            }
            
            _db.SaveChanges();
            return RedirectToAction("XetDuyetTaiKhoan");
        }


    }
}
