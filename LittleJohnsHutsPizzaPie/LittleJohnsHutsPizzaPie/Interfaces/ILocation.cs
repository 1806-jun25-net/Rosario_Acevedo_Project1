using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Interfaces
{
    interface ILocation
    {
        string address { get; set; }
        int ID { get; set; }
        List<int> quantity { get; set; }
        List<string> NameOfProduct { get; set; }
    }
}
