using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Vaitro
{
    public int VaiTroId { get; set; }

    public string? Ten { get; set; }

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}