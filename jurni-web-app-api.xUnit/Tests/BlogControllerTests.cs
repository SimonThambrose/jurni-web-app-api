namespace jurni_web_app_api.xUnit.Tests;

public class BlogControllerTests
{
    private Mock<IBlogRepository> _blogRepo;
    private BlogController _sut;
    
    [Fact]
    public void GetBlogs_ExistingData_ReturnsBlogs()
    {
        //Arrange
        _blogRepo = new Mock<IBlogRepository>();
        _sut = new BlogController(_blogRepo.Object);
        var blogsFromList = CreateListBlogs();

        _blogRepo.Setup(w => w.GetBlogs()).Returns(Task.FromResult(blogsFromList));

        //Act
        var result = _sut.GetBlogs();

        //Assert
        Assert.NotNull(result);
        var blogsFromResult = result.Result;
        Assert.True(blogsFromResult.Count().Equals(blogsFromList.Count()));
        Assert.True(blogsFromResult.FirstOrDefault().Title.Equals(blogsFromList.FirstOrDefault().Title));
    }

    [Fact]
    public void GetBlogs_NonExistingData_ReturnsEmptyList()
    {
        //Arrange
        _blogRepo = new Mock<IBlogRepository>();
        _sut = new BlogController(_blogRepo.Object);
        var blogsEmptyList = CreateEmptyListBlogs();

        _blogRepo.Setup(w => w.GetBlogs()).Returns(Task.FromResult(blogsEmptyList));

        //Act
        var result = _sut.GetBlogs();

        //Assert
        var data = result.Result;
        Assert.Equal(blogsEmptyList.Count(), data.Count());
    }

    private IEnumerable<Blog> CreateListBlogs()
    {
        var hmac = new HMACSHA512();
        var author = new User()
        {
            Id = 1, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
            PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("JohnDoePassword")), PasswordHash = hmac.Key,
            IsAdmin = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
        };

        return new List<Blog>
        {
            new()
            {
                Id = 1, Title = "Blog title", Description = "Blog description", AuthorId = 1, Author = author, Likes = 0,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 2, Title = "Blog title", Description = "Blog description", AuthorId = 1, Author = author, Likes = 1,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 3, Title = "Blog title", Description = "Blog description", AuthorId = 1, Author = author, Likes = 2,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 4, Title = "Blog title", Description = "Blog description", AuthorId = 1, Author = author, Likes = 3,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 5, Title = "Blog title", Description = "Blog description", AuthorId = 1, Author = author, Likes = 4,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 6, Title = "Blog title", Description = "Blog description", AuthorId = 1, Author = author, Likes = 5,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 7, Title = "Blog title", Description = "Blog description", AuthorId = 1, Author = author, Likes = 6,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            }
        };
    }

    private IEnumerable<Blog> CreateEmptyListBlogs()
    {
        return new List<Blog>();
    }
}