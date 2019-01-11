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

            Order order = new Order(CheckDepartment.BuyForECTSFunction(int.Parse((string)Session["ID"])));
            var yourSubjectsYouCanBuy = order.ContextInterface(label);
            return View(yourSubjectsYouCanBuy);
        }
        [HttpPost]
        public ActionResult Marketplace(Data.Subject sub)
        {
            return View();
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
            Receiver receiver = new Receiver();
            Command.Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();
            invoker.SetCommand(command);
            invoker.ExecuteCommand(int.Parse((string)Session["ID"]), sub);
            Session["ECTS"] = invoker.ExecuteCommand(int.Parse((string)Session["ID"]));
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

        public ActionResult Memento(int id = 0)
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
        
    }
}