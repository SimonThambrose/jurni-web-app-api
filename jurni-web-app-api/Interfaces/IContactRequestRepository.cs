namespace jurni_web_app_api.Interfaces;

public interface IContactRequestRepository
{
    Task<IEnumerable<ContactRequest>> GetContactRequests();
    Task<ContactRequest>? GetContactRequest(int id);
    Task<ContactRequest> CreateContactRequest(ContactRequest contactRequest);
}