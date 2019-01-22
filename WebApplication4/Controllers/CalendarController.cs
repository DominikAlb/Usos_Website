using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Controllers.Adapterr;
using WebApplication4.Controllers.Command;
using WebApplication4.Data;
using WebApplication4.ViewModel;

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
            CalendarViewModel calendarViewModel = new CalendarViewModel { date = DateTime.Now, objUser = null };
            return View(calendarViewModel);
        }


        // GET: Calendar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Exam objUser)
        {
            if (Session["Login"] != null)
            {
                CalendarViewModel calendarViewModel2 = new CalendarViewModel { date = DateTime.Now, objUser = objUser };
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
                return View(calendarViewModel2);
            }
            CalendarViewModel calendarViewModel = new CalendarViewModel { date = DateTime.Now, objUser = null };
            return View(calendarViewModel);
        }

    }
}