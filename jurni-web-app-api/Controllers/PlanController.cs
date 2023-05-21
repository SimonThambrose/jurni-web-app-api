namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PlanController : ControllerBase
{
    private readonly JurniWebAppApiDbContext _jurniWebAppApiDbContext;
    
    public PlanController(JurniWebAppApiDbContext jurniWebAppApiDbContext)
    {
        _jurniWebAppApiDbContext = jurniWebAppApiDbContext;
    }
    
    [HttpGet("getPlans")]
    public async Task<IEnumerable<Plan>> GetPlans()
    {
        return await _jurniWebAppApiDbContext.Plans.ToListAsync();
    }
}