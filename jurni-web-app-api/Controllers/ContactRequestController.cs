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

    [HttpGet("getAllContactRequests")]
    public Task<IEnumerable<ContactRequest>> GetAllContactRequests()
    {
        return _contactRequestRepository.GetAllContactRequests();
    }
    
    [HttpGet("getContactRequest/{id}")]
    public async Task<ActionResult<ContactRequest>> GetContactRequest(int id)
    {
        ContactRequest result = await _contactRequestRepository.GetContactRequest(id);
        return result != null ? Ok(result) : NotFound();
    }
    
    [HttpPost("createContactRequest")]
    public async Task<ActionResult<ContactRequest>> CreateContactRequest(ContactRequest contactRequest)
    {
        ContactRequest result = await _contactRequestRepository.CreateContactRequest(contactRequest);
        return result != null ? Ok(result) : BadRequest();
    }
}