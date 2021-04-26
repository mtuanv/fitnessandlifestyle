using fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace fitness.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ViewResult Index(Email email)
        //{
        //    MailMessage mail = new MailMessage(email.From, "minhtuan1690002@gmail.com", email.Subject, email.Body);
        //    mail.IsBodyHtml = true;
        //    string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/WebClient/newFeedback.html"));
        //    content = content.Replace("{{UserName}}", email.From);
        //    content = content.Replace("{{Email}}", email.Email1);
        //    content = content.Replace("{{Feedback}}", email.Body);
        //    mail.
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = new System.Net.NetworkCredential("tuanvm169@gmail.com", "testmail123");
        //    smtp.EnableSsl = true;
        //    smtp.Send(mail);
        //    return View();
        //}

        [HttpPost]
        public JsonResult SendMailToUser(sMail email)
        {
            bool result = false;
            result = SendEmail("minhtuan1690002@gmail.com", email.subject, "<p><b>Name:</b> " + email.name + "<br/><b>Email:</b> " + email.email + "<br/><b>Feedback Content:</b> " + email.content + "</p>");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}