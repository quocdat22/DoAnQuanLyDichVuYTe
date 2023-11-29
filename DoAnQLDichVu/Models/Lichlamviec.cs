using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class Lichlamviec
{
    public int IdLichLlamViec { get; set; }

    public DateTime? ThoiGianBatDau { get; set; }

    public DateTime? ThoiGianKetThuc { get; set; }

    public DateTime? ThoiGianDangKi { get; set; }

    public string? GhiChu { get; set; }

    public byte? Ca { get; set; }

    public int? NhanVien { get; set; }

    public virtual ProfileNhanVien? NhanVienNavigation { get; set; }
}
