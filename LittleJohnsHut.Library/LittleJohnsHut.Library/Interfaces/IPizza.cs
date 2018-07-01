using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IPizza
    {
        bool cheese { get; set; }
        string crust { get; set; }
        string topping { get; set; }

    }
}
