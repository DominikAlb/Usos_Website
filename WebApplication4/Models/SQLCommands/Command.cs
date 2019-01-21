using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Command
{
    abstract public class Command

    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute(int id_user, Subject sub);
        public abstract int? Execute(int id_user);
        public abstract void RemoveExam(int id_user, Subject sub);
        public abstract void AddExam(Exam s, int user_id);
        public abstract void AddUserToGroupExam(int exam_id, int user_id);
    }
}