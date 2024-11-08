namespace AdminUserLibrary.ViewModels;

public class CustomerViewModel
{
    public string Id { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Username { get; set; }
    public bool IsDeleted { get; set; }
    public string UserRole { get; set; }
}
