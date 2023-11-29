using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class ThongKeSoLieu
{
    public int IdThongKe { get; set; }

    public string? TenThongKe { get; set; }

    public DateTime? NgayTk { get; set; }

    public int? MaDv { get; set; }

    public bool? TrangThai { get; set; }

    public string? KetQua { get; set; }

    public DateTime? NgayThongKe { get; set; }

    public virtual DichVu? MaDvNavigation { get; set; }
}
