using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class ProfileKhachHang
{
    public int IdKhachHang { get; set; }

    public string HoTen { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string? Diachi { get; set; }

    public string? Email { get; set; }

    public DateOnly? Ngaysinh { get; set; }

    public bool? GioiTinh { get; set; }

    public byte? TrangThaiTaiKhoan { get; set; }

    public byte? TrangThaiXetDuyet { get; set; }

    public DateTime? ThoiGianCapNhat { get; set; }

    public DateTime? ThoiGianTao { get; set; }

    public string? MoTaBoSung { get; set; }

    public virtual ICollection<Datlich> Datliches { get; set; } = new List<Datlich>();

    public virtual ICollection<TaiKhoanKhachHang> TaiKhoanKhachHangs { get; set; } = new List<TaiKhoanKhachHang>();
}
