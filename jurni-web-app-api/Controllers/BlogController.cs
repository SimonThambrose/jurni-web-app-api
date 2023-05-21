namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BlogController : ControllerBase
{
    private IBlogRepository _blogRepository;

    public BlogController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    [HttpGet("getBlogs")]
    public async Task<IEnumerable<Blog>> GetBlogs()
    {
        return await _blogRepository.GetBlogs();
    }
}