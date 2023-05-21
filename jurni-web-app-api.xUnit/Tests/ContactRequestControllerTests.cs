using jurni_web_app_api.Controllers;

namespace jurni_web_app_api.xUnit.Tests;

public class ContactRequestControllerTests
{
    private Mock<IContactRequestRepository> _contactRequestRepo;
    private ContactRequestController _sut;
    
    [Fact]
    public void GetContactRequests_ExistingData_ReturnsContactRequests()
    {
        //Arrange
        _contactRequestRepo = new Mock<IContactRequestRepository>();
        _sut = new ContactRequestController(_contactRequestRepo.Object);
        var contactRequestsFromList = CreateListContactRequests();

        _contactRequestRepo.Setup(w => w.GetContactRequests()).Returns(Task.FromResult(contactRequestsFromList));

        //Act
        var result = _sut.getContactRequests();

        //Assert
        Assert.NotNull(result);
        var contactRequestsFromResult = result.Result;
        Assert.True(contactRequestsFromResult.Count().Equals(contactRequestsFromList.Count()));
        Assert.True(contactRequestsFromResult.FirstOrDefault().Message
            .Equals(contactRequestsFromList.FirstOrDefault().Message));
    }

    [Fact]
    public void GetContactRequests_NonExistingData_ReturnsEmptyList()
    {
        //Arrange
        _contactRequestRepo = new Mock<IContactRequestRepository>();
        _sut = new ContactRequestController(_contactRequestRepo.Object);
        var contactRequestsEmptyList = CreateEmptyListContactRequests();

        _contactRequestRepo.Setup(w => w.GetContactRequests()).Returns(Task.FromResult(contactRequestsEmptyList));

        //Act
        var result = _sut.getContactRequests();

        //Assert
        var data = result.Result;
        Assert.Equal(contactRequestsEmptyList.Count(), data.Count());
    }

    private IEnumerable<ContactRequest> CreateListContactRequests()
    {
        return new List<ContactRequest>
        {
            new()
            {
                Id = 1, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                Message = "Contact request message", IsEnterprisePlan = true, Status = "OPEN",
                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now
            },
            new()
            {
                Id = 2, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                Message = "Contact request message", IsEnterprisePlan = false,
                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now
            },
            new()
            {
                Id = 3, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                Message = "Contact request message", IsEnterprisePlan = true, Status = "DATED",
                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now
            },
            new()
            {
                Id = 4, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                Message = "Contact request message", IsEnterprisePlan = true, Status = "APPROVED",
                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now
            },
            new()
            {
                Id = 5, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                Message = "Contact request message", IsEnterprisePlan = true, Status = "DENIED",
                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now
            },
            new()
            {
                Id = 6, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                Message = "Contact request message", IsEnterprisePlan = false,
                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now
            },
            new()
            {
                Id = 7, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
                Message = "Contact request message", IsEnterprisePlan = false,
                CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now
            }
        };
    }

    private IEnumerable<ContactRequest> CreateEmptyListContactRequests()
    {
        return new List<ContactRequest>();
    }
}