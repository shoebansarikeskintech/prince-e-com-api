﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AppLoginViewModel
    {
        [Required]
        public string? username { get; set; }
        [Required]
        public string? password { get; set; }
    }
    public class TokenDetailsViewModel
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
    public class SendOtpViewModel
    {
        [Required]
        public string? username { get; set; }
    }
    public class VerifyOtpViewModel
    {
        [Required]
        public string? username { get; set; }
        [Required]
        public string? otp { get; set; }
    }
    public class SendOtpRequestViewModel
    {
        public string? Otp { get; set; }
        public string? UserFullName { get; set; }
    }
    public class ForgotPasswordViewModel
    {
        [Required]
        public string? username { get; set; }
        [Required]
        public string? password { get; set; }
    }
    public class AddAppUserViewModel
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
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Skintype { get; set; }
        public string? IsSkinSensitve { get; set; }
    }

    public class UpdateAppUserViewModel
    {
        public Guid userId { get; set; }
        public string? age { get; set; }
        public string? gender { get; set; }
        public string? skinType { get; set; }
        public string? isSkinSensitve { get; set; }
    }

    public class AddSkinInsightUserViewModel
    {
        public Guid userId { get; set; }
        public string? age { get; set; }
        public string? name { get; set; }
        public string? gender { get; set; }
        public string? skintype { get; set; }
        public string? skinSensitive { get; set; }
        public Guid createdBy { get; set; }
        public IFormFile? imageFile { get; set; }
        //public IFormFile imageFile { get; set; } 
    }
    public class updateSkinInsightUserViewModel
    {
        public Guid userId { get; set; }        
        public Guid skinInsightUserId { get; set; }
        public Guid updatedBy { get; set; }
        public string? name { get; set; }
        public bool active { get; set; }
    }
}
