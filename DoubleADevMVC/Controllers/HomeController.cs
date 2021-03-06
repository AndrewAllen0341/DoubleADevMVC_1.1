using DoubleADevMVC.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DoubleADevMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public JsonResult ContactAjax(ContactFormViewModel cvm)
        {
            // You can make this whatever you want, it will be the body of the message sent
            string body = $"{cvm.Name} has sent you the following message: <br/>" + $"{cvm.Message} from the email address: {cvm.Email}";

            // Message Object
            MailMessage mm = new MailMessage
                (
                // FROM address - email must be on host - creds stored in Web.config
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                // To - email doesn't have to be on host - creds stored in Web.config
                ConfigurationManager.AppSettings["EmailTo"].ToString(),
                // Email subject
                cvm.Subject,
                // Body of the email
                body);

            // Allow HTML in email (That is our formatting with br tag above)
            mm.IsBodyHtml = true;
            // You can make the message be designated as high priority
            mm.Priority = MailPriority.High;
            // Reply to the Person who filled out the form, not your domain email
            mm.ReplyToList.Add(cvm.Email);

            // Configure the mail client - creds stored in web.config
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());
            // Configure the email credentials using values from web.config
            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(), ConfigurationManager.AppSettings["EmailPass"].ToString());

            try
            {
                // Send Mail
                client.Send(mm);
            }
            catch (Exception ex)
            {
                // Log error in ViewBag to be seen by admins
                ViewBag.Message = ex.StackTrace;
                return Json(HttpStatusCode.BadRequest);
            }

            return Json(cvm);

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}