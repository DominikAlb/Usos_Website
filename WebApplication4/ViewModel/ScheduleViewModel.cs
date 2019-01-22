using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.ViewModel
{
    public class ScheduleViewModel
    {
        public List<Course> Courses { get; set; }
        public List<Person> People { get; set; }
        public string[] DaysOfWeek { get; set; }
}
}