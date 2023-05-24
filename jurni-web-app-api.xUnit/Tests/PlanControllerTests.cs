namespace jurni_web_app_api.xUnit.Tests;

public class PlanControllerTests
{
    private Mock<IPlanRepository> _planRepo;
    private PlanController _sut;

    public PlanControllerTests()
    {
        _planRepo = new Mock<IPlanRepository>();
        _sut = new PlanController(_planRepo.Object);
    }
    
    [Fact]
    public void GetAllPlans_ExistingData_ReturnsAllPlans()
    {
        //Arrange
        var plansFromList = CreateListPlans();
        _planRepo.Setup(w => w.GetAllPlans()).Returns(Task.FromResult(plansFromList));

        //Act
        var result = _sut.GetAllPlans();

        //Assert
        Assert.NotNull(result);
        var plansFromResult = result.Result;
        Assert.True(plansFromResult.Count().Equals(plansFromList.Count()));
        Assert.True(plansFromResult.FirstOrDefault().Id.Equals(plansFromList.FirstOrDefault().Id));
    }

    [Fact]
    public void GetAllPlans_NonExistingData_ReturnsEmptyList()
    {
        //Arrange
        var plansEmptyList = CreateEmptyListPlans();
        _planRepo.Setup(w => w.GetAllPlans()).Returns(Task.FromResult(plansEmptyList));

        //Act
        var result = _sut.GetAllPlans();

        //Assert
        Assert.Equal(plansEmptyList.Count(), result.Result.Count());
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
}