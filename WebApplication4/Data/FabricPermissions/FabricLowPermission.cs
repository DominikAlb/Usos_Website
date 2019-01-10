using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Controllers.FabricPermissions
{
    public class FabricLowPermission : FabricSupervises
    {
        public override DriverAdmin DriverAdm()
        {
            return new DriverAdminLowPermission();
        }
        public override DriverUser DriverUs()
        {
            return new DriverUserLowPermission();
        }
    }
}