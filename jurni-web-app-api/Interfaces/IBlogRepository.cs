namespace jurni_web_app_api.Interfaces;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetAllBlogs();
    Task<Blog> UpdateBlogLikes(int id);
    Task<Blog> CreateBlog(Blog blog);
}