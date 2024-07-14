using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
 
namespace bodyshedule.Helpers
{
    public class EmailHelper
    {
        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("proninkolian@yandex.ru");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("proninkolian@yandex", "aJKMZ1cwSLT4");
            client.Host = "connect.smtp.bz";
            client.EnableSsl = true;
            client.Port = 465;
            client.UseDefaultCredentials = false;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return false;
        }
    }
}