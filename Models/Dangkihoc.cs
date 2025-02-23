using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Dangkihoc
{
    public int Id { get; set; }

    public string MaMonHoc { get; set; } = null!;

    public string MaSinhVien { get; set; } = null!;

    public virtual Monhoc MaMonHocNavigation { get; set; } = null!;

    public virtual Sinhvien MaSinhVienNavigation { get; set; } = null!;
}
