using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Utils;

namespace EmployeeLeaveManagementApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Models.LoginModel model)
        {
            if (ModelState.IsValid)
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
            }
            return View(model);
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
                return View("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}