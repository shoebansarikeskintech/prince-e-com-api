using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace EmailSystem
{
    public class EmailService
    {
        private readonly IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<bool> SendEmail<T>(string email, string subject, string body)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                MailMessage Email = new MailMessage();
                Email.To.Add(email);
                Email.From = new MailAddress("noreply@mailsprovidor.com", "noreply@clipstrust.com");
                Email.Subject = subject;
                Email.Body = body.ToString();
                Email.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "email-smtp.us-east-1.amazonaws.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("AKIAUHKMWX7RNVPB6JWW", "BE0X4EOFaWwzvrX9yJQpg+Tq1c6w+1jPOBb68Kanf6G0");
                smtp.Send(Email);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string otpEmailBody(string otp, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'>Dear User,&nbsp;" + name + "</div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'><br></div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'>Please enter below OTP to login to your Clips Trust&nbsp;account.&nbsp;</div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'><br></div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'>OTP - " + otp + "</div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'><br></div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'>Note: This OTP is valid for the next 24 hours only. If you did not make this request please</div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'>write at Support@clipstrust.com</div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'><br></div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'>Regards</div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'>Clips Trust&nbsp;Team</div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'><br></div>");
            sb.Append("<div style='color: rgb(69, 90, 100); font-size: 14px;'<img src = 'https://www.clipstrust.com/static/img/logo.png' alt = 'Logo' width = '100' height = '100'/></div>");

            return sb.ToString();
        }
    }
}
