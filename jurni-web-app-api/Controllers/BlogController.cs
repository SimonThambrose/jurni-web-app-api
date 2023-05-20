namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly jurni_web_app_apiDbContext _jurniWebAppApiDbContext;
    
    public BlogController(jurni_web_app_apiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }
    
    [HttpGet("getBlogs")]
    public async Task<IEnumerable<Blog>> GetBlogs()
    {
        return await _jurniWebAppApiDbContext.Blogs.ToListAsync();
    }
}