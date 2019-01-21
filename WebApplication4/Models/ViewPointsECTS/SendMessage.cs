using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Controllers.Observer
{
    public class SendMessage
    {
        public static string Main(int userID)
        {
            ConcreteSubject sub = new ConcreteSubject(userID);
            sub.Attach(new UpdateECTS(sub));
            sub.SubjectState = DateTime.Now.ToLongDateString();
            return sub.Notify();
        }
    }
}