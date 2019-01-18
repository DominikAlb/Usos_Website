using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.App_Start
{
    public class Teacher : IClient
    {
        public void Test()
        {

        }
        public string GetName()
        {
            return "teacher";
        }
    }
}