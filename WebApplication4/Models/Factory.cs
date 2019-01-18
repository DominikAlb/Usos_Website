using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.App_Start
{
    public class Factory
    {
        public IClient Run(string s)
        {
            IClient client = null;
            switch(s)
            {
                case "Admin":
                    {
                        client = new Admin();
                        break;
                    }
                case "Student":
                    {
                        client = new Student();
                        break;
                    }
                case "Teacher":
                    {
                        client = new Teacher();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return client;
        }
        public IClient Run(int? flag)
        {
            IClient client = null;
            switch (flag)
            {
                case 0:
                    {
                        client = new Admin();
                        break;
                    }
                case 1:
                    {
                        client = new Student();
                        break;
                    }
                case 2:
                    {
                        client = new Teacher();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return client;
        }

    }
}