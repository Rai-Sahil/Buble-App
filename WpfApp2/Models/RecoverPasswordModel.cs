using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Net.Http;
using System.Windows.Forms;

namespace WpfApp2.Models
{
    public class RecoverPasswordModel
    {
        public static string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
           
        }

        public static void SendNewPasswordToUser(string email, string HTML_email_template)
        {
            string frommail = "socialbuble2@gmail.com";
            string fromPassword = "npnbijceqfyzvrzi";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(frommail);

            message.Subject = "Test Subject";
            message.To.Add(new MailAddress(email));
            message.Body = HTML_email_template;

            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(frommail, fromPassword),
                EnableSsl = true,

            };

            
            smtpClient.Send(message);

        }
    }
}
