using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tools
{
    public class SendMail
    {
        public static void SendNotif(string item)
        {
            string from = "EMAIL A METTRE";
            string emailtoSend = "EMAIL A METTRE";
            MailMessage message = new MailMessage(from, emailtoSend);
            message.Subject = "Item vendu";
            message.Body = @"L'item suivant a bien été vendu " + item;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential(from, "MOT DE PASSE A METTRE");
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
