using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;

public class PasswordResetRequest
{
    public string Email { get; set; }
}

public class VerifyOtpRequest
{
    public string Email { get; set; }
    public string OtpCode { get; set; }
}

public class ResetPasswordRequest
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
}

public class EmailService
{
    public async Task SendOtpAsync(string email, string otp)
    {
        var message = new MailMessage("tungdao123pzo@gmail.com", email)
        {
            Subject = "Mã xác thực đặt lại mật khẩu",
            Body = $"Mã OTP của bạn là: {otp}"
        };

        using var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential("tungdao123pzo@gmail.com", "ylgq okgh zqrc kojt"),
            EnableSsl = true
        };

        await smtp.SendMailAsync(message);
    }
}

[ApiController]
[Route("api/[controller]")]
public class PasswordResetController : ControllerBase
{
    private static Dictionary<string, string> otpStorage = new(); // In-memory OTP lưu trữ tạm thời

    private readonly EmailService _emailService;
    private readonly SinhVienDbContext _context;

    public PasswordResetController(EmailService emailService, SinhVienDbContext context)
    {
        _emailService = emailService;
        _context = context;
    }

    [HttpPost("send-otp")]
    public async Task<IActionResult> SendOtp([FromBody] PasswordResetRequest request)
    {
        var user = await _context.Taikhoans.FirstOrDefaultAsync(u => u.Gmail == request.Email);
        if (user == null) return NotFound("Email không tồn tại.");

        var otp = new Random().Next(100000, 999999).ToString();
        otpStorage[request.Email] = otp;

        await _emailService.SendOtpAsync(request.Email, otp);
        return Ok("Đã gửi mã xác thực.");
    }

    [HttpPost("verify-otp")]
    public IActionResult VerifyOtp([FromBody] VerifyOtpRequest request)
    {
        if (otpStorage.TryGetValue(request.Email, out var correctOtp) && correctOtp == request.OtpCode)
        {
            return Ok("Xác thực thành công.");
        }

        return BadRequest("Mã xác thực không đúng.");
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var user = await _context.Taikhoans.FirstOrDefaultAsync(u => u.Gmail == request.Email);
        if (user == null) return NotFound("Email không tồn tại.");
        user.MatKhau = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        // user.MatKhau = HashPassword(request.NewPassword); // Hash lại password nếu cần
        await _context.SaveChangesAsync();
        otpStorage.Remove(request.Email);

        return Ok("Đặt lại mật khẩu thành công.");
    }
    //
    private string HashPassword(string password)
    {
        // Có thể dùng BCrypt hoặc SHA256
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }
}
