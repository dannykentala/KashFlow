using BCrypt.Net;

namespace KashFlow.Application.Utils;

public static class PasswordHashing
{
    public static string HashPassword(string password)
    {   
        // Generate the password hash
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Verify the password against the hash
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}