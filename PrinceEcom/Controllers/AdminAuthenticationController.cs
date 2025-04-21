using Common;
using EmailSystem;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrinceEcom.Utils;
using ServiceContract;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using ViewModel;

namespace PrinceEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly EmailService emailService;
        private readonly ExtractToken extractToken;
        public AdminAuthenticationController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
            extractToken = new ExtractToken(configuration);
            emailService = new EmailService(configuration);
            _configuration = configuration;
        }

        [HttpPost("adminLogin")]
        public async Task<IActionResult> adminLogin(AdminUserLoginViewModel adminLogin)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} adminLogin");
            var adminDetails = await _serviceManager.adminAuthenticationContract.adminUserLogin(adminLogin);
            string token = null;

            if (adminDetails.statusCode == (int)HttpStatusCode.OK)
            {
                token = AdminGenerateTokenForUserName(adminLogin);
            }
            else
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No User Found");
            }
            var response = new
            {
                token,
                adminDetails.statusCode,
                adminDetails.message,
                data = (adminDetails.data as IEnumerable<object>)?.FirstOrDefault()
            };

            return Ok(response);
        }

        private string AdminGenerateTokenForUserName(AdminUserLoginViewModel adminUserLogin)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("username",adminUserLogin.username.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("addAdminUser")]
        public async Task<IActionResult> addAdminUser(AddAdminUserViewModel addAdminUser)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} addAdminUser");
            var returnData = await _serviceManager.adminAuthenticationContract.addAdminUser(addAdminUser);
            return Ok(returnData);
        }

        [HttpPost("adminSendOtp")]
        public async Task<IActionResult> adminSendOtp(AdminSendOtpViewModel adminSendOtp)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} adminSendOtp");

            var loginDetails = await _serviceManager.adminAuthenticationContract.adminSendOtp(adminSendOtp);
            string? message = "";

            if (loginDetails.statusCode == 200)
            {
                bool isEmailSent = false;

                dynamic dynamicData = loginDetails.data;
                var firstItem = dynamicData[0];
                var otp = firstItem.Otp;
                var name = firstItem.firstName;
                var email = firstItem.email;

                loginDetails.data = new { name };

                AdminSendOtpRequestViewModel emailBody = new AdminSendOtpRequestViewModel()
                {
                    Otp = otp,
                    UserFullName = name,
                };

                string mailSubject = "Your OTP code for verification";
                isEmailSent = await emailService.SendEmail<SendOtpRequestViewModel>(email, mailSubject, emailService.otpEmailBody(otp, name));
                loginDetails.message = isEmailSent
                    ? "Otp sent to your email address, please enter otp"
                    : "Error in sending otp, please enter correct username.";
            }
            return Ok(loginDetails);
        }

        [HttpPost("adminVerifyOtp")]
        public async Task<IActionResult> adminVerifyOtp(AdminVerifyOtpViewModel adminVerifyOtp)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} adminVerifyOtp");
            var verifyUser = await _serviceManager.adminAuthenticationContract.adminVerifyOtp(adminVerifyOtp);
            return Ok(verifyUser);
        }

        [HttpPost("adminForgotPassword")]
        public async Task<IActionResult> adminForgotPassword(AdminForgotPasswordViewModel adminUpdatePassword)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} adminForgotPassword");
            var returnData = await _serviceManager.adminAuthenticationContract.adminForgotPassword(adminUpdatePassword);
            return Ok(returnData);
        }


        [HttpPost("getAdminUserDetails")]
        [Authorize]
        public async Task<IActionResult> getAdminUserDetails(AdminUserGuidViewModel adminUserGuid)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            AdminTokenDetailsViewModel loginViewModel = extractToken.ExtractAdminUserDetailsFromToken(token);

            _logger.logInfo($" {LoggingEvents.updateItem} getAdminUserDetails");
            var returnData = await _serviceManager.adminAuthenticationContract.getAdminUserDetails(adminUserGuid, loginViewModel.username);

            var response = new
            {
                returnData.statusCode,
                returnData.message,
                data = (returnData.data as IEnumerable<object>)?.FirstOrDefault()
            };
            return Ok(response);
        }

        [HttpPost("getAdminDashboardDetails")]
        [Authorize]
        public async Task<IActionResult> getAdminDashboardDetails()
        {
            //var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            //AdminTokenDetailsViewModel loginViewModel = extractToken.ExtractAdminUserDetailsFromToken(token);

            //_logger.logInfo($" {LoggingEvents.updateItem} getAdminDashboardDetails");
            //var returnData = await _serviceManager.adminAuthenticationContract.getAdminDashboardDetails(loginViewModel.username);


            _logger.logInfo($" {LoggingEvents.updateItem} getAdminDashboardDetails");
            var returnData = await _serviceManager.adminAuthenticationContract.getAdminDashboardDetails();
            return Ok(returnData);
        }

        [HttpPost("getAllAdminList")]
        [Authorize]
        public async Task<IActionResult> getAllAdminList()
        {
            _logger.logInfo($" {LoggingEvents.updateItem} getAllAdminList");
            var returnData = await _serviceManager.adminAuthenticationContract.getAllAdminList();
            return Ok(returnData);
        }

        [HttpPost("adminDeActivate")]
        [Authorize]
        public async Task<IActionResult> adminDeActivate(string adminuserId)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} getAdminUserDetails");
            var returnData = await _serviceManager.adminAuthenticationContract.updateAdminStatusDeActivate(adminuserId);
            return Ok(returnData);
        }

        [HttpPost("adminActivate")]
        [Authorize]
        public async Task<IActionResult> adminActivate(string adminuserId)
        {

            _logger.logInfo($" {LoggingEvents.updateItem} getAdminUserDetails");
            var returnData = await _serviceManager.adminAuthenticationContract.updateAdminStatusActivate(adminuserId);
            return Ok(returnData);
        }
    }
}
