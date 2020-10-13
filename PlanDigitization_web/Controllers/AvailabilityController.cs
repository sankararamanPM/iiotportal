using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PlanDigitization_web.FilterConfig;

namespace PlanDigitization_web.Controllers
{
    [SessionTimeout]
    public class AvailabilityController : Controller
    {
        public ActionResult AvailabilityLiveDashboard()

        {
            if (this.HasPermission("MachineAvailabilityLive-View"))
            {

                return View();
            }
            else
            {
                return RedirectToAction("Unauth_page","Main");
            }
        }

        public ActionResult AvailabilityHistoricDashboard()

        {
            if (this.HasPermission("MachineAvailabilityHistoric-View"))
            {


                return View();

            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }
        private void MachineListDisplay()
        {
            try
            {
                var AvlModel = new Models.Avl_Input();
                AvlModel.MachineList = new List<string>();
                AvlModel.MachineList.Add("M1");
                AvlModel.MachineList.Add("M2");
                AvlModel.MachineList.Add("M3");
                TempData["MachineList"] = AvlModel.MachineList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void LineListDisplay()
        {
            try
            {
                var AvlModel = new Models.Avl_Input();
                AvlModel.LineList = new List<string>();
                AvlModel.LineList.Add("VFOE");
                AvlModel.LineList.Add("L2");
                AvlModel.LineList.Add("L3");
                TempData["LineList"] = AvlModel.LineList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}