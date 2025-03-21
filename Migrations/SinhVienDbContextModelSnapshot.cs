﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Contexts;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(SinhVienDbContext))]
    partial class SinhVienDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.Sinhvien", b =>
                {
                    b.Property<string>("MaSinhVien")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<ulong?>("BaoHiem")
                        .HasColumnType("bit(1)");

                    b.Property<string>("Cccd")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("CoVanHocTap")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DanToc")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<decimal?>("HocPhi")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)");

                    b.Property<string>("Lop")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int?>("SoLuongDiemF")
                        .HasColumnType("int");

                    b.Property<string>("TenSinhVien")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TinhTrangHocTap")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<float?>("TrungBinhTrungTichLuy")
                        .HasColumnType("float");

                    b.Property<string>("XepLoai")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("MaSinhVien")
                        .HasName("PRIMARY");

                    b.ToTable("sinhvien", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.Taikhoan", b =>
                {
                    b.Property<int>("TaiKhoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TaiKhoanId"));

                    b.Property<string>("Gmail")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MaSinhVien")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("MatKhau")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("VaiTroId")
                        .HasColumnType("int");

                    b.HasKey("TaiKhoanId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MaSinhVien" }, "MaSinhVien");

                    b.HasIndex(new[] { "VaiTroId" }, "VaiTroId");

                    b.ToTable("taikhoan", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.Vaitro", b =>
                {
                    b.Property<int>("VaiTroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("VaiTroId"));

                    b.Property<string>("Ten")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("VaiTroId")
                        .HasName("PRIMARY");

                    b.ToTable("vaitro", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Models.Taikhoan", b =>
                {
                    b.HasOne("WebApplication2.Models.Sinhvien", "MaSinhVienNavigation")
                        .WithMany("Taikhoans")
                        .HasForeignKey("MaSinhVien")
                        .HasConstraintName("taikhoan_ibfk_1");

                    b.HasOne("WebApplication2.Models.Vaitro", "VaiTro")
                        .WithMany("Taikhoans")
                        .HasForeignKey("VaiTroId")
                        .HasConstraintName("taikhoan_ibfk_2");

                    b.Navigation("MaSinhVienNavigation");

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("WebApplication2.Models.Sinhvien", b =>
                {
                    b.Navigation("Taikhoans");
                });

            modelBuilder.Entity("WebApplication2.Models.Vaitro", b =>
                {
                    b.Navigation("Taikhoans");
                });
#pragma warning restore 612, 618
        }
    }
}
