using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class DichVu
{
    public int IdDv { get; set; }

    public string? TenDv { get; set; }

    public string? MoTaDv { get; set; }

    public decimal? GiaDv { get; set; }

    public int? TgDuKienHoanThanhDv { get; set; }

    public byte? TinhTrang { get; set; }

    public virtual ICollection<Datlich> Datliches { get; set; } = new List<Datlich>();

    public virtual ICollection<ThongKeSoLieu> ThongKeSoLieus { get; set; } = new List<ThongKeSoLieu>();
}
