using Microsoft.AspNetCore.Mvc;

namespace jurni_web_app_api.xUnit.Tests;

public class ContactRequestControllerTests
{
    private Mock<IContactRequestRepository> _contactRequestRepo;
    private ContactRequestController _sut;

    public ContactRequestControllerTests()
    {
        _contactRequestRepo = new Mock<IContactRequestRepository>();
        _sut = new ContactRequestController(_contactRequestRepo.Object);
    }
    
    [Fact]
    public void GetAllContactRequests_ExistingData_ReturnsAllContactRequests()
    {
        //Arrange
        IEnumerable<ContactRequest> contactRequestsFromList = CreateListContactRequests();
        _contactRequestRepo.Setup(c => c.GetAllContactRequests()).Returns(Task.FromResult(contactRequestsFromList));

        //Act
        var result = _sut.GetAllContactRequests();

        //Assert
        Assert.NotNull(result);
        var contactRequestsFromResult = result.Result;
        Assert.True(contactRequestsFromResult.Count().Equals(contactRequestsFromList.Count()));
        Assert.True(contactRequestsFromResult.FirstOrDefault().Id.Equals(contactRequestsFromList.FirstOrDefault().Id));
    }

    [Fact]
    public void GetAllContactRequests_NonExistingData_ReturnsEmptyList()
    {
        //Arrange
        IEnumerable<ContactRequest> contactRequestsEmptyList = CreateEmptyListContactRequests();
        _contactRequestRepo.Setup(c => c.GetAllContactRequests()).Returns(Task.FromResult(contactRequestsEmptyList));

        //Act
        var result = _sut.GetAllContactRequests();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(contactRequestsEmptyList.Count(), result.Result.Count());
    }
    
    [Fact]
    public void GetContactRequest_ValidId_ReturnsContactRequest()
    {
        //Arrange
        ContactRequest contactRequest = CreateValidContactRequest();
        _contactRequestRepo.Setup(c => c.GetContactRequest(1)).ReturnsAsync(contactRequest);

        //Act
        var result = _sut.GetContactRequest(1);
        
        Assert.NotNull(result);
        var contactRequestFromResult = result.Result;
        Assert.IsType<OkObjectResult>(contactRequestFromResult.Result);
        Assert.Equal(contactRequest, (ContactRequest)((OkObjectResult)contactRequestFromResult.Result).Value);
    }
    
    [Fact]
    public void GetContactRequest_InValidId_ReturnsNotFound()
    {
        //Arrange
        ContactRequest contactRequest = null;
        _contactRequestRepo.Setup(c => c.GetContactRequest(1)).ReturnsAsync(contactRequest);

        // Act
        var result = _sut.GetContactRequest(1);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<NotFoundResult>(result.Result.Result);
    }
    
    [Fact]
    public void CreateValidContactRequest_ValidContactRequest_ReturnsContactRequest()
    {
        //Arrange
        ContactRequest contactRequest = CreateValidContactRequest();
        _contactRequestRepo.Setup(c => c.CreateContactRequest(contactRequest)).ReturnsAsync(contactRequest);
        
        //Act
        var result = _sut.CreateContactRequest(contactRequest);
        
        //Assert
        Assert.NotNull(result);
        var contactRequestFromResult = result.Result;
        Assert.IsType<OkObjectResult>(contactRequestFromResult.Result);
        Assert.Equal(contactRequest, ((OkObjectResult)contactRequestFromResult.Result).Value);
    }
    
    [Fact]
    public void CreateValidContactRequest_InValidContactRequest_ReturnsNull()
    {
        //Arrange
        ContactRequest contactRequest = CreateInValidContactRequest();
        
        //Act
        var result = _sut.CreateContactRequest(contactRequest);
        
        //Assert
        Assert.NotNull(result);
        Assert.IsType<BadRequestResult>(result.Result.Result);
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
    
    private ContactRequest CreateValidContactRequest()
    {
        ContactRequest contactRequest = new ContactRequest
        {
            Id = 1, FirstName = "John", LastName = "Doe", Email = "john@doe.com",
            Message = "Contact request message", IsEnterprisePlan = true, Status = "OPEN",
            CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now
        };
        
        return contactRequest;
    }
    
    private ContactRequest CreateInValidContactRequest()
    {
        ContactRequest contactRequest = new ContactRequest
        {
            Id = 2, FirstName = null, LastName = null, Email = "invalid-email",
            Message = null, IsEnterprisePlan = false,
            CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now
        };
        
        return contactRequest;
    }
}