using CaptchaMvc.HtmlHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PlanDigitization_web.Controllers
{

    public class MainController : Controller
    {
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        string Baseurl = @System.Configuration.ConfigurationManager.AppSettings["url"];
        //View Login Page
        public ActionResult Login()
        {
            //FormsAuthentication.SignOut();
            //Session.Abandon();

            //// clear authentication cookie
            //HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            //cookie1.Expires = DateTime.Now.AddYears(-1);
            //Response.Cookies.Add(cookie1);

            //// clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            //SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            //HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            //cookie2.Expires = DateTime.Now.AddYears(-1);
            //Response.Cookies.Add(cookie2);
            return View();
        }
        public ActionResult otplogin()
        {
            return View();
        }
        //View Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Settings_err()
        {
            return View();
        }

        //View Forgot Password
        public ActionResult Forgot()
        {
            return View();
        }

        //View Change Password
        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Response.Cookies["UserID"].Value = "";
            Session["CompanyCode"] = "";
            Session["UserID"] = "";
            Session["UserName"] = "";
            Session["User_Function"] = "";
            Session["IsSuperAdmin"] = "";
            Session["Role"] = "";
            Session["PlantCode"] = "";
            Session["CustomerLogo"] = null;
            Session["Email"] = "";
            return RedirectToAction("Login","Main");
        }


        public ActionResult Checklogin(Models.Loginmodel lo)
        {
            if (this.IsCaptchaValid("Validate your captcha"))
            {
                //TempData["lockno"] = 0;
                //TempData["time"] = DateTime.Now;
                if ((Convert.ToInt32(Session["lockno"]) == 5) && (DateTime.Now) <= Convert.ToDateTime(Session["time"]))
                {
                    var diff = (Convert.ToInt32(Convert.ToDateTime(Session["time"]).ToString("mm"))) - (Convert.ToInt32(DateTime.Now.ToString("mm")));
                    TempData["message"] = "Your account is locked.Retry after " + diff + " minutes.";
                    return View("Login");
                }
                try
                {

                    using (var client = new HttpClient())
                    {
                        lo.lastlogin = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = client.PostAsJsonAsync<Models.Loginmodel>("api/UserSettings/Check_login", lo).Result;
                        // var response = client.PostAsJsonAsync<Models.Loginmodel>("api/UserSettings/Check_login", lo).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var res = response.Content.ReadAsStringAsync().Result;

                            JObject json = JObject.Parse(res);
                            var loginmessage = json["loginstatus"].ToString();

                            JObject json1 = JObject.Parse(res);
                            var lastloginres = json1["lastlogindate"].ToString();


                            //Models.Loginmodelres loginmodelres = new JavaScriptSerializer().Deserialize<Models.Loginmodelres>(res);
                            //Models.Loginmodelres loginmodelres = new JavaScriptSerializer().Deserialize<Models.Loginmodelres>(res);

                            TempData["message"] = loginmessage;
                            //TempData["message"] = lastloginres;
                            List<Models.login> DasList = new List<Models.login>();

                            if (loginmessage == "Login Successfull...!")
                            {

                                HttpResponseMessage loginres = client.PostAsJsonAsync<Models.Loginmodel>("api/UserSettings/Get_Login_details", lo).Result;
                                if (loginres.IsSuccessStatusCode)
                                {
                                    var login_data = loginres.Content.ReadAsStringAsync().Result;
                                    DasList = JsonConvert.DeserializeObject<List<Models.login>>(login_data);

                                    Response.Cookies["UserID"].Value = DasList[0].UserID;
                                    Session["CompanyCode"] = DasList[0].CompanyCode;
                                    Session["UserID"] = DasList[0].UserID;
                                    Session["UserName"] = DasList[0].UserName;
                                    Session["User_Function"] = DasList[0].User_Function;
                                    Session["IsSuperAdmin"] = DasList[0].IsSuperAdmin;
                                    Session["Role"] = DasList[0].RoleName;
                                    Session["PlantCode"] = DasList[0].PlantCode;
                                    Session["CustomerLogo"] = null;
                                    if (DasList[0].Logo != null)
                                    {
                                        if (DasList[0].Logo.ToString() != "")
                                        {
                                            Session["CustomerLogo"] = DasList[0].Logo;
                                        }
                                        else
                                        {
                                            Session["CustomerLogo"] = null;
                                        }
                                    }
                                    else
                                    {
                                        Session["CustomerLogo"] = null;
                                    }
                                    Session["Email"] = DasList[0].Email;
                                    //Session["lastlogin"] = loginmodelres.lastlogindate.ToString();
                                    Session["lastlogin"] = lastloginres;
                                    Session["IsAdmin"] = DasList[0].IsAdmin;
                                }

                            }
                            else
                            {
                                int temp = Convert.ToInt32(Session["lockno"]);
                                temp = temp + 1;
                                Session["lockno"] = temp;
                                var temp2 = Session["lockno"];
                                Session["time"] = DateTime.Now.AddMinutes(5);
                                var temp3 = Session["time"];

                                Logger.Warn("Login Failed for user");
                                TempData["message1"] = "Attempt " + Session["lockno"] + "of 5";
                            }
                            return View("Login");
                        }
                        return View("Login");
                    }
                }
                catch (Exception e)
                {
                    Logger.Warn(e);
                    return View("../Error_page");
                }
            }
            else
            {
                TempData["message"] = "Please enter the correct captcha";
                return View("Login");
            }
        }

        //[HttpPost]
        //public ActionResult Checklogin(Models.Loginmodel lo)
        //{
        //    if (this.IsCaptchaValid("Validate your captcha"))
        //    {
        //        if ((Convert.ToInt32(Session["lockno"]) == 5) && (DateTime.Now) <= Convert.ToDateTime(Session["time"]))
        //        {
        //            var diff = (Convert.ToInt32(Convert.ToDateTime(Session["time"]).ToString("mm"))) - (Convert.ToInt32(DateTime.Now.ToString("mm")));
        //            TempData["message"] = "Your account is locked.Retry after " + diff + " minutes.";
        //            return View("Login");
        //        }

        //        try
        //        {
        //            using (var client = new HttpClient())
        //            {
        //                lo.lastlogin = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //                client.BaseAddress = new Uri(Baseurl);
        //                client.DefaultRequestHeaders.Clear();
        //                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                HttpResponseMessage response = client.PostAsJsonAsync<Models.Loginmodel>("api/UserSettings/Check_login", lo).Result;
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var res = response.Content.ReadAsStringAsync().Result;
        //                    JObject json = JObject.Parse(res);
        //                    var loginstatus = json["loginstatus"].ToString();

        //                    JObject json1 = JObject.Parse(res);
        //                    var lastlogindate = json1["lastlogindate"].ToString();

        //                    //Models.Loginmodelres loginmodelres = new JavaScriptSerializer().Deserialize<Models.Loginmodelres>(res);
        //                    TempData["message"] = loginstatus.ToString();
        //                    List<Models.login> DasList = new List<Models.login>();
        //                    if (loginstatus.ToString() == "Login Successfull...!")
        //                    {
        //                        HttpResponseMessage loginres = client.PostAsJsonAsync<Models.Loginmodel>("api/UserSettings/Get_Login_details", lo).Result;
        //                        if (loginres.IsSuccessStatusCode)
        //                        {
        //                            var login_data = loginres.Content.ReadAsStringAsync().Result;
        //                            DasList = JsonConvert.DeserializeObject<List<Models.login>>(login_data);
        //                            Response.Cookies["UserID"].Value = DasList[0].UserID;
        //                            //Response.Cookies["UserID"].HttpOnly = true;
        //                            //Response.Cookies["UserID"].Secure = Convert.ToBoolean(ConfigurationManager.AppSettings["SecureCookie"]);
        //                            Session["CompanyCode"] = DasList[0].CompanyCode;
        //                            Session["UserID"] = DasList[0].UserID;
        //                            Session["UserName"] = DasList[0].UserName;
        //                            Session["User_Function"] = DasList[0].User_Function;
        //                            Session["IsSuperAdmin"] = DasList[0].IsSuperAdmin;
        //                            Session["Role"] = DasList[0].RoleName;
        //                            Session["PlantCode"] = DasList[0].PlantCode;
        //                            Session["CustomerLogo"] = null;
        //                            if (DasList[0].Logo != null)
        //                            {
        //                                if (DasList[0].Logo.ToString() != "")
        //                                {
        //                                    Session["CustomerLogo"] = DasList[0].Logo;
        //                                }
        //                                else
        //                                {
        //                                    Session["CustomerLogo"] = null;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                Session["CustomerLogo"] = null;
        //                            }
        //                            Session["Email"] = DasList[0].Email;
        //                            Session["lastlogin"] = lastlogindate.ToString();
        //                            Session["IsAdmin"] = DasList[0].IsAdmin;
        //                        }

        //                    }
        //                    else
        //                    {
        //                        int temp = Convert.ToInt32(Session["lockno"]);
        //                        temp = temp + 1;
        //                        Session["lockno"] = temp;
        //                        var temp2 = Session["lockno"];
        //                        Session["time"] = DateTime.Now.AddMinutes(5);
        //                        var temp3 = Session["time"];

        //                        Logger.Warn("Login Failed for user");
        //                        TempData["message1"] = "Attempt " + Session["lockno"] + "of 5";
        //                    }


        //                    return View("Login");
        //                }


        //            }
        //            return View("Login");

        //        }
        //        catch (Exception e)
        //        {
        //            Logger.Warn(e);
        //            return View("../Error_page");
        //        }
        //    }
        //    else
        //    {
        //        TempData["message"] = "Please enter the correct captcha";
        //        return View("Login");
        //    }
        //}
        public ActionResult Error_page()
        {
            return View();
        }
        public ActionResult Line_details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePwd(Models.Changepassword C)
        {
            C.Input1 = Session["Email"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync<Models.Changepassword>("api/UserSettings/Changepassword", C).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject(res);
                    TempData["message"] = msg;
                }
                return View("ChangePassword");
            }
        }

        public ActionResult Unauth_page()
        {
            return View();
        }
    }
}