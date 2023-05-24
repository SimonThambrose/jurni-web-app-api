namespace jurni_web_app_api.Interfaces;

public interface IPlanRepository
{
    Task<IEnumerable<Plan>> GetAllPlans();
}