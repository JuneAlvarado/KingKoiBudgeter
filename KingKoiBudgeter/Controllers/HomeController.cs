using KingKoiBudgeter.Models;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KingKoiBudgeter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            EmailModel model = new EmailModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model, string contactName, string contactEmail, string contactPhone, string messBody)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold> ({1})</p><p>{2}</>";
                    var from = "KingKoiBudgeter<example@email.com>";
                    model.Subject = "This is a message from the KingKoi Budgeter. You have been invited to join a Household.";

                    var email = new MailMessage(from, ConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = "KingKoi Budgeter Invitation",
                        Body = string.Format(body, model.FromName, model.FromEmail, model.Body),


                        IsBodyHtml = true

                    };

                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);

                    return View(new EmailModel());
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }
    }
}