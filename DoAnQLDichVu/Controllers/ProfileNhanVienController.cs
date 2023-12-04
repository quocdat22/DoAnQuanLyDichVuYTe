using DoAn.Models;
using DoAnQLDichVu.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnQLDichVu.Controllers
{
    public class ProfileNhanVienController : BaseController
    {

        private readonly QldichVuDangKiContext _db;
        public ProfileNhanVienController(QldichVuDangKiContext db)
        {
            _db = db;
        }
        //private readonly IWebHostEnvironment env;

        //public ProfileNhanVienController(IWebHostEnvironment env)
        //{
        //    this.env = env;
        //}
        [Authentication]
        public IActionResult Index()
        {
            List<ProfileNhanVien> nv = _db.ProfileNhanViens
            .Where(nv => nv.TrangThaiXetDuyet == 3)
            .ToList();
            return View(nv);
            
        }
        [Authentication]
        public IActionResult XetDuyetProfile()
        {
            //ViewBag.DanhSachTrangThai02 = _db.ProfileNhanViens
            //.Where(nv => nv.TrangThaiXetDuyet == 0 || nv.TrangThaiXetDuyet == 2)
            //.ToList();

            //ViewBag.DanhSachTrangThai1 = _db.ProfileNhanViens
            //.Where(nv => nv.TrangThaiXetDuyet == 1)
            //.ToList();

            
            //var query = from ProfileNhanVien in _db.ProfileNhanViens
            //            join BangCap in _db.BangCaps on ProfileNhanVien.IdNhanVien equals BangCap.IdNhanVien
            //            where ProfileNhanVien.TrangThaiXetDuyet == 0
            //            select new BC_PF_NV { NhanVienProfile = ProfileNhanVien, BangCap = BangCap };

            //var query = from BangCap in _db.BangCaps
            //            join ProfileNhanVien in _db.ProfileNhanViens on BangCap.IdNhanVien equals ProfileNhanVien.IdNhanVien
            //            where ProfileNhanVien.TrangThaiXetDuyet == 0
            //            select new BC_PF_NV { NhanVienProfile = ProfileNhanVien, BangCap = BangCap };
            ////ViewBag.DanhSachTaiKhoanKhachHang = query.ToList();
            //var model = query.ToList();
            var query = from BangCap in _db.BangCaps
                        join ProfileNhanVien in _db.ProfileNhanViens on BangCap.IdNhanVien equals ProfileNhanVien.IdNhanVien
                        where ProfileNhanVien.TrangThaiXetDuyet == 0
                        group BangCap by ProfileNhanVien into g
                        select new BC_PF_NV
                        {
                            NhanVienProfile = g.Key,
                            DanhSachBangCap = g.ToList()
                        };

            var model = query.ToList();


            return View(model);

            
        }
        [Authentication]
        public IActionResult ProfileDetail(int id)
        {

            //var nv = _db.ProfileNhanViens.FirstOrDefault(x => x.IdNhanVien == id);

            var nv = from BangCap in _db.BangCaps
                     join ProfileNhanVien in _db.ProfileNhanViens on BangCap.IdNhanVien equals ProfileNhanVien.IdNhanVien
                     where ProfileNhanVien.IdNhanVien == id && BangCap.IdNhanVien == id
                     group BangCap by ProfileNhanVien into g
                     select new BC_PF_NV
                     {
                         NhanVienProfile = g.Key,
                         DanhSachBangCap = g.ToList()
                         //DanhSachBangCap = _db.BangCaps.Where(bc => bc.IdNhanVien == id).ToList()
                     };

            var model = nv.FirstOrDefault();

            if (model==null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [Authentication]
        public IActionResult ProfileAccept(int id)
        {
            var nv = _db.ProfileNhanViens.FirstOrDefault(x => x.IdNhanVien == id);
            if (nv != null)
            {
                nv.TrangThaiXetDuyet = 3;
                nv.ThoiGianCapNhat = DateTime.Now;
                _db.SaveChanges();
            }

            return RedirectToAction("XetDuyetProfile");
        }
        [Authentication]
        public IActionResult ProfileReject(int id)
        {
            var nv = _db.ProfileNhanViens.FirstOrDefault(x => x.IdNhanVien == id);
            if (nv != null)
            {
                nv.TrangThaiXetDuyet = 4;
                nv.ThoiGianCapNhat = DateTime.Now;
                _db.SaveChanges();
            }

            return RedirectToAction("XetDuyetProfile");
        }



    }
}
