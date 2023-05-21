namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;
    
    public BlogController(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }
    
    [HttpGet("getBlogs")]
    public async Task<IEnumerable<Blog>> GetBlogs()
    {
        return await _jurniWebAppApiDbContext.Blogs.ToListAsync();
    }
}