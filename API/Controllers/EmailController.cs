using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost("SendOTP")]
        public IActionResult SendMail(string email)
        {
            var OTP_value = new Random().Next(100000, 999999);
            var emailConfig = new MimeMessage();
            emailConfig.From.Add(MailboxAddress.Parse("drinkstore0311@gmail.com"));
            emailConfig.To.Add(MailboxAddress.Parse(email));
            emailConfig.Subject = "Xác thực OTP";
            emailConfig.Body = new TextPart()
            {
                Text = "Mã xác thực của bạn là : " + OTP_value,
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com",465);
            smtp.Authenticate("drinkstore0311@gmail.com", "kozychosgczhywgg");
            smtp.Send(emailConfig);
            smtp.Disconnect(true);
            return Ok(OTP_value);
        }
        
        [HttpPost("SendMail")]
        public IActionResult SendMail(string email, string body)
        {
            
            var emailConfig = new MimeMessage();
            emailConfig.From.Add(MailboxAddress.Parse(email));
            emailConfig.To.Add(MailboxAddress.Parse("drinkstore0311@gmail.com"));
            emailConfig.Subject = "Phản hồi của khách hàng";
            emailConfig.Body = new TextPart()
            {
                Text = body,
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com",465);
            smtp.Authenticate("drinkstore0311@gmail.com", "kozychosgczhywgg");
            smtp.Send(emailConfig);
            smtp.Disconnect(true);
            return Ok("Success");
        }
    }
}
