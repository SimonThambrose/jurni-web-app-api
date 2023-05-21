namespace jurni_web_app_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PlanController : ControllerBase
{
    private IPlanRepository _planRepository;

    public PlanController(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    [HttpGet("getPlans")]
    public async Task<IEnumerable<Plan>> GetPlans()
    {
        return await _planRepository.GetPlans();
    }
}