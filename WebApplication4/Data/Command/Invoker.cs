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
        public int? ExecuteCommand(int id_user)
        {
            return _command.Execute(id_user);
        }
    }
}