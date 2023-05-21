namespace jurni_web_app_api.Repositories;

public class ContactRequestRepository : IContactRequestRepository
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;

    public ContactRequestRepository(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }

    public async Task<IEnumerable<ContactRequest>> GetContactRequests()
    {
        return await _jurniWebAppApiDbContext.ContactRequests.ToListAsync();
    }
}