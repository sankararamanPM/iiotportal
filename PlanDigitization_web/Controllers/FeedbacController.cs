using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using static PlanDigitization_web.FilterConfig;

namespace PlanDigitization_web.Controllers
{
    [SessionTimeout]
    public class FeedbacController : Controller
    {
        // GET: Feedbac
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PlanDigitization_web.Models.MailModel objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {
                string from = "tealrmpadmin@titan.co.in"; //example:- sourabh9303@gmail.com
                using (MailMessage mail = new MailMessage(from, "krishnapriya@titan.co.in"))
                {
                    mail.Subject = objModelMail.Subject;
                    string username = "Feedback from " + Session["UserName"].ToString() + "\n";
                    mail.Body += username ;
                    mail.Body += "\n Comments:"+objModelMail.Body;
                    if (fileUploader != null)
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "coupleofshoes@2018");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    TempData["message"] = "Mail sent";
                    ViewBag.Message = "Sent";
                    return View("Index");
                }
            }
            else
            {
                return View();
            }
        }
    }
}