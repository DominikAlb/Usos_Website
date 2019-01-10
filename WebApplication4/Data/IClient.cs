using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.App_Start
{
    public interface IClient
    {
        string GetName();
        void Test();

    }
}
