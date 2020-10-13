
using System.Web.Mvc;
using static PlanDigitization_web.FilterConfig;

namespace PlanDigitization_web.Controllers
{
    [SessionTimeout]
    public class OEEController : Controller
    {
        public ActionResult OEELiveDashboard()
        {
            if (this.HasPermission("OEELive-View"))
            {

                return View();
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        public ActionResult OEEHistoricDashboard()
        {
            if (this.HasPermission("OEEHistoric-View"))
            {

                return View();
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }
    }
}