using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Interfaces
{
    interface IOrder
    {
        string location { get; set; }
        string user { get; set; }
        DateTime DateOrder { get; }
        decimal price { get; set; }
        int PizzaCount { get; set; }
    }
}
