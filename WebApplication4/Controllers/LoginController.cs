using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.App_Start;
using WebApplication4.Controllers.Adapterr;
using WebApplication4.Controllers.Observer;
using WebApplication4.Data;

namespace WebApplication4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Autherize(User user)
        {
            using (SimpleDataBase db = new SimpleDataBase())
            {
                User userDetails = null;
                var users = db.User.Where(u => u.Login == user.Login && u.Hash == user.Hash);
                if (users != null && users.Count() != 0)
                {
                    userDetails = users.First();
                }
                if (userDetails == null)
                {
                    user.LoginErrorMessage = "Wrong login or password";
                    Console.WriteLine("QQQQ");
                    return View("Index", user);
                }
                else
                {
                    user.LoginErrorMessage = "";
                    Data.Singleton.Singleton singleton = Data.Singleton.Singleton.Instance;
                    User obj = singleton.Subject(user);
                    if (obj != null)
                    {
                        IClient permission = new Factory().Run(obj.Flag);
                        Session["LoginAs"] = permission.GetName();
                        ITarget target = new Adapterr.Adapterr();

                        Session["ID"] = obj.ID.ToString();
                        Session["ECTS"] = obj.ECTS;
                        Session["Login"] = obj.Login.ToString();
                        Session["LogSub"] = SendMessage.Main(obj.ID);
                        Session["Exams"] = target.SafeData(DateTime.Now.Month + "-" + DateTime.Now.Year, int.Parse((string)Session["ID"]));
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}