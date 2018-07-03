using LittleJohnsHutsPizzaPie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Models
{
    public class Pizza : IPizza
    {
        public bool cheese { get; set ; }
        public string crust { get ; set ; }
        public string topping { get ; set ; }

    }
}
