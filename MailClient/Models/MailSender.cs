using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace MailClient.Models
{
    class MailSender
    {
        private MailMessage mail;
        private SmtpClient smtp;

        public MailMessage Mail { get => mail; set => mail = value; }

        public SmtpClient Smtp { get => smtp; set => smtp = value; }

        public void Send(string from, string to, string theme, string body)
        {

            mail = new MailMessage(from, to) { Subject = theme, Body = body, IsBodyHtml = false };

            smtp = new SmtpClient(SmtpData.GmailHost, SmtpData.GmailPort)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("artstar99@gmail.com", "")
            };

            try
            {
                smtp.Send(mail);
                MessageBox.Show("Письмо должно было быть отправлено");
            }
            catch (Exception e)
            {

                MessageBox.Show("Невозможно отправить письмо" + e.ToString());
            }
        }

        public void AddAttachments()
        {
        }
        public void Send(string from, string to)
        {
        }

        public MailSender()
        {
                
        }

    }
}
