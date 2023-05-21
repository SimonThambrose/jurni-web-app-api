namespace jurni_web_app_api.Interfaces;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetBlogs();
}