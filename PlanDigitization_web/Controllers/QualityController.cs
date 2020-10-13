using System.Web.Mvc;
using static PlanDigitization_web.FilterConfig;

namespace PlanDigitization_web.Controllers
{
    [SessionTimeout]
    public class QualityController : Controller
    {
        // GET: Quality
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QualityLiveDashboard()
        {

            return View();
        }
        public ActionResult QualityHistoricDashboard()
        {

            return View();
        }
        public ActionResult QualityHistoric_Heatmap()
        {

            return View();
        }
    }
}