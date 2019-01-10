using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.App_Start
{
    public class Admin : IClient
    {
        
        public string GetName()
        {
            return "admin";
        }
        public void Test()
        {

        }
    }
}