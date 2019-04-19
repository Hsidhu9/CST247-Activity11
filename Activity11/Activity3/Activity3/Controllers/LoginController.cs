using Activity3.Models;
using Activity3.Services.Business;
using Activity3.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Activity3.Controllers
{
    public class LoginController : Controller
    {
        //private static Logger logger = LogManager.GetLogger("myAppLoggerRules");
        //instantiates logger through custom class mylogger1
        private static MyLogger1 logger = MyLogger1.GetInstance();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
            //return @"<b>Just a test from Index</b>";
        }

        //controller method that passes user model to authenticate
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            //throws custom errors ,tries to pass model to security service
            try
            {

                logger.Info("Entering LoginController.Login()");

                if (!ModelState.IsValid)
                    return View("Login");

                SecurityService sec = new SecurityService();

                bool auth = sec.Authenticate(model);
                logger.Info("Parameters are:", new JavaScriptSerializer().Serialize(model));

                //if authenticator is true, and finds user then pass to login passed page / else login fail
                if (auth)
                {
                    logger.Info("Exit LoginController.DoLogin() with login passing");
                    return View("LoginPassed");

                }
                else
                {
                    logger.Info("Exit LoginController.DoLogin() with login failing");
                    return View("LoginFailed");
                }
            }
            //catch with error redirection rather then displaying broken code on user side / good error doc methodology
            catch (Exception e)
            {
                logger.Error("Exception LoginController.DoLogin()" , e.Message);
                return View("Error");
            }
        }
    }
}