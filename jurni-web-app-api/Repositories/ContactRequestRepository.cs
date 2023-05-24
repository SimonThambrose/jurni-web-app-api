namespace jurni_web_app_api.Repositories;

public class ContactRequestRepository : IContactRequestRepository
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;

    public ContactRequestRepository(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }

    public async Task<IEnumerable<ContactRequest>> GetAllContactRequests()
    {
        return await _jurniWebAppApiDbContext.ContactRequests.ToListAsync();
    }

    public async Task<ContactRequest>? GetContactRequest(int id)
    {
        return await _jurniWebAppApiDbContext.ContactRequests.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<ContactRequest> CreateContactRequest(ContactRequest contactRequest)
    {
        await _jurniWebAppApiDbContext.ContactRequests.AddAsync(contactRequest);
        await _jurniWebAppApiDbContext.SaveChangesAsync();
        return contactRequest;
    }
}