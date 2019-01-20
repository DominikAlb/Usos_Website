using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Command
{
    public class ConcreteCommand : Command

    {   

        public ConcreteCommand(Receiver receiver) :
          base(receiver)
        {
        }

        public override void AddExam(Exam s, int user_id)
        {
            receiver.AddExam(s, user_id);
        }

        public override void AddUserToGroupExam(int exam_id, int user_id)
        {
            receiver.AddUserToGroupExam(exam_id, user_id);
        }

        public override void Execute(int id_user, Subject sub)
        {
            receiver.Action(id_user, sub);
        }
        public override int? Execute(int id_user)
        {
            return receiver.FindUserECTS(id_user);
        }

        public override void RemoveExam(int id_user, Subject sub)
        {
            receiver.RemoveExam(id_user, sub);
        }
    }
}