using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace Usososo.Controllers.Strategy
{
    public abstract class BuyForECTS
    {
        public abstract List<Subject> AlgorithmInterface(List<Subject> main);
    }
}