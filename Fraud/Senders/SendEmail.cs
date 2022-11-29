using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Fraud.Senders
{
    public class SendEmail
    {
        public static void Send(string to,string subject,string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");///از چه اس ام تی پی استتفاده میکنید
            mail.From = new MailAddress("abouhamze.fahime@gmail.com","توانیر");// از چه ایمیلی استفاده میکنید
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587; ///پورت اس ام تی پی ما 
            SmtpServer.Credentials = new System.Net.NetworkCredential("abouhamze.fahime@gmail.com", "****");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}