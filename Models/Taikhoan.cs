using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Taikhoan
{
    public int TaiKhoanId { get; set; }

    public string MaSinhVien { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? Gmail { get; set; }

    public int VaiTroId { get; set; }

    public virtual Sinhvien MaSinhVienNavigation { get; set; } = null!;

    public virtual Vaitro VaiTro { get; set; } = null!;
}
