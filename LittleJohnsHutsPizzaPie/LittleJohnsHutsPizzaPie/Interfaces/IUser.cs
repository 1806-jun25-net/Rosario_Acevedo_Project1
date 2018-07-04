using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Interfaces
{
    interface IUser
    {
        int IDofTheUser { get; set; }
        string firstName { get; set; }
        string LastName { get; set; }
        Models.Location location { get; set; }
    }
}
