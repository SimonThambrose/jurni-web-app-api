namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ContactRequestController : ControllerBase
{
    private IContactRequestRepository _contactRequestRepository;

    public ContactRequestController(IContactRequestRepository contactRequestRepository)
    {
        _contactRequestRepository = contactRequestRepository;
    }

    [HttpGet("getContactRequests")]
    public async Task<IEnumerable<ContactRequest>> getContactRequests()
    {
        return await _contactRequestRepository.GetContactRequests();
    }
}