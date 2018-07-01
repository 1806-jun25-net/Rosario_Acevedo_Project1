using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IUser
    {
        string name { get; set;  }
        string address_Line1 { get; set; }
        string address_Line2 { get; set; }
        string ZipCode { get; set; }
        

    }
}
