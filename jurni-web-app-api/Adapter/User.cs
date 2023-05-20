using jurni_web_app_api.Interfaces;

namespace jurni_web_app_api.Adapter;

public class User
{
    private readonly IUserRepository _userRepository;

    public User(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Data.Entities.User>> GetUsers()
    {
        return await _userRepository.GetUsers();
    }
}