

using ViewModel;

namespace ServiceContract
{
    public interface IUserContract
    {
        public Task<ResponseViewModel> getAppUserGetProfileDetails(Guid UserId);
        public Task<ResponseViewModel> appUserUpdateProfile(UpdateProfileViewModel updateCategory);
        public Task<ResponseViewModel> appUserUpdatePassword(UpdatePasswordViewModel updateCategory);
        
    }
}
