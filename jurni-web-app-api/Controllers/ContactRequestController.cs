namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ContactRequestController : ControllerBase
{
    private readonly IContactRequestRepository _contactRequestRepository;

    public ContactRequestController(IContactRequestRepository contactRequestRepository)
    {
        _contactRequestRepository = contactRequestRepository;
    }

    [HttpGet("getAllContactRequests")]
    public Task<IEnumerable<ContactRequest>> GetAllContactRequests()
    {
        return _contactRequestRepository.GetAllContactRequests();
    }
    
    [HttpGet("getContactRequest/{id}")]
    public async Task<ActionResult<ContactRequest>> GetContactRequest(int id)
    {
        ContactRequest contactRequest = await _contactRequestRepository.GetContactRequest(id);
        return contactRequest != null ? Ok(contactRequest) : NotFound();
    }
    
    [HttpPost("createContactRequest")]
    public async Task<ActionResult<ContactRequest>> CreateContactRequest(ContactRequest contactRequest)
    {
        ContactRequest result = await _contactRequestRepository.CreateContactRequest(contactRequest);
        return result != null ? Ok(contactRequest) : BadRequest();
    }
}