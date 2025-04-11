﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ViewModel;

namespace Common
{
      public class ExtractToken
    {
        private readonly IConfiguration configuration;
        public ExtractToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public TokenDetailsViewModel ExtractUserDetailsFromToken(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = key,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                var name = principal.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                var username = principal.Claims.FirstOrDefault(c => c.Type == "username")?.Value;
                var email = principal.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
                var mobile = principal.Claims.FirstOrDefault(c => c.Type == "mobile")?.Value;

                return new TokenDetailsViewModel
                {
                    name = name,
                    username = username,
                    email = email,
                   // mobile = mobile,
                };
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException("Invalid token", ex);
            }
        }

        public AdminTokenDetailsViewModel ExtractAdminUserDetailsFromToken(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = key,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                var name = principal.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                var username = principal.Claims.FirstOrDefault(c => c.Type == "username")?.Value;
                var email = principal.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
                var mobile = principal.Claims.FirstOrDefault(c => c.Type == "mobile")?.Value;

                return new AdminTokenDetailsViewModel
                {
                    name = name,
                    username = username,
                    email = email,
                    // mobile = mobile,
                };
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException("Invalid token", ex);
            }
        }
    }
}
