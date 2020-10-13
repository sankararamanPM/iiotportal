using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using static PlanDigitization_web.FilterConfig;

namespace PlanDigitization_web.Controllers
{
    [SessionTimeout]
    public class UserSettingsController : Controller
    {
        string Baseurl = @System.Configuration.ConfigurationManager.AppSettings["url"];
        // Cutomer Details
        public ActionResult Customer_setting(Models.usersettings U)
        {
            
                U.QueryType = "Customer";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                    List<Models.Customer> DasList = new List<Models.Customer>();
                    var data = response.Content.ReadAsStringAsync().Result;
                    DasList = JsonConvert.DeserializeObject<List<Models.Customer>>(data);
                    return View(DasList);
                }
        }

        //Plant Details
        public ActionResult Plant_details(Models.usersettings U)
        {
            if (this.HasPermission("PlantSetting-View"))
            {
                if (Session["CompanyCode"] != null)
                {

                    U.QueryType = "Customer_Plant";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.plant> DasList = new List<Models.plant>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.plant>>(data);
                        return View(DasList);
                    }
                }


                else
                {
                    return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Function Details
        public ActionResult Function_details(Models.usersettings U)
        {
            if (this.HasPermission("FunctionSetting-View"))
            {
                if (Session["CompanyCode"] != null)
                {

                    U.QueryType = "Customer_Function_details";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Function> DasList = new List<Models.Function>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Function>>(data);
                        return View(DasList);
                    }
                }

                else
                {
                    return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Operation Settings
        public ActionResult Operation_settings(Models.usersettings U)
        {
            if (this.HasPermission("FunctionSetting-View"))
            {
                if (Session["CompanyCode"] != null)
                {

                    U.QueryType = "Company_Operations";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Operations> DasList = new List<Models.Operations>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Operations>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                    return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Assets Settings
        public ActionResult Assets_settings(Models.usersettings U)
        {
            if (this.HasPermission("AssetSetting-View"))
            {
                if (Session["CompanyCode"] != null || Session["PlantCode"] != null)
                {
                    U.QueryType = "Customer_Assetsdetails";
                    U.Parameter = Session["PlantCode"].ToString();
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.assets> DasList = new List<Models.assets>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.assets>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Product Settings
        public ActionResult Product_details(Models.usersettings U)
        {
            if (this.HasPermission("ProductSetting-View"))
            {
                if (Session["CompanyCode"] != null || Session["PlantCode"] != null)
                {
                    U.QueryType = "Customer_Product_details";
                    U.Parameter = Session["PlantCode"].ToString();
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Products> DasList = new List<Models.Products>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Products>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Holiday Settings
        public ActionResult holiday_details(Models.usersettings U)
        {
            if (this.HasPermission("HolidaySetting-View"))
            {
                if (Session["CompanyCode"] != null)
                {
                    U.QueryType = "Customer_Holiday_details";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Holiday> DasList = new List<Models.Holiday>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Holiday>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Users Settings
        public ActionResult Users_settings(Models.usersettings U)
        {
            if (this.HasPermission("UserSetting-View"))
            {
                if (Session["CompanyCode"] != null)
                {
                    U.QueryType = "Customer_User_details";
                    U.Parameter = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.users> DasList = new List<Models.users>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.users>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Roles Settings
        public ActionResult Roles_settings(Models.usersettings U)
        {

                if (Session["CompanyCode"] != null)
                {
                    U.QueryType = "Role_details";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Roles> DasList = new List<Models.Roles>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Roles>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
        }

        public ActionResult Dept_settings(Models.usersettings U)
        {
            if (this.HasPermission("DepartmentSetting-View"))
            {
                if (Session["CompanyCode"] != null)
                {
                    U.QueryType = "Dept_details";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Department> DasList = new List<Models.Department>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Department>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //SKill Settings
        public ActionResult Skill_settings(Models.usersettings U)
        {

            if (this.HasPermission("SkillSetting-View"))
            {
                if (Session["CompanyCode"] != null)
                {
                    U.QueryType = "Customer_Skill_details";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Skill> DasList = new List<Models.Skill>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Skill>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Operator Skill 
        public ActionResult Operator_skill(Models.usersettings U)
        {

          if (this.HasPermission("OperatorSkillSetting-View"))
             {
                if (Session["CompanyCode"] != null)
                {
                    U.QueryType = "Customer_Operator_skill";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Operatorskill> DasList = new List<Models.Operatorskill>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Operatorskill>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Alarm Data
        public ActionResult Alarm_data(Models.usersettings U)
        {

            if (this.HasPermission("AlarmSetting-View"))
            {
               if (Session["CompanyCode"] != null)
                {
                    U.QueryType = "Customer_Alarm_details";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Alarm> DasList = new List<Models.Alarm>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Alarm>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Rejection Data
        public ActionResult Rejection_data(Models.usersettings U)
        {

            if (this.HasPermission("RejectionDataSetting-View"))
             {
                if (Session["CompanyCode"] != null)
                {

                    U.QueryType = "Customer_Rejectiondetails";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Rejectiondata> DasList = new List<Models.Rejectiondata>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Rejectiondata>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Losses Data
        public ActionResult Losses_data(Models.usersettings U)
        {

             if (this.HasPermission("LossesSetting-View"))
                {
               if (Session["CompanyCode"] != null)
                {
                    U.QueryType = "Customer_Lossesdetails";
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Losses> DasList = new List<Models.Losses>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Losses>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Tool List
        public ActionResult Tool_list(Models.usersettings U)
        {

           if (this.HasPermission("ToolListSetting-View"))
              {
                if (Session["CompanyCode"] != null || Session["PlantCode"] != null)
                {
                    U.QueryType = "Customer_Toolsdetails";
                    U.Parameter = Session["PlantCode"].ToString();
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Toollist> DasList = new List<Models.Toollist>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Toollist>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Operator Settings
        public ActionResult Operator_settings(Models.usersettings U)
        {

            if (this.HasPermission("OperatorSetting-View"))
              {
                 if (Session["CompanyCode"] != null || Session["PlantCode"] != null)
                {
                    U.QueryType = "Customer_Operator_details";
                    U.Parameter = Session["PlantCode"].ToString();
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Operator> DasList = new List<Models.Operator>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Operator>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        //Shift Settings
        public ActionResult Shift_settings(Models.usersettings U)
        {

            if (this.HasPermission("ShiftSetting-View"))
             {
                 if (Session["CompanyCode"] != null || Session["PlantCode"] != null)
                {
                    U.QueryType = "Customer_Shift_details";
                    U.Parameter = Session["PlantCode"].ToString();
                    U.Parameter1 = Session["CompanyCode"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Models.usersettings>("api/UserSettings/settings_details", U).Result;
                        List<Models.Shift> DasList = new List<Models.Shift>();
                        var data = response.Content.ReadAsStringAsync().Result;
                        DasList = JsonConvert.DeserializeObject<List<Models.Shift>>(data);
                        return View(DasList);
                    }
                }
                else
                {
                   return RedirectToAction("Settings_err", "Main");
                }
            }
            else
            {
                return RedirectToAction("Unauth_page", "Main");
            }
        }

        /// <summary>
        /// Insert Department Details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add_Dept(Models.Department dept)
        {
            if (Session["CompanyCode"] != null)
            {
                dept.QueryType = "Insert";
                dept.CompanyCode = Session["CompanyCode"].ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync<Models.Department>("api/UserSettings/Dept_details", dept).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        var msg = JsonConvert.DeserializeObject(res);
                        TempData["message"] = msg;
                    }
                    return RedirectToAction("Dept_settings", "UserSettings");
                }
            }
            else
            {
               return RedirectToAction("Settings_err", "Main");
            }
        }

        /// <summary>
        /// Update Department Details
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_dept(Models.Department dept)
        {
            if (Session["CompanyCode"] != null)
            {
                dept.QueryType = "Update";
                dept.CompanyCode = Session["CompanyCode"].ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync<Models.Department>("api/UserSettings/Dept_details", dept).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        var msg = JsonConvert.DeserializeObject(res);
                        TempData["message"] = msg;
                    }
                    return RedirectToAction("Dept_settings", "UserSettings");
                }
            }
            else
            {
               return RedirectToAction("Settings_err", "Main");
            }
        }

        /// <summary>
        /// Insert Role & Permission details
        /// </summary>
        /// <param name="permissions"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add_Permission(List<PlanDigitization_web.Models.Permission> permissions, List<PlanDigitization_web.Models.Roles> role)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                foreach (var roledetails in role)
                {
                    roledetails.QueryType = roledetails.QueryType;
                    roledetails.CompanyCode = Session["CompanyCode"].ToString();
                    HttpResponseMessage response = client.PostAsJsonAsync<Models.Roles>("api/UserSettings/Roles_details", roledetails).Result;

                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                    if (msg.ToString() == "Inserted"|| msg.ToString() == "Updated")
                    {
                        foreach (var permissiondetails in permissions)
                        {
                            permissiondetails.QueryType = permissiondetails.QueryType;
                            permissiondetails.CompanyCode = Session["CompanyCode"].ToString();
                            HttpResponseMessage response1 = client.PostAsJsonAsync<Models.Permission>("api/UserSettings/Permission_details", permissiondetails).Result;
                            if (response1.IsSuccessStatusCode)
                            {
                                var res1 = response1.Content.ReadAsStringAsync().Result;
                                var msg1 = JsonConvert.DeserializeObject(res1);
                                TempData["message"] = msg1;
                            }
                        }
                    }
                }
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult Set_CompanyCode(string id, Models.Customer Cus)
        {
            Session["CompanyCode"] = id;
            Session["PlantCode"] = null;
            Cus.CompanyCode = id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage loginres = client.PostAsJsonAsync<Models.Customer>("api/UserSettings/Get_Customer_details", Cus).Result;
                List<Models.Customer> DasList = new List<Models.Customer>();
                if (loginres.IsSuccessStatusCode)
                {
                    var customer_data = loginres.Content.ReadAsStringAsync().Result;
                    DasList = JsonConvert.DeserializeObject<List<Models.Customer>>(customer_data);
                    if (DasList.Count != 0)
                    {
                        Session["CustomerLogo"] = DasList[0].Logo;
                    }
                    else
                    {
                        Session["CustomerLogo"] = null;
                    }
                }
            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Set_PlantCode(string id)
        {
            Session["PlantCode"] = id;
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Set_DeptCode(string id)
        {
            Session["DeptCode"] = id;
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Insert Customer details
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add_Customer(Models.Customer C, HttpPostedFileBase Logo)
        {
            C.QueryType = "Insert";
            string filename = string.Empty;
            string filepath = string.Empty;
            if (Logo != null)
            {
                string path = Server.MapPath("~/Images/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filepath = path + Path.GetFileName(Logo.FileName);
                filename = Path.GetFileName(Logo.FileName);
                string extension = Path.GetExtension(Logo.FileName);
                Logo.SaveAs(filepath);
                C.Logo = filename;
            }
            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
            var checkextension = Path.GetExtension(Logo.FileName).ToLower();

            if (allowedExtensions.Contains(checkextension))
            {
                TempData["notice"] = "Select png or jpg or jpeg";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync<Models.Customer>("api/UserSettings/Customer_details", C).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        var msg = JsonConvert.DeserializeObject(res);
                        TempData["message"] = msg;
                    }
                    return RedirectToAction("Customer_setting", "UserSettings");
                }
            }
            return RedirectToAction("Settings_err", "Main");


        }
        /// <summary>
        /// Update Customer Details
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Customer(Models.Customer C, HttpPostedFileBase Logo)
        {
            C.QueryType = "Update";
            string filename = string.Empty;
            string filepath = string.Empty;
            if (Logo != null)
            {
                string path = Server.MapPath("~/Images/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filepath = path + Path.GetFileName(Logo.FileName);
                filename = Path.GetFileName(Logo.FileName);
                string extension = Path.GetExtension(Logo.FileName);
                Logo.SaveAs(filepath);
                C.Logo = filename;
            }
            else
            {
                C.Logo = C.PreLogo;
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Customer>("api/UserSettings/Customer_details", C).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Customer_setting", "UserSettings");
            }
        }

        /// <summary>
        /// Insert Plant Details
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add_Plant(Models.plant P)
        {
            P.QueryType = "Insert";
            P.ParentOrganization = Session["CompanyCode"].ToString();
            P.IsActive = "Active";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.plant>("api/UserSettings/Plant_details", P).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Plant_details", "UserSettings");
            }
        }

        /// <summary>
        /// Update Plant Details
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Plant(Models.plant P)
        {
            P.QueryType = "Update";
            P.ParentOrganization = Session["CompanyCode"].ToString();
            P.IsActive = "Active";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.plant>("api/UserSettings/Plant_details", P).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Plant_details", "UserSettings");
            }
        }

        /// <summary>
        /// Insert Function Details
        /// </summary>
        /// <param name="F"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Function(Models.Function F)
        {
            F.QueryType = "Insert";
            F.CompanyCode = Session["CompanyCode"].ToString();
            F.IsActive = "Active";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Function>("api/UserSettings/Function_details", F).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Function_details", "UserSettings");
            }
        }

        /// <summary>
        /// Update Function Details
        /// </summary>
        /// <param name="F"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Function(Models.Function F)
        {
            F.QueryType = "Update";
            F.CompanyCode = Session["CompanyCode"].ToString();
            F.IsActive = "Active";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Function>("api/UserSettings/Function_details", F).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Function_details", "UserSettings");
            }
        }

        /// <summary>
        /// Insert SkillSet Details
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Skillset(Models.Skill S)
        {
            S.QueryType = "Insert";
            S.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Skill>("api/UserSettings/Skills_details", S).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Skill_settings", "UserSettings");
            }
        }

        /// <summary>
        /// Update SkillSet Details
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Skillset(Models.Skill S)
        {
            S.QueryType = "Update";
            S.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Skill>("api/UserSettings/Skills_details", S).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Skill_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Insert User details
        /// </summary>
        /// <param name="U"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_users(Models.users U)
        {
            U.QueryType = "Insert";
            U.CompanyCode = Session["CompanyCode"].ToString();
            U.PlantCode = Session["PlantCode"].ToString();
            U.IsActive = "Active";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.users>("api/UserSettings/Users_details", U).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Users_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Update User details
        /// </summary>
        /// <param name="U"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_users(Models.users U)
        {
            U.QueryType = "Update";
            U.CompanyCode = Session["CompanyCode"].ToString();
            U.PlantCode = Session["PlantCode"].ToString();
            U.IsActive = "Active";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.users>("api/UserSettings/Users_details", U).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Users_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Asset Details
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_assetdetails(Models.assets A)
        {
            A.QueryType = "Insert";
            A.CompanyCode = Session["CompanyCode"].ToString();
            A.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.assets>("api/UserSettings/Assets_details", A).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Assets_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Update Asset Details
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_assetdetails(Models.assets A)
        {
            A.QueryType = "Update";
            A.CompanyCode = Session["CompanyCode"].ToString();
            A.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.assets>("api/UserSettings/Assets_details", A).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Assets_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Operation details
        /// </summary>
        /// <param name="O"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Operation(Models.Operations O)
        {
            O.QueryType = "Insert";
            O.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Operations>("api/UserSettings/Operation_details", O).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Operation_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Update Operation details
        /// </summary>
        /// <param name="O"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Operation(Models.Operations O)
        {
            O.QueryType = "Update";
            O.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Operations>("api/UserSettings/Operation_details", O).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Operation_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Product Details
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Productdetails(Models.Products P)
        {
            P.QueryType = "Insert";
            P.CompanyCode = Session["CompanyCode"].ToString();
            P.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Products>("api/UserSettings/Product_details", P).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Product_details", "UserSettings");
            }
        }
        /// <summary>
        /// Update Product Details
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Productdetails(Models.Products P)
        {
            P.QueryType = "Update";
            P.CompanyCode = Session["CompanyCode"].ToString();
            P.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Products>("api/UserSettings/Product_details", P).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Product_details", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Holiday Details
        /// </summary>
        /// <param name="H"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Holiday(Models.Holiday H)
        {
            H.QueryType = "Insert";
            H.CompanyCode = Session["CompanyCode"].ToString();
            H.PlantID = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Holiday>("api/UserSettings/Holiday_details", H).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("holiday_details", "UserSettings");
            }
        }
        /// <summary>
        /// Update Holiday details
        /// </summary>
        /// <param name="H"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Holiday(Models.Holiday H)
        {
            H.QueryType = "Update";
            H.CompanyCode = Session["CompanyCode"].ToString();
            H.PlantID = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Holiday>("api/UserSettings/Holiday_details", H).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("holiday_details", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Operator Skill details
        /// </summary>
        /// <param name="OS"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Operatorskill(Models.Operatorskill OS)
        {
            OS.QueryType = "Insert";
            OS.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Operatorskill>("api/UserSettings/OperatorSkill_details", OS).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Operator_skill", "UserSettings");
            }
        }
        /// <summary>
        /// Update Operator Skill details
        /// </summary>
        /// <param name="OS"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Operatorskill(Models.Operatorskill OS)
        {
            OS.QueryType = "Update";
            OS.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Operatorskill>("api/UserSettings/OperatorSkill_details", OS).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Operator_skill", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Alarmdetails
        /// </summary>
        /// <param name="AL"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Alarmdetails(Models.Alarm AL)
        {
            AL.QueryType = "Insert";
            AL.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Alarm>("api/UserSettings/AlarmSettins_details", AL).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Alarm_data", "UserSettings");
            }
        }
        /// <summary>
        /// Update Alarm details
        /// </summary>
        /// <param name="AL"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Alarmdetails(Models.Alarm AL)
        {
            AL.QueryType = "Update";
            AL.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Alarm>("api/UserSettings/AlarmSettins_details", AL).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Alarm_data", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Rejection data details
        /// </summary>
        /// <param name="RJ"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Rejectiondata(Models.Rejectiondata RJ)
        {
            RJ.QueryType = "Insert";
            RJ.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Rejectiondata>("api/UserSettings/Rejection_details", RJ).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Rejection_data", "UserSettings");
            }
        }
        /// <summary>
        /// Update Rejection data details
        /// </summary>
        /// <param name="RJ"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Rejectiondata(Models.Rejectiondata RJ)
        {
            RJ.QueryType = "Update";
            RJ.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Rejectiondata>("api/UserSettings/Rejection_details", RJ).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Rejection_data", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Losses data details
        /// </summary>
        /// <param name="LO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Lossessdata(Models.Losses LO)
        {
            LO.QueryType = "Insert";
            LO.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Losses>("api/UserSettings/LossesSettings_details", LO).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Losses_data", "UserSettings");
            }
        }
        /// <summary>
        /// Update Losses data details
        /// </summary>
        /// <param name="LO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Lossessdata(Models.Losses LO)
        {
            LO.QueryType = "Update";
            LO.CompanyCode = Session["CompanyCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Losses>("api/UserSettings/LossesSettings_details", LO).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Losses_data", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Toollist details
        /// </summary>
        /// <param name="TO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Toollist(Models.Toollist TO)
        {
            TO.QueryType = "Insert";
            TO.CompanyCode = Session["CompanyCode"].ToString();
            TO.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Toollist>("api/UserSettings/Tooli_list_details", TO).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Tool_list", "UserSettings");
            }
        }
        /// <summary>
        /// Update Toollist details
        /// </summary>
        /// <param name="TO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Toollist(Models.Toollist TO)
        {
            TO.QueryType = "Update";
            TO.CompanyCode = Session["CompanyCode"].ToString();
            TO.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Toollist>("api/UserSettings/Tooli_list_details", TO).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Tool_list", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Operator details
        /// </summary>
        /// <param name="OP"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Operators(Models.Operator OP)
        {
            OP.QueryType = "Insert";
            OP.CompanyCode = Session["CompanyCode"].ToString();
            OP.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Operator>("api/UserSettings/Operators_details", OP).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Operator_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Update Operator Details
        /// </summary>
        /// <param name="OP"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Operator(Models.Operator OP)
        {
            OP.QueryType = "Update";
            OP.CompanyCode = Session["CompanyCode"].ToString();
            OP.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Operator>("api/UserSettings/Operators_details", OP).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Operator_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Insert Shift Setting details
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert_Shifts(Models.Shift S)
        {
            S.QueryType = "Insert";
            S.CompanyCode = Session["CompanyCode"].ToString();
            S.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Shift>("api/UserSettings/Shiftsettings_details", S).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Shift_settings", "UserSettings");
            }
        }
        /// <summary>
        /// Update Shift Setting details
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update_Shift(Models.Shift S)
        {
            S.QueryType = "Update";
            S.CompanyCode = Session["CompanyCode"].ToString();
            S.PlantCode = Session["PlantCode"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Shift>("api/UserSettings/Shiftsettings_details", S).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return RedirectToAction("Shift_settings", "UserSettings");
            }
        }
    }
}