namespace jurni_web_app_api.xUnit.Tests;

public class UserControllerTests
{
    private Mock<IUserRepository> _userRepo;
    private UserController _sut;

    public UserControllerTests()
    {
        _userRepo = new Mock<IUserRepository>();
        _sut = new UserController(_userRepo.Object);
    }
    
    [Fact]
    public void GetAllUsers_ExistingData_ReturnsAllUsers()
    {
        //Arrange
        var usersFromList = CreateListUsers();
        _userRepo.Setup(w => w.GetAllUsers()).Returns(Task.FromResult(usersFromList));

        //Act
        var result = _sut.GetAllUsers();

        //Assert
        Assert.NotNull(result);
        var usersFromResult = result.Result;
        Assert.True(usersFromResult.Count().Equals(usersFromList.Count()));
        Assert.True(usersFromResult.FirstOrDefault().Id.Equals(usersFromList.FirstOrDefault().Id));
    }
    
    [Fact]
    public void GetAllUsers_NonExistingData_ReturnsEmptyList()
    {
        //Arrange
        var userEmptyList = CreateEmptyListUsers();
        _userRepo.Setup(w => w.GetAllUsers()).Returns(Task.FromResult(userEmptyList));

        //Act
        var result = _sut.GetAllUsers();

        //Assert
        Assert.Equal(userEmptyList.Count(), result.Result.Count());
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