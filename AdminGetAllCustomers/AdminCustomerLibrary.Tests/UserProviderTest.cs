using AdminCustomerLibrary;
using AdminCustomerLibrary.ViewModels;
using Moq;
using Moq.Protected;
using System.Net.Http.Json;
using System.Net;

public class UserProviderTests
{
    private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
    private readonly UserProvider _userProvider;

    public UserProviderTests()
    {
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri("http://localhost")
        };

        _userProvider = new UserProvider(httpClient);
    }

    //[Fact]
    //public void GetAllCustomersAsync_ShouldReturnCorrectNumberOfUsers()
    //{

    //    var userProvider = new UserProvider(new HttpClient());
    //    int expectedCount = 3;


    //    var mockedUsers = GetMockedUsers();


    //    Assert.Equal(expectedCount, mockedUsers.Count);
    //}
    //new UserViewModel { Id = "1", UserName = "ggre", UserType = "Admin", IsActive = true },   
    //    new UserViewModel { Id = "2", UserName = "bhtdhxhf", UserType = "User", IsActive = false },   
    //    new UserViewModel { Id = "3", UserName = "jjiie", UserType = "User", IsActive = true }

    [Fact]
    public async Task GetAllCustomersAsync_ReturnsCustomerList_WhenSuccessful()
    {
        // Arrange
        var expectedCustomers = new List<CustomerViewModel>
        {
            new CustomerViewModel { Id = "1", Username = "ggre", UserRole = "Admin", IsDeleted = true },
            new CustomerViewModel { Id = "2", Username = "bhtdhxhf", UserRole = "User", IsDeleted = false },
            new CustomerViewModel { Id = "3", Username = "jjiie", UserRole = "User", IsDeleted = true }
        };

        _mockHttpMessageHandler
             .Protected()
             .Setup<Task<HttpResponseMessage>>(
                 "SendAsync",
                 ItExpr.IsAny<HttpRequestMessage>(),
                 ItExpr.IsAny<CancellationToken>()
             )
             .ReturnsAsync(new HttpResponseMessage
             {
                 StatusCode = HttpStatusCode.OK,
                 Content = JsonContent.Create(expectedCustomers)
             });
        // Act
        var result = await _userProvider.GetAllCustomersAsync();

        // Assert
        Assert.Equal(expectedCustomers.Count, result.Count);
        Assert.Equal(expectedCustomers[0].Username, result[0].Username);
        Assert.Equal(expectedCustomers[0].UserRole, result[0].UserRole);
        Assert.Equal(expectedCustomers[0].IsDeleted, result[0].IsDeleted);
    }
}
