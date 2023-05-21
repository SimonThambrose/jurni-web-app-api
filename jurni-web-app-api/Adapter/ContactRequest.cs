using jurni_web_app_api.Interfaces;

namespace jurni_web_app_api.Adapter;

public class ContactRequest
{
    private readonly IContactRequestRepository _contactRequestRepository;

    public ContactRequest(IContactRequestRepository contactRequestRepository)
    {
        _contactRequestRepository = contactRequestRepository;
    }

    public async Task<IEnumerable<Data.Entities.ContactRequest>> GetContactRequests()
    {
        return await _contactRequestRepository.GetContactRequests();
    }
}