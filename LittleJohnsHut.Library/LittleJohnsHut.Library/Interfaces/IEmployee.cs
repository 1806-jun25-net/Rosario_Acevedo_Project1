using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IEmployee : IUser
    {
        string OrderPlace { get; set; }
        decimal salary { get; set; }
        

    }
}
