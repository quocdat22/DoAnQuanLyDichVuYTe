using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class TaiKhoanNhanVien
{
    public int IdTaiKhoanKh { get; set; }

    public int? IdNhanVien { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public DateTime? ThoiGianTao { get; set; }

    public byte? TrangThai { get; set; }

    public virtual ProfileNhanVien? IdNhanVienNavigation { get; set; }
}
