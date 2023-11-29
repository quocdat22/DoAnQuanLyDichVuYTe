using System;
using System.Collections.Generic;

namespace DoAnQLDichVu.Models;

public partial class Quantrivien
{
    public int IdQuanTriVien { get; set; }

    public string? HoTen { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public DateOnly? Ngaysinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? SoCmnd { get; set; }

    public string? Avatar { get; set; }

    public string? TenTk { get; set; }

    public string? MatKhau { get; set; }
}
