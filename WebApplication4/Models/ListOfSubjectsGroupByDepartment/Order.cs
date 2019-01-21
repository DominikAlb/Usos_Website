using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace Usososo.Controllers.Strategy
{
    public class Order
    {
        private BuyForECTS _strategy;
        

        public Order(BuyForECTS strategy)
        {
            this._strategy = strategy;
        }

        public List<Subject> ContextInterface(List<Subject> main)
        {
            return _strategy.AlgorithmInterface(main);
        }
    }
}