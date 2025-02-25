using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HocPhiController : ControllerBase
    {
        private readonly SinhVienDbContext _context;

        public HocPhiController(SinhVienDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var maSinhVien = User.Claims.FirstOrDefault(c => c.Type == "MaSinhVien")?.Value;
                
                var hocphi = await _context.Hocphis
                    .Where(d => d.MaSinhVien == maSinhVien).Select(d => new
                    {
                        d.MaSinhVien,
                        d.MaMonHoc,
                        d.ThanhTien
                    })
                    .ToListAsync();
                return Ok(hocphi);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "bug roi ne" });
            }
        }
    }
}