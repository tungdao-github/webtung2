using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using WebApplication2.Models;

namespace WebApplication2.Contexts;

public partial class SinhVienDbContext : DbContext
{
    public SinhVienDbContext()
    {
    }

    public SinhVienDbContext(DbContextOptions<SinhVienDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dangkihoc> Dangkihocs { get; set; }

    public virtual DbSet<Diem> Diems { get; set; }

    public virtual DbSet<Hocphi> Hocphis { get; set; }

    public virtual DbSet<Monhoc> Monhocs { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Vaitro> Vaitros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("Server=sql12.freemysqlhosting.net;Database=sql12764258;User Id=sql12764258;Password=9lZBCwMI5d;SslMode=Preferred", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Dangkihoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dangkihoc");

            entity.HasIndex(e => e.MaMonHoc, "MaMonHoc");

            entity.HasIndex(e => new { e.MaSinhVien, e.MaMonHoc }, "uq_dangkihoc").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.MaMonHoc).HasMaxLength(100);
            entity.Property(e => e.MaSinhVien).HasMaxLength(100);

            entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.Dangkihocs)
                .HasForeignKey(d => d.MaMonHoc)
                .HasConstraintName("dangkihoc_ibfk_2");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.Dangkihocs)
                .HasForeignKey(d => d.MaSinhVien)
                .HasConstraintName("dangkihoc_ibfk_1");
        });

        modelBuilder.Entity<Diem>(entity =>
        {
            entity.HasKey(e => new { e.MaSinhVien, e.MaMonHoc })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("diem");

            entity.HasIndex(e => e.MaMonHoc, "MaMonHoc");

            entity.Property(e => e.MaSinhVien).HasMaxLength(100);
            entity.Property(e => e.MaMonHoc).HasMaxLength(100);

            entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.MaMonHoc)
                .HasConstraintName("diem_ibfk_2");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.MaSinhVien)
                .HasConstraintName("diem_ibfk_1");
        });

        modelBuilder.Entity<Hocphi>(entity =>
        {
            entity.HasKey(e => new { e.MaSinhVien, e.MaMonHoc })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("hocphi");

            entity.HasIndex(e => e.MaMonHoc, "MaMonHoc");

            entity.Property(e => e.MaSinhVien).HasMaxLength(100);
            entity.Property(e => e.MaMonHoc).HasMaxLength(100);
            entity.Property(e => e.ThanhTien).HasColumnType("int(11)");

            entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.Hocphis)
                .HasForeignKey(d => d.MaMonHoc)
                .HasConstraintName("hocphi_ibfk_2");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.Hocphis)
                .HasForeignKey(d => d.MaSinhVien)
                .HasConstraintName("hocphi_ibfk_1");
        });

        modelBuilder.Entity<Monhoc>(entity =>
        {
            entity.HasKey(e => e.MaMonHoc).HasName("PRIMARY");

            entity.ToTable("monhoc");

            entity.HasIndex(e => e.MaSinhVien, "MaSinhVien");

            entity.Property(e => e.MaMonHoc).HasMaxLength(100);
            entity.Property(e => e.GiaHocPhi).HasColumnType("int(11)");
            entity.Property(e => e.MaSinhVien).HasMaxLength(100);
            entity.Property(e => e.SoTinChi).HasColumnType("int(11)");
            entity.Property(e => e.TenMonHoc).HasMaxLength(100);
            entity.Property(e => e.ThanhTien).HasColumnType("int(11)");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.Monhocs)
                .HasForeignKey(d => d.MaSinhVien)
                .HasConstraintName("monhoc_ibfk_1");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.MaSinhVien).HasName("PRIMARY");

            entity.ToTable("sinhvien");

            entity.Property(e => e.MaSinhVien).HasMaxLength(100);
            entity.Property(e => e.Cmnd).HasMaxLength(100);
            entity.Property(e => e.DanToc).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai).HasMaxLength(100);
            entity.Property(e => e.TenSinhVien).HasMaxLength(100);
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.TaiKhoanId).HasName("PRIMARY");

            entity.ToTable("taikhoan");

            entity.HasIndex(e => e.MaSinhVien, "MaSinhVien");

            entity.HasIndex(e => e.VaiTroId, "VaiTroId");

            entity.Property(e => e.TaiKhoanId).HasColumnType("int(11)");
            entity.Property(e => e.Gmail).HasMaxLength(100);
            entity.Property(e => e.MaSinhVien).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.VaiTroId).HasColumnType("int(11)");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.MaSinhVien)
                .HasConstraintName("taikhoan_ibfk_2");

            entity.HasOne(d => d.VaiTro).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.VaiTroId)
                .HasConstraintName("taikhoan_ibfk_1");
        });

        modelBuilder.Entity<Vaitro>(entity =>
        {
            entity.HasKey(e => e.VaiTroId).HasName("PRIMARY");

            entity.ToTable("vaitro");

            entity.Property(e => e.VaiTroId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Ten).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
