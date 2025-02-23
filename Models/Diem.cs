using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Diem
{
    public string MaSinhVien { get; set; } = null!;

    public string MaMonHoc { get; set; } = null!;

    public float? DiemCc { get; set; }

    public float? DiemKt { get; set; }

    public float? DiemThi { get; set; }

    public float? DiemTongKet { get; set; }

    public virtual Monhoc MaMonHocNavigation { get; set; } = null!;

    public virtual Sinhvien MaSinhVienNavigation { get; set; } = null!;
}
