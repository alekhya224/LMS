using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LMS_WebAPP_ServiceHelpers;
using Utils;
using LMS_WebAPP_Domain;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
       [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (null == Session[Constants.SESSION_OBJ_USER])
            {
                return View();
            }
            else
            {
                return View("Dashboard", (Models.LoginModel)Session[Constants.SESSION_OBJ_USER]);
            }
        }
        //[HttpPost]
        //public ActionResult Index(Models.LoginModel model)
        //{
        //    return View();
        //}
        ////public ActionResult Login()
        ////{
        ////    return View();
        ////}
        [HttpPost]
        public async Task<ActionResult> Login(Models.LoginModel model)
        {
            if (ModelState.IsValid)
            {
               UserManagement user = new UserManagement();
                if (null == Session[Constants.SESSION_OBJ_USER])
                {
                    var data = await user.GetUserAsync();

                    if (null != data)
                    {
                       
                        //#region Cookie setup with remember me
                        //if (model.RememberMe) //adding cookies for the user
                        //{
                        //    var aCookie = new HttpCookie("dguser-" + model.UserName);
                        //    aCookie.Values.Add("USER_NAME", CommonMethods.EncryptDataForLogins(model.UserName, model.Password));
                        //    aCookie.Values.Add("PASS", CommonMethods.EncryptDataForLogins(model.Password));
                        //    aCookie.Expires = DateTime.Now.AddDays(7);
                        //    Response.Cookies.Add(aCookie);
                        //}
                        //else //To delete cookies if remember is false
                        //{
                        //    var myCookie = new HttpCookie("dguser-" + model.UserName);
                        //    myCookie.Expires = DateTime.Now.AddDays(-1d);
                        //    Response.Cookies.Add(myCookie);
                        //}
                        //#endregion

                        //var encryptedPassword = CommonMethods.EncryptDataForLogins(model.UserName, model.Password);
                        ////Get  userdata authenticated against web api
                        ////if (user.GetUser(model.UserName, encryptedPassword))
                        ////{

                        ////}
                        model.EmpName = data.UserName;
                        model.Projectname = data.ProjectName;
                        model.ManagerName = data.ManagerName;
                        model.TotalLeaveCount = Convert.ToInt16(data.TotalLeaveCount);
                        model.TotalLeft = Convert.ToInt16(data.TotalLeaveCount - data.TotalCountTaken);
                        model.TotalTaken = data.TotalCountTaken;
                        model.DateOfJoining = data.DateOfJoining;
                        model.RoleName = data.RoleName;
                        Session[Constants.SESSION_OBJ_USER] = model;
                    }
                    return View("Dashboard", model);
                }
                else
                {
                    return View("Dashboard", (Models.LoginModel)Session[Constants.SESSION_OBJ_USER]);
                }

            }
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
    }
}