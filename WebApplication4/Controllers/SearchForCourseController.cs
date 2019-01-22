using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Data;
using WebApplication4.ViewModel;

namespace WebApplication4.Controllers
{
    public class SearchForCourseController : Controller
    {
        // GET: SearchForCourse
        public ActionResult Index()
        {
            using (SimpleDataBase db = new SimpleDataBase())
            {
                var courseTable = db.Course;
                var personTable = db.Person;
                var viewModel = new SearchForCourseViewModel { courses = courseTable.ToList(),
                    people = personTable.ToList() };

                return View(viewModel);
            }
        }
    }
}