using ViewModel;

namespace RepositoryContract
{
    public interface IAuthenticationRepository
    {
        public Task<ResponseViewModel> appLogin(AppLoginViewModel appLogin);
        public Task<ResponseViewModel> sendOtp(SendOtpViewModel sendOtp);
        public Task<ResponseViewModel> verifyOtp(VerifyOtpViewModel verifyOtp);
        public Task<ResponseViewModel> forgotPassword(ForgotPasswordViewModel forgotPassword);
        public Task<ResponseViewModel> addAppUser(AddAppUserViewModel addAppUser);
        public Task<ResponseViewModel> updateAppUser(UpdateAppUserViewModel updateAppUser);
        public Task<ResponseViewModel> addSkinInsightUser(AddSkinInsightUserViewModel addSkinInsightUser);
        public Task<ResponseViewModel> updateSkinInsightUser(updateSkinInsightUserViewModel updateSkinInsightUser);


    }
}
