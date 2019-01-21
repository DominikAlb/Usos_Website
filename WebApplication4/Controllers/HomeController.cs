using System;
using System.Data.Entity;
using System.Web.Mvc;
using Usososo.Controllers.Strategy;
using WebApplication4.App_Start;
using WebApplication4.Controllers.Adapterr;
using WebApplication4.Controllers.Builder;
using WebApplication4.Controllers.Command;
using WebApplication4.Controllers.Observer;
using WebApplication4.Controllers.Proxy;
using WebApplication4.Data;
using WebApplication4.Data.Strategy;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ITarget target = new Adapterr.Adapterr();
            Session["Exams"] = target.SafeData();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User objUser)
        {
            Data.Singleton.Singleton singleton = Data.Singleton.Singleton.Instance;
            User obj = singleton.Subject(objUser);
            if (obj != null)
            {
                IClient permission = new Factory().Run(obj.Flag);
                ViewBag.Message = permission.GetName();
                ITarget target = new Adapterr.Adapterr();

                Session["ID"] = obj.ID.ToString();
                Session["ECTS"] = obj.ECTS;
                Session["Login"] = obj.Login.ToString();
                Session["LogSub"] = SendMessage.Main(obj.ID);
                Session["Exams"] = target.SafeData(DateTime.Now.Month + "-" + DateTime.Now.Year, int.Parse((string)Session["ID"]));

                return View();
            }


            return View(objUser);
        }
    }
}