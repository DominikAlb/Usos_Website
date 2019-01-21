using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Builder
{
    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract List<Subject> BuildPartB();
        public abstract Product GetResult();
    }
}