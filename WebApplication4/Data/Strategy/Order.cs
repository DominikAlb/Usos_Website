using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Usososo.Controllers.Strategy
{
    public class Order
    {
        private BuyForECTS _strategy;
        

        public Order(BuyForECTS strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}