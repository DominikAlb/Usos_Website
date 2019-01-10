using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Controllers.Command
{
    public class ConcreteCommand : Command

    {   

        public ConcreteCommand(Receiver receiver) :
          base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }
}