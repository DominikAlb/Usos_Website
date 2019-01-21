using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Proxy
{
    public class Proxy : Subject

    {
        private SQLQuestion _realSubject;

        public override User Request(User user)
        {

            if (_realSubject == null)
            {
                _realSubject = new SQLQuestion();
            }

            return _realSubject.Request(user);
        }
    }
}