using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NBU.Common.EmailConfigure
{
    public class SendEmail : ISendEmail
    {
        private readonly IConfiguration _config;

        public SendEmail(IConfiguration config)
        {
            _config = config;
        }

        public void SendMail(string toEmail, string fromMailAddress, string fromMailPassword, string Smtp, string port, string subject, string body)
        {
            try
            {
                if (!string.IsNullOrEmpty(toEmail) && !string.IsNullOrEmpty(fromMailAddress) && !string.IsNullOrEmpty(fromMailPassword) && !string.IsNullOrEmpty(Smtp) && !string.IsNullOrEmpty(port))
                {
                    string AllowSendMail = _config["SendMail"];

                    if (AllowSendMail != null && AllowSendMail.ToLower() == "true")
                    {
                        MailMessage mail = new MailMessage(fromMailAddress, toEmail);
                        SmtpClient client = new SmtpClient(Smtp);

                        client.Port = Convert.ToInt32(port);


                        client.Credentials = new System.Net.NetworkCredential(fromMailAddress, fromMailPassword);
                        client.EnableSsl = true;
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        client.Send(mail);
                    }
                }
            }
            catch
            {

            }

        }
    }
}
