using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;
using WebApplication2.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : Controller
{
    private readonly SinhVienDbContext _context;

    public LoginController(SinhVienDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Taikhoans
            .Include(t => t.VaiTro)
            .FirstOrDefaultAsync(t => t.Gmail == request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.MatKhau)) 
            return Unauthorized(new { Message = "dang nhap false" });

        // Tạo JWT Token
        var token = GenerateJwtToken(user);

        return Ok(new { Token = token });
    }

    private string GenerateJwtToken(Taikhoan user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("detainghiencuukhoahoccntt4k23truongdaihochaiphong2024"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] 
        {
            new Claim(ClaimTypes.Name, user.Gmail),
            new Claim("MaSinhVien", user.MaSinhVien.ToString()),
            new Claim(ClaimTypes.Role, user.VaiTro?.Ten ?? "User"),
        };

        var token = new JwtSecurityToken(
            issuer: "YourIssuer",
            audience: "YourAudience",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}