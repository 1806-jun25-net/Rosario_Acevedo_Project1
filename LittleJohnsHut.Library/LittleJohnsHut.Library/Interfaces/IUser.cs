using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IUser
    {
        string firstName { get; set; }
        string LastName { get; set; }
        string location { get; set; }
        
    }
}
