using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Monhoc
{
    public string MaMonHoc { get; set; } = null!;

    public string MaSinhVien { get; set; } = null!;

    public string TenMonHoc { get; set; } = null!;

    public int SoTinChi { get; set; }

    public int GiaHocPhi { get; set; }

    public int? ThanhTien { get; set; }

    public virtual ICollection<Dangkihoc> Dangkihocs { get; set; } = new List<Dangkihoc>();

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    public virtual ICollection<Hocphi> Hocphis { get; set; } = new List<Hocphi>();

    public virtual Sinhvien MaSinhVienNavigation { get; set; } = null!;
}
