using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Controllers.Proxy;

namespace WebApplication4.Data.Singleton
{
    [Serializable()]
    public sealed class Singleton
    {
        private Controllers.Proxy.Subject _proxy = new Controllers.Proxy.Proxy();
        public static readonly Singleton Instance = new Singleton();
        private Singleton() { }
        public User Subject(User objUser)
        {
            return _proxy.Request(objUser);
        }
    }
}
