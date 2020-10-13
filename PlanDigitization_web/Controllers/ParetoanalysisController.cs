using System.Web.Mvc;
using static PlanDigitization_web.FilterConfig;

namespace PlanDigitization_web.Controllers
{
    [SessionTimeout]
    public class ParetoanalysisController : Controller
    {
        public ActionResult Paretoanalysis()
        {
            if (this.HasPermission("ParetoAnalysisHistoric-View"))
            {

                return View();
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        public ActionResult MTTR()
        {
            return View();
        }

        public ActionResult MTBF()
        {
            return View();
        }

        public ActionResult MOA()
        {
            return View();
        }
        public ActionResult AndonLive()
        {
            if (this.HasPermission("AndonLive-View"))
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