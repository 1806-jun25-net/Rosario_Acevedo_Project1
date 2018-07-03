using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IOrder
    {
        string location { get; set; }
        string user { get; set; }
        decimal price { get; set; }
        int PizzaCount { get; set; }
        
    }
}
