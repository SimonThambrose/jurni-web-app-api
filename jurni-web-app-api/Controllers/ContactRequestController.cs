namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ContactRequestController : ControllerBase
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;
    
    public ContactRequestController(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }
    
    [HttpGet("getContactRequests")]
    public async Task<IEnumerable<ContactRequest>> GetContactRequests()
    {
        return await _jurniWebAppApiDbContext.ContactRequests.ToListAsync();
    }
}