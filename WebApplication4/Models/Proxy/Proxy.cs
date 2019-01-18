using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Proxy
{
    public class Proxy : Subject

    {
        private RealSubject _realSubject;

        public override User Request(User user)
        {

            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }

            return _realSubject.Request(user);
        }
    }
}