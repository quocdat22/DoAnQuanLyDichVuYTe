using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class BangCap
{
    public int IdBangCap { get; set; }

    public string? TenBangCap { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public int? IdNhanVien { get; set; }

    public virtual ProfileNhanVien? IdNhanVienNavigation { get; set; }
}
