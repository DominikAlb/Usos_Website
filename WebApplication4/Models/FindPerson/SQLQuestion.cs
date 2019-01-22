using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;
using System.Web.Mvc;
using WebApplication4.App_Start;
using WebApplication4.Controllers.Builder;
namespace WebApplication4.Controllers.Proxy
{
    public class SQLQuestion : Subject

    {
        
        public override User Request(User objUser)
        {
            
            using (SimpleDataBase db = new SimpleDataBase())
            {
                var obj = db.User.Where(a => a.Login.Equals(objUser.Login) && a.Hash.Equals(objUser.Hash)).FirstOrDefault();
                if (obj != null)
                {
                    return obj;
                }
            }

            return null;
        }
    }
}