using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Hocphi
{
    public string MaSinhVien { get; set; } = null!;

    public string MaMonHoc { get; set; } = null!;

    public int? ThanhTien { get; set; }

    public virtual Monhoc MaMonHocNavigation { get; set; } = null!;

    public virtual Sinhvien MaSinhVienNavigation { get; set; } = null!;
}
