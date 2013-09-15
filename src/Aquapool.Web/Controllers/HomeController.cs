using System;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Web.Mvc;
using Aquapool.Models;

namespace Aquapool.Controllers {
    public class HomeController : Controller {
        private static readonly string To;
        private static readonly string From;
        private static readonly string MessageTemplate;

        static HomeController() {
            var config = WebConfigurationManager.OpenWebConfiguration("~/web.config");
            To = config.AppSettings.Settings["smtp-to-address"].Value;
            From = config.AppSettings.Settings["smtp-from-address"].Value;

            var path = System.Web.HttpContext.Current.Request.MapPath("~/message-template.html");
            MessageTemplate = System.IO.File.ReadAllText(path);
        }

        //
        // GET: /Home/
        public ActionResult Index() {
            return View();
        }

        public ActionResult Nbw() {
            return View();
        }

        public ActionResult Abtiwa() {
            return View();
        }

        public ActionResult Lobby() {
            return View();
        }

        //[HttpPost]
        //public ActionResult Submit(string name, string company, string emailAddress, string subject, string text) {
        //    try {
        //        RelayMessage(new Message { Name = name, Company = company, EmailAddress = emailAddress, Subject = subject, Text = text });
        //    }
        //    catch (Exception ex) {
        //        return Json(new { success = false, error = ex });
        //    }
        //    return Json(new { success = true });
        //}

        [HttpPost]
        public ActionResult Submit(Message message) {
            try {
                RelayMessage(message);
            }
            catch (Exception ex) {
                return Json(new { success = false, error = ex });
            }
            return Json(new { success = true });
        }

        private static void RelayMessage(Message model) {
            var message = new MailMessage(From, To);
            //var sender = model.Title == "-"
            //    ? string.Format("{0} {1} {2}", model.Salutation, model.Name, model.Surname)
            //    : string.Format("{0} {1} {2} {3}", model.Salutation, model.Title, model.Name, model.Surname);

            //message.To.Add(To);
            //message.Subject = string.Format("Kontaktanfrage von {0}", sender);
            //message.SubjectEncoding = Encoding.UTF8;

            //message.Body = Regex.Replace(MessageTemplate, "@[a-zA-Z]+", m => {
            //    if (m.Value == "@sender") {
            //        return sender;
            //    }
            //    if (m.Value == "@subject") {
            //        return model.Subject;
            //    }
            //    if (m.Value == "@email") {
            //        return model.Email;
            //    }
            //    if (m.Value == "@phone") {
            //        return model.IsPhoneCallRequested
            //            ? model.PhoneNumber
            //            : "-";
            //    }
            //    return m.Value == "@text" ? model.Text : m.Value;
            //});

            //message.ReplyToList.Add(model.Email);
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            var client = new SmtpClient();
            client.Send(message);
        }

    }
}
