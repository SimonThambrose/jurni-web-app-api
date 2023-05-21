namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;
    
    public UserController(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }
    
    [HttpGet("getUsers")]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _jurniWebAppApiDbContext.Users.ToListAsync();
    }
}