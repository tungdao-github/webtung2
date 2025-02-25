using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MonHocController : ControllerBase
    {
        private readonly SinhVienDbContext _context;

        public MonHocController(SinhVienDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var maSinhVien = User.Claims.FirstOrDefault(c => c.Type == "MaSinhVien")?.Value;
                
                var monhoc = await _context.Monhocs
                    .Where(d => d.MaSinhVien == maSinhVien).Select(d => new
                    {
                        d.MaMonHoc,
                        d.MaSinhVien,
                        d.TenMonHoc,
                        d.SoTinChi,
                        d.GiaHocPhi,
                        d.ThanhTien
                    })
                    .ToListAsync();
                return Ok(monhoc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "bug roi ne" });
            }
        }
    }
}