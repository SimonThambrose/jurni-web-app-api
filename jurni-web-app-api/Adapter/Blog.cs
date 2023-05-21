using jurni_web_app_api.Interfaces;

namespace jurni_web_app_api.Adapter;

public class Blog
{
    private readonly IBlogRepository _blogRepository;

    public Blog(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<IEnumerable<Data.Entities.Blog>> GetBlogs()
    {
        return await _blogRepository.GetBlogs();
    }
}