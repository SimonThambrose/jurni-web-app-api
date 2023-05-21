namespace jurni_web_app_api.xUnit.Tests;

public class UserControllerTests
{
    private Mock<IUserRepository> _userRepo;
    private UserController _sut;
    
    [Fact]
    public void GetUsers_ExistingData_ReturnsUsers()
    {
        //Arrange
        _userRepo = new Mock<IUserRepository>();
        _sut = new UserController(_userRepo.Object);
        var usersFromList = CreateListUsers();

        _userRepo.Setup(w => w.GetUsers()).Returns(Task.FromResult(usersFromList));

        //Act
        var result = _sut.GetUsers();

        //Assert
        Assert.NotNull(result);
        var usersFromResult = result.Result;
        Assert.True(usersFromResult.Count().Equals(usersFromList.Count()));
        Assert.True(usersFromResult.FirstOrDefault().Email
            .Equals(usersFromList.FirstOrDefault().Email));
    }
    
    [Fact]
    public void GetUsers_NonExistingData_ReturnsEmptyList()
    {
        //Arrange
        _userRepo = new Mock<IUserRepository>();
        _sut = new UserController(_userRepo.Object);
        var userEmptyList = CreateEmptyListUsers();

        _userRepo.Setup(w => w.GetUsers()).Returns(Task.FromResult(userEmptyList));

        //Act
        var result = _sut.GetUsers();

        //Assert
        var data = result.Result;
        Assert.Equal(userEmptyList.Count(), data.Count());
    }

    private IEnumerable<User> CreateListUsers()
    {
        var hmac = new HMACSHA512();
        return new List<User>
        {
            new()
            {
                Id = 1, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("JohnDoePassword")), PasswordHash = hmac.Key,
                IsAdmin = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 2, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("JohnDoePassword")), PasswordHash = hmac.Key,
                IsAdmin = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 3, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("JohnDoePassword")), PasswordHash = hmac.Key,
                IsAdmin = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 4, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("JohnDoePassword")), PasswordHash = hmac.Key,
                IsAdmin = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 5, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("JohnDoePassword")), PasswordHash = hmac.Key,
                IsAdmin = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 6, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("JohnDoePassword")), PasswordHash = hmac.Key,
                IsAdmin = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 7, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("JohnDoePassword")), PasswordHash = hmac.Key,
                IsAdmin = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            }
        };
    }

    private IEnumerable<User> CreateEmptyListUsers()
    {
        return new List<User>();
    }
}