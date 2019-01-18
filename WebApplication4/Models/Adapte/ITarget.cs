using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Adapterr
{
    public interface ITarget
    {
        string SafeData(string monthAndYear, int user_id);
        string SafeData();
        void AddExam(Exam s, int user_id);
    }
}