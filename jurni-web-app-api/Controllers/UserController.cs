namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("getUsers")]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepository.GetUsers();
    }
}