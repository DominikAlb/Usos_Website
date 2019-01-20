using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Data;
using WebApplication4.Data.Singleton;

namespace WebApplication4.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult TestLogin()
        {
            Singleton singleton = Singleton.Instance;
            User user = new Data.User()
            {
                ID = 1,
                Login = "ADMIN",
                Hash = "12345"
            };
            return View(user);
        }
    }
}