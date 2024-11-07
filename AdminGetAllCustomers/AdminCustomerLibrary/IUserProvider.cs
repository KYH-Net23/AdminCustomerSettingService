using AdminCustomerLibrary.ViewModels;

namespace AdminCustomerLibrary
{
    public interface IUserProvider
    {
        Task<List<AdminViewModel>> GetAllAdminsAsync();
        Task<List<CustomerViewModel>> GetAllCustomersAsync();
    }
}