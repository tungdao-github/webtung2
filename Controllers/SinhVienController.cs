using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SinhVienController : ControllerBase
    {
        private readonly SinhVienDbContext _context;

        public SinhVienController(SinhVienDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var maSinhVien = User.Claims.FirstOrDefault(c => c.Type == "MaSinhVien")?.Value;

                if (string.IsNullOrEmpty(maSinhVien))
                {
                    return Unauthorized(new { Message = "Ma sinh vien don't exists" });
                }
                var sinhvien = await _context.Sinhviens
                    .Where(d => d.MaSinhVien == maSinhVien).Select(d => new
                    {
                        d.MaSinhVien,
                        d.TenSinhVien,
                        d.GioiTinh,
                        d.NgaySinh,
                        d.SoDienThoai,
                        d.Cccd,
                        d.DanToc,
                        d.Lop,
                        d.BaoHiem,
                        d.HocPhi,
                        d.TrungBinhTrungTichLuy,
                        d.SoLuongDiemF,
                        d.TinhTrangHocTap,
                        d.XepLoai,
                        d.CoVanHocTap
                    })
                    .ToListAsync();
                return Ok(sinhvien);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "bug roi ne" });
            }
        }
    }
}