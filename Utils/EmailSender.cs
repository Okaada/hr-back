using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace hr_system_v2.Utils
{
    public class EmailSender
    {
        public void SendEmail(string toEmail, string code)
        {

            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("23eacbbd8df984", "643bf91dea85c5"),
                EnableSsl = true
            };

            try
            {
                client.Send("passwordDelivery@RH.com", toEmail, "Reset Passwrod", code);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
    }
}
