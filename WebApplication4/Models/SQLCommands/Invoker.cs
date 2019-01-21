using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Command
{
    public class Invoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand(int id_user, Subject sub)
        {
            _command.Execute(id_user, sub);
        }
        public int ExecuteCommand(int id_user)
        {
            return _command.Execute(id_user).Value;
        }
        public void AddExam(Exam s, int user_id)
        {
            _command.AddExam(s, user_id);
        }
        public void AddUserToGroupExam(int exam_id, int user_id)
        {
            _command.AddUserToGroupExam(exam_id, user_id);
        }
        public void RemoveExam(int id_user, Subject sub)
        {
            _command.RemoveExam(id_user, sub);
        }
    }
}