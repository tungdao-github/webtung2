using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly SinhVienDbContext _context;
        private readonly EmailService _emailService;

        public SendMailController(SinhVienDbContext context)
        {
            _context = context;
            _emailService = new EmailService();  // Khởi tạo service
        }

        [HttpPost("send-password")]
        public async Task<IActionResult> SendPassword([FromBody] EmailRequest request)
        {
            var user = await _context.Taikhoans.FirstOrDefaultAsync(t => t.Gmail == request.Email);
            if (user == null)
                return NotFound(new { message = "Email not found" });

            string newPassword = PasswordHelper.GenerateRandomPassword(10);

            // 2. Hash mật khẩu trước khi lưu vào MySQL
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // 3. Cập nhật mật khẩu vào MySQL
            user.MatKhau = hashedPassword;
            await _context.SaveChangesAsync();

            // 4. Gửi email chứa mật khẩu mới
            bool emailSent = _emailService.SendEmail(user.Gmail, newPassword);
            if (!emailSent)
                return StatusCode(500, new { Message = "Không thể gửi email" });
            
            return Ok(new { Message = "Mật khẩu mới đã được gửi tới email của bạn" });
        }
    }

    public class EmailRequest
    {
        public string Email { get; set; }
    }
}
