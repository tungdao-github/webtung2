using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApplication2.Middleware;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRole(2)]
    public class TaiKhoanController : ControllerBase
    {
        private readonly SinhVienDbContext _context;

        public TaiKhoanController(SinhVienDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var maSinhVien = User.Claims.FirstOrDefault(c => c.Type == "MaSinhVien")?.Value;
                var taikhoan = await _context.Taikhoans
                    .Where(d => d.MaSinhVien == maSinhVien).Select(d => new
                    {
                        d.TaiKhoanId,
                        d.MaSinhVien,
                        d.MatKhau,
                        d.Gmail,
                        d.VaiTroId
                    })
                    .ToListAsync();
                return Ok(taikhoan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "bug roi ne" });
            }
        }
    }
}