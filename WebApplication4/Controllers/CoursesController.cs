using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Controllers.Adapterr;

namespace WebApplication4.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Index()
        {
            ITarget target = new Adapterr.Adapterr();
            Session["Exams"] = target.SafeData();
            return View();
        }
    }
}