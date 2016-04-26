using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Nousware.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        { 
            return View();
        }

        [HttpPost]
        public string Index(string name, string email, string message)
        {
            string emailMessage = name + "<br/>" + email + "<br/>" + message;
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(ConfigurationManager.AppSettings["Email.ToEmail"]);
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["Email.UserName"]);
                mailMessage.Subject = "Quick Message(Message from site nous-ware.com)";
                mailMessage.Body = emailMessage;
                mailMessage.IsBodyHtml = true;

                string server = ConfigurationManager.AppSettings["Email.Server"];
                int port = int.Parse(ConfigurationManager.AppSettings["Email.Port"]);
                SmtpClient smtpClient = new SmtpClient(server, port);
                smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["Email.EnableSsl"]);
                smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Email.UserName"], ConfigurationManager.AppSettings["Email.Password"]);
                smtpClient.Send(mailMessage);
                return "success";
            }
            catch (Exception ex)
            {
                Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
            return "fail";
        }

        public ActionResult UserReg(int? id)
        {
            ViewBag.price = id;
            return View();
        }

        [HttpPost]
        public string UserReg(string name, string email, string message)
        {
            string emailMessage = name + "<br/>" + email + "<br/>" + message;
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(ConfigurationManager.AppSettings["Email.ToEmail"]);
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["Email.UserName"]);
                mailMessage.Subject = "Quick Message(Message from site nous-ware.com)";
                mailMessage.Body = emailMessage;
                mailMessage.IsBodyHtml = true;

                string server = ConfigurationManager.AppSettings["Email.Server"];
                int port = int.Parse(ConfigurationManager.AppSettings["Email.Port"]);
                SmtpClient smtpClient = new SmtpClient(server, port);
                smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["Email.EnableSsl"]);
                smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Email.UserName"], ConfigurationManager.AppSettings["Email.Password"]);
                smtpClient.Send(mailMessage);
                return "success";
            }
            catch (Exception ex)
            {
                Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
            return "fail";
        }

    }
}