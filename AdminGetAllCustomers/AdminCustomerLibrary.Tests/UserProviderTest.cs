using AdminCustomerLibrary; 

public class UserProviderTests
{
    [Fact]
    public void GetMockedUsers_ShouldReturnCorrectNumberOfUsers()
    {
       
        var userProvider = new UserProvider(new HttpClient());
        int expectedCount = 3;

       
        var mockedUsers = userProvider.GetMockedUsers();

        
        Assert.Equal(expectedCount, mockedUsers.Count);
    }

    [Fact]
    public void GetMockedUsers_ShouldReturnUsersWithCorrectData()
    {
        
        var userProvider = new UserProvider(new HttpClient());

        
        var mockedUsers = userProvider.GetMockedUsers();

       
        Assert.Contains(mockedUsers, user => user.UserName == "ggre" && user.IsActive);
        Assert.Contains(mockedUsers, user => user.UserName == "bhtdhxhf" && !user.IsActive);
    }


}
