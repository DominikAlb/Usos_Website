using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Data;
using WebApplication4.ViewModel;

namespace WebApplication4.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            List<Course> courses = new List<Course>();
            List<Person> people;
            int userID = int.Parse((String)Session["ID"]);
            using (SimpleDataBase db = new SimpleDataBase())
            {
                // select users courses
                var temp = db.UserToCourse.Where(x => x.UserID == userID).ToList();
                // get users courses from db
                foreach(var course in db.Course)
                {
                    foreach(var c in temp)
                    {
                        if(course.ID == c.CourseID)
                        {
                            courses.Add(course);
                            break;
                        }
                    }
                }
                // people details from db
                people = db.Person.ToList();
            }
            ScheduleViewModel scheduleViewModel = new ScheduleViewModel
            {
                Courses = courses,
                People = people,
                DaysOfWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }
            };
            return View(scheduleViewModel);
        }
    }
}