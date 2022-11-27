using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class SendMail
    {
        public static void SendNotif(string item)
        {
            string from = "No-reply@GildedRose.com";
            string emailtoSend = "enzo.amieva@gmail.com";
            MailMessage message = new MailMessage(from, emailtoSend);
            message.Subject = "Item vendu";
            message.Body = @"L'item suivant a bien été vendu " + item;
            SmtpClient client = new SmtpClient("smtp-mailtp.alwaysdata.net");
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in SendNotif(): {0}",
                 ex.ToString());
            }
        }
    }
}
