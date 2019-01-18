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
        public void AddExam(Exam s, int user_id)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                if(db.Exam.AsParallel().WithDegreeOfParallelism(4).Where(x => x.NameOfSub.Equals(s.NameOfSub) && x.Professor.Equals(s.Professor)).FirstOrDefault() == null)
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
                    using (conn)
                    {
                        conn.Open();
                        string sql = "Insert Into Exam(NameOfSub, Professor, Date) Values(@param1, @param2, @param3)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 50).Value = s.NameOfSub;
                        cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = s.Professor;
                        cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 20).Value = s.Date;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                int exam_id = db.Exam.AsParallel().WithDegreeOfParallelism(4).Where(x => x.NameOfSub.Equals(s.NameOfSub) && x.Professor.Equals(s.Professor)).First().ID;
                if (db.SubjectGroup.Where(x => x.ID_EXAM == exam_id && x.ID_USER == user_id).FirstOrDefault() == null)
                {
                    AddUserToGroupExam(exam_id, user_id);
                }
                else
                {
                    throw new Exception("Jestes już zapisany na egzamin");
                }
                
            }
        }
        public void AddUserToGroupExam(int exam_id, int user_id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
            using (conn)
            {
                conn.Open();
                string sql = "Insert Into SubjectGroup(ID_USER, ID_EXAM) Values(@param1, @param2)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@param1", SqlDbType.Int).Value = user_id;
                cmd.Parameters.Add("@param2", SqlDbType.Int).Value = exam_id;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
    }
    
}