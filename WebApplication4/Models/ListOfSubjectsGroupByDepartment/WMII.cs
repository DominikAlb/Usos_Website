using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace Usososo.Controllers.Strategy
{
    public class WMII : BuyForECTS

    {
        public override List<Subject> AlgorithmInterface(List<Subject> main)
        {
            return main.Where(x => x.Department.Equals("WMII")).ToList();
        }
    }
}