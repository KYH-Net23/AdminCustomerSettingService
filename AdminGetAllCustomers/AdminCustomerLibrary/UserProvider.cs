
using AdminCustomerLibrary.Models;
using System.Net.Http.Json;

namespace AdminCustomerLibrary;

public class UserProvider
{
    private readonly HttpClient _httpClient;

    public UserProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Users>> GetAllCustomersAsync()
    {
        try
        {
            var users = await _httpClient.GetFromJsonAsync<List<Users>>("api/Customer/GetAll");
            return users ?? new List<Users>();
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<Users>();
        }
    }
}
