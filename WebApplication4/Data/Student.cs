using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.App_Start
{
    public class Student : IClient
    {
        public void Test()
        {

        }
        public string GetName()
        {
            return "student";
        }
    }
}