using System.Security.Cryptography;
using System.Text;

namespace jurni_web_app_api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;

    public UserRepository(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _jurniWebAppApiDbContext.Users.ToListAsync();
    }

    public async Task<User> GetUser(string email, string password)
    {
        User user = await _jurniWebAppApiDbContext.Users.FirstOrDefaultAsync(c => c.Email == email);

        if (user == null)
        {
            return null;
        }

        using (var hmac = new HMACSHA512(user.PasswordSalt))
        {
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (passwordHash.SequenceEqual(user.PasswordHash))
            {
                return user;
            }

            return null;
        }
    }

    public async Task<User> CreateUser(UserModel userModel)
    {
        var hmac = new HMACSHA512();
        User user = new()
        {
            FirstName = userModel.FirstName,
            LastName = userModel.LastName,
            Email = userModel.Email,
            PasswordSalt = hmac.Key,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userModel.Password)),
            IsAdmin = false,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        await _jurniWebAppApiDbContext.Users.AddAsync(user);
        await _jurniWebAppApiDbContext.SaveChangesAsync();

        return user;
    }
}