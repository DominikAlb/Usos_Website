using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Proxy
{
    public abstract class Subject
    {
        public abstract User Request(User user);
    }
}