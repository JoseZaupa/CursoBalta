using System.Net;
using System.Net.Mail;

namespace Blog.Services;

public class EmailService
{
    public bool Send(string toName, string toEmail, string subject, string body, string fromName = "Equipe zaupa.io", string fromEmail = "jazjunior@gmail.com")
    {
        var smtpClient = new SmtpClient(Configuration.Smtp.Host)
        {
            Port = Configuration.Smtp.Port,
            Credentials = new NetworkCredential(Configuration.Smtp.UserName, Configuration.Smtp.Password),
            EnableSsl = true
        };
        var mail = new MailMessage();
        mail.From = new MailAddress(fromEmail, fromName);
        mail.To.Add(new MailAddress(toEmail, toName));
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        try
        {
            smtpClient.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}