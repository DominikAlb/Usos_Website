using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Controllers.Adapterr;
using WebApplication4.Controllers.Command;
using WebApplication4.Data;

namespace WebApplication4.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Login"] != null)
            {
                ITarget target = new Adapterr.Adapterr();
                try
                {
                    Session["Exams"] = target.SafeData(DateTime.Now.Month + "-" + DateTime.Now.Year, int.Parse((string)Session["ID"]));
                }
                catch (Exception e)
                {
                    Session["LogSub"] = e.Message;
                }
            }
            return View();
        }


        // GET: Calendar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Exam objUser)
        {
            if (Session["Login"] != null)
            {
                ITarget target = new Adapterr.Adapterr();
                Receiver receiver = new Receiver();
                Command.Command command = new ConcreteCommand(receiver);
                Invoker invoker = new Invoker();
                invoker.SetCommand(command);
                invoker.AddExam(objUser, int.Parse((string)Session["ID"]));
                try
                {
                    Session["Exams"] = target.SafeData(DateTime.Now.Month + "-" + DateTime.Now.Year, int.Parse((string)Session["ID"]));
                }
                catch (Exception e)
                {
                    Session["LogSub"] = e.Message;
                }
                return View();
            }
            return View(objUser);
        }

    }
}