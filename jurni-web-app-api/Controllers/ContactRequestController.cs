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
    public Task<IEnumerable<ContactRequest>> GetContactRequests()
    {
        return _contactRequestRepository.GetContactRequests();
    }
    
    [HttpGet("getContactRequest/{id}")]
    public Task<ContactRequest> GetContactRequest(int id)
    {
        return _contactRequestRepository.GetContactRequest(id);
    }
    
    [HttpPost("createContactRequest")]
    public Task<ContactRequest> CreateContactRequest(ContactRequest contactRequest)
    {
        return _contactRequestRepository.CreateContactRequest(contactRequest);
    }
}