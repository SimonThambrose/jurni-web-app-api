namespace jurni_web_app_api.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;

    public BlogRepository(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }

    public async Task<IEnumerable<Blog>> GetBlogs()
    {
        return await _jurniWebAppApiDbContext.Blogs.ToListAsync();
    }
}