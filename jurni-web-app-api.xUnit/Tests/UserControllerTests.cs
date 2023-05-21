namespace jurni_web_app_api.xUnit.Tests;

public class UserControllerTests
{
    [Fact]
    public void GetUsers_ExistingData_ReturnsUsers()
    {
        //Arrange
        var userRepo = CreateUserRepo();
        var user = CreateUserAdapter(userRepo);
        var usersFromList = CreateListUsers();

        userRepo.Setup(w => w.GetUsers()).Returns(Task.FromResult(usersFromList));

        //Act
        var result = user.GetUsers();

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
        var userRepo = CreateUserRepo();
        var user = CreateUserAdapter(userRepo);
        var userEmptyList = CreateEmptyListUsers();

        userRepo.Setup(w => w.GetUsers()).Returns(Task.FromResult(userEmptyList));

        //Act
        var result = user.GetUsers();

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

    private Mock<IUserRepository> CreateUserRepo()
    {
        return new Mock<IUserRepository>();
    }

    private Adapter.User CreateUserAdapter(Mock<IUserRepository> userRepository)
    {
        return new Adapter.User(userRepository.Object);
    }
}