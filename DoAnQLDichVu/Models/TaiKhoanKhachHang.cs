using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class TaiKhoanKhachHang
{
    public int IdTaiKhoanKh { get; set; }

    public int? IdKhachHang { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public DateTime? ThoiGianTao { get; set; }

    public byte? TrangThai { get; set; }

    public virtual ProfileKhachHang? IdKhachHangNavigation { get; set; }
}
