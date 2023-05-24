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
}