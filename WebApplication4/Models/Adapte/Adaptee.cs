using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Adapterr
{
    public class Adaptee
    {
        public string SpecificRequest(string monthAndYear, int user_id)
        {

            StringBuilder str = new StringBuilder("<ul id='days' class='connectedSortable'>");
            for (int i = 1; i <= 31; i++)
            {
                str.Append("<li id='number'>");
                str.Append(i);
                string temp = ":<ul id='" + "daysList" + i.ToString() + "'";
                str.Append(temp);
                str.Append("class='connectedSortable'>");
                str.Append(ExamsInDay(user_id, i + "-" + monthAndYear));
                str.Append("</ul></li>");
            }
            str.Append("</ul>");
            return str.ToString();

        }
        public string SpecificRequest()
        {
            StringBuilder str = new StringBuilder("<ul id='days' class='connectedSortable'>");
            for (int i = 1; i <= 31; i++)
            {
                str.Append("<li id='number'>");
                str.Append(i);
                str.Append(":<ul id='daysList");
                str.Append(i);
                str.Append("'class='connectedSortable'>");
                str.Append("</ul></li>");
            }
            str.Append("</ul>");
            return str.ToString();
        }
        public string ExamsInDay(int id_user, string date)
        {
            string ret = "";
            using (NorthwindEntities db = new NorthwindEntities())
            {
                List<Exam> temp = db.Exam.Where(exam => exam.Date.Equals(date)).ToList();
                List<int> list = db
                    .SubjectGroup
                    .Where(x => x.ID_USER == id_user)
                    .Select(x => x.ID_EXAM)
                    .ToList();
                List<Exam> final = temp.Where(x => list.Any(y => y == x.ID)).ToList();
                if (final != null)
                {
                    final.ForEach(z => ret += "<li>" + z.ToString() + "</li>");
                }
            }
            return ret;
        }
        
    }
    
}