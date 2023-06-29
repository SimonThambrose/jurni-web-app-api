namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogRepository _blogRepository;

    public BlogController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    [HttpGet("getAllBlogs")]
    public async Task<IEnumerable<Blog>> GetAllBlogs()
    {
        return await _blogRepository.GetAllBlogs();
    }
    
    [HttpPut("{id}/like")]
    public async Task<ActionResult<Blog>> UpdateBlogLikes(int id)
    {
        Blog result = await _blogRepository.UpdateBlogLikes(id);
        return result != null ? Ok(result) : BadRequest();
    }
    
    [HttpPost("createBlog")]
    public async Task<ActionResult<Blog>> CreateBlog(Blog blog)
    {
        Blog result = await _blogRepository.CreateBlog(blog);
        return result != null ? Ok(blog) : BadRequest();
    }
}