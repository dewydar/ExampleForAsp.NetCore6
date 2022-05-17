using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.Common.EmailConfigure
{
    public interface ISendEmail
    {
        void SendMail(string toEmail, string fromMailAddress, string fromMailPassword, string Smtp, string port, string subject, string body);
    }
}
