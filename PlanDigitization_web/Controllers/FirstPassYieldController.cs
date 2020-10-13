﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlanDigitization_web.Models;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using static PlanDigitization_web.FilterConfig;

namespace PlanDigitization_web.Controllers
{
    [SessionTimeout]
    public class FirstPassYieldController : Controller
    {
        public ActionResult FirstPassYieldHistoricDashboard()
        {
            if (this.HasPermission("FirstPassHistoric-View"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
          }
        public ActionResult HourlyTrackerLive()
        {
            return View();
        }
        public ActionResult FirstPassYieldLiveDashboard()
        {
            if (this.HasPermission("FirstPassLive-View"))
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