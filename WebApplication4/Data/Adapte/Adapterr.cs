using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Adapterr
{
    public class Adapterr : ITarget
    {
        private Adaptee _adaptee = new Adaptee();

        public string SafeData(string monthAndYear, int user_id)
        {
             return _adaptee.SpecificRequest(monthAndYear, user_id);
        }
        public string SafeData()
        {
            return _adaptee.SpecificRequest();
        }
        public void AddExam(Exam s, int user_id)
        {
            _adaptee.AddExam(s, user_id);
        }
    }
}