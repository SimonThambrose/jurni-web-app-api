namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ContactRequestController : ControllerBase
{
    private readonly jurni_web_app_apiDbContext _jurniWebAppApiDbContext;
    
    public ContactRequestController(jurni_web_app_apiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }
    
    [HttpGet("getContactRequests")]
    public async Task<IEnumerable<ContactRequest>> GetContactRequests()
    {
        return await _jurniWebAppApiDbContext.ContactRequests.ToListAsync();
    }
}