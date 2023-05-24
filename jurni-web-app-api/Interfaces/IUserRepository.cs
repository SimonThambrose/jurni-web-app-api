namespace jurni_web_app_api.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
}