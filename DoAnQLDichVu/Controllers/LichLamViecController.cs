using DoAnQLDichVu.Models;
using DoAnQLDichVu.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DoAnQLDichVu.Controllers
{
    public class LichLamViecController : BaseController
    {

        private readonly QldichVuDangKiContext _db;
        public LichLamViecController(QldichVuDangKiContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<ProfileNhanVien> danhSachNhanVien = _db.ProfileNhanViens.ToList();
            return View(danhSachNhanVien);
        }

        // Action xử lý form tìm kiếm
        [HttpPost]
        public IActionResult TimKiem(int employee, DateTime? startDate, DateTime? endDate, int shift)
        {
            IQueryable<TK_NV> query = null;

            if (employee == 0)
            {
                query = from ProfileNhanVien in _db.ProfileNhanViens
                        join Lichlamviec in _db.Lichlamviecs on ProfileNhanVien.IdNhanVien equals Lichlamviec.NhanVien
                        
                        select new TK_NV
                        {
                            NhanVien = ProfileNhanVien,
                            Lichlamviec = _db.Lichlamviecs
                                .Where(lv => lv.NhanVien == ProfileNhanVien.IdNhanVien)
                                .ToList()
                        };
                if (startDate != null && endDate != null)
                {
                    query = query.Where(lv => lv.Lichlamviec[0].ThoiGianBatDau >= startDate && lv.Lichlamviec[0].ThoiGianKetThuc <= endDate);
                }
                if(shift != 0)
                {
                    query = query.Where(lv => lv.Lichlamviec[0].Ca == shift);
                }
            }
            else
            {
                query = from ProfileNhanVien in _db.ProfileNhanViens
                        join Lichlamviec in _db.Lichlamviecs on ProfileNhanVien.IdNhanVien equals Lichlamviec.NhanVien
                        where ProfileNhanVien.IdNhanVien == employee
                        select new TK_NV
                        {
                            NhanVien = ProfileNhanVien,
                            Lichlamviec = _db.Lichlamviecs
                                .Where(lv => lv.NhanVien == ProfileNhanVien.IdNhanVien)
                                .ToList()
                        };
                if (startDate != null && endDate != null)
                {
                    query = query.Where(lv => lv.Lichlamviec[0].ThoiGianBatDau >= startDate && lv.Lichlamviec[0].ThoiGianKetThuc <= endDate);
                }
                if (shift != 0)
                {
                    query = query.Where(lv => lv.Lichlamviec[0].Ca == shift);
                }
            }
            
            //var KetQuaTimKiem = query.ToList();
            var KetQuaTimKiem = query?.ToList() ?? new List<TK_NV>(); // Sử dụng ?. để tránh null reference exception

            return PartialView("_PartialSearchResult", KetQuaTimKiem);
            //return View(KetQuaTimKiem);
        }
    }
}
