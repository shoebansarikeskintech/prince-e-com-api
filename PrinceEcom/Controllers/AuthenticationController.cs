using Common;
using EmailSystem;
using LoggerService;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly EmailService emailService;
        private readonly ExtractToken extractToken;
        public AuthenticationController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
            _configuration = configuration;
            emailService = new EmailService(configuration);
            extractToken = new ExtractToken(configuration);
        }

        [HttpPost("appLogin")]
        public async Task<IActionResult> appLogin(AppLoginViewModel appLogin)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} appLogin");
            var loginDetails = await _serviceManager.authenticationContract.appLogin(appLogin);
            string token = null;

            if (loginDetails.statusCode == (int)HttpStatusCode.OK)
            {
                token = GenerateTokenForUserName(appLogin);
            }
            else
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No User Found");
            }
            var response = new
            {
                token,
                loginDetails.statusCode,
                loginDetails.message,
                data = (loginDetails.data as IEnumerable<object>)?.FirstOrDefault()
            };

            return Ok(response);
        }

        [HttpPost("sendOtp")]
        public async Task<IActionResult> sendOtp(SendOtpViewModel sendOtp)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} sendOtp");

            var loginDetails = await _serviceManager.authenticationContract.sendOtp(sendOtp);
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

                SendOtpRequestViewModel emailBody = new SendOtpRequestViewModel()
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

        [HttpPost("verifyOtp")]
        public async Task<IActionResult> verifyOtp(VerifyOtpViewModel verifyOtp)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} verifyOtp");
            var verifyUser = await _serviceManager.authenticationContract.verifyOtp(verifyOtp);
            return Ok(verifyUser);
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> forgotPassword(ForgotPasswordViewModel updatePassword)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updatePassword");
            var returnData = await _serviceManager.authenticationContract.forgotPassword(updatePassword);
            return Ok(returnData);
        }
        private string GenerateTokenForUserName(AppLoginViewModel login)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("username",login.username.ToString()),
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

        [HttpPost("addAppUser")]
        public async Task<IActionResult> addAppUser(AddAppUserViewModel addAppUser)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} addAppUser");
            var returnData = await _serviceManager.authenticationContract.addAppUser(addAppUser);
            return Ok(returnData);
        }

        [HttpPost("updateAppUser")]
        public async Task<IActionResult> updateAppUser(UpdateAppUserViewModel updateAppUser)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateAppUser");
            var returnData = await _serviceManager.authenticationContract.updateAppUser(updateAppUser);
            return Ok(returnData);
        }

        [HttpPost("addSkinInsightUser")]
        public async Task<IActionResult> addSkinInsightUser(AddSkinInsightUserViewModel addSkinInsightUser)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} addSkinInsightUser");
            var returnData = await _serviceManager.authenticationContract.addSkinInsightUser(addSkinInsightUser);
            return Ok(returnData);
        }

        [HttpPost("updateSkinInsightUser")]
        public async Task<IActionResult> updateSkinInsightUser(updateSkinInsightUserViewModel updateSkinInsightUser)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateSkinInsightUser");
            var returnData = await _serviceManager.authenticationContract.updateSkinInsightUser(updateSkinInsightUser);
            return Ok(returnData);
        }
    }
}
