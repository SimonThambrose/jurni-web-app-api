namespace jurni_web_app_api.Repositories;

public class PlanRepository : IPlanRepository
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;

    public PlanRepository(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }

    public async Task<IEnumerable<Plan>> GetPlans()
    {
        return await _jurniWebAppApiDbContext.Plans.ToListAsync();
    }
}