using ViewModel;

namespace ServiceContract
{
    public interface IAdminAuthenticationContract
    {
        public Task<ResponseViewModel> adminUserLogin(AdminUserLoginViewModel adminAppLogin);
        public Task<ResponseViewModel> addAdminUser(AddAdminUserViewModel adminAddAppUser);
        public Task<ResponseViewModel> adminSendOtp(AdminSendOtpViewModel adminSendOtp);
        public Task<ResponseViewModel> adminVerifyOtp(AdminVerifyOtpViewModel adminVerifyOtp);
        public Task<ResponseViewModel> adminForgotPassword(AdminForgotPasswordViewModel adminUpdatePassword);
        public Task<ResponseViewModel> getAdminUserDetails(AdminUserGuidViewModel adminUserGuid, string username);
        public Task<ResponseViewModel> getAdminDashboardDetails(string username);
    }
}
