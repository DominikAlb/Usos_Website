using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Builder
{
    public class Director
    {
        public List<Subject> Construct(Builder builder)
        {
            builder.BuildPartA();
            return builder.BuildPartB();
        }
    }
}