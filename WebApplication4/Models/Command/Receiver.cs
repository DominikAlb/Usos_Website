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
        public void Action(int id_user, Subject sub)
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
        public int? FindUserECTS(int user_id)
        {
            User user;
            using (NorthwindEntities db = new NorthwindEntities())
            {
                user = db.User.Where(x => x.ID == user_id).FirstOrDefault();
            }
            return user.ECTS;
        }
    }
}