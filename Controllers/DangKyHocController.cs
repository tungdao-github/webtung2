using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DangKiHocController : ControllerBase
    {
        private readonly SinhVienDbContext _context;

        public DangKiHocController(SinhVienDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var maSinhVien = User.Claims.FirstOrDefault(c => c.Type == "MaSinhVien")?.Value;
                
                var dangkihoc = await _context.Dangkihocs
                    .Where(d => d.MaSinhVien == maSinhVien).Select(d => new
                    {
                        d.Id,
                        d.MaSinhVien,
                        d.MaMonHoc
                    })
                    .ToListAsync();
                return Ok(dangkihoc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "bug roi ne" });
            }
        }
    }
}