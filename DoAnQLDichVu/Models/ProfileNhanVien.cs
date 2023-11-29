using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class ProfileNhanVien
{
    public int IdNhanVien { get; set; }

    public string HoTen { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string Diachi { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly NgaySinh { get; set; }

    public bool GioiTinh { get; set; }

    public string SoCmnd { get; set; } = null!;

    public string? Avatar { get; set; }

    public byte? TrangThaiTaiKhoan { get; set; }

    public byte? TrangThaiXetDuyet { get; set; }

    public byte? TrangThaiLamViec { get; set; }

    public DateTime? ThoiGianCapNhat { get; set; }

    public DateTime? ThoiGianTao { get; set; }

    public string? MoTaBoSung { get; set; }

    public virtual ICollection<BangCap> BangCaps { get; set; } = new List<BangCap>();

    public virtual ICollection<Datlich> Datliches { get; set; } = new List<Datlich>();

    public virtual ICollection<Lichlamviec> Lichlamviecs { get; set; } = new List<Lichlamviec>();

    public virtual ICollection<TaiKhoanNhanVien> TaiKhoanNhanViens { get; set; } = new List<TaiKhoanNhanVien>();
}
