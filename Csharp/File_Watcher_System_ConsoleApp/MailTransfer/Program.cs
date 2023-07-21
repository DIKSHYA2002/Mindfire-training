using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MailTransfer
{
    internal class Program
    {
        public static void SendMail()
        {
            try
            {
                var smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("0f45558b49d4cc", "4efba32a3acb58"),
                    EnableSsl = true
                };
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("cse.20bcsa27@silicon.ac.in");
                mailMessage.To.Add("mfsi.dikshyaa@gmail.com");
                mailMessage.Subject = "Subject";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "<h1  style='color:red'>Great offer</h1>" +
                    "<h2>Hello World</h2> <h3>Not so good</h3>";
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email Sent Successfully.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
          
        }
        static void Main(string[] args)
        {
            SendMail();

        }
    }
}
