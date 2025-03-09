using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Sinhvien
{
    public string MaSinhVien { get; set; } = null!;

    public string? TenSinhVien { get; set; }

    public string? GioiTinh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Cccd { get; set; }

    public string? DanToc { get; set; }

    public string? Lop { get; set; }

    public ulong? BaoHiem { get; set; }

    public decimal? HocPhi { get; set; }

    public float? TrungBinhTrungTichLuy { get; set; }

    public int? SoLuongDiemF { get; set; }

    public string? TinhTrangHocTap { get; set; }

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}