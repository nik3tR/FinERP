using System.Linq;
using FinERP.Data;
using FinERP.Models;

public static class DataSeeder
{
    public static void SeedUsers(AppDbContext context)
    {
        var passwordService = new PasswordService();

        var usersToSeed = new List<(string Email, string Password, string Role)>
        {
            ("admin@erp.com", "password", "Admin"),
            ("manager@erp.com", "Manager123!", "Manager"),
            ("employee1@erp.com", "Employee123!", "Employee"),
            ("employee2@erp.com", "Employee123!", "Employee")
        };

        foreach (var (email, password, role) in usersToSeed)
        {
            if (!context.Users.Any(u => u.Email == email))
            {
                var user = new User
                {
                    Email = email,
                    PasswordHash = "",
                    Role = role
                };

                user.PasswordHash = passwordService.HashPassword(user, password);

                context.Users.Add(user);
            }
        }

        context.SaveChanges();
    }
}