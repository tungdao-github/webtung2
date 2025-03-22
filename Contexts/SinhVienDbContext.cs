using WebApplication2.Models;

using System;
using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Imaging;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
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

    public DbSet<ImageModel> Images { get; set; }

    public DbSet<Sinhvien> Sinhviens { get; set; }

    //public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Vaitro> Vaitros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"), 
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ImageModel>().ToTable("image");

        //modelBuilder.Entity<Sinhvien>(entity =>
        //{
        //    entity.HasKey(e => e.MaSinhVien).HasName("PRIMARY");

        //    entity.ToTable("sinhvien");

        //    entity.Property(e => e.MaSinhVien).HasMaxLength(10);
        //    entity.Property(e => e.BaoHiem).HasColumnType("bit(1)");
        //    entity.Property(e => e.Cccd).HasMaxLength(12);
        //    entity.Property(e => e.DanToc).HasMaxLength(20);
        //    entity.Property(e => e.GioiTinh).HasMaxLength(3);
        //    entity.Property(e => e.HocPhi).HasPrecision(10);
        //    entity.Property(e => e.Lop).HasMaxLength(100);
        //    entity.Property(e => e.NgaySinh).HasColumnType("date");
        //    entity.Property(e => e.SoDienThoai).HasMaxLength(15);
        //    entity.Property(e => e.TenSinhVien).HasMaxLength(50);
        //    entity.Property(e => e.TinhTrangHocTap).HasMaxLength(100);
        //    //entity.Property(e => e.CoVan).HasMaxLength(50);
        //    //entity.Property(e => e.XepLoai).HasMaxLength(20);

        //});

        //modelBuilder.Entity<Sinhvien>(entity =>
        //{
        //    entity.Property(e => e.XepLoai).HasColumnType("longtext");
        //    entity.Property(e => e.CoVan).HasColumnType("longtext");
        //});
        modelBuilder.Entity<ImageModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ImageUrl).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(255);

            // Thiết lập khóa ngoại
            entity.HasOne(img => img.SinhVien)
                  .WithMany(sv => sv.Images)
                  .HasForeignKey(img => img.SinhVienId)
                  .OnDelete(DeleteBehavior.Cascade); // Xóa sinh viên thì xóa ảnh
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.MaSinhVien).HasName("PRIMARY");
            entity.ToTable("sinhvien");

            entity.Property(e => e.MaSinhVien).HasMaxLength(10);
            entity.Property(e => e.BaoHiem).HasColumnType("bit(1)");
            entity.Property(e => e.Cccd).HasMaxLength(12);
            entity.Property(e => e.DanToc).HasMaxLength(20);
            entity.Property(e => e.GioiTinh).HasMaxLength(3);
            entity.Property(e => e.HocPhi).HasPrecision(10);
            entity.Property(e => e.Lop).HasMaxLength(100);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TenSinhVien).HasMaxLength(50);
            entity.Property(e => e.TinhTrangHocTap).HasMaxLength(100);
            entity.Property(e => e.CoVanHocTap).HasMaxLength(50);
            entity.Property(e => e.XepLoai).HasMaxLength(20);

            // Thiết lập quan hệ với ImageModel
            entity.HasMany(s => s.Images)
                  .WithOne(i => i.SinhVien)
                  .HasForeignKey(i => i.SinhVienId);
        });
        //modelBuilder.Entity<Sinhvien>(entity =>
        //{
        //    entity.HasKey(e => e.MaSinhVien).HasName("PRIMARY");

        //    entity.ToTable("sinhvien");

        //    entity.Property(e => e.MaSinhVien).HasMaxLength(10);
        //    entity.Property(e => e.BaoHiem).HasColumnType("bit(1)");
        //    entity.Property(e => e.Cccd).HasMaxLength(12);
        //    entity.Property(e => e.DanToc).HasMaxLength(20);
        //    entity.Property(e => e.GioiTinh).HasMaxLength(3);
        //    entity.Property(e => e.HocPhi).HasPrecision(10);
        //    entity.Property(e => e.Lop).HasMaxLength(100);
        //    entity.Property(e => e.NgaySinh).HasColumnType("date");
        //    entity.Property(e => e.SoDienThoai).HasMaxLength(15);
        //    entity.Property(e => e.TenSinhVien).HasMaxLength(50);
        //    entity.Property(e => e.TinhTrangHocTap).HasMaxLength(100);

        //    // Thêm 2 cột mới
        //    entity.Property(e => e.CoVanHocTap).HasMaxLength(50);
        //    entity.Property(e => e.XepLoai).HasMaxLength(20);
        //});

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.TaiKhoanId).HasName("PRIMARY");

            entity.ToTable("taikhoan");

            entity.HasIndex(e => e.MaSinhVien, "MaSinhVien");

            entity.HasIndex(e => e.VaiTroId, "VaiTroId");

            entity.Property(e => e.Gmail).HasMaxLength(50);
            entity.Property(e => e.MaSinhVien).HasMaxLength(10);
            entity.Property(e => e.MatKhau).HasMaxLength(255);

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.MaSinhVien)
                .HasConstraintName("taikhoan_ibfk_1");

            entity.HasOne(d => d.VaiTro).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.VaiTroId)
                .HasConstraintName("taikhoan_ibfk_2");
        });

        modelBuilder.Entity<Vaitro>(entity =>
        {
            entity.HasKey(e => e.VaiTroId).HasName("PRIMARY");

            entity.ToTable("vaitro");

            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<ImageModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ImageUrl).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
