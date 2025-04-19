using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceContract
{
    public interface IAuthenticationContract
    {
        public Task<ResponseViewModel> appLogin(AppLoginViewModel appLogin);
        public Task<ResponseViewModel> sendOtp(SendOtpViewModel sendOtp);
        public Task<ResponseViewModel> verifyOtp(VerifyOtpViewModel verifyOtp);
        public Task<ResponseViewModel> forgotPassword(ForgotPasswordViewModel forgotPassword);
        public Task<ResponseViewModel> addAppUser(AddAppUserViewModel addAppUser);
        public Task<ResponseViewModel> updateAppUser(UpdateAppUserViewModel updateAppUser);

    }
}
