using System;
using System.Data.Entity;
using System.Web.Mvc;
using WebApplication4.App_Start;
using WebApplication4.Controllers.Adapterr;
using WebApplication4.Controllers.Builder;
using WebApplication4.Controllers.Observer;
using WebApplication4.Controllers.Proxy;
using WebApplication4.Data;

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
            Proxy.Subject proxy = new Proxy.Proxy();
            var obj = proxy.Request(objUser);

            if (obj != null)
            {
                IClient permission = new Factory().Run(obj.Flag);
                ViewBag.Message = permission.GetName();
                ITarget target = new Adapterr.Adapterr();
                
                Session["ID"] = obj.ID.ToString();
                Session["Login"] = obj.Login.ToString();
                Session["LogSub"] = SendMessage.Main(obj.ID);
                Session["Exams"] = target.SafeData(DateTime.Now.Month + "-" + DateTime.Now.Year, int.Parse((string)Session["ID"]));
                
                return View();
            }


            return View(objUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calendar(Exam objUser)
        {

            if (Session["Login"] != null)
            {
                ITarget target = new Adapterr.Adapterr();
                target.AddExam(objUser, int.Parse((string)Session["ID"]));
                try
                {
                    Session["Exams"] = target.SafeData(DateTime.Now.Month + "-" + DateTime.Now.Year, int.Parse((string)Session["ID"]));
                }
                catch(Exception e)
                {
                    Session["LogSub"] = e.Message;
                }
                return View();
            }


            return View(objUser);
        }
        public ActionResult Calendar()
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
        public ActionResult Courses()
        {
            ITarget target = new Adapterr.Adapterr();
            Session["Exams"] = target.SafeData();
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Marketplace()
        {
            Director director = new Director();
            Builder.Builder builder = new ConcreteBuilder();
            var label = director.Construct(builder);

            return View(label);
        }
        public ActionResult SearchForCourse()
        {

            return View();
        }
        public ActionResult SearchForPerson()
        {

            return View();
        }
        public ActionResult Edit(int id = 0)
        {
            Data.Subject sub;
            using (NorthwindEntities db = new NorthwindEntities())
            {
                sub = db.Subject.Find(id);
                if (sub == null)
                {
                    return HttpNotFound();
                }

            }
                
            return View(sub);
        }
        

        [HttpPost]
        public ActionResult Edit(Data.Subject sub)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                if (sub == null)
                {
                    db.Entry(sub).State = EntityState.Modified;
                    db.SaveChanges();
                    return View();
                }

            }
            return View(sub);
        }
    }
}