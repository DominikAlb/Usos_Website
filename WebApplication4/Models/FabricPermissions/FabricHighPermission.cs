using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Controllers.FabricPermissions
{
    public class FabricHighPermission : FabricSupervises
    {
        public override DriverAdmin DriverAdm()
        {
            return new DriverAdminHighPermission();
        }
        public override DriverUser DriverUs()
        {
            return new DriverUserHighPermission();
        }
    }
}