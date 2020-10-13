
using System.Web.Mvc;

using static PlanDigitization_web.FilterConfig;

namespace PlanDigitization_web.Controllers
{
    [SessionTimeout]
    public class ToolLifeController : Controller
    {
        public ActionResult ToolLifeLiveDashboard()
        {
            if (this.HasPermission("ToolLifeLive-View"))
            {

                return View();
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }
        public ActionResult ToolLifeHistoricDashboard()
        {
            if (this.HasPermission("ToolLifeHistoric-View"))
            {

                return View();
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }
        public ActionResult PreventiveMaintanenceDashboard()
        {
            return View();
        }
    }
}