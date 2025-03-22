using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public class Sinhvien
{
   
        public string MaSinhVien { get; set; }
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

        // **THÊM 2 CỘT BỊ THIẾU**
        public string? XepLoai { get; set; }
        public string? CoVanHocTap { get; set; }

    //public string MaSinhVien { get; set; }
    //public string TenSinhVien { get; set; }
    //public string GioiTinh { get; set; }
    //public DateTime? NgaySinh { get; set; }
    //public string SoDienThoai { get; set; }
    //public string Cccd { get; set; }
    //public string DanToc { get; set; }
    //public string Lop { get; set; }
    //public ulong? BaoHiem { get; set; }
    //public decimal? HocPhi { get; set; }
    //public double? TrungBinhTrungTichLuy { get; set; }
    //public int? SoLuongDiemF { get; set; }
    //public string TinhTrangHocTap { get; set; }

    //// Thêm 2 trường mới
    //public string CoVanHocTap { get; set; }
    //public string XepLoai { get; set; }

    //public string MaSinhVien { get; set; } = null!;

    //public string? TenSinhVien { get; set; }

    //public string? GioiTinh { get; set; }

    //public DateTime? NgaySinh { get; set; }

    //public string? SoDienThoai { get; set; }

    //public string? Cccd { get; set; }

    //public string? DanToc { get; set; }

    //public string? Lop { get; set; }

    //public ulong? BaoHiem { get; set; }

    //public decimal? HocPhi { get; set; }

    //public float? TrungBinhTrungTichLuy { get; set; }

    //public int? SoLuongDiemF { get; set; }

    //public string? TinhTrangHocTap { get; set; }
    //public string XepLoai { get; set; } // Thêm Xếp Loại

    //public string CoVan { get; set; }  // Thêm Cố Vấn
    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
    public virtual ICollection<ImageModel> Images { get; set; } = new List<ImageModel>();
}

