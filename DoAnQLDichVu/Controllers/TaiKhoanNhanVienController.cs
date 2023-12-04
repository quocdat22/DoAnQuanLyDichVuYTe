using DoAn.Models;
using DoAnQLDichVu.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoAnQLDichVu.Controllers
{
    public class TaiKhoanNhanVienController : BaseController
    {
        private readonly QldichVuDangKiContext _db;
        public TaiKhoanNhanVienController(QldichVuDangKiContext db)
        {
            _db = db;
        }
        [Authentication]
        public IActionResult DanhSachTaiKhoan()
        {
            
            

            var query = from TaiKhoanNhanVien in _db.TaiKhoanNhanViens
                        join ProfileNhanVien in _db.ProfileNhanViens on TaiKhoanNhanVien.IdNhanVien equals ProfileNhanVien.IdNhanVien
                        
                        select new TK_PF_NV { TaiKhoan = TaiKhoanNhanVien, Profile = ProfileNhanVien };
            var model = query.ToList();
            return View(model);
        }

        [Authentication]
        public IActionResult XetDuyetTaiKhoan()
        {

            var nv = _db.TaiKhoanNhanViens.ToList();
            var query = from TaiKhoanNhanVien in _db.TaiKhoanNhanViens
                        join ProfileNhanVien in _db.ProfileNhanViens on TaiKhoanNhanVien.IdNhanVien equals ProfileNhanVien.IdNhanVien
                        where TaiKhoanNhanVien.TrangThai == 0
                        select new TK_PF_NV { TaiKhoan = TaiKhoanNhanVien, Profile = ProfileNhanVien };

            //ViewBag.DanhSachTaiKhoanKhachHang = query.ToList();
            var model = query.ToList();
            return View(model);
        }
        [Authentication]
        public IActionResult TaiKhoanAccept(int id)
        {
            var nv = _db.TaiKhoanNhanViens.FirstOrDefault(x => x.IdNhanVien == id);
            var profile = _db.ProfileNhanViens.FirstOrDefault(x => x.IdNhanVien == id);
            if(nv != null)
            {
                profile.TrangThaiTaiKhoan = 2;
                nv.TrangThai = 2;
                _db.SaveChanges();
            }
            
            return RedirectToAction("XetDuyetTaiKhoan");
        }
        [Authentication]

        public IActionResult TaiKhoanReject(int id)
        {
            var kh = _db.TaiKhoanNhanViens.FirstOrDefault(x => x.IdNhanVien == id);
            var profile = _db.ProfileNhanViens.FirstOrDefault(x => x.IdNhanVien == id);
            if (kh != null)
            {
                profile.TrangThaiTaiKhoan = 3;
                kh.TrangThai = 3;
                _db.SaveChanges();
            }
            
            return RedirectToAction("XetDuyetTaiKhoan");
        }


    }
}
