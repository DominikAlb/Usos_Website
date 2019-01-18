using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Builder
{
    public class Product
    {
        List<Subject> _table;
        public void MakeHTMLTable()
        {
            using(NorthwindEntities db = new NorthwindEntities())
            {
                _table = db.Subject.AsParallel().WithDegreeOfParallelism(4).ToList();
            }
            
        }
        public List<Subject> GetTable()
        {
            return _table;
        }

        private string GetTextFromFileToMarketplace(string file)
        {
            return File.ReadAllText(file);
        }
    }
}