﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LMS_WebAPP_ServiceHelpers;
using LMS_WebAPP_Utils;
using LMS_WebAPP_Domain;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementApp.Controllers
{
    public class AccountController : Controller
    {

        UserManagement user = new UserManagement();
        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.userExist = true;
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Login(Models.LoginModel model)
        {
            if (ModelState.IsValid)
            {

                if (null == Session[Constants.SESSION_OBJ_USER])
                {
                   // var encryptedPassword = CommonMethods.EncryptDataForLogins(model.UserName, model.Password);
                    var data = await user.GetUserAsync(model.UserName, model.Password);
                    if (null != data && data.RefEmployeeId !=0)
                    {
                        // var dataemp = await user.GetUserDetaiilsAsync(data.RefEmployeeId);
                        #region Cookie setup with remember me
                        if (model.RememberMe) //adding cookies for the user
                        {
                            var aCookie = new HttpCookie("dguser-" + model.UserName);
                            aCookie.Values.Add("USER_NAME", CommonMethods.EncryptString(model.UserName));
                            aCookie.Values.Add("PASS", CommonMethods.EncryptString(model.Password));
                            aCookie.Expires = DateTime.Now.AddDays(7);
                            Response.Cookies.Add(aCookie);
                        }
                        else //To delete cookies if remember is false
                        {
                            var myCookie = new HttpCookie("dguser-" + model.UserName);
                            myCookie.Expires = DateTime.Now.AddDays(-1d);
                            Response.Cookies.Add(myCookie);
                        }
                        #endregion
                        Session[Constants.SESSION_OBJ_USER] = data;
                        ViewBag.UserExist = true;
                        return RedirectToAction("Dashboard");
                    }
                    ViewBag.UserExist = false;
                    return View();
                }
                else
                {
                 return   RedirectToAction("Dashboard");
                }
                  
            }
            ViewBag.userExist = true;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            try
            {
                //WebSecurity.
                //Clear Session
                // Session.Abandon();
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                return View("Login");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
        public async Task<ActionResult> Dashboard()
        {
            if (null != Session[Constants.SESSION_OBJ_USER])
            {
                var data = (UserAccount)Session[Constants.SESSION_OBJ_USER];
                EmployeeDetailsModel datares = await user.GetUserDetailsAsync(data.RefEmployeeId);
                
                Models.LoginModel model = new Models.LoginModel();
                model.EmpName = data.UserName;
                model.UserName = data.UserName;
                model.Projectname = datares.ProjectName;
                model.ManagerName = datares.ManagerName;
                model.TotalLeaveCount = Convert.ToInt16(datares.TotalLeaveCount);
                model.TotalTaken = datares.TotalCountTaken;
                model.TotalLeft = Convert.ToInt16(datares.TotalLeaveCount - datares.TotalCountTaken);
                model.DateOfJoining = DateTime.Now;
                model.RoleName = datares.RoleName;
                model.Announcements = new List<Models.Announcement>();
                foreach (var item in datares.Announcements)
                {
                    Models.Announcement announceItem = new Models.Announcement();
                    announceItem.ImagePath = item.ImagePath;
                    announceItem.CarouselContent = item.CarouselContent;
                    announceItem.Title = item.Title;
                    model.Announcements.Add(announceItem);
                }
                // model.Announcements = (Models.Announcement)datares.Announcements;
                return View(model);
            }
            return View("Login");
        }

        //private async Task<EmployeeDetailsModel> GetAsyncData(UserAccount data)
        //{
        //    Task<EmployeeDetailsModel> sCode = Task.Run(async () =>
        //    {
        //        var EmpData = await user.GetUserDetailsAsync(data.RefEmployeeId);
        //        //EmployeeDetailsModel ss = EmpData;
        //        return EmpData;
        //    });
        //    return null;
        //}
    }
}