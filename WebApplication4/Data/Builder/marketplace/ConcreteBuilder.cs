using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Builder
{
    public class ConcreteBuilder : Builder

    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.MakeHTMLTable();
        }

        public override List<Subject> BuildPartB()
        {
            return _product.GetTable();
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
}