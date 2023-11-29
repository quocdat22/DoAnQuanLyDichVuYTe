using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class Datlich
{
    public int IdDatLich { get; set; }

    public int? IdDv { get; set; }

    public int? IdKhachHang { get; set; }

    public int? IdNhanVien { get; set; }

    public DateTime? ThGianHen { get; set; }

    public byte? TrangThai { get; set; }

    public virtual DichVu? IdDvNavigation { get; set; }

    public virtual ProfileKhachHang? IdKhachHangNavigation { get; set; }

    public virtual ProfileNhanVien? IdNhanVienNavigation { get; set; }
}
