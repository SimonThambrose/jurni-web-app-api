namespace jurni_web_app_api.Interfaces;

public interface IContactRequestRepository
{
    Task<IEnumerable<ContactRequest>> GetAllContactRequests();
    Task<ContactRequest>? GetContactRequest(int id);
    Task<ContactRequest> CreateContactRequest(ContactRequest contactRequest);
}