using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace Usososo.Controllers.Strategy
{
    public class FAIS : BuyForECTS

    {
        public override List<Subject> AlgorithmInterface(List<Subject> main)
        {
            return main.Where(x => x.Department.Equals("FAIS")).ToList();
        }   
    }
}