namespace jurni_web_app_api.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;

    public BlogRepository(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }

    public async Task<IEnumerable<Blog>> GetAllBlogs()
    {
        return await _jurniWebAppApiDbContext.Blogs.ToListAsync();
    }
    
    public async Task<Blog> UpdateBlogLikes(int id)
    {
        var blog = _jurniWebAppApiDbContext.Blogs.FirstOrDefault(b => b.Id == id);
        if (blog != null)
        {
            blog.Likes += 1;
            await _jurniWebAppApiDbContext.SaveChangesAsync();
        }
        return blog;
    }
}