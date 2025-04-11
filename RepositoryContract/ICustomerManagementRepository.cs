using ViewModel;

namespace RepositoryContract
{
   public interface ICustomerManagementRepository
    {
        public Task<ResponseViewModel> getAllCustomer();
        public Task<ResponseViewModel> getAllOrderByUser(string username);
        public Task<ResponseViewModel> getAppUserProfileDetails(Guid userId);
        public Task<ResponseViewModel> appUserUpdateProfile(UpdateProfileViewModel updateProfile);
        public Task<ResponseViewModel> appUserUpdatePassword(UpdatePasswordViewModel addAppUser);
    }
}
