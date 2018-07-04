using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Interfaces
{
    interface IPizza
    {
        int IDofThePizza { get; set; }
        bool cheese { get; set; }
        string crust { get; set; }
        Inventory topping { get; set; }
        Order order { get; set; }
    }
}
