using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Dobro.WebUI.Mailing
{
    public class Mailer
    {
        public async Task<bool> SendConfirmation(string email, string callbackUrl)
        {
            Mail mail =
                new Mail("Подтверждение электронной почты", "Для завершения регистрации перейдите по ссылке:: <a href=\""
                                                               + callbackUrl + "\">завершить регистрацию</a>");

            await SendEmail(email, mail);

            return true;

        }

        //метод имеет стандартную версию для отправки одному и перегруженную для рассылок
        private async Task<bool> SendEmail(IEnumerable<string> Addresats, Mail mail)
        {
            var message = new MailMessage();
            foreach (string email in Addresats)
            {
                message.To.Add(new MailAddress(email));
            }

            message.Subject = mail.Subject;

            message.Body = mail.Body;

            message.IsBodyHtml = true;
            //включение Html для показа в письме

            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(message);
            }

            return true; //попытка изобрести асинхронность
        }


        //Добавь асинхронность
        private async Task<bool> SendEmail(string Addresat, Mail mail)
        {
            var message = new MailMessage();

            message.To.Add(new MailAddress(Addresat));

            message.Subject = mail.Subject;

            message.Body = mail.Body;

            message.IsBodyHtml = true;
            //включение Html для показа в письме


            using (var smtp = new SmtpClient())
            {
                //smtp.SendMailAsync(message);
                //убрал так как не умею работат с потоками
                await smtp.SendMailAsync(message);
            }

            return true; //попытка изобрести асинхронный метод
        }
    }
}