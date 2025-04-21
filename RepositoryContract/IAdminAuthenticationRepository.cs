using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace RepositoryContract
{
    public interface IAdminAuthenticationRepository
    {
        public Task<ResponseViewModel> adminUserLogin(AdminUserLoginViewModel adminUserLogin);
        public Task<ResponseViewModel> addAdminUser(AddAdminUserViewModel addAdminUser);
        public Task<ResponseViewModel> adminSendOtp(AdminSendOtpViewModel adminSendOtp);
        public Task<ResponseViewModel> adminVerifyOtp(AdminVerifyOtpViewModel adminVerifyOtp);
        public Task<ResponseViewModel> adminForgotPassword(AdminForgotPasswordViewModel adminForgotPassword);
        public Task<ResponseViewModel> getAdminUserDetails(AdminUserGuidViewModel adminUserGuid, string username);
        public Task<ResponseViewModel> getAdminDashboardDetails();
        public Task<ResponseViewModel> getAllAdminList();
        public Task<ResponseViewModel> updateAdminStatusActivate(string adminuserId);
        public Task<ResponseViewModel> updateAdminStatusDeActivate(string adminuserId);
    }
}
