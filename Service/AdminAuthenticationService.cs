using RepositoryContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
    public class AdminAuthenticationService : IAdminAuthenticationContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public AdminAuthenticationService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> adminUserLogin(AdminUserLoginViewModel adminUserLogin)
        {
            var adminLoginDetails = await _repositoryManager.adminAuthenticationRepository.adminUserLogin(adminUserLogin);
            return adminLoginDetails;
        }

        public async Task<ResponseViewModel> addAdminUser(AddAdminUserViewModel addAdminUser)
        {
            return await _repositoryManager.adminAuthenticationRepository.addAdminUser(addAdminUser); ;
        }

        public async Task<ResponseViewModel> adminSendOtp(AdminSendOtpViewModel adminSendOtp)
        {
            var sendOtpDetails = await _repositoryManager.adminAuthenticationRepository.adminSendOtp(adminSendOtp);
            return sendOtpDetails;
        }
        public async Task<ResponseViewModel> adminVerifyOtp(AdminVerifyOtpViewModel adminVerifyOtp)
        {
            var verifyOtpDetails = await _repositoryManager.adminAuthenticationRepository.adminVerifyOtp(adminVerifyOtp);
            return verifyOtpDetails;
        }
        public async Task<ResponseViewModel> adminForgotPassword(AdminForgotPasswordViewModel adminForgotPassword)
        {
            return await _repositoryManager.adminAuthenticationRepository.adminForgotPassword(adminForgotPassword);
        }

        public async Task<ResponseViewModel> getAdminUserDetails(AdminUserGuidViewModel adminUserGuid, string username)
        {
            return await _repositoryManager.adminAuthenticationRepository.getAdminUserDetails(adminUserGuid, username); 
        }

        public async Task<ResponseViewModel> getAdminDashboardDetails(string username)
        {
            return await _repositoryManager.adminAuthenticationRepository.getAdminDashboardDetails(username);
        }

        public async Task<ResponseViewModel> getAllAdminList()
        {
            return await _repositoryManager.adminAuthenticationRepository.getAllAdminList();
        }

        public async Task<ResponseViewModel> updateAdminStatusActivate(string userId)
        {
            return await _repositoryManager.adminAuthenticationRepository.updateAdminStatusActivate(userId);
        }

        public async Task<ResponseViewModel> updateAdminStatusDeActivate(string userId)
        {
            return await _repositoryManager.adminAuthenticationRepository.updateAdminStatusDeActivate(userId);
        }
    }
}
