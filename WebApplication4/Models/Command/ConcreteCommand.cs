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

        public override void Execute(int id_user, Subject sub)
        {
            receiver.Action(id_user, sub);
        }
        public override int? Execute(int id_user)
        {
            return receiver.FindUserECTS(id_user);
        }
    }
}