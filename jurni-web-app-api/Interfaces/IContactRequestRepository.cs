namespace jurni_web_app_api.Interfaces;

public interface IContactRequestRepository
{
    Task<IEnumerable<ContactRequest>> GetContactRequests();
}