
using ViewModel;

namespace ServiceContract
{
   public interface ICustomerManagementContract
    {
        public Task<ResponseViewModel> getAllCustomer();
        public Task<ResponseViewModel> getAllOrderByUser(string username);
        public Task<ResponseViewModel> getAppUserProfileDetails(Guid userId);
        public Task<ResponseViewModel> appUserUpdateProfile(UpdateProfileViewModel forgotPassword);
        public Task<ResponseViewModel> appUserUpdatePassword(UpdatePasswordViewModel addAppUser);

    }
}
