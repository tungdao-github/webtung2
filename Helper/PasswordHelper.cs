using System.Security.Cryptography;
using System.Text;

namespace WebApplication2.Controllers;

public static class PasswordHelper
{
    public static string GenerateRandomPassword(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var password = new StringBuilder();
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] buffer = new byte[1];
            for (int i = 0; i < length; i++)
            {
                rng.GetBytes(buffer);
                char randomChar = chars[buffer[0] % chars.Length];
                password.Append(randomChar);
            }
        }
        return password.ToString();
    }
}
