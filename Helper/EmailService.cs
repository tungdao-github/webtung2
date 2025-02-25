using MimeKit;
using MailKit.Net.Smtp;

public class EmailService
{
    private readonly string _smtpServer = "smtp.gmail.com"; // Thay đổi theo nhà cung cấp email
    private readonly int _smtpPort = 587;
    private readonly string _emailSender = "dhhpnghiencukhoahoc@gmail.com"; // Email của bạn
    private readonly string _emailPassword = "ffea ykui bthi leqh"; // Mật khẩu ứng dụng

    public bool SendEmail(string recipientEmail, string newPassword)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Admin", _emailSender));
            message.To.Add(new MailboxAddress(recipientEmail, recipientEmail));
            message.Subject = "Mật khẩu mới của bạn";

            message.Body = new TextPart("plain")
            {
                Text = $"Mật khẩu mới của bạn là: {newPassword}\nVui lòng đăng nhập và đổi mật khẩu ngay lập tức."
            };

            using (var client = new SmtpClient())
            {
                client.Connect(_smtpServer, _smtpPort, false);
                client.Authenticate(_emailSender, _emailPassword);
                client.Send(message);
                client.Disconnect(true);
            }
            return true;
        }
        
        catch (Exception ex)
        {
            Console.WriteLine ($"Loi gui mail: {ex.Message}");
            return false;
        }
    }
}