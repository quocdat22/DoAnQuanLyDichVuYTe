using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoAnQLDichVu.Models;

public partial class QldichVuDangKiContext : DbContext
{
    public QldichVuDangKiContext()
    {
    }

    public QldichVuDangKiContext(DbContextOptions<QldichVuDangKiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangCap> BangCaps { get; set; }

    public virtual DbSet<Datlich> Datliches { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<Lichlamviec> Lichlamviecs { get; set; }

    public virtual DbSet<ProfileKhachHang> ProfileKhachHangs { get; set; }

    public virtual DbSet<ProfileNhanVien> ProfileNhanViens { get; set; }

    public virtual DbSet<Quantrivien> Quantriviens { get; set; }

    public virtual DbSet<TaiKhoanKhachHang> TaiKhoanKhachHangs { get; set; }

    public virtual DbSet<TaiKhoanNhanVien> TaiKhoanNhanViens { get; set; }

    public virtual DbSet<ThongKeSoLieu> ThongKeSoLieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DAT\\SQLEXPRESS;Initial Catalog=QLDichVuDangKi;User ID=sa;Password=123;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangCap>(entity =>
        {
            entity.HasKey(e => e.IdBangCap).HasName("PK__BangCap__9EDF8D8AF17B7617");

            entity.ToTable("BangCap");

            entity.Property(e => e.IdBangCap).HasColumnName("Id_BangCap");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdNhanVien).HasColumnName("ID_NhanVien");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenBangCap).HasMaxLength(255);

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.BangCaps)
                .HasForeignKey(d => d.IdNhanVien)
                .HasConstraintName("FK__BangCap__ID_Nhan__4D94879B");
        });

        modelBuilder.Entity<Datlich>(entity =>
        {
            entity.HasKey(e => e.IdDatLich).HasName("PK__DATLICH__70C88F6C1723EEEA");

            entity.ToTable("DATLICH");

            entity.Property(e => e.IdDatLich).HasColumnName("Id_DatLich");
            entity.Property(e => e.IdDv).HasColumnName("Id_DV");
            entity.Property(e => e.IdKhachHang).HasColumnName("Id_KhachHang");
            entity.Property(e => e.IdNhanVien).HasColumnName("Id_NhanVien");
            entity.Property(e => e.ThGianHen).HasColumnType("datetime");

            entity.HasOne(d => d.IdDvNavigation).WithMany(p => p.Datliches)
                .HasForeignKey(d => d.IdDv)
                .HasConstraintName("FK__DATLICH__Id_DV__5812160E");

            entity.HasOne(d => d.IdKhachHangNavigation).WithMany(p => p.Datliches)
                .HasForeignKey(d => d.IdKhachHang)
                .HasConstraintName("FK__DATLICH__Id_Khac__59063A47");

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.Datliches)
                .HasForeignKey(d => d.IdNhanVien)
                .HasConstraintName("FK__DATLICH__Id_Nhan__59FA5E80");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.IdDv).HasName("PK__DichVu__16EC9E2A82E82B4E");

            entity.ToTable("DichVu");

            entity.Property(e => e.IdDv).HasColumnName("Id_DV");
            entity.Property(e => e.GiaDv)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("GiaDV");
            entity.Property(e => e.MoTaDv)
                .HasColumnType("text")
                .HasColumnName("MoTaDV");
            entity.Property(e => e.TenDv)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TenDV");
            entity.Property(e => e.TgDuKienHoanThanhDv).HasColumnName("TG_DuKienHoanThanhDV");
            entity.Property(e => e.TinhTrang).HasDefaultValue((byte)1);
        });

        modelBuilder.Entity<Lichlamviec>(entity =>
        {
            entity.HasKey(e => e.IdLichLlamViec).HasName("PK__LICHLAMV__9E10CF4F4DE9CE83");

            entity.ToTable("LICHLAMVIEC");

            entity.Property(e => e.IdLichLlamViec).HasColumnName("Id_LichLLamViec");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.ThoiGianBatDau).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianDangKi).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianKetThuc).HasColumnType("datetime");

            entity.HasOne(d => d.NhanVienNavigation).WithMany(p => p.Lichlamviecs)
                .HasForeignKey(d => d.NhanVien)
                .HasConstraintName("FK__LICHLAMVI__NhanV__5535A963");
        });

        modelBuilder.Entity<ProfileKhachHang>(entity =>
        {
            entity.HasKey(e => e.IdKhachHang).HasName("PK__ProfileK__D0112EAF0783E65C");

            entity.ToTable("ProfileKhachHang");

            entity.Property(e => e.IdKhachHang).HasColumnName("Id_KhachHang");
            entity.Property(e => e.Diachi).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MoTaBoSung).HasMaxLength(255);
            entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianCapNhat).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TrangThaiTaiKhoan).HasDefaultValue((byte)0);
            entity.Property(e => e.TrangThaiXetDuyet).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<ProfileNhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNhanVien).HasName("PK__ProfileN__670CF92935AAA9CC");

            entity.ToTable("ProfileNhanVien");

            entity.Property(e => e.IdNhanVien).HasColumnName("Id_NhanVien");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Diachi).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.MoTaBoSung).HasMaxLength(255);
            entity.Property(e => e.SoCmnd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SoCMND");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianCapNhat).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TrangThaiLamViec).HasDefaultValue((byte)0);
            entity.Property(e => e.TrangThaiTaiKhoan).HasDefaultValue((byte)0);
            entity.Property(e => e.TrangThaiXetDuyet).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<Quantrivien>(entity =>
        {
            entity.HasKey(e => e.IdQuanTriVien).HasName("PK__QUANTRIV__7711BFC10C241C94");

            entity.ToTable("QUANTRIVIEN");

            entity.Property(e => e.IdQuanTriVien).HasColumnName("Id_QuanTriVien");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");
            entity.Property(e => e.SoCmnd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SoCMND");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenTk)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TenTK");
        });

        modelBuilder.Entity<TaiKhoanKhachHang>(entity =>
        {
            entity.HasKey(e => e.IdTaiKhoanKh).HasName("PK__TaiKhoan__9D3606B83E0732CE");

            entity.ToTable("TaiKhoanKhachHang");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0804A4936").IsUnique();

            entity.Property(e => e.IdTaiKhoanKh).HasColumnName("ID_TaiKhoanKH");
            entity.Property(e => e.IdKhachHang).HasColumnName("Id_KhachHang");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasDefaultValue((byte)0);

            entity.HasOne(d => d.IdKhachHangNavigation).WithMany(p => p.TaiKhoanKhachHangs)
                .HasForeignKey(d => d.IdKhachHang)
                .HasConstraintName("FK__TaiKhoanK__Id_Kh__3F466844");
        });

        modelBuilder.Entity<TaiKhoanNhanVien>(entity =>
        {
            entity.HasKey(e => e.IdTaiKhoanKh).HasName("PK__TaiKhoan__9D3606B854E7D787");

            entity.ToTable("TaiKhoanNhanVien");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0CD77E736").IsUnique();

            entity.Property(e => e.IdTaiKhoanKh).HasColumnName("ID_TaiKhoanKH");
            entity.Property(e => e.IdNhanVien).HasColumnName("Id_NhanVien");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasDefaultValue((byte)0);

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.TaiKhoanNhanViens)
                .HasForeignKey(d => d.IdNhanVien)
                .HasConstraintName("FK__TaiKhoanN__Id_Nh__4AB81AF0");
        });

        modelBuilder.Entity<ThongKeSoLieu>(entity =>
        {
            entity.HasKey(e => e.IdThongKe).HasName("PK__ThongKeS__E8CF5916DC2D1329");

            entity.ToTable("ThongKeSoLieu");

            entity.Property(e => e.IdThongKe)
                .ValueGeneratedNever()
                .HasColumnName("Id_ThongKe");
            entity.Property(e => e.KetQua).HasMaxLength(255);
            entity.Property(e => e.MaDv).HasColumnName("MaDV");
            entity.Property(e => e.NgayThongKe)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTk)
                .HasColumnType("datetime")
                .HasColumnName("NgayTK");
            entity.Property(e => e.TenThongKe).HasMaxLength(255);

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.ThongKeSoLieus)
                .HasForeignKey(d => d.MaDv)
                .HasConstraintName("FK__ThongKeSoL__MaDV__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
