using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Command
{
    public class Receiver
    {
        internal void Action(int id_user, Subject sub)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                User user = db.User.Where(x => x.ID == id_user).FirstOrDefault();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
                using (conn)
                {
                    conn.Open();
                    string sql = "Update [User] Set ECTS = ECTS - @param1 WHERE ID = @param2";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@param1", SqlDbType.Int).Value = sub.ECTS;
                    cmd.Parameters.Add("@param2", SqlDbType.Int).Value = id_user;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    
                }
            }
        }
        internal void AddExam(Exam s, int user_id)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                if (db.Exam.AsParallel().WithDegreeOfParallelism(4).Where(x => x.NameOfSub.Equals(s.NameOfSub) && x.Professor.Equals(s.Professor)).FirstOrDefault() == null)
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
        internal void AddUserToGroupExam(int exam_id, int user_id)
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
        internal int? FindUserECTS(int user_id)
        {
            User user;
            using (NorthwindEntities db = new NorthwindEntities())
            {
                user = db.User.Where(x => x.ID == user_id).FirstOrDefault();
            }
            return user.ECTS;
        }
        internal void RemoveExam(int id_user, Subject sub)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                User user = db.User.Where(x => x.ID == id_user).FirstOrDefault();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
                using (conn)
                {
                    conn.Open();
                    string sql = "Update [User] Set ECTS = ECTS + @param1 WHERE ID = @param2";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@param1", SqlDbType.Int).Value = sub.ECTS;
                    cmd.Parameters.Add("@param2", SqlDbType.Int).Value = id_user;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}