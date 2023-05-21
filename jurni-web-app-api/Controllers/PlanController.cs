namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PlanController : ControllerBase
{
    private readonly jurni_web_app_apiDbContext _jurniWebAppApiDbContext;
    
    public PlanController(jurni_web_app_apiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }
    
    [HttpGet("getPlans")]
    public async Task<IEnumerable<Plan>> GetPlans()
    {
        return await _jurniWebAppApiDbContext.Plans.ToListAsync();
    }
}