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
        internal void MakeHTMLTable()
        {
            using(SimpleDataBase db = new SimpleDataBase())
            {
                _table = db.Subject.AsParallel().WithDegreeOfParallelism(4).ToList();
            }
            
        }
        internal List<Subject> GetTable()
        {
            return _table;
        }

        private string GetTextFromFileToMarketplace(string file)
        {
            return File.ReadAllText(file);
        }
    }
}