namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly jurni_web_app_apiDbContext _jurniWebAppApiDbContext;
    
    public UserController(jurni_web_app_apiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }
    
    [HttpGet("getUsers")]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _jurniWebAppApiDbContext.Users.ToListAsync();
    }
}