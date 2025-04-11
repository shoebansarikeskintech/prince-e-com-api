using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class AuthenticationService : IAuthenticationContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public AuthenticationService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<ResponseViewModel> appLogin(AppLoginViewModel appLogin)
        {
            var appLoginDetails = await _repositoryManager.authenticationRepository.appLogin(appLogin);
            return appLoginDetails;
        }
        public async Task<ResponseViewModel> sendOtp(SendOtpViewModel sendOtp)
        {
            var sendOtpDetails = await _repositoryManager.authenticationRepository.sendOtp(sendOtp);
            return sendOtpDetails;
        }
        public async Task<ResponseViewModel> verifyOtp(VerifyOtpViewModel verifyOtp)
        {
            var verifyOtpDetails = await _repositoryManager.authenticationRepository.verifyOtp(verifyOtp);
            return verifyOtpDetails;
        }
        public async Task<ResponseViewModel> forgotPassword(ForgotPasswordViewModel forgotPassword)
        {
            return await _repositoryManager.authenticationRepository.forgotPassword(forgotPassword);
        }

        public async Task<ResponseViewModel> addAppUser(AddAppUserViewModel addAppUser)
        {
            return await _repositoryManager.authenticationRepository.addAppUser(addAppUser); ;
        }

    }
}
