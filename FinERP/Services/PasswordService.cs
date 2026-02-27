using Microsoft.AspNetCore.Identity;

public class PasswordService
{
    private readonly PasswordHasher<User> _hasher = new();

    public string HashPassword(User user, string password)
    {
        return _hasher.HashPassword(user, password);
    }

    public bool VerifyPassword(User user, string enteredPassword)
    {
        var result = _hasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            enteredPassword);

        return result == PasswordVerificationResult.Success;
    }
}