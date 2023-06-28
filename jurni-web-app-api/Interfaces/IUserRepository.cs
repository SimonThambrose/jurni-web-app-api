namespace jurni_web_app_api.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUser(string email, string password);
    Task<User> CreateUser(UserModel userModel);
}