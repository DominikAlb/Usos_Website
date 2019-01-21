using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Adapterr
{
    public class Adapterr : ITarget
    {
        private RunCalendar.RunCalendar _adaptee = new RunCalendar.RunCalendar();

        public string SafeData(string monthAndYear, int user_id)
        {
            return _adaptee.SpecificRequest(monthAndYear, user_id);
        }
        public string SafeData()
        {
            return _adaptee.SpecificRequest();
        }
    }
}