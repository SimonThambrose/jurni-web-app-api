using jurni_web_app_api.Interfaces;

namespace jurni_web_app_api.Adapter;

public class Plan
{
    private readonly IPlanRepository _planRepository;

    public Plan(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public async Task<IEnumerable<Data.Entities.Plan>> GetPlans()
    {
        return await _planRepository.GetPlans();
    }
}