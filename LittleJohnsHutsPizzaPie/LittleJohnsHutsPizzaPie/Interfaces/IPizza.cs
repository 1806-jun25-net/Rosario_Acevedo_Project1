using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Interfaces
{
    interface IPizza
    {
        bool cheese { get; set; }
        string crust { get; set; }
        Models.Ingridiante topping { get; set; }

    }
}
