using AdminUserLibrary.ViewModels;
using System.Net.Http.Json;

namespace AdminCustomerLibrary;

public class UserProvider
{
    private readonly HttpClient _httpClient;

    public UserProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<UserViewModel>> GetAllCustomersAsync()
    {
        try
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserViewModel>>("api/Customer/GetAll");
            return users ?? new List<UserViewModel>();
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<UserViewModel>();
        }
    }

    public List<UserViewModel> GetMockedUsers()
    {
        return new List<UserViewModel>
    {
        new UserViewModel { Id = "1", UserName = "ggre", UserType = "Admin", IsActive = true },   
        new UserViewModel { Id = "2", UserName = "bhtdhxhf", UserType = "User", IsActive = false },   
        new UserViewModel { Id = "3", UserName = "jjiie", UserType = "User", IsActive = true } 
    };
    }

}
