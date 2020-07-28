using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Security;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = new MailAddress("artstar99@gmail.com", "Kostya");
            var to =new MailAddress("artcore.gen@gmail.com");
            var m = new MailMessage(from, to) {Subject = "Тест", Body = "Тестовое письмо", IsBodyHtml = false};

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("artstar99@gmail.com", "")
            };

            try
            {
                smtp.Send(m);
                Console.WriteLine("Письмо должно было быть отправлено");
            }
            catch (Exception e)
            {

                Console.WriteLine("Невозможно отправить письмо" + e.ToString());
            }

            Console.ReadKey();
        }
    }
}
