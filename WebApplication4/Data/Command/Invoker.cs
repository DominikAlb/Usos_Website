using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Controllers.Command
{
    public class Invoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}