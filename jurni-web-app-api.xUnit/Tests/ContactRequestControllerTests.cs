namespace jurni_web_app_api.xUnit.Tests;

public class ContactRequestControllerTests
{
    [Fact]
    public void GetContactRequests_ExistingData_ReturnsContactRequests()
    {
        //Arrange
        var contactRequestRepo = CreateContactRequestRepo();
        var contactRequest = CreateContactRequestAdapter(contactRequestRepo);
        var contactRequestsFromList = CreateListContactRequests();

        contactRequestRepo.Setup(w => w.GetContactRequests()).Returns(Task.FromResult(contactRequestsFromList));

        //Act
        var result = contactRequest.GetContactRequests();

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
        var contactRequestRepo = CreateContactRequestRepo();
        var contactRequest = CreateContactRequestAdapter(contactRequestRepo);
        var contactRequestsEmptyList = CreateEmptyListContactRequests();

        contactRequestRepo.Setup(w => w.GetContactRequests()).Returns(Task.FromResult(contactRequestsEmptyList));

        //Act
        var result = contactRequest.GetContactRequests();

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

    private Mock<IContactRequestRepository> CreateContactRequestRepo()
    {
        return new Mock<IContactRequestRepository>();
    }

    private Adapter.ContactRequest CreateContactRequestAdapter(Mock<IContactRequestRepository> contactRequestRepository)
    {
        return new Adapter.ContactRequest(contactRequestRepository.Object);
    }
}