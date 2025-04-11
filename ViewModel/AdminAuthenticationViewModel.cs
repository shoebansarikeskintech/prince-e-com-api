
using System.ComponentModel.DataAnnotations;
namespace ViewModel
{
    public class AdminUserLoginViewModel
    {
        [Required]
        public string? username { get; set; }
        [Required]
        public string? password { get; set; }
    }
    public class AdminTokenDetailsViewModel
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public string? username { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? phoneNumber { get; set; }
    }
    public class AddAdminUserViewModel
    {
        [Required]
        public string? username { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public string? phoneNumber { get; set; }
    }

    public class AdminUserGuidViewModel
    {
        public Guid adminUserId { get; set; }
    }

    public class AdminSendOtpViewModel
    {
        [Required]
        public string? username { get; set; }
    }
    public class AdminVerifyOtpViewModel
    {
        [Required]
        public string? username { get; set; }
        [Required]
        public string? otp { get; set; }
    }
    public class AdminSendOtpRequestViewModel
    {
        public string? Otp { get; set; }
        public string? UserFullName { get; set; }
    }
    public class AdminForgotPasswordViewModel
    {
        [Required]
        public string? username { get; set; }
        [Required]
        public string? password { get; set; }
    }
}
