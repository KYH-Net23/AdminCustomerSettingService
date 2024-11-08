using AdminUserLibrary.ViewModels;

namespace AdminUserLibrary
{
    public interface IUserProvider
    {
        Task<List<AdminViewModel>> GetAllAdminsAsync();
        Task<List<CustomerViewModel>> GetAllCustomersAsync();
    }
}