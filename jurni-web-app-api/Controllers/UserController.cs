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

    [HttpGet("getAllUsers")]
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    [HttpGet("getUser")]
    public async Task<ActionResult<User>> GetUser(string email, string password)
    {
        User result = await _userRepository.GetUser(email, password);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost("createUser")]
    public async Task<ActionResult<User>> CreateUser(UserModel userModel)
    {
        User result = await _userRepository.CreateUser(userModel);
        return result != null ? Ok(result) : BadRequest();
    }
}