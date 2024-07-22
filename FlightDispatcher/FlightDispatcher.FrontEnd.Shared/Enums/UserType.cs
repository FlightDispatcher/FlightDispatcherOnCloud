using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Shared.Enums
{
    public enum UserType
    {
        [Description("Administrator")]
        Admin = 1,

        [Description("Client User")]
        ClientUser = 2,
    }
}
