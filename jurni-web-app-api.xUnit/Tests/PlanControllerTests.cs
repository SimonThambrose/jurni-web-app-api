namespace jurni_web_app_api.xUnit.Tests;

public class PlanControllerTests
{
    [Fact]
    public void GetPlans_ExistingData_ReturnsPlans()
    {
        //Arrange
        var planRepo = CreatePlanRepo();
        var plan = CreatePlanAdapter(planRepo);
        var plansFromList = CreateListPlans();

        planRepo.Setup(w => w.GetPlans()).Returns(Task.FromResult(plansFromList));

        //Act
        var result = plan.GetPlans();

        //Assert
        Assert.NotNull(result);
        var plansFromResult = result.Result;
        Assert.True(plansFromResult.Count().Equals(plansFromList.Count()));
        Assert.True(plansFromResult.FirstOrDefault().Name
            .Equals(plansFromList.FirstOrDefault().Name));
    }

    [Fact]
    public void GetBlogs_NonExistingData_ReturnsEmptyList()
    {
        //Arrange
        var planRepo = CreatePlanRepo();
        var plan = CreatePlanAdapter(planRepo);
        var plansEmptyList = CreateEmptyListPlans();

        planRepo.Setup(w => w.GetPlans()).Returns(Task.FromResult(plansEmptyList));

        //Act
        var result = plan.GetPlans();

        //Assert
        var data = result.Result;
        Assert.Equal(plansEmptyList.Count(), data.Count());
    }

    private IEnumerable<Plan> CreateListPlans()
    {
        return new List<Plan>
        {
            new()
            {
                Id = 1, Name = "Free", Price = 0,
                Description = "Limited to 10 matches per month"
            },
            new()
            {
                Id = 2, Name = "Paid", Price = 3.99,
                Description = "Unlimited matches per month"
            },
            new()
            {
                Id = 3, Name = "Enterprise",
                Description = "Contact us for pricing. Unlimited matches per month. 72 hour support."
            }
        };
    }

    private IEnumerable<Plan> CreateEmptyListPlans()
    {
        return new List<Plan>();
    }

    private Mock<IPlanRepository> CreatePlanRepo()
    {
        return new Mock<IPlanRepository>();
    }

    private Adapter.Plan CreatePlanAdapter(Mock<IPlanRepository> planRepository)
    {
        return new Adapter.Plan(planRepository.Object);
    }
}