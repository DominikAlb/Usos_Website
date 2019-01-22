using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Usososo.Controllers.Strategy;

namespace WebApplication4.Data.Strategy
{
    public class CheckDepartment
    {
        public static BuyForECTS BuyForECTSFunction(int user_id) 
        {
            User user;
            using(SimpleDataBase nd = new SimpleDataBase())
            {
                user = nd.User.Where(x => x.ID == user_id).FirstOrDefault();
            }
            switch (user.Department)
            {
                case "FAIS":
                    {
                        return new FAIS();
                    }
                case "WMII":
                    {
                        return new WMII();

                    }
                default:
                    break;
            }
            return null;
        }
    }
}