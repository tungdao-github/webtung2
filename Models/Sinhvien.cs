using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Sinhvien
{
    public string MaSinhVien { get; set; } = null!;

    public string TenSinhVien { get; set; } = null!;

    public bool? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Cmnd { get; set; }

    public string? DanToc { get; set; }

    public virtual ICollection<Dangkihoc> Dangkihocs { get; set; } = new List<Dangkihoc>();

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    public virtual ICollection<Hocphi> Hocphis { get; set; } = new List<Hocphi>();

    public virtual ICollection<Monhoc> Monhocs { get; set; } = new List<Monhoc>();

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}
