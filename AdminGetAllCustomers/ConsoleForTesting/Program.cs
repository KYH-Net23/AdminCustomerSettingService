// See https://aka.ms/new-console-template for more information

using AdminCustomerLibrary;

using var httpClient = new HttpClient { BaseAddress = new Uri("https://rika-identity-user-f5e3fddxg4bve2eg.swedencentral-01.azurewebsites.net") };

var userProvider = new UserProvider(httpClient);
var users = await userProvider.GetAllCustomersAsync();

foreach (var user in users)
{
    Console.WriteLine($"ID: {user.Id}, Name: {user.UserName}, Email: {user.Email}, Phone number {user.PhoneNumber}");
}
