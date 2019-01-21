using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Data;

namespace WebApplication4.Controllers
{
    public class MementoController : Controller
    {
        // GET: Memento
        public ActionResult Index(int id = 0)
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